using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using InterceuticalsService.Models;
using IBatisNet.DataMapper.Exceptions;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;

namespace InterceuticalsService.Dao
{
    public class OrderDao
    {
        public int SaveOrder(Order order)
        {
            return (int) Mapper.Instance().QueryForObject<int>("insertOrder", order);
        }
    }
}