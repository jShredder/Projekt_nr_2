using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject2
{
    abstract class XMLReading
    {
        protected bool isTitle = false, isAuthor = false, isYear = false, isPrice = false, isAmount = false,
            isAvailability = false, isState = false, isCategory = false, isIssue = false;
        protected string title = null, author = null, year = null, state = null, category = null, availability = null,
            amount = null, issue = null, price = null;

        abstract public void readXMLFile(string URLadress);
    }
}
