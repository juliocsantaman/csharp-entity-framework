using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(150)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int CategorySize { get; set; }

        [JsonIgnore]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
