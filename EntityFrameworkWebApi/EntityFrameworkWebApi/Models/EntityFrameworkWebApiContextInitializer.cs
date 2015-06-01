using System.Collections.Generic;
using System.Data.Entity;

namespace EntityFrameworkWebApi.Models
{
    public class EntityFrameworkWebApiContextInitializer : DropCreateDatabaseAlways<EntityFrameworkWebApiContext>
    {
        protected override void Seed(EntityFrameworkWebApiContext context)
        {
            var books = new List<Book>
            {
                new Book() {Name = "War and Peace", Author = "Tolstoy", Price = 19.95m},
                new Book() {Name = "Bla", Author = "Ble", Price = 20.95m},
                new Book() {Name = "Hehe", Author = "Sacre", Price = 17.95m}

            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}