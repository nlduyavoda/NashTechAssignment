import axios from "axios";
import { Formik } from "formik";
import React, { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { host } from "../../config";
import ProductProvider, { ProductContext } from "../../contexts/products";
// import RequestService from "../../../services/request";
import "bootstrap/dist/css/bootstrap.min.css";
import { useHistory } from "react-router-dom";
// import { ProductContext } from "../contexts/products";
const Addcategory = () => {
  const { handleCreateCategory } = useContext(ProductContext);
  const [currentImages, setCurrentImages] = useState([]);
  const { register, handleSubmit } = useForm();
  const history = useHistory();
   const  onSubmit  = (data) => {
    data = {
      ...data,
      pathImage: data.pathImage[0],
    };
    // console.log(data);
    var formData = new FormData();
    formData.append("name", data.name);
    formData.append("PathImage", data.pathImage);

    // for (var value of formData.values()) {
    //   console.log(value);
    // }
    handleCreateCategory(formData);
    setCurrentImages([]);
    history.push("/category");
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("name")} placeholder="Name" />
      <input
        type="file"
        {...register("pathImage")}
        onChange={(e) => {
          setCurrentImages([...e.target.files]);
        }}
      />
      <input type="submit" />
    </form>
  );
};
export default Addcategory;
