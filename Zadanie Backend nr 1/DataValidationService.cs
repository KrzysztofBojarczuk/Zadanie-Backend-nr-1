using System.Globalization;
using Zadanie_Backend_nr_1.Model;

namespace Zadanie_Backend_nr_1
{
    public enum ValidationStatus
    {
        Valid,
        InvalidBirthDate,
        InvalidId,
        EmptyString,
        IdAlreadyExists
    }

    public interface IDataValidationService
    {
        public ValidationStatus ValidatePersonData(Person person, List<Person> persons);
    }

    public class DataValidationService : IDataValidationService
    {
        public ValidationStatus ValidatePersonData(Person person, List<Person> persons)
        {
            if (person.DateBirth > DateTime.Now)
            {
                return ValidationStatus.InvalidBirthDate;
            }

            if (person.Id == 0)
            {
                return ValidationStatus.InvalidId;
            }

            if (persons.Any(p => p.Id == person.Id))
            {
                return ValidationStatus.IdAlreadyExists;
            }

            if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.Adresss))
            {
                return ValidationStatus.EmptyString;
            }
           
            return ValidationStatus.Valid;
        }

    }
}
