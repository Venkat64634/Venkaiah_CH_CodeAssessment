
using Entities;

namespace WebAPI2
{
    public interface IVehicleService
    {
        List<Vehicle> GetAllVehicles();

        Vehicle GetVehicle(int id);

        void SaveVehicle(Vehicle vehicle);
    }
}
