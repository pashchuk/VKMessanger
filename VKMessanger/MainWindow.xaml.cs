using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace VKMessanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string appid = "4447152";
            string scope = "friends,photos,wall,messages,notifications";
            AuthWindow window = new AuthWindow();
            window.ShowDialog();
            string token = window.AccesToken;
            window.Close();
            HttpWebResponse response = ExecuteRequest("messages.getDialogs", "", token);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string resp = reader.ReadToEnd();
            texbox.Text = resp;

        }
        public static HttpWebResponse ExecuteRequest(string method_name, string parameters, string token)
        {
            WebRequest request = HttpWebRequest.Create(string.Format(
            @"https://api.vk.com/method/{0}?{1}&access_token={2}", method_name, parameters, token));
            return (HttpWebResponse)request.GetResponse();
        }
    }

}
