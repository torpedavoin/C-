using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace WindowsForm1
{
    public enum Key { csharp, python, java, JS }
    class Student : Human
    {

        private int group;
        private int money;
        private Key key;

        public Student(string name, string surname, Gender gender, int age, double height,
             double weight, bool habbits, string email, Nation nation, Adress adress, int group, int money, Key key) : base(name, surname,
             gender, age, height, weight, habbits, email, nation, adress)
        {
            this.group = group;
            this.money = money;
            this.key = key;
        }
        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        public Key Key
        {
            get { return key; }
            set { key = value; }

        }

        public override void PrintInfo()
        {
            string data =
              base.ToStr() +
              "Group: " + this.group.ToString() + "\n" +
              "Money: " + this.money.ToString() + "\n" +
               "Key: " + this.key.ToString() + "\n";
            Console.WriteLine(data);
        }
        public override string ToStr()
        {
            string str = base.ToStr();
            str +=
               "Group: " + this.group.ToString() + "\n" +
               "Money: " + this.money.ToString() + "\n" +
               "Key: " + this.key.ToString();
            return str;
        }

    }
}
