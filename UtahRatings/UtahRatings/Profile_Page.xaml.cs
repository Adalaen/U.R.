using System;
using System.Collections.ObjectModel;
using UtahRatings.Model;
using Xamarin.Forms;

namespace UtahRatings
{
    public partial class Profile_Page : ContentPage
    {
        public ObservableCollection<MyList_Model> MyList { get; set; }

        public Profile_Page()
        {
            InitializeComponent();


            MyList = new ObservableCollection<MyList_Model>
            {
                new MyList_Model
                {
                    Name = "Hikes",
                    //ImageUrl = "HikeCategory.png",
                },

                new MyList_Model
                {
                    Name = "Restaurants",
                    //ImageUrl = "restaurantCategory.png",
                },

                new MyList_Model
                {
                    Name = "Entertainment",
                    //Imageurl = "entertainmentCategory.png",
                }
            };
            //Profile_List_View.ItemsSource = MyList;
        }

        /*private static async void AddList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateList());
        }*/

        void AddList_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new CreateList());
        }

    }

    
}
