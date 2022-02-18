using MVC2.Enums;
using MVC2.Entities;
using MVC2.Utilities;
using MVC2.Models;
using System.Data;
using MVC2.InterFaces;

namespace MVC2.Facades
{
    public class PeopleFacade : IPeopleFacade
    {
        IPeopleService _service;

        public PeopleFacade()
        {
            _service = new PeopleService();
        }
        public List<string> GetFullName()
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<Person> members = memberDic.Values.ToList();
            List<string> result = new List<string>();
            members.ForEach(member => result.Add(member.FirstName + " " + member.LastName));
            return result;
        }

        public PersonModel GetOldestPerson()
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<Person> members = memberDic.Values.ToList();
            uint maxAge = members.Max(member =>
            {
                return DateAgeUtility.CalAge(member.DateOfBirth);
            });
            return (PersonModel)(members.FirstOrDefault(member => DateAgeUtility.CalAge(member.DateOfBirth) == maxAge));
        }

        public List<PersonModel> GetPeopleByBirthYear(int year)
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<Person> members = memberDic.Values.ToList();
            List<Person> peopleByBirthYear = members.Where(member => DateAgeUtility.ParseDate(member.DateOfBirth).Year == year).ToList();
            return peopleByBirthYear.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetPeopleByBirthYearGreater(int year)
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<Person> members = memberDic.Values.ToList();
            List<Person> peopleByBirthYearGreater = members.Where(member => DateAgeUtility.ParseDate(member.DateOfBirth).Year > year).ToList();
            return peopleByBirthYearGreater.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetPeopleByBirthYearLess(int year)
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<Person> members = memberDic.Values.ToList();
            List<Person> peopleByBirthYearLess = members.Where(member => DateAgeUtility.ParseDate(member.DateOfBirth).Year < year).ToList();
            return peopleByBirthYearLess.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetPeopleByGender(Gender gender)
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<Person> members = memberDic.Values.ToList();
            List<Person> peopleByGender = members.Where(member => member.Gender == gender).ToList();
            return peopleByGender.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetAllPeople()
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<PersonModel> members = new List<PersonModel>();
            foreach (var pair in memberDic)
            {
                PersonModel temp = (PersonModel)pair.Value;
                temp.Id = pair.Key;
                members.Add(temp);
            }
            return members;
        }

        public DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[7] {
                new DataColumn("FirstName"),
                new DataColumn("LastName"),
                new DataColumn("Gender"),
                new DataColumn("DOB"),
                new DataColumn("Phone"),
                new DataColumn("BirthPlace"),
                new DataColumn("IsGraduated")
            });
            foreach (PersonModel person in GetAllPeople())
            {
                table.Rows.Add(person.FirstName, person.LastName, person.Gender, person.DateOfBirth, person.PhoneNumber, person.BirthPlace, person.IsGraduated);
            }

            return table;
        }

        public PersonModel GetPerson(uint id)
        {
            return (PersonModel)_service.Get(id);
        }

        public void AddPerson(PersonModel model)
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            if (!memberDic.Keys.Contains(model.Id))
            {
                _service.Create(model);
            }
        }

        public void EditPerson(PersonModel model)
        {
            _service.Update(model.Id, model);
        }

        public void DeletePerson(PersonModel model)
        {
            _service.Delete(model.Id);
        }
    }
}