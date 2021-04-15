import React, { useContext } from "react";
import { ProductContext } from "../contexts/products";
import Product from '../components/Product';

const CartDetail = () => {
  const {cart} = useContext(ProductContext);

  console.log(cart);

  return (
     <div>
      <div className='container d-flex'>
      <div className='row mx-auto'>
        {
          cart.map((cartItem) => (
            <div key={cartItem.item.id} className='col-4'>
              <Product {...cartItem.item} />
            </div>
          ))
        }
      </div>
      </div>
    </div> 
   )
};

export default CartDetail;
