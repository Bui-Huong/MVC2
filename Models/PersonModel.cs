using System;
using MVC2.Entities;
using MVC2.Enums;

namespace MVC2.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Gender = "";
            DateOfBirth = "";
            Age = "";
            PhoneNumber = "";
            BirthPlace = "";
            IsGraduated = "";
        }
        public uint Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string Age { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public string IsGraduated { get; set; }
        public static explicit operator Person(PersonModel model)
        {
            Gender genderEnum = Enums.Gender.None;
            Enum.TryParse(model.Gender, out genderEnum);
            Person person = new Person(
                model.FirstName,
                model.LastName,
                genderEnum,
                model.DateOfBirth,
                model.PhoneNumber,
                model.BirthPlace,
                model.IsGraduated == "Yes"
            );
            return person;
        }
    }
}