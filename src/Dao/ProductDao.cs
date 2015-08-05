using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using InterceuticalsService.Models;

namespace InterceuticalsService.Dao
{
    /// <summary>
    /// Dao for product data.
    /// </summary>
    public class ProductDao : IProduct
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
            return (int) Mapper.Instance().Insert("insertProduct", cart);
        }
    }
}