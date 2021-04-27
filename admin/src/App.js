import { Container, Table, Button } from 'reactstrap';
import { PenFill } from 'react-bootstrap-icons';
import Header from './components/Header';
import './App.css';
import { ProductContext } from './contexts/products';
import { useContext, useEffect, useState } from 'react';
import { BrowserRouter, Route, Link } from "react-router-dom";
import CartDetail from './Container/CartDetail';
import Addform from './components/form/product/add';
import Editform from './components/form/product/edit';
import Home from './Container/Home';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'sweetalert2/src/sweetalert2.scss'
import ProtecedRoute from "./utils/protectedRoute";

import AuthProvider from "./utils/authProvider.js";
import userManager, { loadUserFromStorage } from "./services/authService";
import store from "./store";
import { Provider } from "react-redux";
import SignoutOidc from "../src/pages/auth/Signout-oidc";
import SigninOidc from "../src/pages/auth/Signin-oidc";
import { Switch } from 'react-router-dom';







function App() {
  useEffect(() => {
    // fetch current user from cookies
    loadUserFromStorage(store);
  }, []);

  return (
    <Provider store={store}>
      <AuthProvider userManager={userManager} store={store}>
        <BrowserRouter>
          <Header />
          <Switch>

            <Route path="/signout-oidc" component={SignoutOidc} />
            <Route path="/signin-oidc" component={SigninOidc} />
            <ProtecedRoute exact path="/">
              <Home />
            </ProtecedRoute>
            <Route exact path="/CartDetail">
              <CartDetail />
            </Route>
            <Route exact path="/components/form/product/Addform">
              <Addform />
            </Route>
            <Route path="/components/form/product/Editform" component={Editform}>
            </Route>
          </Switch>
        </BrowserRouter>
      </AuthProvider>
    </Provider>
  );
}
export default App;
