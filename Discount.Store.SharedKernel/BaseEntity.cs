using System.ComponentModel.DataAnnotations;

namespace Discount.Store.SharedKernel
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}