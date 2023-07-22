using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGenerator.DataReader
{
    internal class FileDownloader
    {
        private static HttpClient client = new HttpClient();

        public static string GetTXTData(string url, string fileName)
        {
            string result = string.Empty;
            try
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        result = content.ReadAsStringAsync().Result;
                        using (StreamWriter writer = File.AppendText(fileName))
                        { 
                                writer.WriteLine(result.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
