using System;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace lab1
{
    public partial class Form1 : Form
    {
        private readonly Auth auth = new Auth();
        private List<Activity> items=new List<Activity>();
        private Token token;
        public Form1()
        {
            InitializeComponent();
            InitializeDgv();
            getActivities();

        }

        private void InitializeDgv()
        {
            ActivitiesList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id",
                Visible = false,
            });

            ActivitiesList.Columns.Add("name", "Название");
            ActivitiesList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "sport_type",
                HeaderText = "Тип",
                
            });
            ActivitiesList.Columns.Add("elapsed_time", "Длительность");
            ActivitiesList.Columns.Add("start_date_local", "Дата начала");
            ActivitiesList.Columns.Add("distance", "Дистанция");
            ActivitiesList.Columns.Add("average_heartrate", "Пульс");

            btnAddActivity.Enabled = false;
            btnDelete.Enabled = false;
            btnEndSession.Enabled = false;
            btnEdit.Enabled = false;
        }

        private async void getActivities()
        {
            ActivitiesList.Rows.Clear();
            items.Clear();
            token = new Token(Config.Default.refresh_token, Config.Default.access_token);
            if (token.access_token == "")
            {
                token = await auth.GetTokenAsync().ConfigureAwait(false);
                if(token==null)
                {
                    MessageBox.Show("Ошибка авторизации");
                    Invoke((Action)delegate { Close(); });
                }
                Config.Default.access_token = token.access_token;
                Config.Default.refresh_token = token.refresh_token;
                Config.Default.Save();
            }

            var client = new RestClient($"{StravaApi.url}/athlete/activities");
            var request = new RestRequest("", Method.Get)
                .AddParameter("access_token", token.access_token);

            var response = client.Execute(request);

            if(response.StatusCode!=System.Net.HttpStatusCode.OK)
            {
                var refreshClient = new RestClient($"{Config.Default.url}/token");
                var refreshRequest = new RestRequest("", Method.Post)
                    .AddParameter("client_id", Config.Default.client_id)
                    .AddParameter("client_secret", Config.Default.client_secret)
                    .AddParameter("grant_type", "refresh_token")
                    .AddParameter("refresh_token", token.refresh_token);

                var refreshResponse = refreshClient.Execute(refreshRequest);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Что-то не так\nПроверьте подключение к интернету и подключение к VPN");
                    Config.Default.access_token = "";
                    Config.Default.refresh_token = "";
                    Config.Default.Save();
                    Close();
                }
                var refreshResponseContent = refreshResponse.Content;

                var token_type = JsonConvert.DeserializeObject<Dictionary<string, object>>(refreshResponseContent)["token_type"].ToString();
                var expires_at = JsonConvert.DeserializeObject<Dictionary<string, object>>(refreshResponseContent)["expires_at"].ToString();
                var expires_in = JsonConvert.DeserializeObject<Dictionary<string, object>>(refreshResponseContent)["expires_in"].ToString();
                var refresh_token = JsonConvert.DeserializeObject<Dictionary<string, object>>(refreshResponseContent)["refresh_token"].ToString();
                var access_token = JsonConvert.DeserializeObject<Dictionary<string, object>>(refreshResponseContent)["access_token"].ToString();

                token = new Token(token_type, expires_at, expires_in, refresh_token, access_token);
                Config.Default.access_token = access_token;
                Config.Default.refresh_token = refresh_token;
                Config.Default.Save();

                request = new RestRequest("", Method.Get)
                    .AddParameter("access_token", token.access_token);
                response = client.Execute(request);
            }

            var responseContent = response.Content;

            JArray jArray = JArray.Parse(responseContent);

            foreach(var elem in jArray)
            {
                var id = elem.Value<long>("id");
                var elapsed_time = elem.Value<int>("elapsed_time");
                var sport = elem.Value<string>("sport_type");
                var name = elem.Value<string>("name");
                var average_heartrate = elem.Value<float>("average_heartrate");
                var start_date_local = elem.Value<DateTime>("start_date_local");
                var distance = elem.Value<float>("distance");

                var sport_type =(Activity.sport) Enum.Parse(typeof(Activity.sport), sport);

                items.Add(new Activity(id, elapsed_time, sport_type, name, average_heartrate, start_date_local, distance));

            }

            Action a = delegate {
                
                foreach (var item in items)
                {
                    ActivitiesList.Rows.Add(item.id,
                        item.name,
                        item.sport_type,
                        item.elapsed_time,
                        item.start_date_local,
                        item.distance,
                        item.average_heartrate);
                }
                EnableButtons();
            };
            try
            {
                ActivitiesList.Invoke(a);
            }catch(Exception e)
            {
                
                foreach (var item in items)
                {
                    ActivitiesList.Rows.Add(item.id,
                        item.name,
                        item.sport_type,
                        item.elapsed_time,
                        item.start_date_local,
                        item.distance,
                        item.average_heartrate);
                }
                EnableButtons();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Token token = await auth.GetTokenAsync().ConfigureAwait(false);
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            var client = new RestClient($"{Config.Default.url}/deauthorize");
            var request = new RestRequest("", Method.Post)
                .AddParameter("access_token", token.access_token);
            client.Execute(request);

            Config.Default.access_token = "";
            Config.Default.access_token = "";
            Config.Default.Save();
            Close();
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            ActivityForm activityForm = new ActivityForm(true, token);
            if (activityForm.ShowDialog() == DialogResult.OK)
                getActivities();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ActivityForm activityForm = new ActivityForm(token, ActivitiesList.CurrentRow.Cells["id"].Value.ToString(), ActivitiesList.CurrentRow.Cells["name"].Value.ToString(),
                ActivitiesList.CurrentRow.Cells["sport_type"].Value.ToString(), ActivitiesList.CurrentRow.Cells["elapsed_time"].Value.ToString(),
                ActivitiesList.CurrentRow.Cells["start_date_local"].Value.ToString(), ActivitiesList.CurrentRow.Cells["distance"].Value.ToString(),
                ActivitiesList.CurrentRow.Cells["average_heartrate"].Value.ToString());
            if (activityForm.ShowDialog() == DialogResult.OK)
                getActivities();           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = ActivitiesList.CurrentRow.Cells["id"].Value.ToString();
            var client = new RestClient($"{StravaApi.url}/activities/{id}");
            var request = new RestRequest("", Method.Delete)
                .AddParameter("access_token", token.access_token);
            var response=client.Execute(request);
        }

        private void EnableButtons()
        {
            if (token != null)
                btnEndSession.Enabled = true;
            if(ActivitiesList.Rows.Count==0)
            {
                btnEdit.Enabled = false;
                btnAddActivity.Enabled = true;
                btnDelete.Enabled = false;
            }
            if(ActivitiesList.Rows.Count!=0)
            {
                btnAddActivity.Enabled = true;
                btnDelete.Enabled = true;
                btnEndSession.Enabled = true;
                btnEdit.Enabled = true;
            }
        }
    }
}