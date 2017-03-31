using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    public static class Read
    {
        public static int[] ReadFromCSV(string file)
        {
            string[] data = File.ReadAllLines(file);
            //Console.WriteLine(data.Count());
            int[] masForData = new int[data.Count() * data.Count()];
            int count = 0;
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data[i].Split(';').Count(); j++)
                {
                    masForData[count] = Convert.ToInt32(data[i].Split(';')[j]);
                    count++;
                }
            }
            return masForData;
        }
    }
}