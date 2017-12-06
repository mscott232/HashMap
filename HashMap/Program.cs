/**
* Program – Main class
*
* <pre>
*
* Assignment: #4
* Course: ADEV-3001
* Date Created: November 27, 2017
* 
* Revision Log
* Who        When       Reason
* --------- ---------- ----------------------------------
*
* </pre>
*
* @author Matt Scott
* @version 1.0
*/

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

            // Load lines from Item data into hash mao
            foreach(string line in lines)
            {
                string[] lineSplit = line.Split(',');
                StringKey key = new StringKey(lineSplit[0].Trim());
                Item value = new Item(lineSplit[0].Trim(), int.Parse(lineSplit[1].Trim()), double.Parse(lineSplit[2].Trim()));

                hashMap.Put(key, value);
            }            

            // Remove items that have 0 gold pieces
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

            // Iterate through each list item and perform different actions
            for(int i = 0; i < loot.Length; i++)
            {
                bool found = false;
                bool capacity = false;

                foreach(StringKey key in hashMap.Keys())
                {
                    // Determine if the loot items exists in the hash map
                    if(loot[i].Equals(key.ToString()))
                    {
                        found = true;
                        Item foundItem = hashMap.Get(key);  

                        // Determine if it is possible to add the item to your backpack otherwise print out that you're unable to and raise the capacity flag
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

                // If item wasn't found in the hash map print out that it wasn't found
                if(!found)
                {
                    Console.WriteLine("You find an unknown item that is not in your loot table, you leave it alone. " + loot[i]);
                }

                if(capacity)
                {
                    int total = 0;

                    Console.WriteLine("You must sell the following items:");

                    // Iterate through items list, calculate and duplicate items and print out contents
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
