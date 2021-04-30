import React, { useContext, useState } from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  Dropdown,
  ButtonDropdown,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from 'reactstrap';
import { Link } from 'react-router-dom';
import Button from '@material-ui/core/Button';
import { AuthContext } from '../../contexts/authContext';
import { useSelector } from "react-redux";
import { signoutRedirect } from "../../services/authService";

export default (props) => {
  const [isOpen, setIsOpen] = useState(false);
  // const { cart, total } = useContext(ProductContext);
  const user = useSelector((state) => state.auth.user);
  const signOut = () => signoutRedirect();
  const { isAuth } = useContext(AuthContext)
  const [dropdownOpen, setOpen] = useState(false);
  const toggle = () => setOpen(!dropdownOpen);
  console.log('isAuth', isAuth)
  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">Admin - Dashboard</NavbarBrand>
        {
          isAuth ?
            <Dropdown nav isOpen={dropdownOpen} toggle={toggle}>
              <DropdownToggle caret>
                Action
          </DropdownToggle>
              <DropdownMenu>
                <DropdownItem header>
                  <Link to='/category'>
                    Category manage
              </Link>
                </DropdownItem>
                <DropdownItem header>
                  <Link to='/components/form/product/Addform'>
                    Create Product
              </Link>
                </DropdownItem>
              </DropdownMenu>
            </Dropdown> :
            <Dropdown nav isOpen={dropdownOpen} toggle={toggle}>
              <DropdownToggle caret>Login to active
              </DropdownToggle>
            </Dropdown>
        }
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <UncontrolledDropdown nav inNavbar>
            </UncontrolledDropdown>
          </Nav>
          <div className="float-right ">
            <span>Hello,{user?.profile.name}</span>
            <Button
              color="link"
              onClick={signOut}
              className="pl-3 text-danger"
              size="sm"
            >
              Sign Out
        </Button>
          </div>
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
