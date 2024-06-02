using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI1
{
    public class AnimalService : IAnimalService
    {
        private List<AnimalInfo> lAnimalInfo;

        public AnimalService() 
        {
            #region AnimalInfo metaData

            lAnimalInfo = new List<AnimalInfo>()
            {
                new AnimalInfo()
                {
                    Id = 1,
                    Name = "Dog",
                    Age = 10
                },
                new AnimalInfo()
                {
                    Id = 2,
                    Name = "Cat",
                    Age = 6
                },
                new AnimalInfo()
                {
                    Id = 3,
                    Name = "Horse",
                    Age = 30
                }
            };
            #endregion AnimalInfo metaData
        }

        public List<AnimalInfo> GetAllAnimalInfo()
        {
            return lAnimalInfo;
        }

        public AnimalInfo GetAnimalInfo(int id)
        {
            //AnimalInfo animalInfo = lAnimalInfo.FirstOrDefault(x => x.Id.Equals(id));
            //return animalInfo != null ? animalInfo : new AnimalInfo();
            return lAnimalInfo.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void SaveAnimalInfo(AnimalInfo animalInfo)
        {
            if(animalInfo != null)
            {
                lAnimalInfo.Add(animalInfo);
                
            }
        }
    }
}
