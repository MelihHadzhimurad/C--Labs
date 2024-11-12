using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
