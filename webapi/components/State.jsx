import React from "react"

function useDatos() {


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
                <th scope="col">Temperatura</th>
                <th scope="col">Description</th>
                <th scope="col">Wind Speed</th>
                <th scope="col">Wind Degree</th>
                <th scope="col">Pressure</th>
                <th scope="col">Humidity</th>
                <th scope="col">Visibility</th>
              </tr>
            </thead>
            <tbody>

            {data.map(item => (

              <tr key={item.id}>

                <td>{item.temperature}</td>
                <td>{item.wheather_description}</td>
                <td>{item.wind_speed}</td>
                <td>{item.wind_degree}</td>
                <td>{item.pressure}</td>
                <td>{item."humidity}</td>
                <td>{item."visibility}</td>
              </tr>

            ))}

            </tbody>

          </table>

        </div>

      </div>


    </div>

  )
}
