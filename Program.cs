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
            Console.WriteLine("5. UpdateAnimalById");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    crud.FindAll();
                    break;
                case "2":
                    Console.Write("Enter the Animal Id: ");
                    string animalId = Console.ReadLine()!;
                    var animal = crud.FindAnimalById(animalId!);
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
                    string idToDelete = Console.ReadLine()!;
                    crud.DeleteAnimalById(idToDelete!);
                    break;
                case "5":
                    Console.Write("Enter the Animal Id: ");
                    string animalIdForUpdate = Console.ReadLine()!;
                    var animalForUpdate = crud.FindAnimalById(animalIdForUpdate!);
                    if (animalForUpdate != null)
                    {
                        double newAge = animalForUpdate.Age.HasValue ? (double)animalForUpdate.Age + 1 : 0.0;
                        string newBio = animalForUpdate.Bio + " Updated !!";
                        string newBreedId = animalForUpdate.BreedId!;
                        bool newGender = animalForUpdate.Gender;
                        DateTime newLastUpdatedOn = DateTime.Now;
                        string newName = animalForUpdate.Name + " Updated !!";
                        string newPetAvatarId = animalForUpdate.PetAvatarId + " Updated !!";
                        string newPetColors = animalForUpdate.PetColors + " Updated !!";
                        string newSixDigitCode = animalForUpdate.SixDigitCode + " Updated !!";

                        crud.UpdateAnimalById(animalIdForUpdate!, newAge, newBio, newBreedId, animalForUpdate.DateOfBirth, newGender, newLastUpdatedOn, newName, newPetAvatarId, newPetColors, newSixDigitCode);
                        Console.WriteLine("Animal updated successfully!");
                    }
                    return;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    break;
            }
        }
    }
}
