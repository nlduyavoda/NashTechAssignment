import React from 'react';

export default ({
  name, price, image, type, description
}) => {
  console.log(name, price, image, type, description);
  return (
    <div>
      {name}
    </div>
  )
}