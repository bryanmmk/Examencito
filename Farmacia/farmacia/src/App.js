import './App.css';
import { Home } from './Home';
import { Categoria } from './Categoria';
import { Medicamentos } from './Medicamentos';
import { Pedido } from './Pedido';
import { BrowserRouter, Route, Routes, NavLink } from 'react-router-dom';
import { Usuario } from './Usuarios';
import {Administracion} from './Administracion';
import {Proveedor} from './Proveedor';

function App(){
  return (
    <BrowserRouter>
      <div className="App-container">
        <h3 className="m-3 d-flex justify-content-center">
          <img class="Logo" src="BYE-01.png"></img>
        </h3>
        
        <nav className="navbar justify-content-center">
          <a href="Paigna.html.html" class="LinkHtML">
            Volver a la pantalla de Inicio
          </a>
          <ul className="navbar-nav">
            <li className="nav-item- m-1">
              <div className="Colorsitos">
              <NavLink className="btn btn-dark btn-outline-light m-1" to="/categoria">
                Categorias
              </NavLink>
              <NavLink className="btn btn-dark btn-outline-light m-1" to="/medicamentos">
                Medicamentos
              </NavLink>
              <NavLink className="btn btn-dark btn-outline-light m-1" to="/pedido">
                Pedidos
              </NavLink>
              <NavLink className="btn btn-dark btn-outline-light m-1" to="/usuario">
                Usuarios
              </NavLink>
              <NavLink className="btn btn-dark btn-outline-light m-1" to="/proveedor">
                Proveedor
              </NavLink>
              <NavLink className="btn btn-dark btn-outline-light m-1" to="/administracion">
                Administracion
              </NavLink>
              </div>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/home" element={<Home/>} />
          <Route path="/categoria" element={<Categoria/>} />
          <Route path="/medicamentos" element={<Medicamentos/>} />
          <Route path="/pedido" element={<Pedido/>} />
          <Route path="/usuario" element={<Usuario/>} />
          <Route path="/proveedor" element={<Proveedor/>}/>
          <Route path="/administracion" element={<Administracion/>}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
}
export default App;
