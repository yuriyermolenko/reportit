namespace ReportIT.DataAccess.Repositories.Base
{
    internal interface ICreateRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
    }
}
