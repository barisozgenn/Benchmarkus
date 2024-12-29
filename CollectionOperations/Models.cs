using System;

namespace CollectionOperations;
    /// <summary>
    /// Data Transfer Object (DTO) for Person, used for mapping purposes.
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
    /// Data Transfer Object (DTO) for Person, used for mapping purposes.
    /// </summary>
    public class PersonDto
    {
        public int Id { get; set; } // Unique identifier
        public string? FirstName { get; set; } // First name
        public string? LastName { get; set; } // Last name
        public DateTime BirthDate { get; set; } // Date of birth
        public string? Email { get; set; } // Email address
        public List<Address>? Addresses { get; set; } // List of addresses
    }
    /// <summary>
    /// Represents an address associated with a person.
    /// </summary>
    public class Address
    {
        public int Id { get; set; } // Unique identifier
        public string PersonId { get; set; } // Identifier of the associated person
        public string Country { get; set; } = default!; // Country name
        public string City { get; set; } = default!; // City name
    }