using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Traveless.Data
{
    [Serializable]
    public class Reservation
    {
        //Attributes for reservation
        private string reservationCode;
        private string flightId;
        private string airline;
        private double cost;
        private string name;
        private string citizenship;
        private bool isActive = true;
        public Flight SelectedFlight { get; set; }

        //Constructor to generate reservation code and set as active
        public Reservation()
        {
            ReservationCode = GenerateReservationCode();
            IsActive = true; 
        }

        //Method to generate a random reservation code in the format L9999
        private string GenerateReservationCode()
        {
            var random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const int numberOfDigits = 4;

            char letter = letters[random.Next(letters.Length)];
            int digits = random.Next((int)Math.Pow(10, numberOfDigits - 1), (int)Math.Pow(10, numberOfDigits));

            return $"{letter}{digits:D4}";
        }

        //Saves reservations to binary file. Takes the filepath as an argument
        public static void Persist(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, App.AllReservations);
            }
        }

        //Getters and setters
        public string ReservationCode
        {
            get { return reservationCode; }
            set { reservationCode = value; }
        }

        public string FlightId
        {
            get { return flightId; }
            set { flightId = value; }
        }

        public string Airline
        {
            get { return airline; }
            set { airline= value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Citizenship
        {
            get { return citizenship; }
            set { citizenship= value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        
    }

}
