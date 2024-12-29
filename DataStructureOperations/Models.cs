namespace DataStructureOperations.Models
{
    /// <summary>
    /// Represents a person with various personal details.
    /// </summary>
    public class Person
    {
        public int Id { get; set; } // Unique identifier
        public string FirstName { get; set; } = string.Empty; // First name
        public string LastName { get; set; } = string.Empty; // Last name
        public DateTime BirthDate { get; set; } // Date of birth
        public string Email { get; set; } = string.Empty; // Email address
        public List<Address> Addresses { get; set; } = new List<Address>(); // List of addresses
    }
    
    /// <summary>
    /// Represents an address associated with a person.
    /// </summary>
    public class Address
    {
        public int Id { get; set; } // Unique identifier
        public string PersonId { get; set; } = string.Empty; // Identifier of the associated person
        public string Country { get; set; } = string.Empty; // Country name
        public string City { get; set; } = string.Empty; // City name
    }
}