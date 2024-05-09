using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ARM_CRUD_API.Entities
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }    
        public string FirstName { get; set; }    
        public string LastName { get; set; }    
        public string Group { get; set; } 
        public string Position { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
