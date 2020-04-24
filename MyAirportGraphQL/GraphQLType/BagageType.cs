using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using LO.MyAirport.EF;

namespace LO.MyAirport.GraphQL.Type
{
    public class BagageType: ObjectGraphType<Bagage>
    {
        public BagageType()
        {
            Field(x => x.BagageId);
            Field(x => x.Classe);
            Field(x => x.CodeIata);
            Field(x => x.DateCreation);
            Field(x => x.Destination);
            Field(x => x.Escale);
            //Field(x => x.Prioritaire);
            Field(x => x.Sta);
            Field(x => x.Ssur);
            //Field(x => x.VolId);
        }
    }
}
