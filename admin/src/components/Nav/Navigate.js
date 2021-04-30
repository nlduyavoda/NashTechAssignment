import { Link } from "react-router-dom";
import { NavItem } from "reactstrap";

return (
    <div>
        <Nav vertical>
            <NavItem>
                <Link className="text-decoration-none" to="/"></Link>
            </NavItem>
            <NavItem>
                <NavLink>
                    {/* <Link className="text-decoration-none" to="/">
                        Users
                    </Link> */}
                </NavLink>
            </NavItem>
        </Nav>
    </div>
);
