using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace XboxCsMgr.Client
{
    /// <summary>
    /// Interaction logic for Dialogue.xaml
    /// </summary>
    public partial class Dialogue : Window
    {
        public Dialogue()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://login.live.com/oauth20_authorize.srf?client_id=56d7a5b8-2113-4789-928e-981d3129227d&response_type=code&approval_prompt=auto&scope=XboxLive.signin&redirect_uri=https%3A%2F%2Flocalhost%2Foauth_success") { UseShellExecute = true });
        }
    }
}
