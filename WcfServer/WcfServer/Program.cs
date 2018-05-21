using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Unity.Wcf;

namespace WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1st Initialize the Host (Configures Container and Factories)
            ServiceHostController.Initialize();
            //var baseAddress1 = new Uri("http://localhost:5555/BartService");
            //var baseAddress2 = new Uri("net.tcp://localhost:5556/BartService");


            // using (var host = new UnityServiceHost(ServiceHostController.UnityContainer,typeof(BartService),baseAddress1, baseAddress2))
            using (var host = new UnityServiceHost(ServiceHostController.UnityContainer, typeof(BartService)))
            using (var host1 = new UnityServiceHost(ServiceHostController.UnityContainer, typeof(NotificationService)))
            {
                host.Closed += Host_Closed;
                host.Opened += Host_Opened;
                host.Faulted += Host_Faulted;
                host.Open();
                host1.Open();
                Console.WriteLine(string.Join(",", host.BaseAddresses));
                Console.ReadLine();
                // int.MaxValue
            }


        }

        private static void Host_Faulted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Host Opened.");
        }

        private static void Host_Closed(object sender, EventArgs e)
        {

        }
    }
}
