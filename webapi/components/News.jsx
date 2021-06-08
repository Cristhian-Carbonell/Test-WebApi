import React, { useEffect, useState } from "react";
import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function useDatos() {


  const baseUrlCity="http://localhost:58042/api/NewsWeather";
  const baseUrl="http://localhost:58042/api/NewsWeather?city=Bogota";

  const [data, setData]=useState([]);

  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  console.log(data);
  useEffect(()=>{
    peticionGet();
  },[])

  return data
}


export default function Datos() {

  const data = useDatos()

  return (
    <div className="container mt-5" align="center">

      <h4>Listado de Noticias</h4>

      <div className="row">

        <div className="col-md-12">

          <table className="table table-bordered">
            <thead className="thead-dark">
              <tr>
                <th scope="col">Author</th>
                <th scope="col">Title</th>
                <th scope="col">Description</th>
                <th scope="col">Url</th>
                <th scope="col">Content</th>
              </tr>
            </thead>
            <tbody>

            {data.map(item => (

              <tr key={item.id}>

                <td>{item.author}</td>
                <td>{item.title}</td>
                <td>{item.description}</td>
                <td>{item.url}</td>
                <td>{item.content}</td>
              </tr>

            ))}

            </tbody>

          </table>

        </div>

      </div>


    </div>

  )
}
