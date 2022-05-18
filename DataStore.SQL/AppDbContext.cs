using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataStore.SQL
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"),b => b.MigrationsAssembly("WebApp"));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany<Product>(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                .HasMany<Comment>(p => p.Comments)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Customer>()
                .HasMany<Order>(p => p.Orders)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<Brand>()
                .HasMany<Product>(p => p.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);
            modelBuilder.Entity<Order>()
                .HasMany<OrderItems>(p => p.OrderItems)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<OrderItems>()
                .HasOne<Product>(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Comment>()
                .HasOne<Customer>(p => p.Customer)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.CustomerId);

            //Seeding Fake Data for test purpose

            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = new Guid("60d70416-906c-4c1c-8f5e-a0183bf6cada"), Name = "Mountain Bike", Description = "This bike is designed with excellent braking systems and shock-absorbing features that can easily handle serious bumps, rocks, dirt trails, roots and ruts." },
                    new Category { CategoryId = new Guid("e3980339-1e2e-49b2-acd4-bc80d245e446"), Name = "Road Bike", Description = "Road bikes are best identified by their drop or turned-down handlebars and skinny tires." },
                    new Category { CategoryId = new Guid("0bfb6c1a-af0c-4a14-848f-f6912a10e2ab"), Name = "Electric Bike", Description = "These bikes include an electric motor which you can charge by plugging it into a regular outlet.  When you peddle, the electric motor provides an assist so that you go faster and hills are made easier." }
                );
            modelBuilder.Entity<Brand>().HasData(
                    new Brand { BrandId = new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), Name = "Trek" },
                    new Brand { BrandId = new Guid("92f6361a-04ed-4bde-a4ac-84aba9b1f7ca"), Name = "Connondale" }
                );
            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), CategoryId = new Guid("60d70416-906c-4c1c-8f5e-a0183bf6cada"), BrandId = new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), Name = "Rail 9.9 XX1 AXS", Quantity = 100, Size = "L", Color = "Marigold to Red Fade", ModelYear = 2015, Price = 13799.99 },
                    new Product { ProductId = new Guid("3a8e9167-a66a-4b19-88f7-8c6ed0821229"), CategoryId = new Guid("60d70416-906c-4c1c-8f5e-a0183bf6cada"), BrandId = new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), Name = "Rail 9.8 XT", Quantity = 200, Size = "M", Color = "Carbon Red", ModelYear = 2022, Price = 9199.99 },
                    new Product { ProductId = new Guid("a3921483-a45e-4cb7-846d-7c28446bf7a6"), CategoryId = new Guid("e3980339-1e2e-49b2-acd4-bc80d245e446"), BrandId = new Guid("92f6361a-04ed-4bde-a4ac-84aba9b1f7ca"), Name = "CAAD Optimo", Quantity = 300, Size = "S", Color = "Candy Red", ModelYear = 2020, Price = 23213 },
                    new Product { ProductId = new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), CategoryId = new Guid("e3980339-1e2e-49b2-acd4-bc80d245e446"), BrandId = new Guid("92f6361a-04ed-4bde-a4ac-84aba9b1f7ca"), Name = "CAAD13 Disc 105", Quantity = 300, Size = "XS", Color = "Stealth Grey", ModelYear = 2018, Price = 18529.99 },
                    new Product { ProductId = new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), CategoryId = new Guid("0bfb6c1a-af0c-4a14-848f-f6912a10e2ab"), BrandId = new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), Name = "E-Caliber 9.9 XTR", Quantity = 300, Size = "XL", Color = "Gloss Alpine Navy Smoke", ModelYear = 2021, Price = 12549.99 }
                );
            modelBuilder.Entity<Customer>().HasData(
                    new Customer { CustomerId = new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), Name = "Eray Berberoglu", City = "Izmir", District = "Buca", Street = "206/5" },
                    new Customer { CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), Name = "Hakan Bisikletman", City = "Ankara", District = "Cankaya", Street = "Sezginler Street" }
                );
            modelBuilder.Entity<Comment>().HasData(
                    new Comment { CommentId = new Guid("eab0705f-b01b-4aaa-9afd-54a5f0d4491e"), ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), CustomerId = new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), ProductComment = "I had a really good experience here, I ordered some parts from the online site. They were at a great price and it said 4 - 8 days for delivery which was longer than I would have liked but for the price I couldn't complain. The parts arrived the next day and were well packaged and as described! What more could you ask for!" },
                    new Comment { CommentId = new Guid("19e3f536-a607-4f49-9cc1-b3929a1c24d2"), ProductId = new Guid("3a8e9167-a66a-4b19-88f7-8c6ed0821229"), CustomerId = new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), ProductComment = "I got a trek mountain track steel framed bike three years ago and put a 49cc 4 stoke motor on it. I did modify the brakes and put a oil shock front fork on it and it's held up awesome, no cracks or weak spots. All my friends have had to reinforce their bikes in less time than I've had mine. I could not ask for better.. ABSOLUTELY LOVE MY TREK !!!!!!!!!" },
                    new Comment { CommentId = new Guid("e7f4fe96-6c87-4769-ac53-bdb08867cfbe"), ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), ProductComment = "My order went wrong however I was extremely happy with how Will dealt with my issue and I wouldn't hesitate to place another order. " },
                    new Comment { CommentId = new Guid("3786ab8a-40dd-4013-8c62-ebe670d8a4ca"), ProductId = new Guid("a3921483-a45e-4cb7-846d-7c28446bf7a6"), CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), ProductComment = "For most of the bikes I test, I feel like they excel at either climbing or descending. However, the Cannondale Trail 6 really shines as a mellow all-rounder… it lands comfortably in the middle as a true generalist." },
                    new Comment { CommentId = new Guid("fbaaf426-db46-4fcb-bbff-52b3d16bcd28"), ProductId = new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), CustomerId = new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), ProductComment = "The Trail 1 is a bike that seems like an excellent choice on which to gain experience… The intermediate step between a beginner’s bike and a more expensive, expert model." },
                    new Comment { CommentId = new Guid("f215ddb7-09eb-4a86-81c2-68a51bd59cec"), ProductId = new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), ProductComment = "Smartform aluminium frame is one of the most comfortable here… Stand-over clearance is at a premium …seat tube is way too tall… Cannondale… if you’re a heavy rider this fork may just be too quick." },
                    new Comment { CommentId = new Guid("ad76f53b-2679-4eda-88e2-98720815839e"), ProductId = new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), ProductComment = "I purchased this bike to use as a commuter bike… to be capable enough to ride MTB trails… after putting 200mi on it in the three months that I’ve owned it, I can say with confidence that this bike fits the bill." },
                    new Comment { CommentId = new Guid("54bd18c7-3668-405a-89fe-5e97020d6b3c"), ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), ProductComment = "For this price, you do get hydros… It’s an SLX shifter. This works so smooth… The bike itself is really light." }
                );
            modelBuilder.Entity<Order>().HasData(
                    new Order { OrderId = new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), CustomerId = new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), OrderDate = new DateTime(2022, 3, 1, 7, 22, 0) },
                    new Order { OrderId = new Guid("db88ba95-54a5-4094-9ade-2402654b7c95"), CustomerId = new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), OrderDate = new DateTime(2021, 8, 11, 9, 0, 0) },
                    new Order { OrderId = new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), CustomerId = new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), OrderDate = new DateTime(2008, 5, 24, 3, 21, 0) }
                );
            modelBuilder.Entity<OrderItems>().HasData(
                    new OrderItems { OrderItemsId = new Guid("e901026d-a174-4f3f-9efd-542c2bb620c5"), OrderId = new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), Quantity = 3 },
                    new OrderItems { OrderItemsId = new Guid("be250e81-d0c2-4379-9c8a-d9f0336404ed"), OrderId = new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), ProductId = new Guid("3a8e9167-a66a-4b19-88f7-8c6ed0821229"), Quantity = 2 },
                    new OrderItems { OrderItemsId = new Guid("ffd9e796-d416-4ab7-8ef2-9957957a5f0d"), OrderId = new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), Quantity = 1 },
                    new OrderItems { OrderItemsId = new Guid("95c21140-b58d-44a5-8d3b-214a90e59b7d"), OrderId = new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), ProductId = new Guid("a3921483-a45e-4cb7-846d-7c28446bf7a6"), Quantity = 5 },
                    new OrderItems { OrderItemsId = new Guid("61c9ace3-9225-4559-b541-45fe7d5f73d8"), OrderId = new Guid("db88ba95-54a5-4094-9ade-2402654b7c95"), ProductId = new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), Quantity = 2 },
                    new OrderItems { OrderItemsId = new Guid("5da55686-5ef1-4906-851e-b206b748f320"), OrderId = new Guid("db88ba95-54a5-4094-9ade-2402654b7c95"), ProductId = new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), Quantity = 7 },
                    new OrderItems { OrderItemsId = new Guid("ee68e4bf-ce6a-4a8a-beb6-7ca35476547a"), OrderId = new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), ProductId = new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), Quantity = 1 },
                    new OrderItems { OrderItemsId = new Guid("2eee2316-a6a7-4cbc-b716-f88197513cbf"), OrderId = new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), ProductId = new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), Quantity = 6 },
                    new OrderItems { OrderItemsId = new Guid("e304535a-5e65-4ec8-80de-adeeadaf55c9"), OrderId = new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), ProductId = new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), Quantity = 4 }
                );
        }
    }
}