namespace ExtraaEdge_MobileStore_Assignment.BlRepository
{
    
        public interface IRepository<TEntity, Tkey> where TEntity : class
        {
            List<TEntity> GetAll();
            TEntity GetById(Tkey key);
            void Create(TEntity entity);
            void Update(TEntity entity);
            void Delete(Tkey key);


        }

    
}
