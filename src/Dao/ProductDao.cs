using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using InterceuticalsService.Models;
using IBatisNet.DataMapper.Exceptions;
using System.Data.SqlClient;
using System.Diagnostics;

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
                Debug.WriteLine("Saving new product.");
                Mapper.Instance().BeginTransaction();

                int cartId = (int) Mapper.Instance().Insert("saveCart", cart);
                Debug.WriteLine("Saved Cart. Id = " + cartId.ToString());

                int cartItemId = (int)Mapper.Instance().Insert("saveCartItem", cart);
                Debug.WriteLine("Saved Cart Item. Id = " + cartItemId.ToString());

                Mapper.Instance().CommitTransaction();
                Debug.WriteLine("Successfully saved new product.");
                return cartId;
            }
            catch (DataMapperException)
            {
                Debug.WriteLine("Rolling back.");
                Mapper.Instance().RollBackTransaction();
                throw;
            }
            catch (SqlException)
            {
                Debug.WriteLine("Rolling back.");
                Mapper.Instance().RollBackTransaction();
                throw;
            }
            catch (Exception)
            {
                Debug.WriteLine("Rolling back.");
                Mapper.Instance().RollBackTransaction();
                throw;
            }
        }
    }
}