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

        /// <summary>
        /// Adds new product to shopping cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Save(ShoppingCart cart)
        {
            string errMsg = "FAILED: Unable to add to cart.";
            string msg = "Success";
            string devMsg = String.Format("Successfuly added new product to cart. Cart Id = [{0}], Product Id = [{1}], Product Name = [{2}]", cart.Id.ToString(), cart.CartProduct.Id, cart.CartProduct.Label);
            int affectedRows = 0;
            ResponseResult response = null;

            try
            {
                affectedRows = ProductDao.AddProductToShoppingCart(cart);
                response = new ResponseResult { Message = msg, DeveloperMessage = devMsg };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.InternalServerError, response);
            }

        }
    }
}
