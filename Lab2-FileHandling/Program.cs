using System.Runtime.InteropServices;
using System.Text.Json;

namespace Lab2_FileHandling
{
    public class Program
    {
        struct GeoLocation
        {
            public float Lat { get; set; }
            public float Lng { get; set; }
        }

        static void Main(string[] args)
        {
            string rawContent = File.ReadAllText("../input-01.txt");

            List<GeoLocation> locations = new List<GeoLocation>();

            foreach (string record in rawContent.Split(";"))
            {
                string[] geoPoints = record.Split(",");

                locations.Add
                (
                    new GeoLocation
                    {
                        Lat = float.Parse(geoPoints[0], System.Globalization.CultureInfo.InvariantCulture),
                        Lng = float.Parse(geoPoints[1], System.Globalization.CultureInfo.InvariantCulture)
                    }
                );
            }

            File.WriteAllText("../jsonContent.txt", JsonSerializer.Serialize(locations));
        }
    }
}
