using static System.Console;

namespace CarFactory
{
    class Application
    {
        public string[] MenuList = new string[] { "Create Car", "Update Car", "Display Cars", "Delete Car", "Exit" };

        private CarDataModel dataModel;

        public Application()
        {
            dataModel = new CarDataModel();
        }
        public void Menu()
        {
            int choice;

            do
            {
                Clear();

                ForegroundColor = ConsoleColor.Magenta;
                WriteLine("{0,25}", arg0: "Welcome To");

                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("{0}", arg0: "Brose Automotive Factory, Berlin, Germany");
                WriteLine("-----------------------------------------\n");

                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Operations:");
                ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < MenuList.Length; ++i)
                {
                    WriteLine($"{i + 1}. {MenuList[i]}");
                }

                Write("Enter Operation : ");

                int.TryParse(ReadLine(), out choice);

                PerformOperation(choice);

            } while (choice != MenuList.Length);
        }

        public void PerformOperation(int choice)
        {

            switch (choice)
            {
                case 1:
                    dataModel.CreateCars();
                    break;
                case 2:
                    dataModel.UpdateCars();
                    break;
                case 3:
                    dataModel.DisplayCars();
                    Write("Enter To Continue");
                    ReadLine();
                    break;
                case 4:
                    dataModel.DeleteCars();
                    Write("Enter To Continue");
                    ReadLine();
                    break;

                case 5:
                    break;

                default:
                    Clear();
                    WriteLine("Please Enter Valid Operation. Press Enter To Continue...");
                    break;
            }
        }

        public static void Run()
        {
            Application app = new Application();
            app.Menu();
        }
    }
}
