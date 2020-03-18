using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UtahRatings
{
    public class TVShow
    {
        public string Title { get; set; }
        public string Cast { get; set; }
        public string ImageUrl { get; set; }
        public Color BgColor { get; set; }
    }

    public class TVShowService
    {
        public List<TVShow> GetTVShowsList()
        {
            return new List<TVShow>()
            {
                new TVShow()
                {
                    Title="Joker",
                    Cast="Ninja",
                    ImageUrl="https://wallpaperaccess.com/full/1492474.jpg",

                },
                new TVShow()
                {
                    Title="Westeros",
                    Cast="GoT",
                    ImageUrl="https://images-na.ssl-images-amazon.com/images/I/81RciW3G1QL._AC_SY606_.jpg"

                },
                new TVShow()
                {
                    Title="LLL",
                    Cast="La La Land",
                    ImageUrl="https://i.pinimg.com/originals/d1/6f/08/d16f080f78d3ebc25cdcd011e19be2f3.jpg"

                },
                  new TVShow()
                {
                    Title="U Talkin to me?",
                    Cast="Taxi Driver",
                    ImageUrl="https://img.hebus.com/hebus_2019/08/24/preview/1566674990_8965.jpg"

                },
                    new TVShow()
                {
                    Title="Midsommar",
                    Cast="Midsommar",
                    ImageUrl="https://wallpaperaccess.com/full/1492474.jpg"

                }

            };
        }
        }
    }

