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
                   
            string vkUri = "https://oauth.vk.com/authorize?client_id=" + appid + "&scope=" + scope +
                "&redirect_uri=http://oauth.vk.com/blank.html&display=popup&response_type=token";
            browser.Navigate(vkUri);
            browser.LoadCompleted += (sender, e) =>
            {
                string url = ((WebBrowser)sender).Source.AbsoluteUri;
                try
                {
                    string token = url.Split('#')[1].Split('=')[1];
                    MessageBox.Show(token);
                }
                catch { }

                //http://REDIRECT_URI#access_token= 533bacf01e11f55b536a565b57531ad114461ae8736d6506a3&expires_in=86400&user_id=8492 
            };
 
        }
    }

}
