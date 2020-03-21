using System;
using UtahRatings.ViewModel;
using Xamarin.Forms;

namespace UtahRatings
{
    public partial class Profile_Page : ContentPage
    {

        public Profile_Page()
        {
            InitializeComponent();

            BindingContext = new MyList_ViewModel();
        }

        void AddList_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new CreateList());
        }

    }

}