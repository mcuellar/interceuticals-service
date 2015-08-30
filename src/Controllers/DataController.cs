using InterceuticalsService.Common;
using InterceuticalsService.Dao;
using InterceuticalsService.Models;
using System;
using System.Collections;
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
    public class DataController : ApiController
    {
        // Need to DI this way.  Via controller DI did not work.
        AppDao AppDao = (AppDao)AppContext.GetSpringObject("appDao");

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            string errMsg = "FAILED: Unable to get cart totals.";
            string msg = "Success";
            string devMsg = "";
            ResponseResult response = null;
            List<Hashtable> data = null;

            try
            {
                data = AppDao.getDataAsList(id);
                return Request.CreateResponse<List<Hashtable>>(HttpStatusCode.OK, data);
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
