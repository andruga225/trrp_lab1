using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lab1
{
    internal class Auth : IDisposable
    {
        private readonly HttpListener httpListener;
        private readonly CancellationToken cancellationToken;

        private readonly string url;
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string redirectUri;

        public Auth()
        {
            url = Config.Default.url;
            clientId = Config.Default.client_id;
            redirectUri = Config.Default.redirected_uri;
            clientSecret = Config.Default.client_secret;
            cancellationToken = new CancellationToken();
            httpListener = new HttpListener();
            httpListener.Prefixes.Add(redirectUri + "/");
            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

        }

        public async Task<Token> GetTokenAsync()
        {
            if(httpListener.IsListening)
            {
                return null;
            }

            var url = string.Format(@"{0}/authorize?client_id={1}&response_type=code&redirect_uri={2}&approval_prompt=force&scope=read,activity:read,activity:write",
                                    this.url,
                                    this.clientId,
                                    this.redirectUri + "/");
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true,
            });

            httpListener.Start();
            var token=await ListenLoop(httpListener).ConfigureAwait(false);
            httpListener.Stop();
            
            return token;
        }

        private async Task<Token> ListenLoop(HttpListener httpListener)
        {
            while(true)
            {
                if(cancellationToken.IsCancellationRequested)
                {
                    return null;
                }

                var context = await httpListener.GetContextAsync();
                var query = context.Request.QueryString;

                if (query.Count>0)
                {
                    if(!string.IsNullOrEmpty(query["code"]))
                    {
                        var code = query["code"];
                        
                        HttpListenerRequest request = context.Request;
                        // Obtain a response object.
                        HttpListenerResponse response = context.Response;
                        // Construct a response. 
                        string responseString = "<HTML><BODY> Authorization was successful, you can return to the application</BODY></HTML>";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        // Get a response stream and write the response to it.
                        response.ContentLength64 = buffer.Length;
                        System.IO.Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        // You must close the output stream.
                        output.Close();
                        return await SendCodeAsync(code).ConfigureAwait(false);
                    }
                    if (!string.IsNullOrEmpty(query["error"]))
                    {
                        HttpListenerRequest request = context.Request;
                        // Obtain a response object.
                        HttpListenerResponse response = context.Response;
                        // Construct a response. 
                        string responseString = "<HTML><BODY> Authorization failed</BODY></HTML>";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        // Get a response stream and write the response to it.
                        response.ContentLength64 = buffer.Length;
                        System.IO.Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        // You must close the output stream.
                        output.Close();

                        return null;
                    }
                }
            }
        }

        private async Task<Token> SendCodeAsync(string code)
        {
            var client = new RestClient($"{url}token")
            {
                Authenticator = new HttpBasicAuthenticator(clientId, clientSecret)
            };

            var request = new RestRequest("",Method.Post)
                .AddHeader("cache-control", "no-cache")
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddParameter("client_id", clientId)
                .AddParameter("client_secret", clientSecret)
                .AddParameter("code", code)
                .AddParameter("grant_type", "authorization_code");

            var response = client.Execute(request);
            var responseContent = response.Content;

            var token_type = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent)["token_type"].ToString();
            var expires_at = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent)["expires_at"].ToString();
            var expires_in = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent)["expires_in"].ToString();
            var refresh_token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent)["refresh_token"].ToString();
            var access_token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent)["access_token"].ToString();

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.Content = new StringContent(responseContent);

            return new Token(token_type,expires_at,expires_in,refresh_token,access_token);
        }

        public void Dispose()
        {
            if(httpListener!=null)
            {
                httpListener.Stop();
                ((IDisposable)httpListener).Dispose();
            }
        }
    }
}
