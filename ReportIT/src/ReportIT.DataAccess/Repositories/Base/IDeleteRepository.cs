namespace ReportIT.DataAccess.Repositories.Base
{
    internal interface IDeleteRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
    }
}
