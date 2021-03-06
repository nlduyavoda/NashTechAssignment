import Header from "./components/Header";
import "./App.css";
import { useEffect } from "react";
import { BrowserRouter, Route, Link } from "react-router-dom";

import Addform from "./components/Product/add";
import ShowProduct from "./components/Product/show";
import EditProduct from "./components/Product/edit";

import ShowCategory from "./components/Category/show";
import Addcategory from "./components/Category/add";
import EditCategory from "./components/Category/edit";

import "bootstrap/dist/css/bootstrap.min.css";
import "sweetalert2/src/sweetalert2.scss";
import ProtecedRoute from "./utils/protectedRoute";

import AuthProvider from "./utils/authProvider.js";
import userManager, { loadUserFromStorage } from "./services/authService";
import store from "./store";
import { Provider } from "react-redux";
import SignoutOidc from "../src/pages/auth/Signout-oidc";
import SigninOidc from "../src/pages/auth/Signin-oidc";
import { Switch } from "react-router-dom";
import PrivateRoute from "./utils/protectedRoute";

import Home from "./components/Home/Home";

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
            <Route exact path="/" component={Home}></Route>
            <PrivateRoute exact path="/product">
              <ShowProduct />
            </PrivateRoute>
            <Route exact path="/add-product" component={Addform}></Route>
            <Route path="/edit-product" component={EditProduct}></Route>

            <PrivateRoute exact path="/category">
              <ShowCategory />
            </PrivateRoute>
            <Route exact path="/add-category" component={Addcategory}></Route>
            <Route path="/edit-category" component={EditCategory}></Route>
          </Switch>
        </BrowserRouter>
      </AuthProvider>
    </Provider>
  );
}
export default App;
