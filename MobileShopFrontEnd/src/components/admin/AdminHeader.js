import React, {useState,Fragment,useEffect} from  'react';
import { Link } from "react-router-dom";

export  default function AdminHeader(){    
    const [username, setUserName] = useState("");

    useEffect(() => {
      setUserName(localStorage.getItem("username"));
    }, []);
  
    const logout = (e) => {
      e.preventDefault();
      localStorage.removeItem("username");
      window.location.href = "/";
    };
  
    return (
      <Fragment>
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
          <a className="navbar-brand" href="#">
           Admin Portal
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
  
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav mr-auto"> 
            <li className="nav-item">
                <Link to="/myorders" className="nav-link">
                  Total Orders
                </Link>
              </li>             
              <li className="nav-item">
                <Link to="/productmanagement" className="nav-link">
                  Product Managment
                </Link>
              </li>                          
            </ul>
            <form className="form-inline my-2 my-lg-0">
              <button
                className="btn btn-outline-success my-2 my-sm-0"
                type="submit"
                onClick={(e) => logout(e)}
              >
                Logout
              </button>
            </form>
          </div>
        </nav>
      </Fragment>
    );
}