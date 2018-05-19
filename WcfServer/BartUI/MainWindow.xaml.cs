using BartUI.SimpleProxy;
using ServiceLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BartUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BartServiceClient client = new BartServiceClient("NetTcpBinding_IBartService");
            var issues = client.GetIssue(Guid.NewGuid().ToString(), new IssueRequest() { UserName = Environment.UserName });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int objSize = 512 * 512 * 127;
            int rounds = 2;
            BartServiceClient client = new BartServiceClient("NetTcpBinding_IBartService");
            //BartService.BartServiceClient client = new BartService.BartServiceClient("BasicHttpBinding_IBartService");
            Stopwatch timer = new Stopwatch();
            double totalTime = 0;
            for (int r = 0; r < rounds; ++r)
            {
                timer.Restart();

                BigObject obj = client.GetBigObject(objSize);
                timer.Stop();

                Debug.WriteLine("Round: " + r);
                Debug.WriteLine("Name: " + obj.Name);
                Debug.WriteLine("Data Len: " + obj.Data.Count());

                Debug.WriteLine("Elapsed time: " + timer.Elapsed.TotalSeconds);
                totalTime += timer.Elapsed.TotalSeconds;
            }

            Debug.WriteLine("Average time: " + totalTime / rounds);
          
        }
    }
}
