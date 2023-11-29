using System.ComponentModel.DataAnnotations;
using TodoApi.Model;

namespace TodoApi.Tests.ModelTests
{
    public class ModelTests
    {
        [Fact]
        public void Todo_IdValidation_ShouldReturnCorrectErrorMessageForInvalidData()
        {
            // Arrange
            var todo = new Todo
            {
                Id = -1,
                Title = "ValidTitle",
                Description = "ValidDescription",
                DueDate = "2023-12-01",
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);


            // Check specific error messages
            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToList();
            Assert.Contains("Id must be a positive integer", errorMessages);
        }

        [Fact]
        public void Todo_TitleValidation_ShouldReturnCorrectErrorMessageForInvalidData()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "A",
                Description = "ValidDescription",
                DueDate = "2023-12-01"
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);

            // Check specific error messages
            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToList();
            Assert.Contains("Title must be between 5 and 10 characters", errorMessages);
        }

        [Fact]
        public void Todo_DescriptionValidation_ShouldReturnCorrectErrorMessageForInvalidData()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "ValidTitle",
                Description = "TooLongDescription" + new string('a', 190),
                DueDate = "2023-12-01",
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);


            // Check specific error messages
            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToList();
            Assert.Contains("Description must be at most 200 characters long", errorMessages);
        }

        [Fact]
        public void Todo_DueDateValidation_ShouldReturnCorrectErrorMessageForInvalidData()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "ValidTitle",
                Description = "ValidDescription",
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);


            // Check specific error messages
            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToList();
            Assert.Contains("Due date is required", errorMessages);
        }

        [Fact]
        public void Todo_DueDateFormatValidation_ShouldReturnCorrectErrorMessageForInvalidData()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "ValidTitle",
                Description = "ValidDescription",
                DueDate = "abc"
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);

            // Check specific error messages
            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToList();
            Assert.Contains("Due_date should be in the format YYYY-MM-DD", errorMessages);
        }

        [Fact]
        public void Todo_DueDateFutureValidation_ShouldReturnCorrectErrorMessageForInvalidData()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "ValidTitle",
                Description = "ValidDescription",
                DueDate = "2022-10-10"
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);

            // Check specific error messages
            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToList();
            Assert.Contains("Due date must be in the future", errorMessages);

        }

        [Fact]
        public void Todo_AllPropertiesValid_ShouldPassValidation()
        {
            // Arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "ValidTitle",
                Description = "ValidDescription",
                DueDate = "2023-12-01", 
            };

            // Act
            var validationContext = new ValidationContext(todo, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(todo, validationContext, validationResults, validateAllProperties: true);

            // Assert
            Assert.True(isValid, "Validation should pass for valid Todo object");

        }
    }
}
