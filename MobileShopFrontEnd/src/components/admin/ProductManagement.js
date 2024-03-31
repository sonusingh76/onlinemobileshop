import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import AdminHeader from "./AdminHeader";
import { baseUrl } from "../constants";

export default function ProductManagement() {
  const [data, setData] = useState([]);
  const [productId, setproductId] = useState("");
  const [brand, setBrand] = useState("");
  const [price, setPrice] = useState(0);
  const [model, setModel] = useState("");
  const [description, setDescription] = useState("");
  const [imgUrl, setImgUrl] = useState("");
  const [addUpdateFlag, setAddUpdateFlag] = useState(true);

  const AddProduct = async (e) => {
    e.preventDefault();
    let error = '';
    if (brand === '')
      error += 'Brand ,';
    if (model === '')
      error += 'model ,';
    if (price === '')
      error += 'Price ';
      if (description === '')
      error += 'description ';
      if (imgUrl === '')
      error += 'imgUrl ';

    if (error === '') {
      const token = localStorage.getItem('loginToken');
      const config = {
        headers: { Authorization: `Bearer ${token}` }
    };
      const data = {
        brand: brand,
        model: model,
        price: price,
        description: description,
        imageUrl: imgUrl
      };
      const url = `${baseUrl}/api/mobiles`;
      axios
        .post(url, data, config)
        .then((result) => {
          debugger
          if (result.status === 200) {
            getData();
            Clear();
          }
        })
        .catch((error) => {
          console.log(error);
        });
    }
    else {
      error += ' are mandatory fields.'
      alert(error);
    }
  };

  const Clear = () => {
    setBrand("");
    setPrice("");
    setModel("");
    setDescription("");
    setImgUrl("");
  };

  useEffect(() => {
    getData();
  }, []);

  const getData = () => {    
    const url = `${baseUrl}/api/mobiles`;
    axios
      .get(url)
      .then((result) => {
        if(result.status === 200)
        {
          setData(result.data);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const DeleteProduct = (e, id) => {
    debugger;
    if(window.confirm('Are you sure to delete this product'))
    {
    e.preventDefault();  
    const token = localStorage.getItem('loginToken');
    const config = {
      headers: { Authorization: `Bearer ${token}` }
    };  
    const url = `${baseUrl}/api/mobiles/${id}`;
    axios
      .delete(url,config)
      .then((result) => {
        if(result.status === 200)
        {
          getData();
          alert('Record deleted.');
        }
      })
      .catch((error) => {
        console.log(error);
      });
    }
  };

  const EditProduct = (e, id) => {
    e.preventDefault();
    setAddUpdateFlag(false);    
    const token = localStorage.getItem('loginToken');
    const config = {
      headers: { Authorization: `Bearer ${token}` }
    };  
    const url = `${baseUrl}/api/mobiles/${id}`;
    axios
      .get(url,config)
      .then((result) => {
        if(result.status === 200)
        {        
          setproductId(id);
          setBrand(result.data.brand);
          setModel(result.data.model);
          setDescription(result.data.description);
          setPrice(result.data.price);
          setImgUrl(result.data.imageUrl)
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const UpdateProduct = (e) => {
    debugger
    e.preventDefault();
    let error = '';
    if (brand === '')
      error += 'Brand ,';
    if (model === '')
      error += 'model ,';
    if (price === '')
      error += 'Price ';
      if (description === '')
      error += 'description ';
      if (imgUrl === '')
      error += 'imgUrl ';

    if (error === '') {
      const token = localStorage.getItem('loginToken');
      const config = {
        headers: { Authorization: `Bearer ${token}` }
    };
      const data = {
        id: productId,
        brand: brand,
        model: model,
        price: price,
        description: description,
        imageUrl: imgUrl
      };
      
      const url = `${baseUrl}/api/mobiles/${productId}`;
      axios
        .put(url, data, config)
        .then((result) => {
          if (result.status === 200) {
            getData();
            Clear();
            alert('Record updated.');
          }
        })
        .catch((error) => {
          console.log(error);
        });
    }
    else {
      error += ' are mandatory fields.'
      alert(error);
    }
  };

  return (
    <Fragment>
      <AdminHeader />
      <br></br>
      <form>
        <div
          class="form-row"
          style={{ width: "80%", backgroundColor: "white", margin: " auto" }}
        >
          <div class="form-group col-md-12">
            <h3>Mobiles Management</h3>
          </div>
          <div className="form-group col-md-6">
            <input
              type="text"
              onChange={(e) => setBrand(e.target.value)}
              placeholder="Brand"
              className="form-control"
              required
              value={brand}
            />
          </div>
          <div className="form-group col-md-6">
            <input
              type="text"
              onChange={(e) => setModel(e.target.value)}
              placeholder="Model"
              className="form-control"
              required
              value={model}
            />
          </div>

          <div className="form-group col-md-6">
            <input
              type="number"
              className="form-control"
              id="validationTextarea"
              placeholder="Price"
              onChange={(e) => setPrice(e.target.value)}
              required
              value={price}
            ></input>
          </div>
          <div className="form-group col-md-6">
            <input
              type="text"
              onChange={(e) => setDescription(e.target.value)}
              placeholder="Description"
              className="form-control"
              required
              value={description}
            />
          </div>
          <div className="form-group col-md-6">
            <input
              type="text"
              onChange={(e) => setImgUrl(e.target.value)}
              placeholder="Image Url"
              className="form-control"
              required
              value={imgUrl}
            />
          </div>
          <div className="form-group col-md-6">

            {addUpdateFlag ? (
              <button
                className="btn btn-primary"
                style={{ width: "150px", float: "left" }}
                onClick={(e) => AddProduct(e)}
              >
                Add
              </button>
            ) : (
              <button
                className="btn btn-primary"
                style={{ width: "150px", float: "left" }}
                onClick={(e) => UpdateProduct(e)}
              >
                Update
              </button>
            )}
            <button
              className="btn btn-danger"
              style={{ width: "150px" }}
              onClick={(e) => Clear(e)}
            >
              Reset
            </button>
          </div>
        </div>
      </form>
      {data ? (
        <table
          className="table stripped table-hover mt-4"
          style={{ backgroundColor: "white", width: "80%", margin: "0 auto" }}
        >
          <thead className="thead-dark">
            <tr>
              <th scope="col">#</th>
              <th scope="col">Brand</th>
              <th scope="col">Model</th>
              <th scope="col">Price</th>
              <th scope="col">Description</th>
              <th scope="col">Image</th>
              <th scope="col" colSpan="2">
                Action
              </th>
            </tr>
          </thead>
          <tbody>
            {data.map((val, index) => {
              return (
                <tr key={index}>
                  <td scope="row">{index + 1}</td>
                  <td>{val.brand}</td>
                  <td>{val.model}</td>
                  <td>{val.price}</td>
                  <td>{val.description}</td>
                  <td><img src={val.imageUrl} style={{width:"50px"}} /></td>
                  <td>
                    <button onClick={(e) => EditProduct(e, val.id)}>
                      Edit
                    </button>{" "}
                 |{" "}
                    <button onClick={(e) => DeleteProduct(e, val.id)}>
                      Delete
                    </button>{" "}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      ) : (
        "No data found"
      )}
    </Fragment>
  );
}
