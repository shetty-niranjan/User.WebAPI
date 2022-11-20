using System;

namespace User.API.Models
{
    public class UsersResponseDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int MonthlySalary { get; set; }
        public int? MonthlyExpenses { get; set; }
    }
}
