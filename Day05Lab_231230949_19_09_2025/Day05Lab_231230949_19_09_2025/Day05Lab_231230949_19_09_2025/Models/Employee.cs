using System.ComponentModel.DataAnnotations;

namespace Day05Lab_231230949_19_09_2025.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public string Status { get; set; }
    }
}
