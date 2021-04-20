import { Formik } from "formik";
import React, { useContext } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
// import { ProductContext } from "../contexts/products";

export const Addform = () => {
    // const { productitems } = useContext(ProductContext);
    return (
        <Formik>
            {formikProps => {
                //do some thing
                return (
                    <FormGroup row>
                        <Label sm={2}>Price</Label>
                        <Col sm={10}>
                            <Controller
                                name="productPrice"
                                control={control}
                                defaultValue=""
                                render={({ field }) => (
                                    <Input
                                        {...field}
                                        type="number"
                                        placeholder="enter product price"
                                    />
                                )}
                            />
                        </Col>
                    </FormGroup>
                )
            }}
        </Formik>
    );
};

// import React from "react";

// const Home = () => {
//     return <h1> Home page</h1>;
// };
// export default Home;
