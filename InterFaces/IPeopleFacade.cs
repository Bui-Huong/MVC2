using System.Collections.Generic;
using System.Data;
using MVC2.Enums;
using MVC2.Models;

namespace MVC2.InterFaces
{
    public interface IPeopleFacade
    {
        List<PersonModel> GetPeopleByGender(Gender gender);

        PersonModel GetOldestPerson();

        List<string> GetFullName();

        List<PersonModel> GetPeopleByBirthYear(int year);

        List<PersonModel> GetPeopleByBirthYearGreater(int year);

        List<PersonModel> GetPeopleByBirthYearLess(int year);

        List<PersonModel> GetAllPeople();

        DataTable GetDataTable();

        PersonModel GetPerson(uint id);

        void AddPerson(PersonModel model);

        void EditPerson(PersonModel model);

        void DeletePerson(PersonModel model);
    }
}