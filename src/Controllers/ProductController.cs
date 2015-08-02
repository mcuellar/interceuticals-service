using InterceuticalsService.Dao;
using InterceuticalsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterceuticalsService.Controllers
{
    public class ProductController : ApiController
    {
        IProduct ProductDao { get; set; }

        string Test { get; set; }

        public HttpResponseMessage Get(int id)
        
        {
            string errMsg = "FAILED: Unable to get products.";
            ResponseResult response = null;
            List<Product> products = null;

            try
            {
                products = ProductDao.GetProducts(id);
                return Request.CreateResponse<List<Product>>(HttpStatusCode.OK, products);
            }
            catch (Exception ex)
            {
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, response);
            }
            
        }

        
    }
}
