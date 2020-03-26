using System;
using System.Collections.Generic;

namespace modularzation_activity
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryList = new List<string>(){"Nuts", "Fish", "Lentils", "Whole Grains", "Beans", "Olive Oil", "Eggs", "Yogurt"};
            int choice = 0;


            while(choice != 4){
                choice = programOptions();
                if(choice == 1){
                    ListGroceries(groceryList);
                }else if(choice == 2){
                    groceryList.Add(AddGroceryItem());
                }else if(choice == 3){
                    groceryList.Remove(RemoveGroceryItem(groceryList));
                }else if(choice == 4){
                    endProgram();
                }else{
                    Console.WriteLine("Please choose a valid option.\n");
                    
                    Console.Write("press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        public static int programOptions(){
            System.Console.WriteLine("Choose an option:");
            System.Console.WriteLine("[1] View Current Grocery List");
            System.Console.WriteLine("[2] Add Item to Grocery List");
            System.Console.WriteLine("[3] Remove Item to Grocery List");
            System.Console.WriteLine("[4] End Program\n");
            
            int choice = Convert.ToInt16(Console.ReadLine());
            
            return choice;
        }
        public static void ListGroceries(List<string> groceryList){
            Console.WriteLine("Your current grocery list: ");
            foreach(string groceryItem in groceryList){
                Console.WriteLine($"\t -{groceryItem}");
            }
            Console.Write("\npress any key to continue...");
            Console.ReadKey();
        }
        public static string AddGroceryItem(){
            Console.Write("Enter an item you wish to add: ");
            string groceryItem = Console.ReadLine();
            Console.WriteLine($"You added {groceryItem} to your grocery list");

            
            Console.Write("\npress any key to continue...");
            Console.ReadKey();

            return groceryItem;
        }
        public static string RemoveGroceryItem(List<string> groceryList){
            Console.Write("Enter an item you wish to remove: ");
            string groceryItem = Console.ReadLine();
            if(!groceryList.Contains(groceryItem)){
                Console.WriteLine("\nThe item you selected does not exsist\n");
                return RemoveGroceryItem(groceryList);
            }else{
                Console.WriteLine($"You removed {groceryItem} to your grocery list");
                
                Console.Write("\npress any key to continue...");
                Console.ReadKey();

                return groceryItem;
            }
        }
        public static void endProgram(){
            Console.WriteLine("The program has ended");
        }
    }
}
