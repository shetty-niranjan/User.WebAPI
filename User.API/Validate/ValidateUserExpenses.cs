using Microsoft.VisualBasic;
using User.API.Entities;
using User.API.Helpers;
using User.API.Models;

namespace User.API.Validate
{
    public class ValidateUserExpenses : IValidate<UsersResponseDto, string>
    {
        public string Validate(UsersResponseDto userResponse)
        {
            if (userResponse.MonthlyExpenses < ApplicationConstants.MinExpense)
                return $"Cannot create an account for less than {ApplicationConstants.MinExpense} amount";
            return string.Empty;
        }
    }
}
