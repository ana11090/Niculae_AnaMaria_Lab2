using Microsoft.EntityFrameworkCore;
using Niculae_AnaMaria_Lab2.Models;

namespace Niculae_AnaMaria_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new
           LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>()))
            {
                //if (context.Books.Any())
                //{
                //    return; // BD a fost creata anterior
                //}
                //context.Books.AddRange(
                //new Book
                //{
                //    Title = "Baltagul",
                //    Author = "Mihail Sadoveanu",Price=Decimal.Parse("22")},

                //new Book
                //{
                //    Title = "Enigma Otiliei",
                //    Author = "George  Calinescu",Price=Decimal.Parse("18")},

                //new Book
                //{
                //    Title = "Maytrei",
                //    Author = "Mircea Eliade",Price=Decimal.Parse("27")}

                //);


                //context.Customers.AddRange(
                //new Customer
                //{
                //    Name = "Popescu Marcela",
                //    Adress = "Str. Plopilor, nr. 24",
                //    BirthDate = DateTime.Parse("1979-09-01")
                //},
                //new Customer
                //{
                //    Name = "Mihailescu Cornel",
                //    Adress = "Str. Bucuresti, nr. 45, ap. 2",BirthDate=DateTime.Parse("1969 - 07 - 08")}

                //);

                //context.SaveChanges();

                // Check if books or customers already exist in the database
                if (!context.Books.Any())
                {
                    // Add authors to the Author table
                    var authorMihailSadoveanu = new Author { FirstName = "Mihail", LastName = "Sadoveanu" };
                    var authorGeorgeCalinescu = new Author { FirstName = "George", LastName = "Calinescu" };
                    var authorMirceaEliade = new Author { FirstName = "Mircea", LastName = "Eliade" };

                    context.Authors.AddRange(authorMihailSadoveanu, authorGeorgeCalinescu, authorMirceaEliade);

                    context.SaveChanges(); // Save changes to generate Author IDs

                    // Add books with valid AuthorIDs
                    context.Books.AddRange(
                        new Book { Title = "Baltagul", AuthorID = authorMihailSadoveanu.ID, Price = Decimal.Parse("22") },
                        new Book { Title = "Enigma Otiliei", AuthorID = authorGeorgeCalinescu.ID, Price = Decimal.Parse("18") },
                        new Book { Title = "Maytrei", AuthorID = authorMirceaEliade.ID, Price = Decimal.Parse("27") }
                    );

                    // Add customers
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Popescu Marcela",
                            Adress = "Str. Plopilor, nr. 24",
                            BirthDate = DateTime.Parse("1979-09-01")
                        },
                        new Customer
                        {
                            Name = "Mihailescu Cornel",
                            Adress = "Str. Bucuresti, nr. 45, ap. 2",
                            BirthDate = DateTime.Parse("1969-07-08")
                        }
                    );

                    context.SaveChanges(); // Save changes to add books and customers
                }

            }
        }
    }
}
