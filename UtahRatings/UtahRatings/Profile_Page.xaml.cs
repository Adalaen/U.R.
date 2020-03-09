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
                    CategoryName = "Hikes",
                    //Image = "HikeCategory.png",
                },

                new MyList_Model
                {
                    CategoryName = "Restaurants",
                    //Image = "restaurantCategory.png",
                },

                new MyList_Model
                {
                    CategoryName = "Entertainment",
                    //Image = "entertainmentCategory.png",
                }
            };
            //Profile_List_View.ItemsSource = MyList;
        }
    }
}
