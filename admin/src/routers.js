import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Product from "./pages/products/Product";
import Category from "./pages/categories/Category";
import User from "./pages/users/User";
import NotMatch from "./pages/errors/NotMatch";
//authen
import SigninOidc from "./pages/auth/Signin-oidc";
import SignoutOidc from "./pages/auth/Signout-oidc";
import PrivateRoute from "./utils/protectedRoute";
import ProtectedRoute from "./utils/protectedRoute";

export default function Routes(props) {
  return (
    <switch>
      <Route path="/signout-oidc" component={SignoutOidc} />
      <Route path="/signin-oidc" component={SigninOidc} />

      <Redirect exact from="/" to="/products" />

      <PrivateRoute path="/products" component={Product} />
      <PrivateRoute path="/categories" component={Category} />
      <PrivateRoute path="/users" component={User} />

      <Route path="*" component={NotMatch} />
    </switch>
  );
}
