import logo from './logo.svg';
import { Container, Table } from 'reactstrap';
import Header from './components/Header';
import './App.css';
import ProductProvider, { ProductContext } from './contexts/products';
import { useContext } from 'react';
import { BrowserRouter, Route } from "react-router-dom";
import CartDetail from './Container/CartDetail';
import Home from './Container/Home';
import Addform from './components/form/product/add';
import 'bootstrap/dist/css/bootstrap.min.css';



function App() {
  const { products } = useContext(ProductContext);
  console.log([products])
  const setValue = (date) => {
    console.log(date)

  }
  return (
    <BrowserRouter>
      <Header />
      {/* <TopBanner /> */}
      <Route exact path="/"  >
        <Home />
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
                <td className="align-middle">{prod.name}</td>
                <td className="align-middle">$ {prod.price}</td>
                <td className="align-middle"> {prod.categoryName}</td>
                {prod.images.length > 0 && (
                  <td>
                    <img
                      className="img-fluid"
                      src={prod.images[0].pathImage}
                      alt="alu alu"
                    />
                  </td>
                )}

                <td className="align-middle">
                  <button className="btn btn-primary" onClick={() => setValue(!prod.isDelete)}>Edit</button>
                  <button className="btn btn-danger" onClick={() => setValue(!prod.isDelete)}>Delete</button>
                </td>
              </tr> : ''
            ))}
          </tbody>
        </Table>
        {/* <ProductContext.Provider value={this.products.name}>
          <Content />
        </ProductContext.Provider> */}
      </Route>
      <Route exact path="/CartDetail">
        <CartDetail />
      </Route>
      <Route exact path="/components/form/product/Addform">
        <h1>
          Form create product
     </h1>
        <Addform />
      </Route>

    </BrowserRouter>
  );
}

export default App;
