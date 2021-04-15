import React, { useContext } from 'react';
import { Card, CardImg, CardText, CardBody, CardTitle, CardSubtitle, Button } from 'reactstrap';
import { ProductContext } from '../../contexts/products';

export default (props) => {
  const {id, name, price, image, type, description } = props;

  const {addToCart} = useContext(ProductContext);

  const handleAddToCart = () => {
    addToCart(id);
  }

  return (
    <div className='my-2'>
      <Card>
        <CardBody>
          <CardImg top width="100%" src={image} alt="Card image cap" />
          <CardTitle tag="h5">{name}</CardTitle>
          <CardSubtitle tag="h6" className="mb-2 text-muted">${price}</CardSubtitle>
          <CardSubtitle tag="h6" className="mb-2 text-muted">{type}</CardSubtitle>
          <CardText>{description}</CardText>
          <Button onClick={handleAddToCart}>Add to Cart</Button>
        </CardBody> 
      </Card>
    </div>
  )
}
