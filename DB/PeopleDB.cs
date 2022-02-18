using System;
using System.Collections.Generic;
using MVC2.Entities;
using MVC2.Enums;

namespace MVC2.DB
{
    public class PeopleDB
    {
        private static PeopleDB _instance;
        public static PeopleDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PeopleDB();
                }
                return _instance;
            }
        }
        private Dictionary<uint, Person> _people;
        public PeopleDB()
        {
            Initialize();
        }
        private void Initialize()
        {
            Connected = false;
            _people = new Dictionary<uint, Person>()
            {
                    {1, new Person("Bui", "Huong", Gender.Male, "03/08/2000", "0338559513")},
                    {2, new Person("Nguyen", "Thanh Loc", Gender.Male, "20/09/2000", "0966416123")},
                    {3, new Person("Do", "Ngoc Anh", Gender.Male, "01/01/1994", "0962828299", "Ha Noi", true)},
                    {4, new Person("Pham", "Duc Loc", Gender.Male, "01/01/1999", "0343428821")},
                    {5, new Person("Pham", "Thanh Long", Gender.Male, "01/01/2000", "0944531628", "Ha Noi")},
                    {6, new Person("Chu Ky", "Giang Son", Gender.Male, "01/01/1998", "0963164813")},
                    {7, new Person("Lai", "Quoc Long", Gender.Male, "01/01/1997", "0354505588")},
                    {8, new Person("Pham","Duc Tien",Gender.Male,"01/01/1998", "0963164813")},
                    {9, new Person("Do","Tien Thanh",Gender.Male,"01/01/2000", "0585032360")},
                    {10, new Person("Do","Hong Son",Gender.Male,"01/01/2000", "0975378309")},
                    {11, new Person("Vu","Quang Hiep",Gender.Male,"01/01/2000", "0964910360")},
                    {12, new Person("Vu","Minh Duc",Gender.Male,"01/01/2000", "0395429489")},
                    {13, new Person("Nguyen","Duc Huy",Gender.Male,"01/01/1996", "0925206686")},
                    {14, new Person("Pham","Dinh Quan",Gender.Male,"01/01/2000", "0326894875")},
                    {15, new Person("Nguyen","Tuan Nghia",Gender.Male,"01/01/2000", "0866626802")},
                    {16, new Person("Nguyen","Thanh Nam",Gender.Male,"01/01/2001", "0965510506")},
                    {17, new Person("Nguyen","Nam Phuong",Gender.Female,"01/01/2001", "0943746666")},
                    {18, new Person("Ta","Phi Hung",Gender.Female,"01/01/2000", "0368133069")},
                    {19, new Person("Dao","Tan Dung",Gender.Female,"01/01/2000", "0968442865")},
                    {20, new Person("Tran","Chi Thanh",Gender.Female,"01/01/2000", "0376959875")},
                    {21, new Person("Nguyen","Manh Cuong",Gender.Male,"01/01/1999", "0981226250")},
                    {22, new Person("Nguyen","Hung Son",Gender.Male,"01/01/1999", "0965976864")},
                    {23, new Person("Le","Duc Manh",Gender.Male,"01/01/2001", "0869269948")},
                    {24, new Person("Nguyen","Quang Huy",Gender.Male,"01/01/1992", "0842140392")},
                    {25, new Person("Leu","Duy Tan",Gender.None,"01/01/1996", "0922110996")},
                    {26, new Person("Do","Van Thai",Gender.None,"01/01/2001", "0989479615")},
                    {27, new Person("Bui","Chi Huong",Gender.Male,"01/01/2000", "0338559513")},
                    {28, new Person("Vu","Trung Kien",Gender.None,"01/01/1996", "0947681357")},
                    {29, new Person("Dao","Tuan Phong",Gender.Male,"01/01/2000", "0963199204")},
                    {30, new Person("Nguyen","Thai Hoc",Gender.Male,"01/01/1999", "0862916198")},
                    {31, new Person("Dao","Quy Vuong",Gender.Male,"01/01/2000", "0335878777")},
                    {32, new Person("Pham","Tran Duy",Gender.Male,"01/01/1999", "0946301025")},
                    {33, new Person("Le","Trung Nghia",Gender.Male,"01/01/2000", "0946696302")},
                    {34, new Person("Phuong","Viet Hoang",Gender.None,"01/01/1999", "0702028599")},
                    {35, new Person("Nguyen","Tien Truong",Gender.Male,"01/01/2000", "0968034684")},
                    {36, new Person("Nguyen","Van A",Gender.None,"01/01/1845")}
            };
        }
        public Dictionary<uint, Person> PeopleDic
        {
            get
            {
                if (Connected)
                    return _people;
                else
                    throw new Exception("Connection not established with PeopleDB");
            }
            set
            {
                if (Connected)
                    _people = value;
                else
                    throw new Exception("Connection not established with PeopleDB");

            }
        }
        public bool Connected { get; set; }
    }
}