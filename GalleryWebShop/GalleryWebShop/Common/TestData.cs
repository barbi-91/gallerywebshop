using GalleryWebShop.Models;

namespace GalleryWebShop.Common
{
    public static class TestData
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>() { 
                new Product()
                {
                    Id = 1,
                    Image = "2023-06-24-12-11-35_sea.jpg",
                    Description = "Seascape using the acrylic  on canvas technique.",
                    InStock = 1,
                    Price = 250.00M,
                    Title = "Rippling sea",
                    Sku = "1dfd314716",
                    Size = "30x45",
                },
                new Product()
                {
                    Id = 2,
                    Image = "2023-06-23-06-52-54_bird.jpg",
                    Description = "Bird portrait using the oil on canvas technique.",
                    InStock = 1,
                    Price = 320.00M,
                    Title = "Bird song",
                    Sku = "4632ec6f16",
                    Size = "30x30"
                },

                new Product()
                {
                    Id = 3,
                    Image = "2023-06-23-06-53-16_unsplash.jpg",
                    Description = "Nature scape using the acrylic on canvas technique.",
                    InStock = 2,
                    Price = 260.00M,
                    Title = "Autumn over the river",
                    Sku = "dfa45d4dfa",
                    Size = "20x30"
                },

                new Product()
                {
                    Id = 4,
                    Image = "2023-06-22-07-11-17_face.jpg",
                    Description = "Abstract painting of face using Oil technice.",
                    InStock = 5,
                    Price = 670.00M,
                    Title = "Conqueror's view",
                    Sku = "ela45d4d11",
                    Size = "50x70"
                },

                new Product()
                {
                    Id = 5,
                    Image = "2023-06-22-07-12-09_abstract3.jpg",
                    Description = "Abstract painting of world with using ink wash technic.",
                    InStock = 2,
                    Price = 345.00M,
                    Title = "Abstract World",
                    Sku = "5jfd314733",
                    Size = "50x80"
                },

                new Product()
                {
                    Id = 6,
                    Image = "2023-06-23-06-54-50_animals.jpg",
                    Description = "A drawing made with light and shadow, i.e. tones, then such a drawing is called a tonal or painterly drawing.",
                    InStock = 3,
                    Price = 880.00M,
                    Title = "Forest story",
                    Sku = "kk545d4dfa",
                    Size = "50x70"
                },

                new Product()
                {
                    Id = 7,
                    Image = "2023-06-22-07-13-13_cats.jpg",
                    Description = "A drawing made with light and shadow, i.e. tones, then such a drawing is called a tonal or painterly drawing.",
                    InStock = 1,
                    Price = 550.00M,
                    Title = "Playful cats",
                    Sku = "dfa4545zuh",
                    Size = "60x80"
                },

                new Product()
                {
                    Id = 8,
                    Image = "2023-06-22-07-13-56_water.jpg",
                    Description = "Deep blue sea drawn with acrylic technique.",
                    InStock = 1,
                    Price = 290.00M,
                    Title = "Deep sea",
                    Sku = "12sd8d4d22",
                    Size = "50x70"
                },

                new Product()
                {
                    Id = 9,
                    Image = "2023-06-22-07-14-38_flower.jpg",
                    Description = "Flowers in a vase painted with acrylic technique",
                    InStock = 1,
                    Price = 385.00M,
                    Title = "Garden flowers",
                    Sku = "12h23d4d22",
                    Size = "90x70"
                },

                new Product()
                {
                    Id = 10,
                    Image = "2023-06-23-06-55-27_flowers2.jpg",
                    Description = "Flowers in a vase in summer painted with acrylic technique.",
                    InStock = 1,
                    Price = 450.00M,
                    Title = "Summer touch",
                    Sku = "dfa45fff11",
                    Size = "50x80"
                },

                new Product()
                {
                    Id = 11,
                    Image = "2023-06-22-07-15-42_abstract2jpg.jpg",
                    Description = "Abstract painting of life using oil technic.",
                    InStock = 2,
                    Price = 330.00M,
                    Title = "Abstract Life",
                    Sku = "gga45d4333",
                    Size = "90x50"
                },
                new Product()
                {
                    Id = 12,
                    Image = "2023-06-22-07-16-08_abstract4.jpg",
                    Description = "Abstract painting of soul using ink wash technic.",
                    InStock = 1,
                    Price = 320.00M,
                    Title = "Abstract  Soul",
                    Sku = "gzt5derfa",
                    Size = "90x70"
                },
                new Product()
                {
                    Id = 13,
                    Image = "2023-06-22-07-16-47_cat.jpg",
                    Description = "Cat portret using watercolor technic.",
                    InStock = 1,
                    Price = 290.00M,
                    Title = "Cat",
                    Sku = "89hzud4882",
                    Size = "90x50"
                },
                new Product()
                {
                    Id = 14,
                    Image = "2023-06-23-07-46-00_waterfall.jpg",
                    Description = "Waterfall on river using watercolor technic.",
                    InStock = 1,
                    Price = 140.00M,
                    Title = "Waterfall",
                    Sku = "ed456d2w3e",
                    Size = "40x50"
                },
                new Product()
                {
                    Id = 15,
                    Image = "2023-06-23-07-46-22_apple.jpg",
                    Description = "The simple shape is not too uniform and symmetrical. Apple painted using watercolor technic.",
                    InStock = 2,
                    Price = 220.00M,
                    Title = "Apple",
                    Sku = "afadj33dfa",
                    Size = "50x70"
                },
                new Product()
                {
                    Id = 16,
                    Image = "2023-06-23-06-56-22_fruit.jpg",
                    Description = "Fruits in silence was painted using the acrylic technique on canvas.",
                    InStock = 1,
                    Price = 550.00M,
                    Title = "Fruit in silence",
                    Sku = "t37dj24ddd",
                    Size = "50x80"
                },
                new Product()
                {
                    Id = 17,
                    Image = "2023-06-23-07-46-45_fox.jpg",
                    Description = "The hungry fox in the manor's court was painted using the technique of drawing on canvas.",
                    InStock = 2,
                    Price = 310.00M,
                    Title = "Hungry fox",
                    Sku = "987bgh5rd3",
                    Size = "90x70"
                },
                new Product()
                {
                    Id = 18,
                    Image = "2023-06-23-07-47-10_castel.jpg",
                    Description = "The castle captured in the time of wealth was painted using the technique of water colors.",
                    InStock = 3,
                    Price = 680.00M,
                    Title = "Castle in time",
                    Sku = "g38ks9e567",
                    Size = "90x70"
                },
                new Product()
                {
                    Id = 19,
                    Image = "2023-06-23-07-47-40_girl.jpg",
                    Description = "Little girl in her mind on the grass using ink wash technic.",
                    InStock = 1,
                    Price = 600.00M,
                    Title = "A girl with a heavy heart",
                    Sku = "kt85ffps55",
                    Size = "90x50"
                },

                new Product()
                {
                    Id = 20,
                    Image = "2023-06-23-06-57-21_tunder.jpg",
                    Description = "The painting called Heaven and Hell is an abstract art created by observing the sky during a storm, and it was painted using the oil on canvas technique.",
                    InStock = 2,
                    Price = 490.00M,
                    Title = "Heaven and hell",
                    Sku = "j8z08jut54",
                    Size = "90x70"
                },

                new Product()
                {
                    Id = 21,
                    Image = "2023-06-23-07-48-02_town.jpg",
                    Description = "City calm is a work of art created using the drawing technique on canvas.",
                    InStock = 4,
                    Price = 270.00M,
                    Title = "City calm",
                    Sku = "dh46dje9ii",
                    Size = "50x70"
                },

                new Product()
                {
                    Id = 22,
                    Image = "2023-06-25-09-56-41_snow.jpg",
                    Description = "Mountains in winter is a work of art created using the acrylic technique on canvas, which depicts the idyll of winter in a mountainous area.",
                    InStock = 2,
                    Price = 380.00M,
                    Title = "Mountains in winterm",
                    Sku = "ju876tr45d",
                    Size = "50x80"
                }
            };
        }

        public static IEnumerable<ProductCategory> GetProductsCategory()
        {
            return new List<ProductCategory>()
            {
                new ProductCategory()
                {
                  Id= 1,
                  CategoryId = 2,
                  ProductId = 4
                },
                new ProductCategory()
                {
                    Id= 2,
                    CategoryId = 3,
                    ProductId = 5
                },
                new ProductCategory()
                {
                    Id= 3,
                    CategoryId = 4,
                    ProductId = 7
                },
                new ProductCategory()
                {
                    Id= 4,
                    CategoryId= 1,
                    ProductId= 8
                },
                new ProductCategory()
                {
                    Id= 5,
                    CategoryId= 1,
                    ProductId= 9
                },
                new ProductCategory()
                {
                    Id= 6,
                    CategoryId= 2,
                    ProductId= 11
                },
                new ProductCategory()
                {
                    Id= 7,
                    CategoryId= 3,
                    ProductId= 12
                },
                new ProductCategory()
                {
                    Id= 8,
                    CategoryId= 5,
                    ProductId= 13
                },
                new ProductCategory()
                {
                    Id= 9,
                    CategoryId= 2,
                    ProductId= 2
                },
                new ProductCategory()
                {
                    Id= 10,
                    CategoryId= 1,
                    ProductId= 3
                },
                new ProductCategory()
                {
                    Id= 11,
                    CategoryId= 4,
                    ProductId= 6
                },
                new ProductCategory()
                {
                    Id= 12,
                    CategoryId= 1,
                    ProductId= 10
                },
                new ProductCategory()
                {
                    Id= 13,
                    CategoryId= 1,
                    ProductId= 16
                },
                new ProductCategory()
                {
                    Id= 14,
                    CategoryId= 2,
                    ProductId= 20
                },
                new ProductCategory()
                {
                    Id= 15,
                    CategoryId= 5,
                    ProductId= 14
                },
                new ProductCategory()
                {
                    Id= 16,
                    CategoryId= 5,
                    ProductId= 15
                },
                new ProductCategory()
                {
                    Id= 17,
                    CategoryId= 4,
                    ProductId= 17
                },
                new ProductCategory()
                {
                    Id= 18,
                    CategoryId= 5,
                    ProductId= 18
                },
                new ProductCategory()
                {
                    Id= 19,
                    CategoryId= 3,
                    ProductId= 19
                },
                new ProductCategory()
                {
                    Id= 20,
                    CategoryId= 4,
                    ProductId=21
                },
                new ProductCategory()
                {
                    Id= 21,
                    CategoryId= 1,
                    ProductId=1
                },
                new ProductCategory()
                {
                    Id= 22,
                    CategoryId= 1,
                    ProductId=22
                }
            };
        }   
    }
}