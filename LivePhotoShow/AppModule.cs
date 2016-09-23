using Caliburn.Micro;
using Ninject.Modules;

namespace LivePhotoShow
{
    class AppModule : NinjectModule
    {
        public override sealed void Load()
        {
            this.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            this.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
        }
    }
}
