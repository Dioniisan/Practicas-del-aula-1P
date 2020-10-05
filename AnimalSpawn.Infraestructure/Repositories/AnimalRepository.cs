using System;
using System.Collections.Generic;
using AnimalSpawn.Domain.Entities;
using System.Text;
using System.Linq;
using AnimalSpawn.Domain.Interfaces;
using System.Threading.Tasks;
//using AnimalSpawn.Infraestructure.Data;

namespace AnimalSpawn.Infraestructure.Repositories
{
    //public class AnimalRepository: IAnimalRepository
    //{
    //    //private readonly AnimalSpawnDBContext _context;
    //    //public AnimalRepository(AnimalSpawnDBContext context)
    //    {
    //        this._context = context;
    //    }

    //    public async Task<IEnumerable<Animal>> GetAnimals()
    //    {
    //        var animals = Enumerable.Range(1, 10).Select(index => new Animal
    //        {
    //            Name = $"animal-{index}",
    //            CaptureCondition = "Good",
    //            CaptureDate = DateTime.Now,
    //            Description = $"Description of animal-{index}",
    //            EstimatedAge = (int)Math.Truncate(DateTime.Now.Minute * 2.5),
    //            Gender = index % 2 == 0,
    //            Height = Math.Round(DateTime.Now.Minute * 1.16, 2),
    //            Weight = Math.Round(DateTime.Now.Minute * 4.5, 2)

    //        });

    //        await Task.Delay(10);

    //        return animals;
    //    } 
    //}
}
