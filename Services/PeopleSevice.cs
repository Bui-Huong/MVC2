using System;
using System.Collections.Generic;
using System.Linq;
using MVC2.DB;
using MVC2.Entities;
using MVC2.InterFaces;
using MVC2.Models;

namespace MVC2.Services
{
    public class PeopleSevice : IPeopleService
    {
        public void OpenCon()
        {
            PeopleDB.Instance.Connected = true;
        }
        public void CloseCon()
        {
            PeopleDB.Instance.Connected = false;
        }

        public Dictionary<uint, Person> Read()
        {
            OpenCon();
            Dictionary<uint, Person> result = PeopleDB.Instance.PeopleDic;
            CloseCon();
            return result;
        }

        public Person Get(uint id)
        {
            Dictionary<uint, Person> list = Read();
            if (list.Keys.Contains(id))
                return list[id];
            return null;
        }

        public void Create(PersonModel model)
        {
            Person newPerson = (Person)model;
            Dictionary<uint, Person> list = Read();
            uint nextID = list.Keys.Max();
            list[nextID] = newPerson;
            OpenCon();
            PeopleDB.Instance.PeopleDic = list;
            CloseCon();
        }

        public bool Update(uint id, PersonModel model)
        {
            Person newPerson = (Person)model;
            Dictionary<uint, Person> list = Read();
            if (!list.Keys.Contains(id))
                return false;
            list[id] = newPerson;
            OpenCon();
            PeopleDB.Instance.PeopleDic = list;
            CloseCon();
            return true;
        }

        public bool Delete(uint id)
        {
            Dictionary<uint, Person> list = Read();
            if (!list.Keys.Contains(id))
                return false;
            list.Remove(id);
            OpenCon();
            PeopleDB.Instance.PeopleDic = list;
            CloseCon();
            return true;
        }
    }
}