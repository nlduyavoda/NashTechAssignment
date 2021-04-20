import axios from 'axios';
import React, { createContext, useEffect, useState } from 'react';
import { host } from '../config';
import items from '../productItems.json';
import 'bootstrap/dist/css/bootstrap.min.css';

export const ProductContext = createContext({});

export default ({ children }) => {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [selectedItem, setSelectedItem] = useState({});
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


  //api get products
  useEffect(() => {
    axios.get(host + "/api/Product")
      .then(resp => {
        var re = resp.data;
        setProducts(re);
      })
      .catch(err => console.log(err))
  }, [])
  //api get categories
  useEffect(() => {
    axios.get(host + "/api/categories")
      .then(resp => {
        var re = resp.data;
        setCategories(re);
      })
      .catch(err => console.log(err))
  }, [])

  // useEffect(() => {
  //   const fetchData = async () => {
  //     setCategories(await GetCategories());
  //     setProductItems(await GetProducts());
  //   };
  //   fetchData();
  // }, []);


  return (
    <ProductContext.Provider value={{
      products,
      categories,
      selectedItem,
      cart,
      addToCart,
      total,
    }}>
      {children}
    </ProductContext.Provider>
  )
}