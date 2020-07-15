using System.ComponentModel.DataAnnotations;

namespace Bread.Data.Models
{
    public class City : BreadDataModel
    {
        [Required]
        public string Name { get; set; }
    }
}
