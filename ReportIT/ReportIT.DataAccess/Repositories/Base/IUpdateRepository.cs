namespace ReportIT.DataAccess.Repositories.Base
{
    internal interface IUpdateRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }
}
