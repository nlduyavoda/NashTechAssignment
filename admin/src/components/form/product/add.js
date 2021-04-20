import { Formik } from "formik";
import React, { useContext, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
// import { ProductContext } from "../contexts/products";

const Addform = () => {
    const [value, setvalue] = useState({
        name: "carrot",
        price: 299
    })
    const [summitted, setSummit] = useState(false)
    const [valid, setValid] = useState(false)
    const handleNameProductInputChange = (event) => {
        // setvalue({ ...value, name: event.target.value })
    }
    const handlePriceProductInputChange = (event) => {
        // setvalue({ ...value, price: event.target.value })
    }
    const handleSummit = (event) => {
        setvalue({ ...value, price: event.target.value })
        setvalue({ ...value, name: event.target.value })
        event.preventDefault();
        setSummit(true);
    }
    console.log(value.name, value.price, "log form");
    return (
        <Formik>
            <div className="form-container">
                <form className="register-form" onSt={handleSummit}>
                    {summitted ? <div className="success-message">Success !</div> : null}
                    <input onChange={handleNameProductubmiInputChange}
                        value={value.name}
                        className="form-field"
                        name="name"></input>
                    <input onChange={handlePriceProductInputChange}
                        value={value.price}
                        className="form-field"
                        name="price"></input>
                    <button className="btn btn-danger"
                        type="submit">Create</button>
                </form>
            </div>
        </Formik>
    );
}

export default Addform;


// import React from "react";

// const Home = () => {
//     return <h1> Home page</h1>;
// };

