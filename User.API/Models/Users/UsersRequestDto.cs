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
        public int MonthlySalary { get; set; }

        public int MonthlyExpenses { get; set; }
    }
}
