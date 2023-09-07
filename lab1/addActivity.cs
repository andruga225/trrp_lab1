using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class ActivityForm : Form
    {
        Token token;
        bool isCreate=false;
        long id = 0;
        public ActivityForm(bool isCreate, Token token)
        {
            this.token = token;
            this.isCreate = isCreate;
            InitializeComponent();
            cbSportType.DataSource = Enum.GetValues(typeof(Activity.sport)).Cast<Activity.sport>().ToList();
            cbSportType.SelectedIndex = 0;
            btnSave.Enabled = false;
            checkFields();
        }

        public ActivityForm(Token token, string id, string name, string sport_type,
            string elapsed_time, string start_date_local, string distance, string average_heartrate)
        {
            this.token = token;
            InitializeComponent();
            tbName.Text = name;
            cbSportType.DataSource = Enum.GetValues(typeof(Activity.sport)).Cast<Activity.sport>().ToList();
            int index = 0;
            for(int i=0;i<cbSportType.Items.Count;++i)
            {
                if (cbSportType.Items[i].ToString()==sport_type)
                {
                    index = i;
                    break;
                }
            }
            cbSportType.SelectedIndex=index;
            tbElapsedTime.Text = elapsed_time;
            DateTime toStartDate = DateTime.ParseExact(start_date_local, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            tbStartDate.Text = toStartDate.ToString("yyyy-MM-dd HH:mm:ss");
            tbDistance.Text = distance;
            this.id = long.Parse(id);
        }

        private void checkFields()
        {
            bool nameFilled = !string.IsNullOrWhiteSpace(tbName.Text);
            bool sportTypeFilled = !string.IsNullOrEmpty(cbSportType.Text);
            bool elapsedTimeFilled = !string.IsNullOrWhiteSpace(tbElapsedTime.Text) && Double.TryParse(tbElapsedTime.Text, out double time);
            bool startDateFilled = !string.IsNullOrWhiteSpace(tbStartDate.Text) && DateTime.TryParseExact(tbStartDate.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date);
            bool distanceFilled = !string.IsNullOrWhiteSpace(tbDistance.Text) && Double.TryParse(tbDistance.Text, out double dist);

            if (nameFilled && sportTypeFilled && elapsedTimeFilled && startDateFilled && distanceFilled)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isCreate)
            {
                var client = new RestClient($"{StravaApi.url}/activities");
                var request = new RestRequest("", Method.Post)
                    .AddParameter("name", tbName.Text)
                    .AddParameter("sport_type", cbSportType.Text)
                    .AddParameter("start_date_local", tbStartDate.Text)
                    .AddParameter("elapsed_time", tbElapsedTime.Text)
                    .AddParameter("distance", tbDistance.Text)
                    .AddParameter("access_token", token.access_token);

                var response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Тренировка не добавлена");
                    Close();
                }
            }
            else
            {
                var client = new RestClient($"{StravaApi.url}/activities/{id}");
                var request = new RestRequest("", Method.Put)
                    .AddParameter("name", tbName.Text)
                    .AddParameter("sport_type", cbSportType.Text)
                    .AddParameter("start_date_local", tbStartDate.Text)
                    .AddParameter("elapsed_time", tbElapsedTime.Text)
                    .AddParameter("distance", tbDistance.Text)
                    .AddParameter("has_heartrate", "true")
                    .AddParameter("access_token", token.access_token);

                var response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Тренировка не добавлена");
                    Close();
                }
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void cbSportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void tbElapsedTime_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void tbStartDate_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void tbDistance_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void tbHeartrate_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }
    }
}
