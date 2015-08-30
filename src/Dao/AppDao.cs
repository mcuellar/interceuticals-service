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
    public class AppDao
    {
        public List<Hashtable> getDataAsList(string name, Dictionary<string,string> inParams = null)
        {
            //IList<Hashtable> result = Mapper.Instance().QueryForList<Hashtable>(name, inParams);

            //List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();

            //foreach (var item in result)
            //    results.Add(HashtableToDictionary(item));

            return (List<Hashtable>) Mapper.Instance().QueryForList<Hashtable>(name, inParams);
        }
    }
}