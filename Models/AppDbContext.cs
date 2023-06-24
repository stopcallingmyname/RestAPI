using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Shirt",
                    ProductTypeId = 1,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 2,
                    Name = "Jeans",
                    ProductTypeId = 1,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 3,
                    Name = "Subwoofer",
                    ProductTypeId = 2,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 4,
                    Name = "Against All",
                    ProductTypeId = 4,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 5,
                    Name = "Sneakers",
                    ProductTypeId = 1,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 6,
                    Name = "Laptop",
                    ProductTypeId = 3,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 7,
                    Name = "Headphones",
                    ProductTypeId = 2,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 8,
                    Name = "Watch",
                    ProductTypeId = 3,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 9,
                    Name = "Dress",
                    ProductTypeId = 1,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 10,
                    Name = "TV",
                    ProductTypeId = 3,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 11,
                    Name = "Sunglasses",
                    ProductTypeId = 3,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 12,
                    Name = "Speaker",
                    ProductTypeId = 2,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 13,
                    Name = "Hat",
                    ProductTypeId = 1,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 14,
                    Name = "Backpack",
                    ProductTypeId = 3,
                    Description = "Something blah blah blah.."
                },
                new Product
                {
                    Id = 15,
                    Name = "Guitar",
                    ProductTypeId = 2,
                    Description = "Something blah blah blah.."
                });

            modelBuilder.Entity<Catalog>().HasData(
                new Catalog
                {
                    Id = 1,
                    Name = "T-Shirt",
                    ProductTypeId = 1,
                    Description = "Wow-Wow-Wow, great description :)"
                },
                new Catalog
                {
                    Id = 2,
                    Name = "Baggy Jeans",
                    ProductTypeId = 1,
                    Description = "Wow-Wow-Wow, great description :)"
                },
                new Catalog
                {
                    Id = 3,
                    Name = "JBL Subwoofer",
                    ProductTypeId = 2,
                    Description = "Wow-Wow-Wow, great description :)"
                },
                new Catalog
                {
                    Id = 4,
                    Name = "No Emotions",
                    ProductTypeId = 4,
                    Description = "Wow-Wow-Wow, great description :)"
                },
                new Catalog
                {
                    Id = 5,
                    Name = "Sneakers",
                    ProductTypeId = 1,
                    Description = "Wow-Wow-Wow, great description :)"
                },
                new Catalog
                {
                    Id = 6,
                    Name = "Laptop",
                    ProductTypeId = 2,
                    Description = "Wow-Wow-Wow, great description :)"
                },
                new Catalog
                {
                    Id = 7,
                    Name = "Apple Iphone 12",
                    ProductTypeId = 2,
                    Description = "Wow-Wow-Wow, great description :)"
                }
                );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType
                {
                    Id = 1,
                    Name = "Clothing"
                },

                new ProductType
                {
                    Id = 2,
                    Name = "Electronics"
                },

                new ProductType
                {
                    Id = 3,
                    Name = "Furniture"
                },

                new ProductType
                {
                    Id = 4,
                    Name = "Books"
                });
        }
    }
}