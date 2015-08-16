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
    public class CartDao
    {
        /// <summary>
        /// Saves product to existing cart.
        /// </summary>
        /// <param name="cart">ShoppingCart object</param>
        /// <returns></returns>
        public int AddProductToExistingCart(ShoppingCart cart)
        {
            return (int)Mapper.Instance().Insert("saveCartItem", cart);
        }

        /// <summary>
        /// Gets list of cart items for a given cart.
        /// </summary>
        /// <param name="cartId">Unique cart id identifier</param>
        /// <returns></returns>
        public List<ShoppingCartDetails> GetCartDetails(int cartId)
        {
            return(List<ShoppingCartDetails>) Mapper.Instance().QueryForList<ShoppingCartDetails>("getCartDetails", cartId);
        }

        public ShoppingCartTotals GetCartTotals(int cartId)
        {
            return Mapper.Instance().QueryForObject<ShoppingCartTotals>("getCartTotals", cartId);
        }

        /// <summary>
        /// Removes all cart items.
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <returns></returns>
        public int EmptyCart(int cartId)
        {
            return (int)Mapper.Instance().Delete("clearCart", cartId);
        }

        /// <summary>
        /// Removes a given item from the cart.
        /// </summary>
        /// <param name="cartItemId">Unique Cart Item Id Identifier</param>
        /// <returns></returns>
        public int RemoveFromCart(int cartItemId)
        {
            return (int)Mapper.Instance().Delete("deleteFromCart", cartItemId);
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

                int cartId = (int)Mapper.Instance().Insert("saveCart", cart);
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