using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.DLL
{
    public class Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string UIN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public byte[] Wrapper { get; set; }
        public Bitmap WrapperImage
        {
            get
            {
                if (Wrapper != null)
                {
                    return (Bitmap)Image.FromStream(new MemoryStream(Wrapper));
                }
                else
                {
                    return new Bitmap(1,1);
                }
            }
        }

        public byte[] Content { get; set; }
        public int CountPages { get; set; }
        public int Year { get; set; }
        public string ManuFacture { get; set; }
        public string Categoty { get; set; }
        public string Disciples { get; set; }

        public List<BookOnReader> Ticket { get; set; } = new List<BookOnReader>();
        public List<Storage> InStorage { get; set; } = new List<Storage>();
        public override string ToString()
        {
            return $"Книга '{Title}', Автор:{Author}, Год:{Year}";
        }
    }
    public class Storage
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public override string ToString()
        {
            return $"Книга '{Book.Title}', Кол-во:{Count}, На дату:{Date}";
        }
    }
    public class BookReader
    {
        public int ID { get; set;}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public string DateRegistration { get; set; }
        public string Type { get; set; }
        public BookTicket Ticket { get; set; }

    }
    public class BookTicket
    {
        public int ID { get; set; }
        public DateTime DateRegistration { get; set; }
        public BookReader Reader { get; set; }
        public DateTime DateUnRegistration { get; set; }
        public List<BookOnReader> Books { get; set; } = new List<BookOnReader>();

    }
    public class BookOnReader
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public BookTicket Ticket { get; set; }
        public DateTime DateBegin { get; set; } = DateTime.Now;
        public DateTime DateEnd { get; set; }
        public bool IsExpired { get; set; } = false;
        public decimal Peny { get; set; }=0.0m;



    }
}

