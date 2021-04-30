import Header from './components/Header';
import './App.css';
import { useEffect } from 'react';
import { BrowserRouter, Route, Link } from "react-router-dom";
import Addform from './components/form/product/add';
import EditProduct from './components/form/product/edit';
import Home from './components/Product/Home';
import Category from './components/Category/Category';
import EditCategory from './components/form/category/edit';

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
            <Route exact path="/components/form/product/Addform">
              <Addform />
            </Route>
            <Route path="/edit-product" component={EditProduct}>
            </Route>

            <Route exact path="/category">
              <Category />
            </Route>
            <Route exact path="/components/form/category/Addform">
              <Addform />
            </Route>
            <Route path="/edit-category" component={EditCategory}>
            </Route>




          </Switch>
        </BrowserRouter>
      </AuthProvider>
    </Provider>
  );
}
export default App;
