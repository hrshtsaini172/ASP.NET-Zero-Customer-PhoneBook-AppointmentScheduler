using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace MyTraining1121AngularDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class MyTraining1121AngularDemoRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<MyTraining1121AngularDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyTraining1121AngularDemoRepositoryBase(IDbContextProvider<MyTraining1121AngularDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="MyTraining1121AngularDemoRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class MyTraining1121AngularDemoRepositoryBase<TEntity> : MyTraining1121AngularDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyTraining1121AngularDemoRepositoryBase(IDbContextProvider<MyTraining1121AngularDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)!!!
    }
}
