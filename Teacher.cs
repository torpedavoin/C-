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
	public enum KeyWords { csharp, python, java, JS }
	class Teacher : Human
	{
		private int salary;
		private string department;
		private int numofseats;
		private KeyWords keywords;
		private CourseWork _coursework;
		public Teacher() : base()
		{
			List = new List<Student>();
		}
		public Teacher(string name, string surname, Gender gender, int age, double height,
			double weight, bool habbits, string email, Nation nation, Adress adress, int salary, string department, int numofseats, KeyWords keywords) : base(name, surname,
				gender, age, height, weight, habbits, email, nation, adress)
		{
			this.salary = salary;
			this.department = department;
			this.numofseats = numofseats;
			this.keywords = keywords;
			this.List = new List<Student>();
		}
		public void Add(Student student)
		{
			if (Check_NumOfSet(student.Key.ToString()))
			{
				List.Add(student);
			}
			else
			{
				Console.WriteLine("Мест нет либо интересы не совпадают!");
			}
		}
		public void Show()
		{
			for (int n = 0; n < List.Count; n++)
				List[n].PrintInfo();
		}
		public override void PrintInfo()
		{
			string data =
			   base.ToStr() +
			   "Salary: " + this.salary.ToString() + "\n" +
			   "Money: " + this.department + "\n" +
				"Number of set: " + this.numofseats.ToString() + "\n" +
				"Key: " + this.keywords.ToString() + "\n";
			Console.WriteLine(data);
		}
		public bool Check_NumOfSet(string key)
		{
			bool check;
			check = (List.Count < numofseats) && (key == keywords.ToString());
			return check;
		}

		public override string ToStr()
		{
			string str = base.ToStr();
			str +=
						"Salary: " + this.Salary.ToString() + "\n" +
						"Money: " + this.Department + "\n" +
						"Number of set: " + this.numofseats.ToString() + "\n" +
						"Key: " + this.keywords.ToString();
			return str;
		}

		public int Salary
		{
			get { return salary; }
			set { salary = value; }
		}
		public string Department
		{
			get { return department; }
			set { department = value; }
		}
		public int NumOfSeats
		{
			get { return numofseats; }
			set { numofseats = value; }
		}
		public KeyWords KeyWords
		{
			get { return keywords; }
			set { keywords = value; }
		}
		public List<Student> List { get; set; }
		public CourseWork CourseWorks
		{
			get { return _coursework; }
			set { _coursework = value; }
		}
	}
}


