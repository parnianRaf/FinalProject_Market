using System;
namespace AppCore.Contracts.Services
{
    public class IdGeneratorService : IIdGeneratorService
    {
        public int Execute<T>(List<T> entities)
        {
            return entities.Count() + 1;
        }

    }
}

