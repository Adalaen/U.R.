using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UtahRatings
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
                InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CVMovies.ItemsSource = new MovieService().GetMoviesList();
            CVTVShows.ItemsSource = new TVShowService().GetTVShowsList();
            CVBooks.ItemsSource = new BookService().GetBooksList();

        }
    }
}
