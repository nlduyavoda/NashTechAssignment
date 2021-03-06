import React, { Component } from "react";
import axios from "axios";
import { Table, Button } from "reactstrap";
import { PenFill, Trash2Fill, TruckFlatbed } from "react-bootstrap-icons";
import { Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import { ProductContext } from "../../contexts/products";
import { useContext, useState } from "react";
import { host } from "../../config";
import Swal from "sweetalert2";
import { ButtonBase } from "@material-ui/core";

const ShowProduct = () => {
  const { products, handleDelete } = useContext(ProductContext);
  const { editable } = useState(false);
  console.log("zzzzzzz", products);
  const deleteForm = (prod) => {
    console.log("proID: ", prod.id);
    console.log("proIsDelete: ", prod.isDelete);
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!",
    }).then((result) => {
      if (result.isConfirmed) {
        console.log("is Confirmed", prod.isDelete);
        result = !prod.isDelete;
        console.log(result);
        handleDelete(prod.id);

        Swal.fire("Deleted!", "Your file has been deleted.", "success");
      }
    });
  };
  return (
    <form>
      <Table responsive={true} color={true} striped={true}>
        <thead>
          <tr>
            <th>STT</th>
            <th>Product ID</th>
            <th>Product Name</th>
            <th>Product Price</th>
            <th>Category</th>
            <th>Product Images</th>
            <th>
              <Link to="/add-product">Create Product +</Link>
            </th>
          </tr>
        </thead>
        <tbody>
          {products.map((prod, index) =>
            prod.isDelete ? (
              <tr key={prod.id}>
                <th className="align-middle" scope="row">
                  {index + 1}
                </th>
                <td className="align-middle">
                  {editable ? "asd" : <p>{prod.id}</p>}
                </td>
                <td className="align-middle">
                  {editable ? "asd" : <p>{prod.name}</p>}
                </td>
                <td className="align-middle">$ {prod.price}</td>
                <td className="align-middle"> {prod.categoryName}</td>
                {prod.images.length > 0 && (
                  <td>
                    <img
                      className="img-fluid"
                      src={
                        host +
                        "/" +
                        prod.images[prod.images.length - 1].pathImage
                      }
                      alt="alu alu"
                    />
                  </td>
                )}

                <td className="align-middle">
                  <Button color="secondary" className="mr-2">
                    <Link
                      to={{
                        pathname: "/edit-product",
                        id: prod.id,
                        product: {
                          name: prod.name,
                          price: prod.price,
                          categoryId: prod.categoryId,
                          categoryName: prod.categoryName,
                          images: null,
                        },
                      }}
                    >
                      <PenFill color="white" size={20} />
                    </Link>
                  </Button>
                  <Button
                    type="button"
                    value={prod.id}
                    onClick={() =>
                      deleteForm({
                        id: prod.id,
                        isDelete: prod.isDelete,
                      })
                    }
                    className="mr-2"
                  >
                    <Trash2Fill color="white" size={20} />
                  </Button>
                </td>
              </tr>
            ) : (
              ""
            )
          )}
        </tbody>
      </Table>
    </form>
  );
};
export default ShowProduct;
