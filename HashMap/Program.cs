using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = File.ReadAllLines(@"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 4\ItemData.txt");

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5);

            foreach(string line in lines)
            {
                string[] lineSplit = line.Split(',');
                StringKey key = new StringKey(lineSplit[0].Trim());
                Item value = new Item(lineSplit[0].Trim(), int.Parse(lineSplit[1].Trim()), double.Parse(lineSplit[2].Trim()));

                hashMap.Put(key, value);
            }
        }
    }
}
