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

            foreach (StringKey key in hashMap.Keys())
            {
                Item item = hashMap.Get(key);

                if(item != null && item.GetGoldPieces() == 0)
                {
                    hashMap.Remove(key);
                }
            }

            String[] loot = File.ReadAllLines(@"C:\Users\Matt\Documents\School\Term 5\Programming 4\Assignments\Assignment 4\adventureLoot.txt");
            List<Item> items = new List<Item>();
            double weight = 0;

            for(int i = 0; i < loot.Length; i++)
            {
                bool found = false;
                bool capacity = false;

                foreach(StringKey key in hashMap.Keys())
                {
                    if(loot[i].Equals(key.ToString()))
                    {
                        found = true;
                        Item foundItem = hashMap.Get(key);  

                        if((weight + foundItem.GetWeight()) <= 75)
                        {
                            Console.WriteLine("You have picked up a " + loot[i] + "!");                            
                            items.Add(foundItem);
                            weight += foundItem.GetWeight();                        
                        }
                        else
                        {
                            Console.WriteLine("You cannot pick up the " + loot[i] + ", you are already carrying " + weight + "KG and it weights " + foundItem.GetWeight() + "KG.");
                            capacity = true;
                        }
                        
                    }
                }

                if(!found)
                {
                    Console.WriteLine("You find an unknown item that is not in your loot table, you leave it alone. " + loot[i]);
                }

                if(capacity)
                {
                    int total = 0;

                    Console.WriteLine("You must sell the following items:");

                    foreach(Item item in items.ToList())
                    {
                        int itemQuantity = items.Where(x => x.GetName() == item.GetName()).Count();

                        if (itemQuantity > 0)
                        {
                            Console.WriteLine(string.Format("{0} - Quantity: {1} - Subtotal: {2}GP", item.ToString(), itemQuantity, item.GetGoldPieces() * itemQuantity));
                            total += (item.GetGoldPieces() * itemQuantity);
                        }

                        items.RemoveAll(x => x.GetName().Equals(item.GetName()));
                    }

                    Console.WriteLine("Total value of sold items: " + total + "GP");

                    items = new List<Item>();
                }                
            }
            
            Console.ReadKey();
        }
    }
}
