using Microsoft.Extensions.Configuration;

namespace WinForm_Core_AppSettings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var setting = Program.config.GetSection("Settings").Get<Settings>();
            //MessageBox.Show(setting.KeyOne.ToString());
            //MessageBox.Show(setting.KeyTwo.ToString());
            //MessageBox.Show(setting.KeyThree.ToString());
            //MessageBox.Show(setting.Logger.Path);


            int keyOne = Program.config.GetValue<int>("Settings:KeyOne");

            string ip_0 = Program.config.GetValue<string>("Settings:IpAddress:0");
            string ip_1 = Program.config.GetValue<string>("Settings:IpAddress:1");
            string ip_2 = Program.config.GetValue<string>("Settings:IpAddress:2");


            string ip_index_0 = Program.config["Settings:IpAddress:0"];


        }
    }
}