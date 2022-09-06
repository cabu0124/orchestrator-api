using CsvHelper;
using Entities.DTO.Parameters;
using Entities.Model.Parameters;
using Logic.DataTransformation.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OrchestratorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductECMLogic productECM;
        private readonly IProductMKTLogic productMKT;
        private readonly IProductCSVLogic productCSV;

        public ProductsController(IProductECMLogic productECM, IProductMKTLogic productMKT, IProductCSVLogic productCSV)
        {
            this.productECM = productECM;
            this.productMKT = productMKT;
            this.productCSV = productCSV;
        }

        /// <summary>
        /// Allows to get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("{type}/GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts(string type)
        {
            switch (type)
            {
                case "ECM":
                    return Ok(await productECM.GetAllAsync());
                case "MKT":
                    return Ok(await productMKT.GetAllAsync());
                default:
                    return BadRequest();
            }
        }

        /// <summary>
        /// Allows to get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{type}/Get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById(string type, string id)
        {
            if (id == null)
                return BadRequest();

            switch (type)
            {
                case "ECM":
                    return Ok(await productECM.GetByIdAsync(id));
                case "MKT":
                    return Ok(await productMKT.GetByIdAsync(id));
                default:
                    return BadRequest();
            }
        }

        /// <summary>
        /// Allows to get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("CSV/GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProductsAsCSV()
        {
            var fileBytes = await productCSV.GetAllCSVAsync();
            return new FileStreamResult(new MemoryStream(fileBytes), "text/csv") { FileDownloadName = "products.csv" };
        }

        /// <summary>
        /// Allows to delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            if (id == null)
                return BadRequest();

            await productECM.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Allows to update a product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("ECM/Update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProductECM([FromBody] ProductECM product, string id)
        {
            if (id == null)
                return BadRequest();

            await productECM.UpdateAsync(product);

            return Created("Product Added", true);
        }

        /// <summary>
        /// Allows to update a product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("MKT/Update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProductMKT([FromBody] ProductMKT product, string id)
        {
            if (id == null)
                return BadRequest();

            await productMKT.UpdateAsync(product);

            return Created("Product Added", true);
        }

        /// <summary>
        /// Allows to update products from CSV File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPut("CSV/Update")]
        public async Task<IActionResult> UpdateProductsCSV(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (file.ContentType.Equals("application/vnd.ms-excel") || file.FileName.ToLower().EndsWith(".csv"))
                {
                    try
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            await productCSV.UpdateFromCSVAsync(stream);
                        }
                        return Created("Product Added", true);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("ECM/Create")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProductECM([FromBody] ProductECM product)
        {
            if (product == null)
                return BadRequest();

            await productECM.AddAsync(product);

            return Created("Product Added", true);
        }

        /// <summary>
        /// Allows to create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("MKT/Create")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProductMKT([FromBody] ProductMKT product)
        {
            if (product == null)
                return BadRequest();

            await productMKT.AddAsync(product);

            return Created("Product Added", true);
        }

        /// <summary>
        /// Allows to create products from CSV File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("CSV/Create")]
        public async Task<IActionResult> AddProductsCSV(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (file.ContentType.Equals("application/vnd.ms-excel") || file.FileName.ToLower().EndsWith(".csv"))
                {
                    try
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            await productCSV.AddFromCSVAsync(stream);
                        }
                        return Created("Product Added", true);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
