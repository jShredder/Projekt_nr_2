using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject2
{
    class Books1
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string Availability { get; set; }
        public string State { get; set; }
        public string Category { get; set; }

        public Books1(string t, string author, string year, string p, string amount, string availability, string s, string c)
        {
            Title = t;
            this.Author = author;
            this.Year = year;
            State = s;
            Category = c;
            Price = p;
            this.Amount = amount;
            this.Availability = availability;
        }
    }
}
