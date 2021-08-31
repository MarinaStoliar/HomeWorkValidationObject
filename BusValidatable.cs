using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ValidationObject
{
    public class BusValidatable : IValidatableObject
    {
        private const int capacity = 40;
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]{1,40}$", ErrorMessage = "Строка должна содержать только английские буквы")]
        public string Name { get; set; }

        [Required]
        [SchoolCapacity(40)]
        [Range(28, 98)]
        public DateTime OperationDate { get; set; }

        public int NumberOfSeats { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Category == Category && NumberOfSeats <= capacity)
            {
                yield return new ValidationResult(
                    $"Школьный автобус не может иметь меньше чем {capacity} мест.",
                    new[] { "NumberOfSeats" });
            }
            if (OperationDate > DateTime.Now)
            {
                yield return new ValidationResult($"Дата регистрации автобуса не должна быть более поздней чем сегодняшняя."
                    new[] { "OperationDate" });
            }
        }
    }
}
