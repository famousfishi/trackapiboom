using System.ComponentModel.DataAnnotations;

namespace trackapiboom.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required please")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
