import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import Header from "./AdminHeader";
import { baseUrl } from "../constants";
import "./Orders.css";

  const Orders = () => {
  const [data, setData] = useState([]);


  useEffect(() => {
    getData();
  }, []);

  const getData = () => {    
    const url = `${baseUrl}/api/orders`;    
    axios
      .get(url)
      .then((result) => {
        if(result.status === 200)
        {
          setData(result.data)
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <Fragment>
      <Header />
      <div className="container">
        <h3 className="page-title">Orders</h3>
        {data.length > 0 ? (
          <table className="table">
            <thead>
              <tr>
                <th>#</th>
                <th>Mobile Id</th>
                <th>Customer Name</th>
                <th>Customer Email</th>
                <th>Shipping Address</th>
              </tr>
            </thead>
            <tbody>
              {data.map((order, index) => (
                <tr key={order.id}>
                  <td>{index + 1}</td>
                  <td>{order.mobileId}</td>
                  <td>{order.customerName}</td>
                  <td>{order.customerEmail}</td>
                  <td>{order.shippingAddress}</td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : (
          <p className="no-data">No data found</p>
        )}
      </div>
    </Fragment>
  );
};

export default Orders;

