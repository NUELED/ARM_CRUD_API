using System.Text.Json.Serialization;

namespace ARM_CRUD_API.Common.DTO
{
    public class StaffDTO
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
