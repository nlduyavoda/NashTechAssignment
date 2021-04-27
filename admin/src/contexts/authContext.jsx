import React, { createContext, useState } from 'react';
import { signinRedirectCallback } from '../Services/authService';
import {
    STORE_USER,
    USER_SIGNED_OUT,
    USER_EXPIRED,
    LOADING_USER,
} from './types';
import { setAuthHeader } from "../utils/axiosHeaders";


export function storeUser(user) {
    alert(user.access_token);
    setAuthHeader(user.access_token);
    return {
        type: STORE_USER,
        payload: user,
    };
}
export function loadingUser() {
    return {
        type: LOADING_USER,
    };
}
export function storeUserError() {
    return {
        type: STORE_USER_ERROR,
    };
}
export function userExpired() {
    return {
        type: USER_EXPIRED,
    };
}
export function userSignedOut() {
    return {
        type: USER_SIGNED_OUT,
    };
}
export const AuthContext = createContext({});

const AuthContextProvider = ({ children }) => {
    const [isAuth, setAuth] = useState(false);
    const [user, setUser] = useState(null);

    const signInRedirectCallback = () => {
        signinRedirectCallback()
            .then(res => {
                const userRes = res;
                setAuth(true);
                setUser(userRes);
            })
            .catch(err => console.log(err));
    };

    return (
        <AuthContext.Provider value={{
            isAuth,
            user,
            setAuth,
            setUser,
            signInRedirectCallback
        }}>
            {children}
        </AuthContext.Provider>
    )
}