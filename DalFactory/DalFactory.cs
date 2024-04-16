using DataLayer.Services;
using LogicLayer;
using LogicLayer.Models;

namespace DalFactory
{
    public class DalFactory
    {
        public static Core CreateCore()
        {
            var core = new Core(new DatabaseEntityService<Player>());
            
            return core;
        }
    }
}

