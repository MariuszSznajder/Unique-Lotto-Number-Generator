using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGenerator.TxtFileModel
{
    internal class Model
    {
        public int OrderNumber { get; set; }
        public DateTime DateTime { get; set; }
        public List<string> Numbers { get; set; }

        public static List<Model> ReadFile(string path)
        {
            List<Model> models = new List<Model>();

            using (StreamReader reader = new StreamReader(path))
            {
                string file;
                while ((file = reader.ReadLine()) != null)
                {
                    Model model = new Model();
                    string[] lines = file.Replace(' ', '|').Split(new char[] { '|' });

                    model.OrderNumber = int.Parse(lines[0].Trim('.'));
                    model.DateTime = DateTime.ParseExact(lines[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    var numbers = lines[2].Split("");

                    model.Numbers = new List<string>();

                    foreach (var number in numbers)
                    {
                        model.Numbers.Add(number);
                    }

                    models.Add(model);
                }
            }

            return models;
        }



        public override string ToString() 
        {
            return string.Format("Order Number: {0}, Date Time: {1}, Number: {2}", OrderNumber, DateTime, Numbers);
        }

    }
}
