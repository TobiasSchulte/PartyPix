using System;
using System.Windows;
using Caliburn.Micro;
using LivePhotoShow.ViewModels;
using Ninject;

namespace LivePhotoShow
{
    public class AppBootstrapper : BootstrapperBase
    {
        protected IKernel Kernel { get; private set; }

        public AppBootstrapper()
        {
            this.Initialize();
        }


        protected override sealed void Configure()
        {
            this.Kernel = new StandardKernel(new AppModule());

            base.Configure();
        }

        protected override sealed object GetInstance(Type service, string key)
        {
            return this.Kernel.Get(service);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // var settings = new Dictionary<string, object>
            //{
            //    { "SizeToContent", SizeToContent.Manual },
            //    { "Height", 500  },
            //    { "Width", 650 },
            //    { "MinHeight", 500  },
            //    { "MinWidth", 650 },
            //};

            this.DisplayRootViewFor<AppViewModel>();// settings);
        }
    }
}
