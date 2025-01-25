using Mission3;

namespace FoodBankInventorySystem
{
    public static class Program
    {
        public static void Run()
        {
            List<FoodItem> foodItems = new List<FoodItem>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nFood Bank Inventory System");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFoodItem(foodItems);
                        break;
                    case "2":
                        DeleteFoodItem(foodItems);
                        break;
                    case "3":
                        PrintFoodItems(foodItems);
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFoodItem(List<FoodItem> foodItems)
        {
            Console.Write("Enter food name: ");
            string name = Console.ReadLine();

            Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
            string category = Console.ReadLine();

            int quantity;
            while (true)
            {
                Console.Write("Enter quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
            }

            DateTime expirationDate;
            while (true)
            {
                Console.Write("Enter expiration date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out expirationDate) && expirationDate > DateTime.Now)
                {
                    break;
                }
                Console.WriteLine("Invalid date. Please enter a valid future date.");
            }

            FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
            foodItems.Add(newItem);

            Console.WriteLine("Food item added successfully.");
        }

        static void DeleteFoodItem(List<FoodItem> foodItems)
        {
            if (foodItems.Count == 0)
            {
                Console.WriteLine("No food items to delete.");
                return;
            }

            PrintFoodItems(foodItems);

            int index;
            while (true)
            {
                Console.Write("Enter the number of the item to delete: ");
                if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= foodItems.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }

            foodItems.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully.");
        }

        static void PrintFoodItems(List<FoodItem> foodItems)
        {
            if (foodItems.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items:");
            for (int i = 0; i < foodItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {foodItems[i]}");
            }
        }
    }
}
