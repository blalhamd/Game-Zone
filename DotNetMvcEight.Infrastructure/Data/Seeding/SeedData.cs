

namespace DotNetMvcEight.Infrastructure.Data.Seeding
{
    public static class SeedData
    {

        public static IEnumerable<Category> LoadCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Sports",

                },
                new Category()
                {
                    Id = 2,
                    Name = "Action",
             
                },
                 new Category()
                {
                    Id = 3,
                    Name = "Film",

                },
                  new Category()
                {
                    Id = 4,
                    Name = "Racing",

                },
                   new Category()
                {
                    Id = 5,
                    Name = "Fighting",

                },
                     new Category()
                {
                    Id = 6,
                    Name = "Adventure",

                },
            };
        }
        public static IEnumerable<Game> LoadGames()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Id = 1,
                    Name = "PUBGI",
                    Description = "",
                    CategoryId = 5,
                    ImagePath = "",

                },
                new Game()
                {
                    Id = 2,
                    Name = "Free Fire",
                    Description = "",
                    CategoryId = 1,
                    ImagePath = "",

                },
               
            };
        }

        public static IEnumerable<Device> LoadDevices()
        {
            return new List<Device>()
            {
                new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
                new Device { Id = 2, Name = "xbox", Icon = "bi bi-xbox" },
                new Device { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch" },
                new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }
            };
        }

    }
}
