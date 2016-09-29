using Caliburn.Micro;
using LivePhotoShow.Messages;

namespace LivePhotoShow.ViewModels
{
    class PhotoShowViewModel : Screen, IHandle<ShowPhoto>
    {
        private readonly IEventAggregator eventAggregator;

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
            this.eventAggregator = eventAggregator;

            this.eventAggregator.Subscribe(this);
        }

        public void Handle(ShowPhoto message)
        {
            this.PhotoPath = message.Path;
        }

        protected override void OnDeactivate(bool close)
        {
            this.eventAggregator.PublishOnUIThread(new PhotoShowClosed());
        }
    }
}
