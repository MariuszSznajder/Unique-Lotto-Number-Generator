using LottoGenerator.DataReader;
using LottoGenerator.RandomNumberModel;
using LottoGenerator.TxtFileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGenerator.StartApplication
{
    internal class Start
    {
        private static readonly string path = "http://www.mbnet.com.pl/dl.txt";

        private static readonly string saveFilePath = Directory.GetCurrentDirectory() + "\\lotto.txt";

        private static readonly SortedSet<int> uniqueLottoNumber = NumberGenerator.GetRundomNumber(6, 49);

        private static readonly string resultString = string.Join(",", uniqueLottoNumber);


        public static void Run()
        {
            FileDownloader.GetTXTData(path, saveFilePath);

            List<Model> models = Model.ReadFile(saveFilePath);


            bool foundNumber = true;

            foreach (Model model in models)
            {
                List<string> numbers = model.Numbers;

                foreach (string number in numbers)
                {
                    if (number.Equals(resultString, StringComparison.Ordinal))
                    {
                        Console.WriteLine($"Your number was drawn on: {model.DateTime} Number: {number}");
                        foundNumber = false;
                        break;
                    }
                }

                if (!foundNumber)
                {
                    break;
                }
            }

            if (foundNumber)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Unique lotto number: {resultString}");
                Console.ResetColor();
            }


        }
    }
}
