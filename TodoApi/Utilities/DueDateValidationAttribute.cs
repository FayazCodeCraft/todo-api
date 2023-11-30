using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TodoApi.Utilities
{
    /// <summary>
    /// Validates that a due date is in the future and follows the format YYYY-MM-DD.
    /// </summary>
    public class DueDateValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates the due date.
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="validationContext">The validation context</param>
        /// <returns>Sucess if validation is correct,otherwise throw error</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string dateString = (string) value;

            if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
            {
                if (dueDate > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Due date must be in the future");
                }
            }

            return new ValidationResult("Due_date should be in the format YYYY-MM-DD");
        }
    }
}
