import axios from "axios";
import React, { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { host } from "../../config";
import { ProductContext } from '../../contexts/products';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useHistory } from "react-router-dom";


const Editform = (props) => {
    const id = props.location.id;
    const productItem = props.location.product;
    const history = useHistory();


    const { categories, handleEditProduct } = useContext(ProductContext);
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
        handleEditProduct(formData, id);
        history.push('/product');



    };
    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <label>Name: </label>
            <input  {...register("name")} placeholder="Name" />
            <label>Price: </label>
            <input {...register("price")} placeholder="Price" formEncType='multipart/form-data' />
            <label>Catgory: </label>
            <select {...register("categoryId")}>
                <option selected={true} value={productItem.categoryId}>{productItem.categoryName} </option>
                {categories.map((cate, index) =>
                    <option value={cate.id}>{cate.name}</option>)}
            </select>
            <input type='file' multiple {...register("images")} />
            <input type="submit" />
        </form>
    );
}


export default Editform;