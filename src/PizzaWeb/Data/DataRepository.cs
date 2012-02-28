using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FubuCore.Util;

namespace PizzaWeb.Data
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        IEnumerable GetAll(Type entityType);
        T Get<T>(Guid id) where T : Entity;
        object Get(Type entityType, Guid id);
        T Find<T>(Func<T, bool> where) where T : Entity;
        void Save(Entity entity);
    }

    public class DataRepository : IRepository
    {
        private readonly Cache<Type, Cache<Guid, object>> _dataCache = new Cache<Type, Cache<Guid, object>>(t => new Cache<Guid, object>());

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            var typeCache = _dataCache[typeof(T)];
            return typeCache.GetAll().Cast<T>();
        }

        public IEnumerable GetAll(Type entityType)
        {
            var typeCache = _dataCache[entityType];
            return typeCache.GetAll();
        }

        public T Get<T>(Guid id) where T : Entity
        {
            var typeCache = _dataCache[typeof(T)];
            if (typeCache.Has(id)) return (T)typeCache[id];

            return null;
        }

        public object Get(Type entityType, Guid id)
        {
            var typeCache = _dataCache[entityType];
            return typeCache.Has(id) ? typeCache[id] : null;
        }

        public T Find<T>(Func<T, bool> where) where T : Entity
        {
            var typeCache = _dataCache[typeof(T)];
            return (T) typeCache.Find(o => where((T) o));
        }

        public void Save(Entity entity)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
            var typeCache = _dataCache[entity.GetType()];
            typeCache[entity.Id] = entity;
        }

        public void LoadDefaultSampleData()
        {
            Save(new Store { StoreID = "HP001", Name = "East Side Pi" });
            Save(new Store { StoreID = "HP002", Name = "Pi on Sixth" });
            Save(new Store { StoreID = "HP003", Name = "Pi on the Drag" });

            Save(new PizzaType { PizzaID = "PT001", Name = "Before it was cool", Description = "A pre-mainstream pie with spelt wheat crust, heirloom tomato sauce, yarlsburg cheese, and salamino piccante (pepperoni is too mainstream)." });
            Save(new PizzaType { PizzaID = "PT002", Name = "American Spirit", Description = "Thick crust, smokey tomato sauce, smoked parmesean cheese, and spinach with just a hint of tobacco flavor." });
            Save(new PizzaType { PizzaID = "PT003", Name = "PBR", Description = "Thin, cheap crust, canned tomato sauce, american cheese slices, and spam." });
        }
    }
}