using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using InterceuticalsService.Models;
using IBatisNet.DataMapper.Exceptions;
using System.Data.SqlClient;

namespace InterceuticalsService.Dao
{
    /// <summary>
    /// Dao for product data.
    /// </summary>
    public class ProductDao
    {
        /// <summary>
        /// Gets list of products
        /// </summary>
        /// <param name="categoryId">Category Id for BM or BW</param>
        /// <returns></returns>
        public List<Product> GetProducts(int categoryId)
        {
            return (List<Product>) Mapper.Instance().QueryForList<Product>("getProducts", categoryId);
        }

        /// <summary>
        /// Adds product to cart
        /// </summary>
        /// <param name="cart">ShoppingCart object</param>
        /// <returns></returns>
        public int AddProductToShoppingCart(ShoppingCart cart)
        {
            try
            {
                Mapper.Instance().BeginTransaction();
                int cartId = (int) Mapper.Instance().Insert("saveCart", cart.SessionId);
                int cartItemId = (int)Mapper.Instance().Insert("saveCartItem", cart);

                Mapper.Instance().CommitTransaction();
                return cartId;
            }
            catch (DataMapperException)
            {
                Mapper.Instance().RollBackTransaction();
                throw;
            }
            catch (SqlException)
            {
                Mapper.Instance().RollBackTransaction();
                throw;
            }
            catch (Exception)
            {
                Mapper.Instance().RollBackTransaction();
                throw;
            }
        }
    }
}