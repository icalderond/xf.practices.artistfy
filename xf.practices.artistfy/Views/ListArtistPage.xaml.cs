using System;
using System.Collections.Generic;

using Xamarin.Forms;
using xf.practices.artistfy.ViewModels;

namespace xf.practices.artistfy.Views
{
    public partial class ListArtistPage : ContentPage
    {
        public ListArtistPage()
        {
            InitializeComponent();
            BindingContext = new ListArtistViewModel();
        }
    }
}
