using System.Drawing;
using System.Dynamic;
using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace CarFactory
{
    public class CarDataModel : IDataModel
    {
        public CarDataModel()
        {
            // Car.CarList = new List<Car>();
            CreateVehicle();
            CreateVehicle();
            CreateVehicle();
        }
        public void CreateVehicle()
        {
            Car carObject = new Car(Colors.Blue, "Audi A4");
            Car.CarList.Add(carObject);
        }
        public void DisplayVehicle()
        {
            Clear();
            WriteLine("{0,24}", arg0: "Cars In Batch");
            WriteLine("----------------------------------------\n");

            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("{0,4} {1,11} {2,15}", arg0: "Id|", arg1: "Model|", arg2: "Color|");

            ForegroundColor = ConsoleColor.White;

            foreach (Car car in Car.CarList)
            {
                WriteLine($"{car.Id + "|",4} {car.Model + "|",11} {car.BodyPaint + "|",15}");
            }

        }
        public void UpdateVehicle()
        {
            int carId = ChooseVehicleId();
            int choice;
            do
            {
                Clear();
                WriteLine("1. Update Color");
                WriteLine("2. Update Model");
                WriteLine("3. Exit");

                Write("Enter Your Choice : ");
                int.TryParse(ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Car.CarList[carId].BodyPaint = ChooseColor();
                        break;

                    case 2:
                        Car.CarList[carId].Model = ChooseModel();
                        break;

                    case 3:
                        break;

                    default:
                        Clear();
                        WriteLine("Please Enter Correct Choice. Press Enter To Continue");
                        break;

                }

            } while (choice != 3);

        }
        public int ChooseVehicleId()
        {
            int carId = -1;
            do
            {
                Clear();
                DisplayVehicle();
                Write("Enter Car Id: ");
                int.TryParse(ReadLine(), out carId);

                if (carId < 0 || carId > Car.CarList.Count)
                {
                    Clear();
                    WriteLine("Please Enter Valid Car Id. Enter To Continue");
                    ReadLine();
                }
            } while (carId == -1 || carId > Car.CarList.Count);
            int index = Car.CarList.FindIndex(car => car.Id == carId);
            return index;
        }
        public Colors ChooseColor()
        {
            int choice;
            Clear();
            WriteLine("Avaialable Colors In Paint Shop: ");
            for (int i = 0; i < Enum.GetValues(typeof(Colors)).Length; ++i)
            {
                WriteLine($"{i + 1}. {(Colors)Enum.ToObject(typeof(Colors), i)}");
            }

            Write("Enter Your Choice : ");
            int.TryParse(ReadLine(), out choice);
            return (Colors)Enum.ToObject(typeof(Colors), choice - 1);
        }
        public string? ChooseModel()
        {
            Clear();
            WriteLine("Please Enter Your Model Name : ");
            return ReadLine();
        }
        public void DeleteVehicle()
        {
            int carId = ChooseVehicleId();
            Clear();
            Write($"To Delete {Car.CarList[carId]} Type Model Name : ");
            string modelName = ReadLine();

            if (Car.CarList[carId].Model.Equals(modelName))
            {
                int index = Car.CarList.FindIndex(car => car.Id == carId);
                Car.CarList.RemoveAt(index);
                Clear();
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Successful!");
                ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Failed!");
                ForegroundColor = ConsoleColor.White;
            }
        }

    }
}