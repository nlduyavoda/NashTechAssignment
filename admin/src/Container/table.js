import React, { useContext } from "react";
import { Table, Button } from "reactstrap";
import { ProductContext } from "../contexts/products";

export const MyTable = () => {
    const { productitems } = useContext(ProductContext);
    const [categories] = useContext(ProductContext);

    console.log(productitems)
    console.log(categories)
    return (
        <div>table-container</div>
    );
};