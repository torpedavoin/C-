using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsForm1
{
    class ListHuman
    {
        private readonly List<Human> listHumans;

        public ListHuman()
        {
            listHumans = new List<Human>();
        }

        public List<Human> ListHumans
        {
            get { return listHumans; }
        }
    
    public void Add(Human human)
        {
            listHumans.Add(human);
        }
        public void Show()
        {
            for (int n = 0; n < listHumans.Count; n++)
                listHumans[n].PrintInfo();
        }
        public void FindCountry_Nation(string str)
        {
            for (int n = 0; n < listHumans.Count; n++)
            {
                if (listHumans[n].Adress.Country == str &&
                    listHumans[n].Nation.ToString() == "Ukranian")
                {
                    listHumans[n].PrintInfo();
                }
            }
        }
        public void FindName(string str)
        {
            for (int n = 0; n < listHumans.Count; n++)
            {
                if (listHumans[n].Name == str)
                    listHumans[n].PrintInfo();
            }
        }
        public void Age_weight_height_sort(int choise)
        {
            int length_humans = listHumans.Count;
            double[] age_weight_height = new double[length_humans];
            int[] count_hum = new int[length_humans];
            for (int n = 0; n < length_humans; n++)
            {
                count_hum[n] = n;
                if (choise == 1) { age_weight_height[n] = listHumans[n].Age; }
                else if (choise == 2) { age_weight_height[n] = listHumans[n].Weight; }
                else if (choise == 3) { age_weight_height[n] = listHumans[n].Height; }
            }
            int j = length_humans - 1;
            for (int b = 0; b < j; b++)
            {
                for (int i = j; i != 0; i--)
                {
                    if (age_weight_height[i] < age_weight_height[i - 1])
                    {
                        (age_weight_height[i - 1], age_weight_height[i]) = (age_weight_height[i], age_weight_height[i - 1]);
                        (count_hum[i - 1], count_hum[i]) = (count_hum[i], count_hum[i - 1]);
                    }
                }
            }
            if (listHumans.Count != 0)
            {
                Console.WriteLine("Список отсортирован");
                for (int k = listHumans.Count - 1; k >= 0; k--)
                {
                    listHumans[count_hum[k]].PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Список пустой");
            }
        }
        public void Average_age()
        {
            int age = 0;
            for (int n = 0; n < listHumans.Count; n++)
                age += listHumans[n].Age;
            if (listHumans.Count != 0)
            {
                float result = age / listHumans.Count;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Список пустой");
            }
        }
        public void Show(bool b)
        {
            foreach (Human obj in listHumans)
                obj.PrintInfo();
        }
        public string T_Txt()
        {
            string res = "";
            for (int n = 0; n < listHumans.Count; n++)
            {
                res += listHumans[n].ToStr();
                res += "\n";
            }

            return res;
        }
        public void TextsWriter(string url)
        {
            StreamWriter sw = new StreamWriter(url);
            sw.WriteLine(T_Txt());
            sw.Close();
        }
        public void delete(int i)
        {
            listHumans.RemoveAt(i - 1);
        }
        public int Counts()
        {
            int counts1 = listHumans.Count;
            return counts1;
        }


    }

}

