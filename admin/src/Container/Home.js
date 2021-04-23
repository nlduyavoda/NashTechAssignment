import React from "react";
import { Table, Button } from 'reactstrap';
import { PenFill } from 'react-bootstrap-icons';
import { Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import { ProductContext } from '../contexts/products';
import { useContext, useState } from 'react';



const Home = () => {
  const { products } = useContext(ProductContext);
  const { editable, setEditable } = useState(false)
  const { deleteable, setDeleteable } = useState(true)
  return (
    <Table responsive={true} color={true} striped={true}>
      <thead>
        <tr>
          <th>STT</th>
          <th>Product Name</th>
          <th>Product Price</th>
          <th>Category</th>
          <th>Product Images</th>
          <th>#</th>
          {/* <th>Product Description</th> */}
        </tr>
      </thead>
      <tbody>
        {products.map((prod, index) => (
          prod.isDelete ? <tr key={prod.id}>
            <th className="align-middle" scope="row">
              {index + 1}
            </th>
            <td className="align-middle">
              {editable ? 'asd' : <p>{prod.name}</p>}
            </td>
            <td className="align-middle">$ {prod.price}</td>
            <td className="align-middle"> {prod.categoryName}</td>
            {prod.images.length > 0 && (
              <td>
                <img
                  className="img-fluid"
                  src={prod.images[prod.images.length - 1].pathImage}
                  alt="alu alu"
                />
              </td>
            )}

            <td className="align-middle">
              <Button color="secondary" className="mr-2">
                <Link to={{
                  pathname: '/components/form/product/Editform',
                  id: prod.id,
                  product: {
                    name: prod.name,
                    price: prod.price,
                    categoryId: prod.categoryId,
                    categoryName: prod.categoryName,
                    images: null,
                  }
                }}>
                  <PenFill color="white" size={20} />
                </Link>
              </Button>
              <Button onClick={setDeleteable => !setDeleteable}
                className="mr-2">Delete</Button>
            </td>
          </tr> : ''
        ))}
      </tbody>
    </Table>
  )
}
export default Home;
