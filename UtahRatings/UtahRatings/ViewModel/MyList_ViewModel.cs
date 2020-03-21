using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using UtahRatings.Model;

namespace UtahRatings.ViewModel
{
    public class MyList_ViewModel : INotifyPropertyChanged //ContentView
    {
        readonly IList<MyList_Model> source;
        MyList_Model selectedMyList_Model;
        int selectionCount = 1;

        public ObservableCollection<MyList_Model> MyList_Models { get; private set; }
        public IList<MyList_Model> EmptyMyList_Models { get; private set; }

        public MyList_Model SelectedMyList_Model
        {
            get
            {
                return selectedMyList_Model;
            }
            set
            {
                if (selectedMyList_Model != value)
                {
                    selectedMyList_Model = value;
                }
            }
        }

        ObservableCollection<object> selectedMyList_models;
        public ObservableCollection<object> SelectedMyList_Models
        {
            get
            {
                return selectedMyList_models;
            }
            set
            {
                if (selectedMyList_models != value)
                {
                    selectedMyList_models = value;
                }
            }
        }

        public string SelectedMyList_ModelMessage { get; private set; }

        public ICommand DeleteCommand => new Command<MyList_Model>(RemoveMyList_Model);
        public ICommand FavoriteCommand => new Command<MyList_Model>(FavoriteMyList_Model);
        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand MyList_ModelSelectionChangedCommand => new Command(MyList_ModelSelectionChanged);

        public MyList_ViewModel()
        {
            source = new List<MyList_Model>();
            CreateMyList_ModelCollection();

            selectedMyList_Model = MyList_Models.Skip(3).FirstOrDefault();
            MyList_ModelSelectionChanged();

            SelectedMyList_Models = new ObservableCollection<object>()
            {
                MyList_Models[1], MyList_Models[3], MyList_Models[4]
            };
        }

        void CreateMyList_ModelCollection()
        {
            source.Add(new MyList_Model
            {
                Name = "Arches National Park",
                Location = "Moab Utah",
                Details = "Stunning stone arches and rolling petrified dunes, backed by the often snow-capped peaks of the La Sal Mountains, make this one of the most scenic parks in Utah. Arches National Park is home to more than 2,000 natural stone arches. The most famous of these, and the most photographed, is Delicate Arch, standing like a horseshoe jutting out of the ground, framing the distant mountains. Numerous walking trails and hikes lead to the most popular arches and other interesting rock formations. But many of the main highlights can be seen right from the scenic drives through the park and easily accessed from the parking areas. The top attractions in the park are Devil's Garden, Delicate Arch, Fiery Furnace, Double Arch, Park Avenue, Balanced Rock, the Windows, Broken Arch, and Sandstone Arch",
                ImageUrl = "https://media.deseretdigital.com/file/d80d2f7647?crop=top:0|left:0|width:624|height:416|gravity:Center&quality=55&interlace=none&resize=height:416&order=resize,crop&c=14&a=2a58f914"
            });

            source.Add(new MyList_Model
            {
                Name = "Zion National Park",
                Location = "Springdale, Utah",
                Details = "Zion National Park, less than a three-hour drive from Las Vegas, features some of Utah's most outstanding scenery, with red rock cliffs, waterfalls, and beautiful vistas. Many of the park's most impressive sites are found in Zion Canyon, along the Zion Canyon Scenic Drive, which follows the valley floor.",
                ImageUrl = "https://assets3.thrillist.com/v1/image/2739834/size/tl-full_width_tall_mobile.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Canyonlands National Park",
                Location = "Town of Moab",
                Details = "Canyonlands National Park is Utah's version of the Grand Canyon, without the crowds. The park has three sections, but the main portion, which attracts the majority of sightseers, is Island in the Sky. This area offers incredible vistas looking out over carved canyons and beyond to the snow-capped mountains. It is arguably as impressive as the Grand Canyon in its own unique way, and far less visited. The other two sections of the park, the Needles District and The Maze, offer a slightly different type of landscape but are also impressive. These areas are more remote.",
                ImageUrl = "https://www.planetware.com/photos-large/USUT/utah-canyonlands-national-park.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Bryce Canyon National Park",
                Location = "South Utah, Bryce",
                Details = "Bryce Canyon National Park is located at an elevation of 8,000 to over 9,000 feet and receives snowfall during the winter months and into spring. Temperatures up here, even in summer, can be cool to very cold. The best time to visit is from April to October, particularly if you are planning on staying at one of the campgrounds in the area.",
                ImageUrl = "https://www.planetware.com/photos-large/USUT/utah-bryce-canyon-national-park.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Zion National Park",
                Location = "Springdale, Utah",
                Details = "Zion National Park, less than a three-hour drive from Las Vegas, features some of Utah's most outstanding scenery, with red rock cliffs, waterfalls, and beautiful vistas. Many of the park's most impressive sites are found in Zion Canyon, along the Zion Canyon Scenic Drive, which follows the valley floor.",
                ImageUrl = "https://assets3.thrillist.com/v1/image/2739834/size/tl-full_width_tall_mobile.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Park City and nearby Ski Resorts",
                Location = "Park City Utah",
                Details = "Park City is a fun mountain town, about 45 minutes southeast of Salt Lake City, and home to two awesome ski resorts. On the town's doorstep is Park City Mountain Resort, with lifts operating right from town, and just down the road is Deer Valley Resort, one of Utah's poshest ski resorts. Both of these offer outstanding terrain for all levels of skiers.",
                ImageUrl = "https://www.planetware.com/photos-large/USUT/utah-park-city.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Grand Staircase-Escalante National Monument",
                Location = "Kanab, Utah",
                Details = "Grand Staircase-Escalante National Monument is a huge area of rugged terrain, with a landscape of canyons, arches, hills, waterfalls, forest, and scrubland. It offers a sense of remoteness that is hard to find in other parks. Dirt roads, where you can drive great distances without ever passing another vehicle, are all part of the experience. Covering 1.9 million acres, this is the largest national monument in the United States, and it's managed by the Bureau of Land Management, not the National Park Service",
                ImageUrl = "https://www.planetware.com/photos-large/USUT/utah-grand-staircase-escalante-national-monument.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Great Salt Lake",
                Location = "West Salt Lake City ",
                Details = "The Great Salt Lake, a half-hour drive northwest of Salt Lake City, is the largest inland lake west of the Mississippi, measuring 72 miles long, 34 miles wide, and up to 50 feet deep. It is a remnant of a much larger freshwater lake, Lake Bonneville. Following a fall in the water table, this lake was left with no outlet and shrank as a result of evaporation, leaving the Great Salt Lake Desert",
                ImageUrl = "https://www.planetware.com/photos-large/USUT/utah-great-salt-lake.jpg"
            });

            source.Add(new MyList_Model
            {
                Name = "Bonneville Salt Flats",
                Location = "Wendover, Utah",
                Details = "About 90 minutes west of Salt Lake City along I-80, near Wendover, is an unassuming area of flat land, extending off into the distance as far as the eye can see. But during certain times of the year, this area becomes the world's fastest race course.",
                ImageUrl = "https://media.deseretdigital.com/file/4c14626423?type=jpeg&quality=55&c=15&a=4379240d"
            });

            source.Add(new MyList_Model
            {
                Name = "Ruth Lake",
                Location = "Wasatch Mountains, Utah",
                Details = "Ruth Lake Trail es un sendero circular de 2 millas con tráfico pesado localizado cerca de Kamas, Utah. Tiene un lago y es bueno para todos los niveles de habilidad. El sendero ofrece una serie de opciones de actividades y es mejor utilizado de mayo hasta octubre. Los perros también pueden usar este sendero.",
                ImageUrl = "https://www.dirtinmyshoes.com/wp-content/uploads/2015/08/Ruth-Lake-Hayden-Peak1-e1441036008348.jpg"
            });


            MyList_Models = new ObservableCollection<MyList_Model>(source);
        }

        void FilterItems(string filter)
        {
            var filteredItems = source.Where(myList_model => myList_model.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var myList_model in source)
            {
                if (!filteredItems.Contains(myList_model))
                {
                    MyList_Models.Remove(myList_model);
                }
                else
                {
                    if (!MyList_Models.Contains(myList_model))
                    {
                        MyList_Models.Add(myList_model);
                    }
                }
            }
        }

        void MyList_ModelSelectionChanged()
        {
            SelectedMyList_ModelMessage = $"Selection {selectionCount}: {SelectedMyList_Model.Name}";
            OnPropertyChanged("SelectedMyList_ModelMessage");
            selectionCount++;
        }

        void RemoveMyList_Model(MyList_Model myList_model)
        {
            if (MyList_Models.Contains(myList_model))
            {
                MyList_Models.Remove(myList_model);
            }
        }

        void FavoriteMyList_Model(MyList_Model myList_model)
        {
            myList_model.IsFavorite = !myList_model.IsFavorite;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}