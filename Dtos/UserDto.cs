using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionCodeAPI.Dtos
{
    public class UserDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }


        [Required]
        [MaxLength(15)]
        public string Password { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
