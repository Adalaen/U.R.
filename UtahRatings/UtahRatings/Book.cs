using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UtahRatings
{
    public class Book
    {
        public string Title { get; set; }
        public string Cast { get; set; }
        public string ImageUrl { get; set; }
        public Color BgColor { get; set; }
    }
    public class BookService
    {
        public List<Book> GetBooksList()
        {
            return new List<Book>()
            {
                new Book()
                {

                Title="Joker",
                    Cast="Ninja",
                    ImageUrl="https://wallpaperaccess.com/full/1492474.jpg",

                },
                new Book()
                {
                    Title="Westeros",
                    Cast="GoT",
                    ImageUrl="https://images-na.ssl-images-amazon.com/images/I/81RciW3G1QL._AC_SY606_.jpg"

                },
                new Book()
                {
                    Title="LLL",
                    Cast="La La Land",
                    ImageUrl="https://i.pinimg.com/originals/d1/6f/08/d16f080f78d3ebc25cdcd011e19be2f3.jpg"

                },
                  new Book()
                {
                    Title="U Talkin to me?",
                    Cast="Taxi Driver",
                    ImageUrl="https://img.hebus.com/hebus_2019/08/24/preview/1566674990_8965.jpg"

                },
                    new Book()
                {
                    Title="Midsommar",
                    Cast="Midsommar",
                    ImageUrl="https://wallpaperaccess.com/full/1492474.jpg"

                }

            };
        }
        }
    }

