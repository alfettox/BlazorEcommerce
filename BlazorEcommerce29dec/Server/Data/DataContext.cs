

namespace BlazorEcommerce29dec.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "War and Peace",
                    Description = "War and Peace[a] is a literary work by Russian author Leo Tolstoy. Set during the Napoleonic Wars, the work mixes fictional narrative with chapters discussing history and philosophy. First published serially beginning in 1865, the work was rewritten and published in its entirety in 1869. It is regarded as Tolstoy's finest literary achievement and remains an internationally praised classic of world literature.[1][2][3]",
                    ImageUrl = "https://m.media-amazon.com/images/I/81oHM-dzefL._AC_UF1000,1000_QL80_.jpg",
                    Price = 9.99m
                },
                new Product
                {
                    Id = 2,
                    Title = "The Divine Comedy",
                    Description = "The Divine Comedy (Italian: Divina Commedia [diˈviːna komˈmɛːdja]) is an Italian narrative poem by Dante Alighieri, begun c. 1308 and completed around 1321, shortly before the author's death. It is widely considered the pre-eminent work in Italian literature[1] and one of the greatest works of Western literature.[2] The poem's imaginative vision of the afterlife is representative of the medieval worldview as it existed in the Western Church by the 14th century. It helped establish the Tuscan language, in which it is written, as the standardized Italian language.[3] It is divided into three parts: Inferno, Purgatorio, and Paradiso.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/b/ba/Dante03.jpg",
                    Price = 15.55m
                },
                new Product
                {
                    Id = 3,
                    Title = "The Betrothed",
                    Description = "The Betrothed (Italian: I promessi sposi [i proˈmessi ˈspɔːzi]) is an Italian historical novel by Alessandro Manzoni, first published in 1827, in three volumes, and significantly revised and rewritten until the definitive version published between 1840 and 1842. It has been called the most famous and widely read novel in the Italian language.[1]",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/72/Frontispiece_promessi_sposi.jpg",
                    Price = 23.33m
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
