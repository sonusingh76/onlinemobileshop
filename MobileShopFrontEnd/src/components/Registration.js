
import React, { Fragment, useState } from "react";
import { Link } from "react-router-dom";
import { baseUrl } from './constants';
import axios from "axios";

export default function Registration() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [email, setEmail] = useState("");
  const [isAdmin, setIsAdmin] = useState(false);

  const handleSave = (e) => {
    let error = "";
    if (password === confirmPassword) {
      if (!validateUsername(username)) {
        alert("Username can only start with alphabate, contain letters, numbers, underscores, and hyphens");
        return;
      }
      if (!validateEmail(email)) {
        alert("Please enter a valid email address");
        return;
      }
      if (password === "") error = error + "Password, ";

      if (error.length > 0) {
        error = error.substring(0, error.length - 1) + " can not be blank";
        alert(error);
        return;
      }

      e.preventDefault();
      const url = `${baseUrl}/api/users/register`;
      const data = {
        username: username,
        password: password,
        confirmPassword: password,
        email: email,
        isAdmin: isAdmin
      };

      axios
        .post(url, data)
        .then((result) => {
          if (result.status === 200) {
            clear();
            const dt = result.data;
            alert("Registration completed.");
          } else {
            alert("Some error occurred. Try again after some time.");
          }
        })
        .catch((error) => {
          console.log(error);
        });
    } else {
      alert("Password and confirm password do not match");
    }
  };

  const validateUsername = (username) => {
    const pattern = /^[a-zA-Z][a-zA-Z0-9_-]*$/;
    return pattern.test(username);
  };

  const validateEmail = (email) => {
    const pattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return pattern.test(email);
  };

  const clear = () => {
    setUsername("");
    setEmail("");
    setPassword("");
    setConfirmPassword("");
  };

  return (
    <Fragment>
      <div
        className="registration-page"
        style={{
          backgroundColor: "white",
          backgroundImage: 'url(https://images.pexels.com/photos/1772123/pexels-photo-1772123.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2)',
          backgroundSize: "cover",
          width: "100vw",
          height: "100vh",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <div className="registration-card">
          <h3 className="registration-title">Registration Page</h3>
          <div className="registration-form">
            <div className="form-group">
              <i className="fas fa-user fa-lg form-icon"></i>
              <input
                type="text"
                className="form-control"
                style={{ width: "100%" }}
                placeholder="Username"
                onChange={(e) => setUsername(e.target.value)}
                value={username}
              />
            </div>
            <div className="form-group">
              <i className="fas fa-envelope fa-lg form-icon"></i>
              <input
                type="email"
                className="form-control"
                style={{ width: "100%" }}
                placeholder="Email"
                onChange={(e) => setEmail(e.target.value)}
                value={email}
              />
            </div>
            <div className="form-group">
              <i className="fas fa-lock fa-lg form-icon"></i>
              <input
                type="password"
                className="form-control"
                style={{ width: "100%" }}
                placeholder="Password"
                onChange={(e) => setPassword(e.target.value)}
                value={password}
              />
            </div>
            <div className="form-group">
              <i className="fas fa-lock fa-lg form-icon"></i>
              <input
                type="password"
                className="form-control"
                style={{ width: "100%" }}
                placeholder="Confirm Password"
                onChange={(e) => setConfirmPassword(e.target.value)}
                value={confirmPassword}
              />
            </div>
            <div className="form-group">
              <button
                type="button"
                className="btn btn-primary btn-lg btn-block"
                onClick={handleSave}
              >
                Register
              </button>
            </div>
            <div className="form-group">
              <Link to="/" className="btn btn-info btn-lg btn-block">
                Login
              </Link>
            </div>
          </div>
        </div>
      </div>
    </Fragment>
  );
}
