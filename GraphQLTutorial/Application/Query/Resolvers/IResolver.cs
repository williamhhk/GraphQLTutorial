using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTutorial.Application.Query.Resolvers
{
    public interface IResolver
    {
        void Resolve(GraphQLQuery graphQLQuery);
    }
}
