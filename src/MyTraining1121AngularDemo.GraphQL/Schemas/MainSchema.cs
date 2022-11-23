using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using MyTraining1121AngularDemo.Queries.Container;
using System;

namespace MyTraining1121AngularDemo.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}