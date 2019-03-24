using System;
namespace xf.practices.artistfy.ViewModels
{
    public class ListArtistViewModel : NotificationEnabledObject
    {
        public ListArtistViewModel()
        {
            Title = "Artist";
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }
    }
}
