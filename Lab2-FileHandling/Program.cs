using System.Runtime.InteropServices;
using System.Text.Json;

namespace Lab2_FileHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
