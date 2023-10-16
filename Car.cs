using static System.Console;

namespace CarFactory
{
    public enum Colors
    {
        Blue,
        Red,
        Yellow,
        White,
        Black,
        Purple,
        Orange,
        Brown,
        OliveGreen,
    }
    public class Car
    {
        private int id;
        private Colors bodyPaint;
        private string model;
        private static List<Car>? carList;
        public static List<Car>? CarList { get => carList; set => carList = value; }
        public string Model { get => model; set => model = value; }
        public int Id { get => id; set => id = value; }
        public Colors BodyPaint { get => bodyPaint; set => bodyPaint = value; }
        public Car(Colors colorToSet, string model)
        {
            BodyPaint = colorToSet;
            Model = model;
            Id = CarList.Count;
        }



    }
}