import React, { useContext, useState } from "react";
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
} from "reactstrap";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import { AuthContext } from "../../contexts/authContext";
import { useSelector } from "react-redux";
import { signoutRedirect, signinRedirect } from "../../services/authService";

export default (props) => {
  const [isOpen, setIsOpen] = useState(false);
  // const { cart, total } = useContext(ProductContext);
  const user = useSelector((state) => state.auth.user);
  console.log(user);
  const signOut = () => signoutRedirect();
  const { isAuth } = useContext(AuthContext);
  const [dropdownOpen, setOpen] = useState(false);
  const toggle = () => setOpen(!dropdownOpen);
  const handleClick = () => signinRedirect();
  console.log(isAuth);
  // if (!isAuth) return (
  //   <div className='text-white'>
  //     <div>UnAuthorization</div>
  //     <button onClick={handleLogin} className='button'>
  //       login
  //     </button>
  //   </div>
  // )

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">Admin - Dashboard</NavbarBrand>
        <Dropdown nav isOpen={dropdownOpen} toggle={toggle}>
          <DropdownToggle caret>Action</DropdownToggle>
          <DropdownMenu>
            <DropdownItem header>
              <Link to="/product">Product manage</Link>
            </DropdownItem>
            <DropdownItem header>
              <Link to="/category">Category manage</Link>
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <UncontrolledDropdown nav inNavbar></UncontrolledDropdown>
          </Nav>
          <div className="float-right ">
            {isAuth ? <span>Hello,{user?.profile.name}</span> : ""}
            <span>Hello,{user?.profile.name}</span>
            <Button
              color="link"
              className="pl-3 text-danger"
              size="sm"
              onClick={handleClick}
            >
              Login
            </Button>
            <Button
              color="link"
              onClick={signOut}
              className="pl-3 text-danger"
              size="sm"
            >
              Sign Out
            </Button>
          </div>
          <Link to="/cartdetail">
            <NavbarBrand NavbarBrand>
              {/* {cart.length} items - ${total} */}
            </NavbarBrand>
          </Link>
        </Collapse>
      </Navbar>
    </div>
  );
};
