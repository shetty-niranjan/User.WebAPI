using System;
using System.ComponentModel.DataAnnotations;

namespace User.API.Entities

{
    public class Users
    {
        [Required]

        [Key]
        public Guid UserId { get; set; }
        [MaxLength(100)]
        [Required]

        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string EmailAddress { get; set; }
        [Range(1, int.MaxValue)]

        public int MonthlySalary { get; set; }
        [Range(1, int.MaxValue)]
        public int? MonthlyExpenses { get; set; }
    }
}

