using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDriver
{
    // Using C# structures instead of normal abstract class inheritance

    struct Car {
        public FuelGauge fuelgauge;
        public Odometer odometer;

        public void drive(int x) {
            int miles = x;
            int fuelburned = miles / 24;
            while (fuelburned != 0) { fuelgauge.decfuel(); fuelburned--; }
            while (miles != 0) { odometer.incmileage(); miles--; }
        }

        public void filltank(int x) {
            int fuel = x;
            while(fuel != 0) { fuelgauge.incfuel(); fuel--; }
        }

        public override String ToString() {
            return "Fuel: " + fuelgauge.ToString() + " Odometer: " + odometer.ToString() + "\n";
        }
    }

    struct ElectricCar {
        // Cannot instantiate in C# structs
        public ElectricFuelGauge electricfuelgauge;
        public ElectricOdometer electricodometer;

        public void drive(int x) {
            int miles = x;
            int fuelburned = miles / 24;
            while (fuelburned != 0) { electricfuelgauge.decfuel(); fuelburned--; }
            while (miles != 0) { electricodometer.incmileage(); miles--; }
        }

        public void filltank(int x) {
            int fuel = x;
            while (fuel != 0) { electricfuelgauge.incfuel(); fuel--; }
        }

        public override String ToString() {
            return "Fuel: " + electricfuelgauge.ToString() + " Odometer: " + electricodometer.ToString() + "\n";
        }
    }

    struct MechanicalCar {
        public AnalogFuelGauge analogfuelgauge;
        public MechanicalOdometer mechanicalodometer;

        public void drive(int x) {
            int miles = x;
            int fuelburned = miles / 24;
            while (fuelburned != 0) { analogfuelgauge.decfuel(); fuelburned--; }
            while (miles != 0) { mechanicalodometer.incmileage(); miles--; }
        }

        public void filltank(int x) {
            int fuel = x;
            while (fuel != 0) { analogfuelgauge.incfuel(); fuel--; }
        }

        public override String ToString() {
            return "Fuel: " + analogfuelgauge.ToString() + " Odometer: " + mechanicalodometer.ToString() + "\n";
        }
    }

    abstract class Odometer {
        public abstract String status();
        public abstract void incmileage();
        public abstract void resetmileage();
    }

    abstract class FuelGauge {
        public abstract String status();
        public abstract void incfuel();
        public abstract void decfuel();
    }

    class MechanicalOdometer : Odometer {
        private int Mileage;

        public MechanicalOdometer(int x) { Mileage = x; }

        override public String status() {
            // Not sure what to use here because C# requires consts for switch cases, went with if statements instead
            // I'm sure there's a more efficient way to do this though ..
            if (Mileage > 0 && Mileage < 10) { return "00000" + Mileage.ToString() + "\n"; }
            if (Mileage >= 10 && Mileage < 100) { return "0000" + Mileage.ToString() + "\n"; }
            if (Mileage >= 100 && Mileage < 1000) { return "000" + Mileage.ToString() + "\n"; }
            if (Mileage >= 1000 && Mileage < 10000) { return "00" + Mileage.ToString() + "\n"; }
            if (Mileage >= 1000 && Mileage < 10000) { return "00" + Mileage.ToString() + "\n"; }
            if (Mileage >= 10000 && Mileage < 100000) { return "0" + Mileage.ToString() + "\n"; }
            if (Mileage >= 100000 && Mileage < 1000000) { return Mileage.ToString() + "\n"; }
            if (Mileage >= 1000000) { return (Mileage / 100000).ToString() + "\n"; }
            else { return "error\n"; }
        }

        public override void incmileage() { Mileage++; }

        public override void resetmileage() { Mileage = 0; }

        public override string ToString() {
            if (Mileage > 0 && Mileage < 10) { return "00000" + Mileage.ToString() + "\n"; }
            if (Mileage >= 10 && Mileage < 100) { return "0000" + Mileage.ToString() + "\n"; }
            if (Mileage >= 100 && Mileage < 1000) { return "000" + Mileage.ToString() + "\n"; }
            if (Mileage >= 1000 && Mileage < 10000) { return "00" + Mileage.ToString() + "\n"; }
            if (Mileage >= 1000 && Mileage < 10000) { return "00" + Mileage.ToString() + "\n"; }
            if (Mileage >= 10000 && Mileage < 100000) { return "0" + Mileage.ToString() + "\n"; }
            if (Mileage >= 100000 && Mileage < 1000000) { return Mileage.ToString() + "\n"; }
            if (Mileage >= 1000000) { return (Mileage / 100000).ToString() + "\n"; }
            else { return "error\n"; }
        }
    }

    class ElectricOdometer : Odometer {
        private int Mileage;

        public ElectricOdometer(int x) { Mileage = x; }

        public override String status() { return Mileage.ToString() + "\n"; }

        public override void incmileage() { Mileage++; }

        public override void resetmileage() { Mileage = 0; }

        public override String ToString() { return Mileage.ToString() + "\n"; }
    }

    class AnalogFuelGauge : FuelGauge {
        private int Gallons;

        public AnalogFuelGauge(int x) { Gallons = x; }

        public override String status() {
            if (Gallons == 15) { return "Full" + "\n"; }
            if (Gallons < 15 && Gallons > 11) { return "3/4 Full" + "\n"; }
            if (Gallons < 12 && Gallons > 7) { return "1/2 Full" + "\n"; }
            if (Gallons < 8 && Gallons > 3) { return "1/4 Full" + "\n"; }
            if (Gallons < 3) { return "Empty" + "\n"; }
            else { return "error\n"; }
        }

        public override void incfuel() {
            if (Gallons < 15) {
                Gallons++;
            }
        }

        public override void decfuel() { 
           if(Gallons > 0) { Gallons--; }
        }

        public override String ToString() {
            if (Gallons == 15) { return "Full" + "\n"; }
            if (Gallons < 15 && Gallons > 11) { return "3/4 Full" + "\n"; }
            if (Gallons < 12 && Gallons > 7) { return "1/2 Full" + "\n"; }
            if (Gallons < 8 && Gallons > 3) { return "1/4 Full" + "\n"; }
            if (Gallons < 3) { return "Empty" + "\n"; }
            else { return "error\n"; }
        }

    }

    class ElectricFuelGauge : FuelGauge {
        private int Gallons;

        public ElectricFuelGauge(int x) { Gallons = x; }

        public override String status() { return Gallons.ToString() + "-Gal." + "\n"; }

        public override void incfuel() {
            if(Gallons < 15) { Gallons++; }
            else { Console.Write("Fuel Tank Full!" + "\n"); }
        }

        public override void decfuel() {
            if(Gallons > 0) { Gallons--; }
            else { Console.Write("Fuel Tank Empty!" + "\n"); }
        }

        public override String ToString() {
            return Gallons.ToString() + "-Gal." + "\n";
        }
    }

    // Testing ..
    class CarProgram
    {
        static void Main(string[] args)
        {
            // Generic Car Testing
            Car car1;
            car1.fuelgauge = new ElectricFuelGauge(0);
            car1.odometer = new MechanicalOdometer(0);
            car1.filltank(20);
            Console.Write(car1.fuelgauge.status());
            car1.drive(48);
            Console.Write(car1.ToString());
            car1.drive(148);
            Console.Write(car1.odometer.status());

            // Electric Car Testing
            ElectricCar car2;
            car2.electricfuelgauge = new ElectricFuelGauge(0);
            car2.electricodometer = new ElectricOdometer(0);
            car2.filltank(20);
            Console.Write(car2.electricfuelgauge.status());
            car2.drive(72);
            Console.Write(car2.ToString());

            // Mechanical Car Testing
            MechanicalCar car3;
            car3.analogfuelgauge = new AnalogFuelGauge(0);
            car3.mechanicalodometer = new MechanicalOdometer(0);
            car3.filltank(20);
            Console.Write(car3.analogfuelgauge.status());
            car3.drive(48);
            Console.Write(car3.mechanicalodometer.status());
            car3.drive(148);
            Console.Write(car3.ToString());

            Console.Read();
        }
    }
}
