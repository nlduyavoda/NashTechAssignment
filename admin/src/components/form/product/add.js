import { Formik } from "formik";
import React, { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import ProductProvider, { ProductContext } from '../../../contexts/products';



// import { ProductContext } from "../contexts/products";

const Addform = () => {
    const { products } = useContext(ProductContext);
    const { register, handleSubmit } = useForm();
    const onSubmit = (data) => alert(JSON.stringify(data));
    console.log(products)
    // let category_names = products.map(products.categoriesName);
    // console.log(category_names);z
    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input {...register("name")} placeholder="Name" />
            <input {...register("price")} placeholder="Price" />
            <select {...register("category")}>
                <option value="">Select categoy </option>


                {products.map((cate_name, index) =>
                    <option value={cate_name.categoryName}>{cate_name.categoryName}</option>)}
            </select>
            <input type="submit" />
        </form>
    );
}

export default Addform;

