using System.ComponentModel.DataAnnotations;

namespace bulkyweb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Masx length is 10") ]
        public string Name { get; set; }
        [Required]
        public string DisplayOrder { get; set; }

    }
}
