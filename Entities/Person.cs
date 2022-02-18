using MVC2.Enums;
using MVC2.Models;
using MVC2.Utilities;

namespace MVC2.Entities
{
    public class Person
    {
        public Person(string firstName, string lastName, Gender gender, string dob = "", string phone = "", string birthPlace = "", bool isGraduated = false)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dob;
            PhoneNumber = phone;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public bool IsGraduated { get; set; }

        public static explicit operator PersonModel(Person personEntity)
        {
            PersonModel model = new PersonModel()
            {
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Gender = personEntity.Gender.ToString(),
                DateOfBirth = personEntity.DateOfBirth,
                Age = DateAgeUtility.CalAge(personEntity.DateOfBirth).ToString(),
                PhoneNumber = personEntity.PhoneNumber,
                BirthPlace = personEntity.BirthPlace
            };
            model.IsGraduated = personEntity.IsGraduated ? "Yes" : "No";
            return model;
        }
    }
}