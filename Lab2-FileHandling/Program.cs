namespace Lab2_FileHandling
{
    public class Program
    {
        static void Main()
        {
            int choice = 0;

            do
            {
                Console.WriteLine("To convert data from txt to csv press - 1\nTo get contacts from txt press - 2\nTo exit the program press - 0");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Make choice, please!");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        break;

                    case 1:
                        string rawContent = File.ReadAllText("../input-01.txt");

                        string csvData = ProgramFeatures.ConvertDataToCsv(rawContent);

                        if (File.Exists("../locationsData.csv"))
                        {
                            File.AppendAllText("../locationsData.csv", csvData);
                        }
                        else
                        {
                            File.WriteAllText("../locationsData.csv", "Name,Latitude,Longtitude,\n" + csvData);
                        }
                        break;

                    case 2:
                        string rawData = File.ReadAllText("../input-02.txt");

                        List<Contact> contacts = ProgramFeatures.ReadContactsFromFile(rawData);

                        foreach (Contact contact in contacts)
                        {
                            Console.WriteLine(contact.ShowDetails());
                        }

                        Console.WriteLine("Do you want to save contacts as XML? (Y/N)");
                        string saveXmlChoice = Console.ReadLine();

                        switch (saveXmlChoice.ToUpper())
                        {
                            case "Y":
                                ProgramFeatures.SaveContactsAsXml(contacts);
                                Console.WriteLine("The data has been saved successfully!");
                                break;

                            case "N":
                                break;

                            default:
                                break;
                        }

                        Console.WriteLine("Do you want to get specific contact? (Y/N)");
                        string serchContactChoice = Console.ReadLine();

                        switch (serchContactChoice.ToUpper())
                        {
                            case "Y":

                                Console.WriteLine("Please enter the field to search for: (Identifier/Name)");
                                string searchKey = Console.ReadLine();

                                try
                                {
                                    foreach (Contact contact in ProgramFeatures.getExactContact(searchKey, contacts))
                                    {
                                        Console.WriteLine(contact.ShowDetails());
                                    }
                                }
                                catch (KeyNotFoundException)
                                {
                                    Console.WriteLine("Contact with specified field has not been found!");
                                }

                                break;

                            case "N":
                                break;

                            default:
                                break;
                        }

                        break;

                    default:
                        Console.WriteLine("Unsupported operation!");
                        break;
                }
            }
            while (choice != 0);

        }
    }
}
