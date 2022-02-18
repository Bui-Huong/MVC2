using System.Collections.Generic;
using MVC2.Entities;
using MVC2.Models;

namespace MVC2.InterFaces
{
    public interface IPeopleService
    {
        void OpenCon();

        void CloseCon();

        Dictionary<uint, Person> Read();

        Person Get(uint id);

        void Create(PersonModel model);

        bool Update(uint id, PersonModel model);

        bool Delete(uint id);
    }
}