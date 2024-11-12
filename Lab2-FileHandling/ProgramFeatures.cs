using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace Lab2_FileHandling
{
    public static class ProgramFeatures
    {
        public static string ConvertDataToCsv(string rawContent)
        {
            string csvData = string.Empty;
            int counter = 1;

            foreach (string record in rawContent.Split(";"))
            {
                string[] geoPoints = record.Split(",");

                if (geoPoints.Length > 2)
                {
                    csvData += $"{geoPoints[0]},{geoPoints[1]},{geoPoints[2]},\n";
                }
                else
                {
                    csvData += $"Location{counter},{geoPoints[0]},{geoPoints[1]},\n";
                    counter++;
                }
            }

            return csvData;
        }

        public static string ConvertDatatoJson(string rawData)
        {
            return string.Empty;
        }

        public static List<Contact> ReadContactsFromFile(string rawData)
        {
            string[] cleanData = rawData.Split([" ", "\t", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries);

            List<Contact> contacts = new List<Contact>();
            int counter = 0;
            string name = string.Empty;
            string number = string.Empty;
            string id = string.Empty;

            foreach (var item in cleanData)
            {
                if (counter == 3 && number.Length == 14)
                {
                    contacts.Add(new Contact(id, name, number));
                    counter = 0;
                }

                if (item.StartsWith("+"))
                {
                    number = item;
                    counter++;
                    continue;
                }

                if (char.IsDigit(item[0]))
                {
                    if (item.Length > 3)
                    {
                        id = item;
                        counter++;
                        continue;
                    }
                    else
                    {
                        number += $" {item}";
                        continue;
                    }
                }
                else
                {
                    name = item;
                    counter++;
                    continue;
                }
            }

            return contacts;
        }

        public static void SaveContactsAsXml(List<Contact> contacts)
        {
            XmlDocument document = new XmlDocument();

            XmlNode rootElement = document.CreateElement("contacts");

            foreach (var item in contacts)
            {
                XmlElement nameTag = document.CreateElement("name");
                nameTag.InnerText = item.Name;

                XmlElement numberTag = document.CreateElement("number");
                numberTag.InnerText = item.Number;

                XmlElement contactNode = document.CreateElement("contact");
                contactNode.SetAttribute("id", item.Id);

                contactNode.AppendChild(nameTag);
                contactNode.AppendChild(numberTag);

                rootElement.AppendChild(contactNode);
            }

            document.AppendChild(rootElement);

            document.Save("../contacts.xml");
        }

        public static List<Contact> getExactContact(string identifier, List<Contact> contacts)
        {
            List<Contact> filteredContacts;

            if (char.IsDigit(identifier[0]))
            {
                filteredContacts = contacts.FindAll(contact => contact.Id.Equals(identifier));

                if (filteredContacts.Count == 0)
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    return filteredContacts;
                }
            }
            else
            {
                filteredContacts = contacts.FindAll(contact => contact.Name.ToLower().Equals(identifier.ToLower()));

                if (filteredContacts.Count == 0)
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    return filteredContacts;
                }
            }
        }
    }
}
