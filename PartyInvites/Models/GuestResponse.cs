using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Nickname is required!")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Fancy mail is required!")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage="Please enter a valid fancy email!")]
        public string Fancymail { get; set; }

        [Required(ErrorMessage = "Favourite animal is required!")]
        public string FavouriteAnimal { get; set; }

        [Required(ErrorMessage = "Please, specify whether you would be there! :) ")]
        public bool? WillAttend { get; set; }
    }
}
