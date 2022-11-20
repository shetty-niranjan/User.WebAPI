using User.API.Models;

namespace User.API.Validate
{
    public class ValidateUserEmailAddress : IValidate<bool, string>
    {
        public ValidateUserEmailAddress() { }
        public string Validate(bool isEmail)
        {
            if (isEmail)
                return $"User with EmailAddress already exist";
            return string.Empty;
        }
    }
}
