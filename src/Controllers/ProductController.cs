using InterceuticalsService.Common;
using InterceuticalsService.Dao;
using InterceuticalsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace InterceuticalsService.Controllers
{
    public class ProductController : ApiController
    {
        // Need to DI this way.  Via controller DI did not work.
        ProductDao ProductDao = (ProductDao) AppContext.GetSpringObject("productDao");

        string Test { get; set; }
         
        /// <summary>
        /// Get the list of products for a given category. (Ex: Betterwoman)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Mvc.OutputCache(CacheProfile = "Cache15MinById")]
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
                Debug.Write(ex);
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.InternalServerError, response);
                
            }
            
        }

    }
}
