using ServiceLibrary;
using System;
using Unity;

namespace WcfServer
{
    internal class ServiceHostController
    {
        private static object _locker = new object();
        private static IUnityContainer _container;
        public static IUnityContainer UnityContainer
        {
            get
            {
                lock (_locker)
                {
                    if (!_initialized)
                    {
                        Initialize();
                    }
                    return _container;
                }
            }

           
        }
        private static bool _initialized;

        internal static void Initialize()
        {
            _initialized = true;
            _container = new UnityContainer();
            _container.RegisterType<IBartService, BartService>();
            _container.RegisterType<IIssueProvider, IssueProvider>(new Unity.Lifetime.ContainerControlledLifetimeManager());
                
            Console.WriteLine("Initialized the container");
        }
    }
}