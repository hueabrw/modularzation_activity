/*

    Author: Abe Huerta
    Description: An inclass activity for CWEB1112. It's focus is to interate through an array and to modify that array.

    NOTICE: 
        Hey Chris, I went a little over the requirements for this activity. I hope you don't mind. I just wanted to practice my programming skills.

*/
using System;
using System.Collections.Generic;

namespace modularzation_activity
{
    class Program
    {
        //This is the global array
        //I made it a List from System.Collections.Generic because Lists are a bit easier to work with than arrays in c#
        public struct GroceryItem{
            public string name;
            public double price;
        
            public GroceryItem(string _name, double _price){
                name = _name;
                price = _price;
            }
        }

        public static List<GroceryItem> groceryList = new List<GroceryItem>(){new GroceryItem("Nuts",0.75), 
                                                                            new GroceryItem("Fish",3.00), 
                                                                            new GroceryItem("Lentils", 2.00),
                                                                            new GroceryItem("Whole Grains",1.00), 
                                                                            new GroceryItem("Beans",1.75), 
                                                                            new GroceryItem("Olive Oil", 7.49), 
                                                                            new GroceryItem("Eggs",4.00), 
                                                                            new GroceryItem("Yogurt",1.29)};
        
        //Main method with flow control
        static void Main(string[] args)
        {
            ConsoleKey choice = 0;
            while(choice != ConsoleKey.D5){
                choice = programOptions();
                if(choice == ConsoleKey.D1){
                    listGroceries();
                }else if(choice == ConsoleKey.D2){
                    addGroceryItem();
                }else if(choice == ConsoleKey.D3){
                    removeGroceryItem();
                }else if(choice == ConsoleKey.D4){
                    getItemPrice();
                }else if(choice == ConsoleKey.D5){
                    endProgram();
                }else{
                    Console.WriteLine("Please choose a valid option.\n");
                    
                    Console.Write("press any key to continue...");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
        //Method that presents users with the option menu
        public static ConsoleKey programOptions(){
            System.Console.WriteLine("Choose an option:");
            System.Console.WriteLine("[1] View Current Grocery List");
            System.Console.WriteLine("[2] Add Item to Grocery List");
            System.Console.WriteLine("[3] Remove Item to Grocery List");
            System.Console.WriteLine("[4] Get price of item");
            System.Console.WriteLine("[5] End Program\n");
            
            ConsoleKey choice = Console.ReadKey().Key;
            Console.Clear();
            
            return choice;
        }
        //Method that lists all current groceries in the groceryList
        public static void listGroceries(){
            Console.WriteLine("Your current grocery list: ");
            foreach(GroceryItem groceryItem in groceryList){
                Console.WriteLine($"\t -{groceryItem.name}");
            }
            Console.Write("\npress any key to continue...");
            Console.ReadKey();
        }
        //Method to add an item to the groceryList
        public static void addGroceryItem(){
            Console.Write("Enter an item you wish to add: ");
            string itemName = Console.ReadLine();
            Console.Write("Enter the price of the item: $");
            double itemPrice = Convert.ToDouble(Console.ReadLine());

            GroceryItem newItem = new GroceryItem(itemName, itemPrice);

            groceryList.Add(newItem);

            Console.WriteLine($"You added {newItem.name} to your grocery list for the price of {newItem.price.ToString("c")}");

            
            Console.Write("\npress any key to continue...");
            Console.ReadKey();


        }
        //Method that removes an item to the groceryList
        public static void removeGroceryItem(){
            Console.Write("Enter an item you wish to remove (type \"cancel\" to go back to menu): ");
            string itemName = Console.ReadLine();

            if(itemName.ToLower() == "cancel"){
                return;
            }

            foreach(GroceryItem item in groceryList){
                if(item.name == itemName){
                    Console.WriteLine($"You removed {itemName} to your grocery list");
                    
                    Console.Write("\npress any key to continue...");
                    Console.ReadKey();
                    groceryList.Remove(item);

                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("\nThe item you selected does not exsist\n");
            removeGroceryItem();
        }
        //Gets the price for the item that is selected
        public static void getItemPrice(){
            Console.Write("Enter an item to see it's price: ");
            string itemName = Console.ReadLine();

            foreach(GroceryItem item in groceryList){
                if(item.name.ToUpper() == itemName.ToUpper()){
                    Console.WriteLine($"The price for {item.name} is {item.price.ToString("c")}");
                    
                    Console.Write("\npress any key to continue...");
                    Console.ReadKey();

                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("\nThe item you selected does not exsist\n");
            getItemPrice();
        }
        //The ending method
        public static void endProgram(){
            Console.WriteLine("The program has ended");
        }
    }
}
