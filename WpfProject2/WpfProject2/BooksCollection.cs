using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Xml;

namespace WpfProject2
{
    class BooksCollection
    {
        Collection<Books1> booksList1 = new Collection<Books1>();
        public Collection<Books1> booksList2 { get { return booksList1; } }

        public BooksCollection()
        {
            XmlTextReader reader = new XmlTextReader("http://ojp.cba.pl/Books.xml");
            bool isTitle = false, isAuthor = false, isYear=false, isPrice = false, isAmount = false, isAvailability = false, isState = false, isCategory = false;
            string title = null, author = null, year = null, state = null, category = null, availability = null, amount = null, price = null;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //textbox1.Text+="<" + reader.Name;
                        switch (reader.Name)
                        {
                            case "tltle":
                                isTitle = true;
                                isAuthor = false; isYear=false; isPrice = false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "author":
                                isAuthor = true;
                                isTitle = false; isYear=false; isPrice = false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "year":
                                isYear = true;
                                isTitle = false; isAuthor=false; isPrice = false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "price":
                                isPrice = true;
                                isTitle = false; isAuthor = false; isYear=false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "amount":
                                isAmount = true;
                                isTitle = false; isAuthor = false; isYear=false; isPrice = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "availability":
                                isAvailability = true;
                                isTitle = false; isAuthor = false; isYear=false; isPrice = false; isAmount = false; isState = false; isCategory = false;
                                break;
                            case "state":
                                isState = true;
                                isTitle = false; isAuthor = false; isYear=false; isPrice = false; isAmount = false; isAvailability = false; isCategory = false;
                                break;
                            case "category":
                                isCategory = true;
                                isTitle = false; isAuthor = false; isYear=false; isPrice = false; isAmount = false; isAvailability = false; isState = false;
                                break;
                        }
                        while (reader.MoveToNextAttribute()) ; // Read the attributes.
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        if (isTitle)
                        {
                            title = reader.Value;
                        }
                        else if (isAuthor)
                        {
                            author = reader.Value;
                        }
                        else if (isYear)
                        {
                            year = reader.Value;
                        }
                        else if (isPrice)
                        {
                            price = reader.Value;
                        }
                        else if (isAmount)
                        {
                            amount = reader.Value;
                        }
                        else if (isAvailability)
                        {
                            availability = reader.Value;
                        }
                        else if (isState)
                        {
                            state = reader.Value;
                        }
                        else if (isCategory)
                        {
                            category = reader.Value;
                        }
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        break;
                }

                if (title != null && author != null && year != null && state != null && category != null && availability != null && amount != null && price != null)
                {
                    booksList1.Add(new Books1(title, author, year, state, category, price, amount, availability));
                    title = null; author = null; year = null; state = null; category = null; price = null; amount = null; availability = null;
                }
            }
        }
    }
}
