using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace WindowsForm1
{
    class ListStudent
    {
        public ListStudent()
        {
            List = new List<Student>();
        }

        public void Add(Student human)
        {
            List.Add(human);
        }
        public void Show()
        {
            for (int n = 0; n < List.Count; n++)
                List[n].PrintInfo();
        }
        public List<Student> List { get; set; }
        public void Save_json()
        {
            const string fileName = "Students.json";
            string jsonString = JsonSerializer.Serialize(this.List);
            File.WriteAllText(fileName, jsonString);

        }
        public string T_Txt()
        {
            string res = "";
            for (int n = 0; n < List.Count; n++)
            {
                res += List[n].ToStr();
                res += "\n \n";
            }

            return res;
        }
        public void TextsWriter(string url)
        {
            StreamWriter sw = new StreamWriter(url);
            sw.WriteLine(T_Txt());
            sw.Close();
        }
        public int Counts()
        {
            int counts1 = List.Count;
            return counts1;
        }
    }
}