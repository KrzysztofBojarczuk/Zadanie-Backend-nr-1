using Zadanie_Backend_nr_1.Model;

namespace Zadanie_Backend_nr_1
{
    public class PersonService : IPersonService
    {
        private readonly IDataValidationService _validationService;
        private readonly List<Person> _persons;

        public PersonService(IDataValidationService validationService, List<Person> persons)
        {
            _validationService = validationService;
            _persons = persons;
        }

        public void Create(Person person, List<Person> persons)
        {
            var validationResult = _validationService.ValidatePersonData(person, persons);

            switch (validationResult)
            {
                case ValidationStatus.InvalidBirthDate:
                    throw new ArgumentException("Invalid date of birth.");

                case ValidationStatus.InvalidId:
                    throw new ArgumentException("Invalid identifier Id.");

                case ValidationStatus.EmptyString:
                    throw new ArgumentException("Empty field in personal data.");

                case ValidationStatus.IdAlreadyExists:
                    throw new ArgumentException("Id already exists.");

                case ValidationStatus.Valid:
                    _persons.Add(person);
                    break;

                default:
                    throw new ArgumentException("Invalid personal data.");
            }
        }
    }

    public interface IPersonService
    {
        void Create(Person person, List<Person> persons);
    }
}
