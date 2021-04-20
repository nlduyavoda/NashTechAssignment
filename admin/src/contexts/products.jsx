
import axios from 'axios';
import React, { createContext, useEffect, useState } from 'react';
import {host} from '../config';
import items from '../productItems.json';

export const ProductContext = createContext({});

export default ({children}) => {
  const [products, setProducts] = useState(items);
  const [cart, setCart] = useState([]);
  const [total, setTotal] = useState(0);

  const addToCart = (id) => {
    const index = cart.findIndex(existId => existId.item.id === id);
    if (index !== -1) {
      cart[index].quantity += 1;
    } else {
    const item = items.find(i => i.id === id);
      cart.push({ item, quantity: 1 });
    }
    setCart([...cart]);
  };

  useEffect(() => {
    setTotal(cart.reduce((newTotal, cartItem) => 
      newTotal += cartItem.quantity * cartItem.item.price, 0));

  }, [cart]);

  useEffect(()=>{
    axios.get(host+"/api/Product")
      .then(resp =>{
      var re = resp.data;
      // setProducts(re);
      console.log(re);
      })
      .catch(err=> console.log(err))
  },[])

  return (
    <ProductContext.Provider value={{
      products,
      cart,
      addToCart,
      total,
    }}>
      {children}
    </ProductContext.Provider>
  )
} 