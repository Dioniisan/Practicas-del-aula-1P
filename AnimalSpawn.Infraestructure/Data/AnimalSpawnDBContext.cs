using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnimalSpawn.Infraestructure.Data
{
    public partial class AnimalSpawnDBContext : DbContext
    {
        public AnimalSpawnDBContext()
        {
        }

        public AnimalSpawnDBContext(DbContextOptions<AnimalSpawnDBContext> options)
            : base(options)
        {
        }


    }
}
