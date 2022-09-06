using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Repository.Collections;
using Entities.DTO.Common;
using Entities.DTO.Parameters;
using Entities.Mapping.Profiles;
using Entities.Model.Parameters;
using SharpCompress.Common;
using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logic.DataTransformation.Parameters
{
    public class ProductCSVLogic : IProductCSVLogic
    {
        protected readonly IMapper mapper;
        protected readonly IProductRepository repository;

        public ProductCSVLogic(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddFromCSVAsync(Stream stream)
        {
            var products = ReadDataFromCSV(stream);
            await this.repository.AddManyAsync(products);
        }

        public async Task<byte[]> GetAllCSVAsync()
        {
            List<ProductCSV>  products = mapper.Map<List<ProductCSV>>(await this.repository.GetAllAsync());

            byte[] fileBytes;
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.Context.RegisterClassMap<ProductCsvProfile>();
                        csvWriter.WriteRecords(products);
                        writer.Flush();
                        fileBytes = stream.ToArray();
                    }
                }
            }
            return fileBytes;
        }

        public async Task UpdateFromCSVAsync(Stream stream)
        {
            var products = ReadDataFromCSV(stream);
            await this.repository.UpdateManyAsync(products);
        }

        private List<Product> ReadDataFromCSV(Stream stream)
        {
            List<UploadResult<ProductCSV>> result = new List<UploadResult<ProductCSV>>();

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", MissingFieldFound = null, HeaderValidated = null };
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<ProductCSV>();
                    result.AddRange(records.Select((value, i) => new { i, value }).Select(item => new UploadResult<ProductCSV>(item.i + 1, item.value)));
                }
            }
            List<Product> products = mapper.Map<List<Product>>(result);
            return products;
        }
    }
}
