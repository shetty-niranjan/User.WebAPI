using System.ComponentModel.DataAnnotations;

namespace User.API.Models
{
    public class UsersRequestDto
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MonthlySalary { get; set; }
        [Range(1, int.MaxValue)]
        public int MonthlyExpenses { get; set; }
    }
}
