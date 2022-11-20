using System;
using User.API.Models;

namespace User.API.Models
{
    public class AccountsResponseDto
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
    }
}
