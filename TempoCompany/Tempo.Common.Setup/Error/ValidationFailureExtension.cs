using FluentValidation.Results;

namespace Tempo.Common.Setup.Error
{
    /// <summary>
    /// This is used to convert objects into a list
    /// </summary>
    public static class ValidationFailureExtension
    {
        public static IList<CustomValidationFailure> ToCustomValidationFailure(this IList<ValidationFailure> failures)
        {
            return failures.Select(f => new CustomValidationFailure(f.PropertyName, f.ErrorMessage)).ToList();
        }
        public static IList<CustomValidationFailure> ToDictionaryValidationFailure(this ICollection<string[]> failures)
        {
            return failures.Select(f => new CustomValidationFailure("Propried", f.FirstOrDefault(""))).ToList();
        }
    }
}
