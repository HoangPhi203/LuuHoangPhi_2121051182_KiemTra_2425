using System.ComponentModel.DataAnnotations;

namespace Netmvc.Models
{
    public class Demoabc
    {
        [Key]
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}