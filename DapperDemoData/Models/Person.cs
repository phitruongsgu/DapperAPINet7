using System.ComponentModel.DataAnnotations;

namespace DapperDemoData.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
