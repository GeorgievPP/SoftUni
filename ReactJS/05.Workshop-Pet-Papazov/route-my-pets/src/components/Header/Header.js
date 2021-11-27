import { Link } from "react-router-dom";

const Header = ({ isAuthenticated, user }) => {

  let guestNavigation = (
    <div id="guest">
      <Link to="/login" className="button">
        Login
      </Link>
      <Link to="/register" className="button">
        Register
      </Link>
    </div>
  );

  let userNavigation = (
    <div id="user">
      <span>Welcome, {user}</span>
      <Link to="/my-pets" className="button">
        My Pets
      </Link>
      <Link to="/create" className="button">
        Add Pet
      </Link>
      <Link className="button" to="">
        Logout
      </Link>
    </div>
  );

  return (
    <header id="site-header">
      <nav className="navbar">
        <section className="navbar-dashboard">
          <Link to="/">Dashboard</Link>

          {isAuthenticated ? userNavigation : guestNavigation}
        </section>
      </nav>
    </header>
  );
};

export default Header;
