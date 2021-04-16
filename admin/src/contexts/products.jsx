
import React, { createContext, useState } from 'react';

import items from '../productItems.json';

export const ProductContext = createContext({});

export default ({children}) => {
  const [products, setProducts] = useState(items);

  return (
    <ProductContext.Provider value={{
      products
    }}>
      {children}
    </ProductContext.Provider>
  )
} 