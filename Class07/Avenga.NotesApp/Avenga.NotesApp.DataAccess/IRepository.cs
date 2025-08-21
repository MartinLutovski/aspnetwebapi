namespace Avenga.NotesApp.DataAccess
{
    public interface IRepository<T>
    {
        // CRUD operations
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
