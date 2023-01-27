using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm1
{
    class CourseWork
    {
        private string _description;
        private string _name;

        private DateTime _date;
        
        public CourseWork(string description, string name, DateTime date)
        {
            this._description = description;
            this._name = name;
            this._date = date;

        }

        public void Printinfo()
        {
            string text = "Description: " + _description + "\n" +
                 "Name: " + _name + "\n" +
                 "Date: " + _date + "\n";
            Console.WriteLine(text);
        }
        public string Strinfo()
        {
            return "Description: " + _description + "\n" +
                 "Name: " + _name + "\n" +
                 "Date: " + _date + "\n";

        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
