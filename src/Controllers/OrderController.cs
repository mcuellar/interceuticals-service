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
    [EnableCors(origins: "localhost", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        OrderDao OrderDao = (OrderDao) AppContext.GetSpringObject("orderDao");

       
        public HttpResponseMessage Save(Order order)
        {
            string errMsg = "FAILED: Unable to save order.";
            string msg = "Success. New order saved.";
            string devMsg = "";
            int cartId = 0;
            ResponseResult response = null;

            try
            {
                devMsg = String.Format("Successfuly added new order to. Cart Id = [{0}]", order.CartId);
                int orderId = OrderDao.SaveOrder(order);
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
        
    }
}
