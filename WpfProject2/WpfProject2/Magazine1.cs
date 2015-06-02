using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject2
{
    class Magazine1
    {
        public string Title { get; set; }
        public string Issue { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string Availability { get; set; }

        public Magazine1(string t, string i, string s, string c, string p, string amount, string availability)
        {
            Title = t;
            Issue = i;
            State = s;
            Category = c;
            Price = p;
            this.Amount = amount;
            this.Availability = availability;
        }
    }
}
