using System.ComponentModel.DataAnnotations;

namespace Bread.Data.Models
{
    public class Voucher
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }
    }
}
