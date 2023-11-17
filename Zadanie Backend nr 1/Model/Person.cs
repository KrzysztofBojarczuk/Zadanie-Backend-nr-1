using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Zadanie_Backend_nr_1.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }
        public string Adresss { get; set; }
    }
}
