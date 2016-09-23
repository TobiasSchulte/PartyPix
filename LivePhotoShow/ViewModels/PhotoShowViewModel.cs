using System.Windows;
using Caliburn.Micro;
using LivePhotoShow.Messages;

namespace LivePhotoShow.ViewModels
{
    class PhotoShowViewModel : Screen, IHandle<ShowPhoto>
    {
        private WindowState windowState;

        private string photoPath;

        public string PhotoPath
        {
            get
            {
                return photoPath;
            }

            set
            {
                if (photoPath != value)
                {
                    photoPath = value;
                    this.NotifyOfPropertyChange(nameof(this.PhotoPath));
                }
            }
        }

        public PhotoShowViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public void Handle(ShowPhoto message)
        {
            this.PhotoPath = message.Path;
        }

        private void ToggleFullScreen()
        {

        }
    }
}
