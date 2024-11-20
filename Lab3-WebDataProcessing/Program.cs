using HtmlAgilityPack;

namespace Lab3_WebDataProcessing
{
    public class Program
    {
        static void Main()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                                            "AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            int choice;

            do
            {
                Console.WriteLine("To check for country by Internet protocol adress, press 1\nTo get time and date of specific caountry and city, press 2");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Enter the IP adress: ");
                        string adress = Console.ReadLine();

                        string response = client.GetAsync("https://ipapi.co/" + adress + "/country/").Result.Content.ReadAsStringAsync().Result;

                        Console.WriteLine(response);
                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the Country:");
                        string country = Console.ReadLine();

                        Console.WriteLine("Enter the name of city:");
                        string city = Console.ReadLine();

                        string responseContent = client.GetAsync("https://www.timeanddate.com/worldclock/" + country + "/" + city)
                                                 .Result.Content.ReadAsStringAsync().Result;

                        HtmlDocument html = new HtmlDocument();
                        html.LoadHtml(responseContent);

                        var time = html.DocumentNode.SelectSingleNode("//*[@id=\"ct\"]").InnerText;
                        var date = html.DocumentNode.SelectSingleNode("//*[@id=\"ctdat\"]").InnerText;

                        Console.WriteLine($"Time in {city}, {country}: {time} - {date}");
                        break;
                    default:
                        break;
                }
            } while (choice != 0);


        }
    }
}