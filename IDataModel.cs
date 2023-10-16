namespace CarFactory
{
    public interface IDataModel
    {
        public void CreateCars();
        void DisplayCars();
        void UpdateCars();
        int ChooseCarId();
        Colors ChooseColor();
        string? ChooseModel();
        void DeleteCars();

    }
}