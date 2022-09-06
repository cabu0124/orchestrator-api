using CsvHelper.Configuration;
using Entities.DTO.Parameters;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mapping.Profiles
{
    public sealed class ProductCsvProfile: ClassMap<ProductCSV>
    {
        public ProductCsvProfile()
        {
            Map(m => m.prod);
            Map(m => m.desc);
            Map(m => m.type);
            Map(m => m.qty);
            Map(m => m.value);
        }
    }
}
