namespace CassandraExample;
public class Animal 
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Bio { get; set; } = string.Empty;
    public string? PetColors { get; set; } = string.Empty;
    public string? SixDigitCode { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public double? Age { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string? BreedId { get; set; }
    public string? PetAvatarId { get; set; }
}
