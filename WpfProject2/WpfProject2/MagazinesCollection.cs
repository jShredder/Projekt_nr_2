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
    class MagazinesCollection : XMLReading
    {
        Collection<Magazine1> magazinesList1 = new Collection<Magazine1>();
        public Collection<Magazine1> magazinesList2 { get { return magazinesList1; } }

        public MagazinesCollection()
        {
            readXMLFile("http://ojp.cba.pl/Magazines.xml");
        }

        override public void readXMLFile(string URLadress)
        {
            XmlTextReader reader = new XmlTextReader(URLadress);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //textbox1.Text+="<" + reader.Name;
                        switch (reader.Name)
                        {
                            case "title":
                                isTitle = true;
                                isIssue = false; isPrice = false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "issue":
                                isIssue = true;
                                isTitle = false; isPrice = false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "price":
                                isPrice = true;
                                isTitle = false; isIssue = false; isAmount = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "amount":
                                isAmount = true;
                                isTitle = false; isIssue = false; isPrice = false; isAvailability = false; isState = false; isCategory = false;
                                break;
                            case "availability":
                                isAvailability = true;
                                isTitle = false; isIssue = false; isPrice = false; isAmount = false; isState = false; isCategory = false;
                                break;
                            case "state":
                                isState = true;
                                isTitle = false; isIssue = false; isPrice = false; isAmount = false; isAvailability = false; isCategory = false;
                                break;
                            case "category":
                                isCategory = true;
                                isTitle = false; isIssue = false; isPrice = false; isAmount = false; isAvailability = false; isState = false;
                                break;
                        }
                        while (reader.MoveToNextAttribute()) ; // Read the attributes.
                        // textbox1.Text+=" " + reader.Name + "='" + reader.Value + "'";
                        // textbox1.Text += ">";
                        // textbox1.Text += ">";
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        if (isTitle)
                        {
                            // textbox1.Text += "title: " + reader.Value + "\n";
                            title = reader.Value;
                        }
                        else if (isIssue)
                        {
                            //textbox1.Text += "issue: " + reader.Value + "\n";
                            issue = reader.Value;
                        }
                        else if (isPrice)
                        {
                            //textbox1.Text += "price: " + reader.Value + "\n";
                            price = reader.Value;
                        }
                        else if (isAmount)
                        {
                            //textbox1.Text += "amount: " + reader.Value + "\n";
                            amount = reader.Value;
                        }
                        else if (isAvailability)
                        {
                            //textbox1.Text += "availability: " + reader.Value + "\n";
                            availability = reader.Value;
                        }
                        else if (isState)
                        {
                            //textbox1.Text += "state: " + reader.Value + "\n";
                            state = reader.Value;
                        }
                        else if (isCategory)
                        {
                            //textbox1.Text += "category: " + reader.Value + "\n";
                            category = reader.Value;
                        }
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        // textbox1.Text+="</" + reader.Name;
                        //textbox1.Text+=">";
                        break;
                }

                if (title != null && issue != null && state != null && category != null && availability != null && amount != null && price != null)
                {
                    magazinesList1.Add(new Magazine1(title, issue, state, category, price, amount, availability));
                    title = null; issue = null; state = null; category = null; price = null; amount = null; availability = null;
                }
            }
        }
    }
}
