
using Entities;

namespace WebAPI2
{
    public class VehicleService : IVehicleService
    {
        private List<Vehicle> lVehicle;

        public VehicleService()
        {
            #region Vehicle metaData

            lVehicle = new List<Vehicle>()
            {
                new Vehicle()
                {
                    Id = 1,
                    Name = "Benze",
                    Price = 5000000
                },
                new Vehicle()
                {
                    Id = 2,
                    Name = "BMW",
                    Price = 3500000
                },
                new Vehicle()
                {
                    Id = 3,
                    Name = "Tesla",
                    Price = 6000000
                },
                new Vehicle()
                {
                    Id = 4,
                    Name = "RollsRoyce",
                    Price = 3000000
                }
            };
            #endregion Vehicle metaData
        }

        public List<Vehicle> GetAllVehicles()
        {
            return lVehicle;
        }

        public Vehicle GetVehicle(int id)
        {
            return lVehicle.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                lVehicle.Add(vehicle);
            }
        }
    }
}
