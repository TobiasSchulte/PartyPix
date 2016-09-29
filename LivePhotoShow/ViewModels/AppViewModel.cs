using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using LivePhotoShow.Messages;

namespace LivePhotoShow.ViewModels
{
    class AppViewModel : Screen, IHandle<PhotoShowClosed>
    {
        private IWindowManager windowManager;
        private IEventAggregator eventAggregator;
        private PhotoShowViewModel photoShowViewModel;
        private bool liveViewVisible = false;

        public AppViewModel(IWindowManager windowManager, IEventAggregator eventAggregator, PhotoShowViewModel photoShowViewModel)
        {
            this.windowManager = windowManager;
            this.eventAggregator = eventAggregator;
            this.photoShowViewModel = photoShowViewModel;

            this.eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            if (close)
            {
                this.photoShowViewModel.TryClose();
            }
        }

        public void ToggleLiveViewWindow()
        {
            if (this.liveViewVisible)
            {
                this.photoShowViewModel.TryClose();
                // liveViewVisible will be set to false by method Handle(PhotoShowClosed message)
            }
            else
            {
                var currentScreen = System.Windows.Forms.Screen.FromHandle(
                    new System.Windows.Interop.WindowInteropHelper((Window)this.GetView()).Handle);
                var targetScreen = System.Windows.Forms.Screen.AllScreens.FirstOrDefault(s => s.DeviceName != currentScreen.DeviceName);

                if (targetScreen == null)
                {
                    targetScreen = currentScreen;
                }

                var settings = new Dictionary<string, object>
                {
                    { "Top", targetScreen.WorkingArea.Top },
                    { "Left", targetScreen.WorkingArea.Left },
                    { "Width", targetScreen.WorkingArea.Width },
                    { "Height", targetScreen.WorkingArea.Height }
                };

                this.windowManager.ShowWindow(this.photoShowViewModel, null, settings);

                this.liveViewVisible = !this.liveViewVisible;
            }
        }

        public void ShowMeerkat()
        {
            this.eventAggregator.PublishOnUIThread(new ShowPhoto(@"C:\Users\tschulte\Pictures\Sample Pictures\meerkat.jpg"));
        }

        public void ShowBalloon()
        {
            this.eventAggregator.PublishOnUIThread(new ShowPhoto(@"C:\Users\tschulte\Pictures\Sample Pictures\balloon.jpg"));
        }

        public void Handle(PhotoShowClosed message)
        {
            this.liveViewVisible = false;
        }
    }
}