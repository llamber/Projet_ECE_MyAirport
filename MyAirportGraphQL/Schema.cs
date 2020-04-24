using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace LO.MyAirport.GraphQL
{
    public class AirportSchema : Schema
    {
        public AirportSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AirportQuery>();
            //Can also add Mutator here
        }
    }
}
