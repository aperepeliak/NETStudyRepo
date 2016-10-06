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

using System.Xml;

namespace LoopXMLdoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string booksFile = @"D:\Study\NETStudyRepo\XML-and-JSON\books.xml";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLoop_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(booksFile);
            textBlockResults.Text = FormatText(document.DocumentElement as XmlNode, "", "");
        }

        private string FormatText(XmlNode node, string text, string indent)
        {
            if (node is XmlText)
            {
                text += node.Value;
                return text;
            }
            if (string.IsNullOrEmpty(indent))
            {
                indent = "";
            }
            else
            {
                text += "\r\n" + indent;
            }
            if (node is XmlComment)
            {
                text += node.OuterXml;
                return text;
            }

            text += "<" + node.Name;

            if (node.Attributes.Count > 0)
            {
                AddAttributes(node, ref text);
            }
            if (node.HasChildNodes)
            {
                text += ">";
                foreach (XmlNode child in node.ChildNodes)
                {
                    text = FormatText(child, text, indent + "  ");
                }

                if (node.ChildNodes.Count == 1 &&
                    (node.FirstChild is XmlText || node.FirstChild is XmlComment))
                {
                    text += "</" + node.Name + ">";
                }
                else
                {
                    text += "\r\n" + indent + "</" + node.Name + ">";
                }
            }
            else
            {
                text += " />";
            }
            return text;
        }

        private void AddAttributes(XmlNode node, ref string text)
        {
            foreach (XmlAttribute atr in node.Attributes)
            {
                text += " " + atr.Name + "='" + atr.Value + "'";
            }
        }

        private void buttonCreateNode_Click(object sender, RoutedEventArgs e)
        {
            // Load the xml document
            XmlDocument document = new XmlDocument();
            document.Load(booksFile);

            // Get the root element
            XmlElement root = document.DocumentElement;

            // Create new nodes
            XmlElement newBook = document.CreateElement("book");
            XmlElement newTitle = document.CreateElement("title");
            XmlElement newAuthor = document.CreateElement("Author");
            XmlElement newCode = document.CreateElement("code");

            XmlText title = document.CreateTextNode("Learning Angular");
            XmlText author = document.CreateTextNode("John Peterson");
            XmlText code = document.CreateTextNode("1123234");
            XmlComment comment = document.CreateComment("New book");

            //Insert elements
            newBook.AppendChild(comment);
            newBook.AppendChild(newTitle);
            newBook.AppendChild(newAuthor);
            newBook.AppendChild(newCode);

            newTitle.AppendChild(title);
            newAuthor.AppendChild(author);
            newCode.AppendChild(code);

            root.InsertAfter(newBook, root.LastChild);

            document.Save(booksFile);
        }

        private void buttonDeleteNode_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(booksFile);

            XmlElement root = document.DocumentElement;

            if (root.HasChildNodes)
            {
                XmlNode book = root.LastChild;
                root.RemoveChild(book);

                document.Save(booksFile);
            }
        }
    }
}
