import React, { Fragment, useState } from "react";
import { Link } from "react-router-dom";
import { baseUrl } from './constants';
import axios from "axios";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = (e) => {
    e.preventDefault();
    let error = '';
    if (username === '')
      error = error + 'username, ';

    if (password === '')
      error = error + 'Password ';

    if (error.length > 0) {
      error = error + 'can not be blank';
      alert(error);
      return;
    }

    const data = {
      username: username,
      password: password,
    };
    const url = `${baseUrl}/api/users/login`;
    axios
      .post(url, data)
      .then((result) => {
        if (result.status === 200) {
          console.log(result.data.token);
          localStorage.setItem('loginToken', result.data.token);
          localStorage.setItem('loggedUserId', result.data.userId);
          localStorage.setItem("loggedEmail", result.data.id);
          if (username === "admin1" && password === "1234") {
            window.location.href = "/admindashboard";
          } else {
            window.location.href = "/dashboard";
          }
        } else {
          alert("Invalid user");
        }
      })
      .catch((error) => {
        alert("Invalid user");
        console.log(error);
      });
  };

  return (
    <Fragment>
      <div
        style={{
          backgroundColor: "rgba(255, 255, 255, 0.9)",
          backgroundImage:
            'url(https://images.pexels.com/photos/2064124/pexels-photo-2064124.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2)',
          backgroundSize: "cover",
          width: "100vw",
          height: "100vh",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <div
          className="card"
          style={{
            width: "400px",
            borderRadius: "10px",
            boxShadow: "0 0 10px rgba(0, 0, 0, 0.2)",
            background: "transparent",
          }}
        >
          <div className="card-body">
            <h3 className="card-title text-center mb-4">Login Page</h3>
            <form>
              <div className="form-group mb-4">
                <input
                  type="email"
                  className="form-control form-control-lg"
                  onChange={(e) => setUsername(e.target.value)}
                  value={username}
                  placeholder="Enter username"
                  style={{ background: "rgba(255, 255, 255, 0.7)" }}
                />
              </div>

              <div className="form-group mb-4">
                <input
                  type="password"
                  className="form-control form-control-lg"
                  onChange={(e) => setPassword(e.target.value)}
                  value={password}
                  placeholder="Enter Password"
                  style={{ background: "rgba(255, 255, 255, 0.7)" }}
                />
              </div>

              <button
                type="submit"
                className="btn btn-primary btn-lg btn-block mb-3"
                onClick={handleLogin}
              >
                Sign in
              </button>
              <Link to="/Registration" className="btn btn-info btn-lg btn-block">
                Registration
              </Link>
            </form>
          </div>
        </div>
      </div>
    </Fragment>
  );
}
