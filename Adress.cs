using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm1
{
    class Adress
    {
        public Adress()
        {
            this.Country = "Ukraine";
            this.City = "Kherson";
            this.Street = "Pivnichna";
            this.House = 57;
        }

        public Adress(string country, string city, string street, int house)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.House = house;
        }

        public override string ToString()
        {
            return
                "Country: " + this.Country + "\n" +
                "City: " + this.City + "\n" +
                "Street: " + this.Street + "\n" +
                "House: " + this.House.ToString();
        }
        public Adress Inputadress()
        {
            Console.WriteLine("Country: ");
            string country = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Street: ");
            string street = Console.ReadLine();
            Console.WriteLine("House: ");
            int house = int.Parse(Console.ReadLine());
            return new Adress(country, city, street, house);
        }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int House { get; set; }
    }
}