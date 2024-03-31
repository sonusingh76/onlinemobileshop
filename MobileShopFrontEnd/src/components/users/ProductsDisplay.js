import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import { baseUrl } from "../constants";
import Header from "./Header";

import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

export default function ProductsDisplay() {
  const [data, setData] = useState([]);
  const [customerName, setCustomerName] = useState('');
  const [customerEmail, setCustomerEmail] = useState('');
  const [shippingAddress, setShippingAddress] = useState('');
  const [show, setShow] = useState(false);
  const [showPayment, setShowPayment] = useState(false);
  const [productId, setProductId] = useState("");
  const [orderId, setOrderId] = useState("");
  const [price, setPrice] = useState("");
  const [formError, setFormError] = useState(false);

  useEffect(() => {
    getData();
  }, []);

  const getData = () => {
    const url = `${baseUrl}/api/mobiles`;
    axios
      .get(url)
      .then((result) => {
        if (result.status === 200) {
          setData(result.data);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleClose = () => {
    setShow(false);
  };

  const handlePaymentClose = () => {
    setShowPayment(false);
  };

  const handlePlaceOrder = () => {
    if (customerName.trim() === '' || customerEmail.trim() === '' || shippingAddress.trim() === '') {
      setFormError(true);
      return;
    }

    const currentDate = new Date();
    const data = {
      mobileId: productId,
      userId: localStorage.getItem("loggedUserId"),
      customerName: customerName,
      customerEmail: customerEmail,
      shippingAddress: shippingAddress,
      orderDate: currentDate,
      isShipped: true,
      Amount: price,
    };
    const url = `${baseUrl}/api/orders`;
    axios
      .post(url, data)
      .then((result) => {
        if (result.status === 200) {
          setOrderId(result.data.orderId);
          setShow(false);
          setShowPayment(true);
          setCustomerName("");
          setCustomerEmail("");
          setShippingAddress("");
          setFormError(false);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handlePayment = () => {
    const currentDate = new Date();
    const data = {
      amount: price,
      orderId: orderId,
      paymentDate: currentDate,
    };
    const url = `${baseUrl}/api/payments`;
    axios
      .post(url, data)
      .then((result) => {
        if (result.status === 200) {
          setPrice("");
          setShow(false);
          setShowPayment(false);
          alert("Your order has been Placed Successfully");
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleOrderDetails = (e, id, price) => {
    e.preventDefault();
    setShow(true);
    setProductId(id);
    setPrice(price);
  };

  return (
    <Fragment>
      <Header />
      <br></br>
      <div
        style={{
          backgroundColor: "white",
          backgroundImage: 'url(https://images.pexels.com/photos/341523/pexels-photo-341523.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2)',
          width: "99vw",
          height: "97vh",
          backgroundSize: "cover",
          backgroundPosition: "center",
        }}
      >
        <div class="row">
          {data.length > 0 ? (
            data.map((val, index) => (
              <div
                key={index}
                class="col-md-3"
                style={{ marginBottom: "21px" }}
              >
                <div class="card">
                  <div class="card-body">
                    <img src={val.imageUrl} style={{ width: "150px" }} />
                    <hr />
                    <h4 class="card-title">Brand: {val.brand}</h4>
                    <hr />
                    <h4 class="card-title">Description: {val.description}</h4>
                    <hr />
                    <h4 class="card-title">Price: {val.price}</h4>
                    <hr />
                    <button
                      class="btn btn-primary"
                      onClick={(e) => handleOrderDetails(e, val.id, val.price)}
                    >
                      Place Order
                    </button>
                  </div>
                </div>
              </div>
            ))
          ) : (
            <div>Loading products...</div>
          )}
        </div>
      </div>
      <div className="modal-container">
        <Modal show={show} onHide={handleClose} centered>
          <Modal.Header closeButton>
            <Modal.Title>Kindly fill below details</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div className="form-container">
              <div className="form-group">
                <input
                  type="text"
                  onChange={(e) => setCustomerName(e.target.value)}
                  className="form-control"
                  required
                  value={customerName}
                  placeholder="Customer Name"
                />
              </div>
              <div className="form-group">
                <input
                  type="text"
                  onChange={(e) => setCustomerEmail(e.target.value)}
                  className="form-control"
                  required
                  value={customerEmail}
                  placeholder="Customer Email"
                />
              </div>
              <div className="form-group">
                <input
                  type="text"
                  onChange={(e) => setShippingAddress(e.target.value)}
                  className="form-control"
                  required
                  value={shippingAddress}
                  placeholder="Shipping Address"
                />
              </div>
              {formError && (
                <p className="text-danger">Please fill in all the fields.</p>
              )}
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="primary" onClick={handlePlaceOrder}>
              Place Order
            </Button>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>
      </div>
      <div className="modal-container">
        <Modal show={showPayment} onHide={handlePaymentClose} centered>
          <Modal.Header closeButton>
            <Modal.Title>Please Check the Payment Amount</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <div className="form-container">
              <div className="form-group">
                <input
                  type="text"
                  onChange={(e) => setPrice(e.target.value)}
                  className="form-control"
                  required
                  value={price}
                  placeholder="Order Amount"
                />
              </div>
            </div>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="primary" onClick={handlePayment}>
              Cash On Delivery
            </Button>
            <Button variant="secondary" onClick={handlePaymentClose}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>
      </div>
    </Fragment>
  );
}
