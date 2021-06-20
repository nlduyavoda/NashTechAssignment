import React, { Component } from "react";
import axios from "axios";
import { Table, Button } from 'reactstrap';
import { PenFill, Trash2Fill, TruckFlatbed } from 'react-bootstrap-icons';
import { Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import { ProductContext } from '../../contexts/products';
import { useContext, useState } from 'react';
import { host } from "../../config";
import Swal from 'sweetalert2'
import { useHistory } from "react-router";




const ShowCategory = () => {
  const { categories } = useContext(ProductContext);
  const { editable } = useState(false);
// console.log(categories)
  return (
    <form>
      <Table responsive={true} color={true} striped={true}>
        <thead>
          <tr>
            <th>STT</th>
            <th>Category Name</th>
            <th>Category Images</th>
            <th>
              <Link to='/add-category'>
                Create Category +
                </Link>
            </th>
          </tr>
        </thead>
        <tbody>
          {categories.map((cate, index) => (
            <tr key={cate.id}>
              <th className="align-middle" scope="row">
                {index + 1}
              </th>
              <td className="align-middle">
                {editable ? 'asd' : <p>{cate.name}</p>}
              </td>
              <td>
                <img
                  className="img-fluid"
                  src={host + '/' + cate.pathImage}
                  alt="alu alu"
                />
              </td>


              <td className="align-middle">
                <Button color="secondary" className="mr-2">
                  <Link to={{
                    pathname: '/edit-category',
                    id: cate.id,
                    category: {
                      name: cate.name,
                      pathImage: null,
                    }
                  }}>
                    <PenFill color="white" size={20} />
                  </Link>
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </form>
  )
}
export default ShowCategory
