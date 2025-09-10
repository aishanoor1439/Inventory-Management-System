using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_SIZE = 100;
            string[] inventory = new string[MAX_SIZE];
            int itemCount = 0;

            bool running = true;

            while (running) {
                Console.WriteLine("\n===== Inventory Management System =====");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Search Item");
                Console.WriteLine("4. Display Inventory");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (itemCount < MAX_SIZE)
                        {
                            Console.WriteLine("Enter item name to add: ");
                            string newItem = Console.ReadLine();

                            inventory[itemCount] = newItem;
                            itemCount++;
                            Console.WriteLine($"'{newItem}' added to inventory.");
                        }
                        else
                        {
                            Console.WriteLine("Inventory is full! Cannot add more items.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter item name to remove: ");
                        string removeItem = Console.ReadLine();
                        bool found = false;

                        for (int i = 0; i < itemCount; i++)
                        {
                            if (inventory[i].Equals(removeItem, StringComparison.OrdinalIgnoreCase))
                            {
                                for (int j = i; j < itemCount; j++)
                                {
                                    inventory[j] = inventory[j + 1];
                                }
                                itemCount--;
                                inventory[itemCount] = null;
                                Console.WriteLine($"'{removeItem}' removed from inventory.");
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            Console.WriteLine($"'{removeItem}' not found in inventory.");
                        break;

                    case "3":
                        Console.WriteLine("Enter item name to searcch: ");
                        string searchItem = Console.ReadLine();
                        bool exists = false;

                        for (int i = 0; i < itemCount; i++)
                        {
                            if (inventory[i].Equals(searchItem, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"'{searchItem}' is present in inventory.");
                                exists = true;
                                break;
                            }
                        }
                        if (!exists)
                            Console.WriteLine($"'{searchItem}' is not in inventory.");
                        break;

                    case "4":
                        Console.WriteLine("\n--- Current Inventory ---");
                        if (itemCount == 0)
                            Console.WriteLine("Inventory is empty.");
                        else
                        {
                            for (int i = 0; i < itemCount; i++)
                            {
                                Console.WriteLine($"{i + 1}. {inventory[i]}");
                            }
                        }
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Exiting program... Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter 1-5.");
                        break;

                }
            }
        }
    }
}