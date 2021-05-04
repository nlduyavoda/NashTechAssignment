import axios from "axios";
import { Formik } from "formik";
import React, { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { host } from "../../config";
import ProductProvider, { ProductContext } from '../../contexts/products';
// import RequestService from "../../../services/request";
import { useHistory } from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';

const Addform = () => {
    const history = useHistory();
    const { categories, handleCreateProduct } = useContext(ProductContext);
    const { register, handleSubmit } = useForm();
    const onSubmit = (data) => {
        data = {
            ...data,
            categoryId: Number(data.categoryId),
            price: Number(data.price),
        };
        var formData = new FormData();

        formData.append('name', data.name);
        formData.append('price', data.price);
        formData.append('categoryId', data.categoryId);

        [...data.images].forEach(image => {
            formData.append('images', image);
        });
        handleCreateProduct(formData);
        history.push('/product');
    };
    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input {...register("name")} placeholder="Name" />
            <input {...register("price")} placeholder="Price" formEncType='multipart/form-data' />
            <select {...register("categoryId")}>
                <option>Select ProductCategory </option>
                {categories.map((cate, index) =>
                    <option value={cate.id}>{cate.name}</option>)}
            </select>
            <input type='file' multiple {...register("images")} />
            <input type="submit" />
        </form>
    );
}


export default Addform;

