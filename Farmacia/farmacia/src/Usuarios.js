import React, { Component } from 'react';
import { variables } from './Variables.js';
import { tsConstructorType } from '@babel/types';



export class Usuario extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Usuario:[],
            modalTitle:"",
            ID_Usuario:0,
            Nombre:"",
            Telefono:0,
            Direccion:"",
            Email:"",
            Contraseña:"",
        }
    }

    refreshList(){
        fetch(variables.API_URL+'Usuario')
        .then(response=>response.json())
        .then(data=>{
            this.setState({Usuario:data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    cambiarUsuarioNombre=(e)=>{
        this.setState({Nombre:e.target.value});
    }
    cambiarUsuarioTelefono=(e)=>{
        this.setState({Telefono:e.target.value});
    }
    cambiarUsuarioDireccion=(e)=>{
        this.setState({Direccion:e.target.value});
    }
    cambiarUsuarioEmail=(e)=>{
        this.setState({Email:e.target.value});
    }
    cambiarUsuarioContraseña=(e)=>{
        this.setState({Contraseña:e.target.value});
    }

    addClick(){
        this.setState({
            modalTitle:"Agregar Usuario",
            ID_Usuario:"",
            Nombre:"",
            Telefono:0,
            Direccion:"",
            Email:"",
            Contraseña:"",

        });
    }

    editClick(usu){
        this.setState({
            modalTitle:"editar Usuario",
            ID_Usuario:usu.ID_Usuario,
            Nombre:usu.Nombre,
            Telefono:usu.Telefono,
            Direccion:usu.Direccion,
            Email:usu.Email,
            Contraseña:usu.Contraseña
        });
    }

    createClick(){
        fetch(variables.API_URL+'Usuario',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Nombre:this.state.Nombre,
                Telefono:this.state.Telefono,
                Direccion:this.state.Direccion,
                Email:this.state.Email,
                Contraseña:this.state.Contraseña
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }
    updateClick(id){
        fetch(variables.API_URL+'Usuario/'+id,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                ID_Usuario:this.state.ID_Usuario,
                Nombre:this.state.Nombre,
                Telefono:this.state.Telefono,
                Direccion:this.state.Direccion,
                Email:this.state.Email,
                Contraseña:this.state.Contraseña
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    deleteClick(id){
        if(window.confirm('¿Estas seguro?')){
        fetch(variables.API_URL+'Usuario/'+id,{
            method:'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
        }
    }



    render() {
        const{
            modalTitle,
            Usuario,
            ID_Usuario,
            Nombre,
            Telefono,
            Direccion,
            Email,
            Contraseña
        }=this.state;
        return (
            <div>
                <button type="button"
                className="btn btn-dark btn-outline-light m-1 float-end"
                data-bs-toggle="modal"
                data-bs-target="#exampleModal"
                onClick={()=>this.addClick()}>
                    Agregar Usuario
                </button>
                <table className="table table-dark">
                    <thead>
                        <tr>
                        <th className="table-success">
                                Nombre
                            </th>
                        <th className="table-success">
                                Telefono
                            </th>
                        <th className="table-success">
                                Direccion
                            </th>
                        <th className="table-success">
                                Email
                            </th>
                        <th className="table-success">
                                Contraseña
                            </th>
                        <th className="table-success">
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {Usuario.map(usu =>
                            <tr key={usu.ID_Usuario}>
                                <td>{usu.Nombre}</td>
                                <td>{usu.Telefono}</td>
                                <td>{usu.Direccion}</td>
                                <td>{usu.Email}</td>
                                <td>{usu.Contraseña}</td>
                                <td>
                                    <button type="button"
                                        className="btn btn-ligth m-1"
                                        data-bs-toggle="modal"
                                        data-bs-target="#exampleModal"
                                        onClick={()=>this.editClick(usu)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                        </svg>
                                    </button>

                                    <button type="button"
                                        className="btn btn-dark btn-outline-light m-1"
                                        onClick={()=>this.deleteClick(usu.ID_Usuario,Nombre,Telefono,Direccion,Email,Contraseña)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                                        </svg>
                                    </button>
                                </td>
                            </tr>
                        )}

                    </tbody>

                </table>
                
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog modal-lg modal-dialog-centered">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="title">{modalTitle}</h5>
                        <button type="button" className="btm-close" data-bs-dismiss="modal" aria-label="Cerrar">

                        </button>
                    </div>
                    <div className="modal-body">
                        <div className="input-group mb-3">
                            <span className="input-group-text">Nombre</span>
                            <input type="text" className="form-control"
                            value={Nombre}
                            onChange={this.cambiarUsuarioNombre}/>
                        </div>

                        <div className="input-group mb-3">
                            <span className="input-group-text">Telefono</span>
                            <input type="text" className="form-control"
                            value={Telefono}
                            onChange={this.cambiarUsuarioTelefono}/>
                        </div>

                        <div className="input-group mb-3">
                            <span className="input-group-text">Direccion</span>
                            <input type="text" className="form-control"
                            value={Direccion}
                            onChange={this.cambiarUsuarioDireccion}/>
                        </div>

                        <div className="input-group mb-3">
                            <span className="input-group-text">Email</span>
                            <input type="text" className="form-control"
                            value={Email}
                            onChange={this.cambiarUsuarioEmail}/>
                        </div>

                        <div className="input-group mb-3">
                            <span className="input-group-text">Contraseña</span>
                            <input type="text" className="form-control"
                            value={Contraseña}
                            onChange={this.cambiarUsuarioContraseña}/>
                        </div>


                            {ID_Usuario==0?
                            <button type="button"
                            className="btn btn-dark float-start"
                            onClick={()=>this.createClick()}
                            >Crear
                            </button>
                            :null}

                            {ID_Usuario!=0?
                            <button type="button"
                            className="btn btn-dark float-start"
                            onClick={()=>this.updateClick(ID_Usuario)}
                            >Actualizar
                            </button>
                            :null}

                    </div>
                </div>    
                </div>
                </div>

            </div>
        )
    }
}

