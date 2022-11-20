using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.API.Entities
{
    public class Accounts
    {
        [Key]
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        [ForeignKey("Users")]

        public Guid UserId { get; set; }
      
        public Users Users { get; set; }

    }
}
