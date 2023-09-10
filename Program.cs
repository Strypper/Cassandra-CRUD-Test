namespace CassandraExample;

class Program
{
    static void Main(string[] args)
    {
        CRUD crud = new();

        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. GetAll");
            Console.WriteLine("2. GetAnimalById");
            Console.WriteLine("3. AddAnimal");
            Console.WriteLine("4. DeleteAnimalById");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    crud.FindAll();
                    break;
                case "2":
                    Console.Write("Enter the Animal Id: ");
                    string animalId = Console.ReadLine()!;
                    var animal = crud.FindAnimalById(animalId!);
                    // Implement logic to get animal by Id (you can add this to your CRUD class)
                    // Example: crud.GetAnimalById(animalId);
                    break;
                case "3":
                    crud.AddAnimal(
                            4.5,
                            "Friendly cat",
                            "breed789",
                            DateTimeOffset.UtcNow,
                            new DateTimeOffset(2018, 5, 10, 0, 0, 0, TimeSpan.Zero),
                            false,
                            DateTimeOffset.UtcNow,
                            "Whiskers",
                            "avatar999",
                            "gray",
                            "54321");
                    break;
                case "4":
                    Console.Write("Enter the Animal Id to delete: ");
                    string idToDelete = Console.ReadLine();
                    crud.DeleteAnimalById(idToDelete!);
                    break;
                case "5":
                    Console.WriteLine("Exiting the program.");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    break;
            }
        }
    }
}
