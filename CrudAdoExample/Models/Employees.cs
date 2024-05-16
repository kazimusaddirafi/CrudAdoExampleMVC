using System.ComponentModel.DataAnnotations;

namespace CrudAdoExample.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool Is_Active { get; set; }
    }
}
