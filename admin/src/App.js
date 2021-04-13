import logo from './logo.svg';
import { Container } from 'reactstrap';

import Nav from './components/Header';
import TopBanner from './components/TopBanner';
import './App.css';
import ProductProvider, { ProductContext } from './contexts/products';
import { useContext } from 'react';

function App() {
  const {products} = useContext(ProductContext);

  console.log(products);

  return (
    <div>
      <Nav />
      <TopBanner />
    </div>
  );
}

export default App;
