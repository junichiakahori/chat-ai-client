using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ChatAiClient.Properties;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ChatAiClient
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.Default.ApiKey = textBoxApiKey.Text;
            Settings.Default.ApiUrl = textBoxApiUrl.Text;
            Settings.Default.Save();
            this.Close();
        }

        private void LoadSettings()
        {
            textBoxApiKey.Text = Settings.Default.ApiKey;
            textBoxApiUrl.Text = Settings.Default.ApiUrl;
        }
    }
}
