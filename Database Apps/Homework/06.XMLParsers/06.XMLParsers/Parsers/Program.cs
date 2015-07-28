using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Parsers
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Problem 2.DOM Parser: Extract Album Names
            GetAllAlbumsDOM();
            Console.WriteLine();
            //// Problem 3.DOM Parser: Extract All Artists Alphabetically
            GetAllArtistsAlphabeticallyDOM();
            Console.WriteLine();
            //// Problem 4.DOM Parser: Extract Artists and Number of Albums
            GetAllArtistsAndAlbumsDOM();
            Console.WriteLine();
            //// Problem 5.XPath: Extract Artists and Number of Albums
            GetAllArtistsAndAlbumsXPath();
            Console.WriteLine();
            //// Problem 6.DOM Parser: Delete Albums
            DeleteAllOverAPriceDOM(20);
            Console.WriteLine();
            //// Problem 7.DOM Parser and XPath: Old Albums
            //// The parameters shows how many years back from now
            OldAlbumsXPath(5);
            Console.WriteLine();
            //// Problem 8.LINQ to XML: Old Albums
            // The parameters shows how many years back from now
            OldAlbumsLinq(5);
        }

        private static void GetAllAlbumsDOM()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");


            var rootNode = doc.DocumentElement;
            foreach (XmlNode child in rootNode.ChildNodes)
            {
                if (child["name"] != null)
                {
                    Console.WriteLine("Album name: {0}", child["name"].InnerText);
                }
            }
        }

        private static void GetAllArtistsAlphabeticallyDOM()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            SortedSet<string> artists = new SortedSet<string>();

            var rootNode = doc.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                if (child["artist"] != null)
                {
                    artists.Add(child["artist"].InnerText);
                }
            }

            Console.WriteLine("Artists:");
            Console.WriteLine(string.Join(Environment.NewLine, artists));
        }


        private static void GetAllArtistsAndAlbumsDOM()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();

            var rootNode = doc.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                var artist = child["artist"];

                if (artist != null)
                {
                    if (!artistsAndAlbums.ContainsKey(artist.InnerText))
                    {
                        artistsAndAlbums.Add(artist.InnerText, 1);
                        continue;
                    }
                    artistsAndAlbums[artist.InnerText] += 1;
                }
            }

            Console.WriteLine("Artists with DOM:");
            Console.WriteLine(string.Join(Environment.NewLine, artistsAndAlbums.OrderBy(x => x.Value)));
        }

        private static void GetAllArtistsAndAlbumsXPath()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();

            string xPathArtist = "catalog/album/artist";

            XmlNodeList artists = doc.SelectNodes(xPathArtist);

            foreach (XmlNode artist in artists)
            {
                if (!artistsAndAlbums.ContainsKey(artist.InnerText))
                {
                    artistsAndAlbums.Add(artist.InnerText, 1);
                    continue;
                }
                artistsAndAlbums[artist.InnerText] += 1;
            }
            Console.WriteLine("Artists with XPath:");
            Console.WriteLine(string.Join(Environment.NewLine, artistsAndAlbums.OrderBy(x => x.Value)));
        }

        private static void DeleteAllOverAPriceDOM(int maxPrice)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlDocument newDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = newDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root node
            var rootNode = doc.DocumentElement;
            XmlElement rootElement = newDoc.CreateElement(rootNode.Name);
            newDoc.AppendChild(rootElement);

            // Add the xml declaration
            newDoc.InsertBefore(xmlDeclaration, newDoc.DocumentElement);

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                var price = child["price"];
                if (price != null && decimal.Parse(price.InnerText) < maxPrice)
                {
                    rootElement.AppendChild(newDoc.ImportNode(child, true));
                }
            }

            newDoc.Save("../../../cheap-albums.xml");
            Console.WriteLine("Document saved.");
        }


        private static void OldAlbumsXPath(int years)
        {
            Console.WriteLine("Old Albums XPath");
            var doc = XDocument.Load("../../../catalog.xml");

            string xPathAlbums = "catalog/album";

            var albums = doc.XPathSelectElements(xPathAlbums);


            foreach (var album in albums)
            {
                var name = album.Element("name");

                if (name != null)
                {
                    var year = album.Element("year");
                    if (year != null)
                    {
                        if (int.Parse(year.Value) < DateTime.Now.AddYears(years * -1).Year)
                        {
                            var price = album.Element("price");
                            if (price != null)
                            {
                                Console.WriteLine("Album: {0}, Price: {1}", name.Value, price.Value);
                            }
                        }
                    }
                }
            }
        }

        private static void OldAlbumsLinq(int years)
        {
            Console.WriteLine("Old Albums Linq");
            var doc = XDocument.Load("../../../catalog.xml");

            var yearToCompare = DateTime.Now.AddYears(years * -1).Year;

            var albums1 = doc.Descendants("album")
                .Where(x => x.Element("year") != null && int.Parse(x.Element("year").Value) < yearToCompare)
                .Select(x=>new
                {
                    Album = x.Element("name")!=null?x.Element("name").Value:"N/A",
                    Price = x.Element("price") != null ? x.Element("price").Value : "N/A",

                });

            Console.WriteLine(string.Join(Environment.NewLine, albums1));

        }
    }
}
