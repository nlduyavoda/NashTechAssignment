import { Container, Table, Button } from 'reactstrap';
import { PenFill } from 'react-bootstrap-icons';
import Header from './components/Header';
import './App.css';
import { ProductContext } from './contexts/products';
import { useContext, useState } from 'react';
import { BrowserRouter, Route, Link } from "react-router-dom";
import CartDetail from './Container/CartDetail';
import Addform from './components/form/product/add';
import Editform from './components/form/product/edit';
import Home from './Container/Home';
import 'bootstrap/dist/css/bootstrap.min.css';



function App() {
  return (
    <BrowserRouter>
      <Header />
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/CartDetail">
        <CartDetail />
      </Route>
      <Route exact path="/components/form/product/Addform">
        <Addform />
      </Route>
      <Route path="/components/form/product/Editform" component={Editform}>
      </Route>
    </BrowserRouter>
  );
}
export default App;
