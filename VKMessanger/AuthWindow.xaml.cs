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
using System.Windows.Shapes;

namespace VKMessanger
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public string AccesToken { get; private set; }
        public AuthWindow()
        {
            InitializeComponent();
            string appid = "4447152";
            string scope = "friends,photos,wall,messages,notifications";

            string vkUri = "https://oauth.vk.com/authorize?client_id=" + appid + "&scope=" + scope +
                "&redirect_uri=http://oauth.vk.com/blank.html&display=popup&response_type=token";
            browser.Navigate(vkUri);
            browser.LoadCompleted += (sender, e) =>
            {
                string url = ((WebBrowser)sender).Source.AbsoluteUri;
                try
                {
                    string token = url.Split('#')[1].Split('=')[1];
                    AccesToken = token;
                    this.Hide();
                }
                catch { }
            };
        }
    }
}
