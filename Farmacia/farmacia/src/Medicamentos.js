import React, { Component } from 'react';
import { variables } from './Variables.js';
import { tsConstructorType } from '@babel/types';



export class Medicamentos extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Medicamentos:[],
            modalTitle:"",
            Nombre:"",
            ID_Medicamento:0,
            ID_Categoria:0,
            Descripcion:"",
            Precio:0.0,
            
        }
    }

    refreshList(){
        fetch(variables.API_URL+'Medicamentos')
        .then(response=>response.json())
        .then(data=>{
            this.setState({Medicamentos:data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    cambiarMedicamentosNombre=(e)=>{
        this.setState({Nombre:e.target.value});
    }

    
    cambiarMedicamentosDescripcion=(e)=>{
        this.setState({Descripcion:e.target.value});
    }
    
    cambiarMedicamentosPrecio=(e)=>{
        this.setState({Precio:e.target.value});
    }

    cambiarMedicamentosCategoria=(e)=>{
        this.setState({ID_Categoria:e.target.value});
    }

    addClick(){
        this.setState({
            modalTitle:"Agregar Medicamento",
            ID_Medicamento:0,
            ID_Categoria:"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
            Nombre:"",
            Descripcion:"",
            Precio:0.0
        });
    }

    editClick(med){
        this.setState({
            modalTitle:"editar Medicamento",
            ID_Medicamento:med.ID_Medicamento,
            Nombre:med.Nombre,
            Descripcion:med.Descripcion,
            Precio:med.Precio,
            ID_Categoria:med.ID_Categoria
        });
    }

    createClick(){
        fetch(variables.API_URL+'Medicamentos',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
            ID_Categoria:this.state.ID_Categoria,    
            Nombre:this.state.Nombre,
            Descripcion:this.state.Descripcion,
            Precio:this.state.Precio,
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
        fetch(variables.API_URL+'Medicamentos/'+id,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                ID_Medicamento:this.state.ID_Medicamento,
                Nombre:this.state.Nombre,
                Descripcion:this.state.Descripcion,
                Precio:this.state.Precio
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
        fetch(variables.API_URL+'Medicamentos/'+id,{
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
            Medicamentos,
            modalTitle,
            ID_Medicamento,
            Nombre,
            Descripcion,
            Precio,
            ID_Categoria
        }=this.state;
        return (
            <div>
                <button type="button"
                className="btn btn-dark btn-outline-light m-1 float-end"
                data-bs-toggle="modal"
                data-bs-target="#exampleModal"
                onClick={()=>this.addClick()}>
                    Agregar Medicamento
                </button>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th className="table-success">
                                Nombre
                            </th>
                            <th className="table-success">
                                Descripcion
                            </th>
                            <th className="table-success">
                                ID_Categoria
                            </th>
                            <th className="table-success">
                                Precio
                            </th>
                            <th className="table-success">
                                Opciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {Medicamentos.map(med =>
                            <tr key={med.ID_Medicamento}>
                                <td>{med.Nombre}</td>
                                <td>{med.Descripcion}</td>
                                <td>{med.ID_Categoria}</td>
                                <td>{med.Precio}</td>
                                <td>
                                    <button type="button"
                                        className="btn btn-ligth m-1"
                                        data-bs-toggle="modal"
                                        data-bs-target="#exampleModal"
                                        onClick={()=>this.editClick(med)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                        </svg>
                                    </button>

                                    <button type="button"
                                        className="btn btn-dark btn-outline-light m-1"
                                        onClick={()=>this.deleteClick(med.ID_Medicamento,Nombre,Descripcion,Precio)}>
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
                            <span className="input-group-text">NombreDeMedicamento</span>
                            <input type="text" className="form-control"
                            value={Nombre}
                            onChange={this.cambiarMedicamentosNombre}/>
                        </div>
                        
                        <div className="input-group mb-3">
                            <span className="input-group-text">DescripcionDeMedicamento</span>
                            <input type="text" className="form-control"
                            value={Descripcion}
                            onChange={this.cambiarMedicamentosDescripcion}/>
                        </div>
                        
                        <div className="input-group mb-3">
                            <span className="input-group-text">PrecioDeMedicamento</span>
                            <input type="text" className="form-control"
                            value={Precio}
                            onChange={this.cambiarMedicamentosPrecio}/>
                        </div>
                        <div className="input-group mb-3">
                            <span className="input-group-text">CategoriaDeMedicamento</span>
                            <input type="text" className="form-control"
                            value={ID_Categoria}
                            onChange={this.cambiarMedicamentosCategoria}/>
                        </div>


                            {ID_Medicamento==0?
                            <button type="button"
                            className="btn btn-dark float-start"
                            onClick={()=>this.createClick()}
                            >Crear
                            </button>
                            :null}

                            {ID_Medicamento!=0?
                            <button type="button"
                            className="btn btn-dark float-start"
                            onClick={()=>this.updateClick(ID_Medicamento)}
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