using Cassandra;
using ConsoleTables;
using System.Reflection;

namespace CassandraExample;
public class CRUD
{
    private readonly ISession session;
    public CRUD()
    {
        var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        this.session = cluster.Connect("test_keyspace");
    }
    public void FindAll()
    {
        var rs = session.Execute("SELECT * FROM animal");

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var row in rs)
        {
            var id = row.GetValue<Guid>("id");
            var age = row.GetValue<double>("age");
            var bio = row.GetValue<string>("bio");
            var breedId = row.GetValue<string>("breedid");
            var createdOn = row.GetValue<DateTime>("createdon");
            var dateOfBirth = row.GetValue<DateTime>("dateofbirth");
            var gender = row.GetValue<bool>("gender");
            var lastUpdatedOn = row.GetValue<DateTime>("lastupdatedon");
            var name = row.GetValue<string>("name");
            var petAvatarId = row.GetValue<string>("petavatarid");
            var petColors = row.GetValue<string>("petcolors");
            var sixDigitCode = row.GetValue<string>("sixdigitcode");

            Console.WriteLine("{0,-10} {1,-5} {2,-20} {3,-10} {4,-30} {5,-30} {6,-6} {7,-30} {8,-10} {9,-20} {10,-15} {11,-10}",
                id, age, bio, breedId, createdOn, dateOfBirth, gender, lastUpdatedOn, name, petAvatarId, petColors, sixDigitCode);
        }
        Console.ResetColor();
    }

    public void AddAnimal(
                double age,
                string bio,
                string breedId,
                DateTimeOffset createdOn,
                DateTimeOffset dateOfBirth,
                bool gender,
                DateTimeOffset lastUpdatedOn,
                string name,
                string petAvatarId,
                string petColors,
                string sixDigitCode)
    {
        var insertQuery = session.Prepare(
            "INSERT INTO animal (id, age, bio, breedid, createdon, dateofbirth, gender, lastupdatedon, name, petavatarid, petcolors, sixdigitcode) " +
            "VALUES (uuid(), ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");

        var statement = insertQuery
            .Bind(age, bio, breedId, createdOn, dateOfBirth, gender, lastUpdatedOn, name, petAvatarId, petColors, sixDigitCode);

        session.Execute(statement);
    }

    public Animal FindAnimalById(string id)
    {
        var selectQuery = session.Prepare("SELECT * FROM animal WHERE id = ?");

        var statement = selectQuery.Bind(Guid.Parse(id));

        var rs = session.Execute(statement);

        var row = rs.FirstOrDefault();

        if (row != null)
        {

            Animal animal = new()
            {
                Id = row.GetValue<Guid>("id").ToString(),
                Age = row.GetValue<double>("age"),
                Bio = row.GetValue<string>("bio"),
                BreedId = row.GetValue<string>("breedid"),
                CreatedOn = row.GetValue<DateTime>("createdon"),
                DateOfBirth = row.GetValue<DateTime>("dateofbirth"),
                Gender = row.GetValue<bool>("gender"),
                LastUpdatedOn = row.GetValue<DateTime>("lastupdatedon"),
                Name = row.GetValue<string>("name"),
                PetAvatarId = row.GetValue<string>("petavatarid"),
                PetColors = row.GetValue<string>("petcolors"),
                SixDigitCode = row.GetValue<string>("sixdigitcode")
            };

            Type type = animal.GetType();
            PropertyInfo[] properties = type.GetProperties();
            ConsoleTable table = new("Property", "Value");
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(animal)!;
                table.AddRow(property.Name, value);
            }
            table.Write();
            return animal;
        }
        else
        {
            return null; // Return null if no matching record is found
        }
    }

    public void DeleteAnimalById(string id)
    {
        var deleteQuery = session.Prepare("DELETE FROM animal WHERE id = ?");

        var statement = deleteQuery.Bind(Guid.Parse(id));

        session.Execute(statement);
    }
}