using System.ComponentModel.DataAnnotations;

namespace MovieBasmala.Dtos.NationalityDtos
{
    public class NationalityDto
    {
        [Required]
        public string NationalityName { get; set; }
    }
}
