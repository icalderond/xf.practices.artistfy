using System;
using System.Collections.ObjectModel;
using QuickType;
using xf.practices.artistfy.Service;
using System.Linq;
using Xamarin.Essentials;

namespace xf.practices.artistfy.ViewModels
{
    public class ListArtistViewModel : NotificationEnabledObject
    {
        LastFMService service;

        public ListArtistViewModel()
        {
            service = new LastFMService();

            service.TrackSearch_Completed += (s, a) =>
            {
                TrackList = new ObservableCollection<Track>(a.Result.Value);
                Current = TrackList.First();
            };

            Title = "Artist";

            service.TrackSearch("malone");
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

        private ObservableCollection<Track> _TrackList;
        public ObservableCollection<Track> TrackList
        {
            get { return _TrackList; }
            set
            {
                _TrackList = value;
                OnPropertyChanged();
            }
        }

        private Track _Current;
        public Track Current
        {
            get { return _Current; }
            set
            {
                _Current = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand<Uri> _OpenBrowserCommand;
        public ActionCommand<Uri> OpenBrowserCommand
        {
            get
            {
                if (_OpenBrowserCommand == null)
                {
                    _OpenBrowserCommand = new ActionCommand<Uri>((param) =>
                   {
                       Browser.OpenAsync(param, BrowserLaunchMode.SystemPreferred);
                   });
                }
                return _OpenBrowserCommand;
            }
            set
            {
                _OpenBrowserCommand = value;
                OnPropertyChanged();
            }
        }
    }
}
