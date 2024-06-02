using Entities;

namespace WebAPI1
{
    public interface IAnimalService
    {
        List<AnimalInfo> GetAllAnimalInfo();

        AnimalInfo GetAnimalInfo(int id);

        void SaveAnimalInfo(AnimalInfo animalInfo);
    }
}
