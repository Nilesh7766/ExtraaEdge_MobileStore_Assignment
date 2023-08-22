
using Microsoft.EntityFrameworkCore;
using ExtraaEdge_MobileStore_Assignment.Models;

namespace ExtraaEdge_MobileStore_Assignment.BlRepository
{
    public class Repository<Tentity, Tkey> : IRepository<Tentity, Tkey> where Tentity : class
    {
        ExtraaEdge_TaskContext db;
        public Repository()
        {
            db = new ExtraaEdge_TaskContext(); 
        }
        public void Create(Tentity entity)
        {
            db.Set<Tentity>().Add(entity);
            Save();
        }

        public void Delete(Tkey key)
        {
            Tentity t = GetById(key);
            db.Set<Tentity>().Remove(t);
            Save();
        }

        public List<Tentity> GetAll()
        {
           return db.Set<Tentity>().ToList();
        }

        public Tentity GetById(Tkey key)
        {
            Tentity t = db.Set<Tentity>().Find(key);
            return t;
        }

        public void Update(Tentity entity)
        {
            db.Entry<Tentity>(entity).State = EntityState.Modified;
            Save();
        }
        private void Save()
        {
            db.SaveChanges();
        }
    }
}
