using MovieBasmala.Dtos.NationalityDtos;
using MovieBasmala.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieBasmala.Dtos.DirectorDtos
{
    public class DirectorPostWithNationality
    {
        [Required]
        public string DirectorName { get; set; }
        [Phone(ErrorMessage ="Invalid Phone Number")]
       public string DirectorPhone { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string DirectorEmail { get; set; }
        public NationalityDto Nationalitydto { get; set; }
    }
}
