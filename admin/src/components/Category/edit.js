import axios from "axios";
import React, { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useHistory } from "react-router";
import { host } from "../../config";
import ProductProvider, { ProductContext } from "../../contexts/products";
import "bootstrap/dist/css/bootstrap.min.css";

const EditCategory = (props) => {
  const id = props.location.id;
  const history = useHistory();
  const [currentImages, setCurrentImages] = useState([]);
  const { categories, handleEditCategory } = useContext(ProductContext);
  const { register, handleSubmit } = useForm();
  const onSubmit = (data) => {
    data = {
      ...data,
      pathImage: data.pathImage[0],
    };
    var formData = new FormData();
    formData.append("name", data.name);
    formData.append("PathImage", data.pathImage);

    // for (var value of formData.values()) {
    //   console.log(value);
    // }
    handleEditCategory(formData, id);
    setCurrentImages([]);
    history.push("/category");
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <label>Name: </label>
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

export default EditCategory;
