using Biblioteca.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.BLL
{
    public static class Functions
    {
        public static Book CreateBook(string title, string author, int year)
        {
            return new Book { Title = title, Author = author, Year = year };
        }

        public static Book SetBookOnStorage (Book book, bool minus=false)
        {
            int count = book.InStorage
                .OrderByDescending(s => s.Date)
                .Select(d => d.Count)
                .FirstOrDefault();
            if (minus) count--;
            else count++;


            book.InStorage.Add(new Storage { Book = book, Count = count + 1, Date = DateTime.Now });
            return book;
        }
        public static Book GiveToReader(Book book, BookReader bookReader)
        {
            var ticket = bookReader.Ticket;
            ticket.Books.Add(new BookOnReader { Book = book, Ticket = ticket });
            SetBookOnStorage(book);
            return book;
        }
        public static Book ReturnFromReader(BookOnReader onReader)
        {
            var book = onReader.Book;
            onReader.DateEnd = DateTime.Now;

            SetBookOnStorage(book);
            return book;
        }

        public static BookReader CreateReader (string fName,
            string lName, string pName, DateTime bDate)
        {
            var user = new BookReader
            {
                FirstName = fName,
                LastName = lName,
                Patronymic = pName,
                BirthDay = bDate,
            };
            user.Ticket = new BookTicket { Reader = user };
            return user;
        }

    }

}
