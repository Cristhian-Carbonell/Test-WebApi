import React, { Component} from 'react';
import { render } from 'react-dom';
import './index.css';
import Menu from './Menu';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter as Router, Route, Link, Switch} from 'react-router-dom';
import News from './components/News';
import State from './components/State';
import 'bootstrap/dist/css/bootstrap.min.css';


class App extends Component {
  render() {
    return (
      <>
      <div className="app s-py-2">
        <h1 className="s-center">Bienvenidos, Consultar Noticias nacionales e internacionales y estado del tiempo</h1>
        <Router>
          <ul className="nav-container s-border s-main-center s-pl-0">
            <li className="nav-container--item s-mr-2">
            <Link to="/news">Noticias</Link></li>
            <li className="nav-container--item s-mr-2">
            <Link to="/state">Estado de tiempo</Link></li>
            <li className="nav-container--item s-mr-2">
            <Link to="/city">Ciudades</Link></li>
        </ul>
        <Switch>
          <Route exact path="/news" component={News}/>
          <Route exact path="/state" component={State}/>
        </Switch>
        </Router>
      </div>
      </>
    );
  }
}

render(<App />, document.getElementById('root'));
