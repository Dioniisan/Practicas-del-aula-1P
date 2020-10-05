using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Infraestructure
{
    public class OtherDBRepository:IAnimalRepository
    {
        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var animals = Enumerable.Range(1, 10).Select(index => new Animal
            {
                Name = $"animal-{index}",
                CaptureCondition = "Good",
                CaptureDate = DateTime.Now,
                Description = $"Description of animal-{index} in other database",
                EstimatedAge = (int)Math.Truncate(DateTime.Now.Minute * 2.5),
                Gender = index % 2 == 0,
                Height = Math.Round(DateTime.Now.Minute * 1.25, 2),
                Weight = Math.Round(DateTime.Now.Minute * 0.15, 2)

            });

            await Task.Delay(10);

            return animals;
        }
    }
}
