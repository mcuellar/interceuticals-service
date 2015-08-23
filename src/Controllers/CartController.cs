using InterceuticalsService.Common;
using InterceuticalsService.Dao;
using InterceuticalsService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InterceuticalsService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartController : ApiController
    {
        // Need to DI this way.  Via controller DI did not work.
        CartDao CartDao = (CartDao) AppContext.GetSpringObject("cartDao");

        /// <summary>
        /// Adds new product to a new or existing shopping cart
        /// </summary>
        /// <param name="cart">ShoppingCart object</param>
        /// <returns></returns>
        [HttpPost]
        //[EnableCors(origins: "http://localhost:49900", headers: "*", methods: "*")]
        public HttpResponseMessage Save(ShoppingCart cart)
        {
            string errMsg = "FAILED: Unable to save cart.";
            string msg = "Success. New item added to cart.";
            string devMsg = "";
            int cartId = 0;
            ResponseResult response = null;

            try
            {
                devMsg = String.Format("Successfuly added new product to cart. Session Id = [{0}], Product Id = [{1}]", cart.SessionId, cart.CartProduct.Id);

                if(cart.Id > 0)
                    cartId = CartDao.AddProductToExistingCart(cart);
                else
                    cartId = CartDao.AddProductToShoppingCart(cart);

                response = new ResponseResult { Message = msg, DeveloperMessage = devMsg, Id = cartId };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.InternalServerError, response);
            }

        }

        [HttpPost]
        public HttpResponseMessage Clear(int id)
        {
            string errMsg = "FAILED: Unable to empty cart.";
            string msg = "Success. Removed all cart items.";
            int rowsAffected = 0;
            string devMsg = "";
            ResponseResult response = null;

            try
            {
                devMsg = String.Format("Successfuly removed all items from cart. Cart Id = [{0}]", id);
                rowsAffected = CartDao.EmptyCart(id);
                response = new ResponseResult { Message = msg, DeveloperMessage = devMsg, Id = id };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost]
        public HttpResponseMessage DeleteItem(int id)
        {
            string errMsg = "FAILED: Unable to remove cart item.";
            string msg = "Success. Item removed from cart.";
            int rowsAffected = 0;
            string devMsg = "";
            ResponseResult response = null;

            try
            {
                devMsg = String.Format("Successfuly removed item from cart. Cart Item Id = [{0}]", id);
                rowsAffected = CartDao.RemoveFromCart(id);
                response = new ResponseResult { Message = msg, DeveloperMessage = devMsg, Id = id };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet]
        public HttpResponseMessage Items(int id)
        {
            string errMsg = "FAILED: Unable to remove cart item.";
            string msg = "Success";
            string devMsg = "";
            ResponseResult response = null;
            List<ShoppingCartDetails> cartItems = null;

            try
            {
                devMsg = String.Format("Successfuly retrieved items from cart. Cart Id = [{0}]", id);
                cartItems = CartDao.GetCartDetails(id);
                return Request.CreateResponse<List<ShoppingCartDetails>>(HttpStatusCode.OK, cartItems);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                response = new ResponseResult { Message = errMsg, DeveloperMessage = ex.Message };
                return Request.CreateResponse<ResponseResult>(HttpStatusCode.InternalServerError, response);
            }
        }

        private string getCartTotal(List<ShoppingCartDetails> cartItems)
        {
            string total = "";
            try
            {
                foreach(ShoppingCartDetails item in cartItems)
                {

                }
            }
            catch (Exception ex)
            {

            }

            return total;
        }

        [HttpGet]
        public HttpResponseMessage Totals(int id)
        {
            string errMsg = "FAILED: Unable to get cart totals.";
            string msg = "Success";
            string devMsg = "";
            ResponseResult response = null;
            ShoppingCartTotals cartTotals = null;
            
            try
            {
                devMsg = String.Format("Successfuly retrieved cart totals. Cart Id = [{0}]", id);
                cartTotals = CartDao.GetCartTotals(id);

                if (cartTotals == null)
                    cartTotals = new ShoppingCartTotals();

                return Request.CreateResponse<ShoppingCartTotals>(HttpStatusCode.OK, cartTotals);
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
