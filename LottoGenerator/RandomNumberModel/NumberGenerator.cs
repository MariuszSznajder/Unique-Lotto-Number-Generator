using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGenerator.RandomNumberModel
{
    internal class NumberGenerator
    {
        public int Count { get; set; }
        public int MaxNumber { get; set; }

        public NumberGenerator(int count, int maxNumber)
        {
            Count = count;
            MaxNumber = maxNumber;
        }

        public static SortedSet<int> GetRundomNumber(int count, int MaxNumber)
        {
            
            Random random = new Random();
            SortedSet<int> result = new SortedSet<int>();


            while (result.Count < count)
            {
                int rnd = random.Next(1, MaxNumber);
                result.Add(rnd);

            }
            return result;
        }

    }
}
