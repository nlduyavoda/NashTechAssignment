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


  const handleDelete = (id) => {
    axios({
      method: 'delete',
      url: host + '/api/product/' + id,
    }).then((res) => {
      console.log('res data', res);
      if (res.data) {
        axios.get(host + "/api/Product")
          .then(resp => {
            var re = resp.data;
            setProducts(re);
          })
          .catch(err => console.log(err))
      }

    }).catch(err => {
      console.log('err from put', err);
    });
  }
  const handleEditCategory = (formData, id) => {
    axios({
      method: 'put',
      url: host + '/api/categories/' + id,
      data: formData,
    }).then((res) => {
      console.log(res.data);
      if (res.data) {
        axios.get(host + "/api/categories")
          .then(resp => {
            var re = resp.data;
            setProducts(re);
          })
          .catch(err => console.log(err))
      }
    }).catch(err => {
      console.log('err from put', err);
    });
  }
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
  const handleEditProduct = (formData, id) => {
    axios({
      method: 'put',
      url: host + '/api/Product/' + id,
      data: formData,
    }).then((res) => {
      console.log(res.data);
      if (res.data) {
        axios.get(host + "/api/Product")
          .then(resp => {
            var re = resp.data;
            setProducts(re);
          })
          .catch(err => console.log(err))
      }
    }).catch(err => {
      console.log('err from put', err);
    });
  }
  const handleCreateProduct = (formData) => {
    axios({
      method: 'post',
      url: host + '/api/Product/',
      data: formData,
    }).then((res) => {
      console.log(res.data);
      if (res.data) {
        axios.get(host + "/api/Product")
          .then(resp => {
            var re = resp.data;
            setProducts(re);
          })
          .catch(err => console.log(err))
      }
    }).catch(err => {
      console.log('err from put', err);
    });
  }
  const handleCreateCategory = (formData) => {
    axios({
      method: 'post',
      url: host + '/api/categories/',
      data: formData,
    }).then((res) => {
      console.log(res.data);
      if (res.data) {
        axios.get(host + "/api/categories")
          .then(resp => {
            var re = resp.data;
            setProducts(re);
          })
          .catch(err => console.log(err))
      }
    }).catch(err => {
      console.log('err from post', err);
    });
  }
  //api get products
  useEffect(() => {
    axios.get(host + "/api/Product")
      .then(resp => {
        var re = resp.data;
        setProducts(re);
      })
      .catch(err => console.log(err))
  }, [])
  useEffect(() => {
    axios.get(host + "/api/categories")
      .then(resp => {
        var re = resp.data;
        setCategories(re);
      })
      .catch(err => console.log(err))
  }, [])

  return (
    <ProductContext.Provider value={{
      products,
      categories,
      selectedItem,
      cart,
      addToCart,
      total,
      handleDelete,
      handleCreateCategory,
      handleEditCategory,
      handleEditProduct,
      handleCreateProduct
    }}>
      {children}
    </ProductContext.Provider>
  )
}