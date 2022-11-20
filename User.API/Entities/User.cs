using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int MonthlySalary { get; set; }
        public int? MonthlyExpenses { get; set; }
    }
}

