namespace CarFactory
{
    public interface IDataModel
    {
        public void CreateVehicle();
        void DisplayVehicle();
        void UpdateVehicle();
        int ChooseVehicleId();
        Colors ChooseColor();
        string? ChooseModel();
        void DeleteVehicle();

    }
}