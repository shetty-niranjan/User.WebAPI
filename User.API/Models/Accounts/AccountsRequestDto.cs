using User.API.Models;

namespace User.API.Models
{
    public class AccountsRequestDto : UsersRequestDto
    {
        public string AccountName { get; set; }
    }
}
