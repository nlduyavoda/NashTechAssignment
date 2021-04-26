import React, { useContext, useState } from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  NavbarText
} from 'reactstrap';
import { Link } from 'react-router-dom';
import { Addform } from '../../components/form/product/add';
import Button from '@material-ui/core/Button';
// import { ProductContext } from '../../contexts/products';

export default (props) => {
  const [isOpen, setIsOpen] = useState(false);
  // const { cart, total } = useContext(ProductContext);

  const toggle = () => setIsOpen(!isOpen);

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">Admin - Dashboard</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <NavItem>
              <NavLink href="/components/">Components</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="https://github.com/reactstrap/reactstrap">GitHub</NavLink>
            </NavItem>
            <UncontrolledDropdown nav inNavbar>
            </UncontrolledDropdown>
          </Nav>
          <Button variant="contained" id="button-createProduct" color="primary">
            <Link to='/components/form/product/Addform'>
              Create Product
                  </Link>
          </Button>
          <Link to='/cartdetail'>
            <NavbarBrand NavbarBrand >
              {/* {cart.length} items - ${total} */}
            </NavbarBrand>
          </Link>

        </Collapse>
      </Navbar>
    </div>
  );
}
