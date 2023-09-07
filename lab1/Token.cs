using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Token
    {
        public string token_type { get; set; }
        public string expires_at { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }

        public Token(string token_type, string expires_at, string expires_in, string refresh_token, string access_token)
        {
            this.token_type = token_type;
            this.expires_at = expires_at;
            this.expires_in = expires_in;
            this.refresh_token = refresh_token;
            this.access_token = access_token;
        }

        public Token(string refresh_token, string access_token)
        {
            this.refresh_token = refresh_token;
            this.access_token = access_token;
        }
    }
}
