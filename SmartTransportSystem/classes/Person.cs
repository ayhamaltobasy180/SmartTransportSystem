
using SmartTransportSystem.classes.SmartTransportSystem.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person() { }
        public Person(int id = 0, string name = null, string email = null, string phone = "")
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }
        public abstract void DisplayInfo();
        public virtual void ValidateData()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Name cannot be empty!");

            if (!SystemHelper.ValidateEmail(Email))
                throw new ArgumentException("Invalid email format!");
        }


    }
}
