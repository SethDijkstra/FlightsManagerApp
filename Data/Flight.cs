using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    [Serializable]
    public class Flight
    {
        //Attributes for object Flight
        private string flightId;
        private string airline;
        private string departureCode;
        private string arrivalCode;
        private string day;
        private string departTime;
        private int seats;
        private double costPerSeat;

        public Flight(string row)
        {
            //Splits each column into seperate data
            string[] data = row.Split(',');

            //Stores data as attributes
            this.flightId = data[0];
            this.airline = data[1];
            this.departureCode = data[2];
            this.arrivalCode = data[3];
            this.day = data[4];
            this.departTime = data[5];
            this.seats = Convert.ToInt32(data[6]);
            this.costPerSeat= Convert.ToDouble(data[7]);
        }

        //Getters & setters
        public string FlightId
        {
            get { return flightId; }
            set { flightId = value; }
        }

        public string Airline
        {
            get { return airline; }
            set { airline = value; }
        }

        public string DepartureCode
        {
            get { return departureCode; }
            set { departureCode = value; }
        }

        public string ArrivalCode
        {
            get { return arrivalCode; }
            set { arrivalCode = value; }
        }

        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        public string DepartTime
        {
            get { return departTime; }
            set { departTime = value; }
        }

        public int Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        public double CostPerSeat
        {
            get { return costPerSeat; }
            set { costPerSeat = value;}
        }
    }
}
