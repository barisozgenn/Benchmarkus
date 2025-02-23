namespace Common.Models
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
    /// <summary>
    /// Represents a person with various personal details.
    /// </summary>
    public class PersonDto
    {
        public int Id { get; set; } // Unique identifier
        public string FirstName { get; set; } = string.Empty; // First name
        public string LastName { get; set; } = string.Empty; // Last name
        public DateTime BirthDate { get; set; } // Date of birth
        public string Email { get; set; } = string.Empty; // Email address
        public List<Address> Addresses { get; set; } = new List<Address>(); // List of addresses
    }
    /// <summary>
    /// BaseDtoClass Represents a person with various personal details.
    /// </summary>
    public class BaseDtoClass
    {

        public int Id { get; init; } // Unique identifier
        public DateTime CreatedDate { get; set; }
    }
    /// <summary>
    /// BaseDtoAbstractClass Represents a person with various personal details.
    /// </summary>
    public abstract class BaseDtoAbstractClass
    {

        public int Id { get; init; } // Unique identifier
        public DateTime CreatedDate { get; set; }
    }
    /// <summary>
    /// BaseDtoRecord Represents a person with various personal details.
    /// </summary>
    public record BaseDtoRecord
    {

        public int Id { get; init; } // Unique identifier
        public DateTime CreatedDate { get; init; }
    }
    /// <summary>
    /// Represents a person with various personal details.
    /// </summary>
    public class PersonDtoWithBaseClass : BaseDtoClass
    {
        public string FirstName { get; set; } = string.Empty; // First name
        public string LastName { get; set; } = string.Empty; // Last name
        public DateTime BirthDate { get; set; } // Date of birth
        public string Email { get; set; } = string.Empty; // Email address
    }
    /// <summary>
    /// Represents a person with various personal details.
    /// </summary>
    public class PersonDtoWithBaseAbstractClass : BaseDtoAbstractClass
    {
        public string FirstName { get; set; } = string.Empty; // First name
        public string LastName { get; set; } = string.Empty; // Last name
        public DateTime BirthDate { get; set; } // Date of birth
        public string Email { get; set; } = string.Empty; // Email address
    }
    /// <summary>
    /// Represents a person with various personal details.
    /// </summary>
    public record PersonDtoWithBaseRecord : BaseDtoRecord
    {
        public string FirstName { get; init; } = string.Empty; // First name
        public string LastName { get; init; } = string.Empty; // Last name
        public DateTime BirthDate { get; init; } // Date of birth
        public string Email { get; init; } = string.Empty; // Email address
    }
}