import logo from './logo.svg';
import { Container } from 'reactstrap';

import Header from './components/Header';
import TopBanner from './components/TopBanner';
import './App.css';
import ProductProvider, { ProductContext } from './contexts/products';
import { useContext } from 'react';
import Product from './components/Product';
import {BrowserRouter,Route} from "react-router-dom";
import CartDetail from './Container/CartDetail';
import Home from './Container/Home';





function App() {
  const {products} = useContext(ProductContext);
  const {cart, total} = useContext(ProductContext);

  return (
  <BrowserRouter>
      <Header />
      <TopBanner />

      
     <Route exact path="/"  >
      <Home/>
       <div>
      <div className='container d-flex'>
      <div className='row mx-auto'>
        {
          products.map((product) => (
            <div key={product.name} className='col-4'>
              <Product {...product} />
            </div>
          ))
        }
      </div>
      </div>
    </div> 
    </Route>

    
    <Route exact path="/CartDetail"  >
      <CartDetail/>
    </Route>
      
  </BrowserRouter>
  );
}

export default App;
