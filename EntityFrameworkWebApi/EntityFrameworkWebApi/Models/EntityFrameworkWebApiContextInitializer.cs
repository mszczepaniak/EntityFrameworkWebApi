using System;
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

            var order = new Order() {Customer = "John Doe", OrderDate = new DateTime(2014,7,10)};

            var details = new List<OrderDetail>()
            {
                new OrderDetail() {Book = books[0], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[2], Quantity = 2, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 3, Order = order}
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            order = new Order() {Customer = "Joe Smith", OrderDate = new DateTime(2014, 9, 18)};
            details = new List<OrderDetail>()
            {
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[3], Quantity = 12, Order = order},
                new OrderDetail() {Book = books[4], Quantity = 3, Order = order}
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}