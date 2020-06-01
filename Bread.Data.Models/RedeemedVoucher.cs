using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class RedeemedVoucher
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int VoucherId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(VoucherId))]
        public Voucher Voucher { get; set; }
    }
}
