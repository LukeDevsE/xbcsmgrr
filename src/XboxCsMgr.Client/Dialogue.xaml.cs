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
            Process.Start(new ProcessStartInfo("https://login.live.com/oauth20_authorize.srf?client_id=c36a9fb6-4f2a-41ff-90bd-ae7cc92031eb&response_type=code&approval_prompt=auto&scope=Xboxlive.signin+Xboxlive.offline_access") { UseShellExecute = true });
        }
    }
}
