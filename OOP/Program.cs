using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Contract C = new Contract("HANA", 3, 120);
                Vehicle V = new Vehicle("V1", C);
                Car car = new Car("C1", C, 5);
                Truck truck = new Truck("T1", C, 1000);
                Motorcycle motorcycle = new Motorcycle("M1", C, true);

                Console.WriteLine("Vehicle payment: " + V.Payment());
                Console.WriteLine("Car payment: " + car.Payment());
                Console.WriteLine("Truck payment: " + truck.Payment());
                Console.WriteLine("Motorcycle payment: " + motorcycle.Payment());
            
        }

        class Contract
        {
            private string name;
            private int days;
            private int kilo;

            public Contract(string name, int days, int kilo)
            {
                this.name = name;
                this.days = days;
                this.kilo = kilo;
            }

            public int Getdays()
            {
                return days;
            }

            public int Getkilo()
            {
                return kilo;
            }
        }

        class Vehicle
        {
            protected string id;
            protected Contract contract;

            public Vehicle(string id, Contract contract)
            {
                this.id = id;
                this.contract = contract;
            }

            public virtual double Payment()
            {
                return (this.contract.Getdays() * 60)
                     + (this.contract.Getkilo() * 2);
            }
        }

        class Car : Vehicle
        {
            private int seats;

            public Car(string id, Contract contract, int seats)
                : base(id, contract)
            {
                this.seats = seats;
            }
        }

        class Truck : Vehicle
        {
            private int max;

            public Truck(string id, Contract contract, int max)
                : base(id, contract)
            {
                this.max = max;
            }

            public override double Payment()
            {
                return base.Payment() + 500;
            }
        }

        class Motorcycle : Vehicle
        {
            private bool offRoad;

            public Motorcycle(string id, Contract contract, bool offRoad)
                : base(id, contract)
            {
                this.offRoad = offRoad;
            }

            public override double Payment()
            {
                return base.Payment() / 2;
            }
        }
    }
}
