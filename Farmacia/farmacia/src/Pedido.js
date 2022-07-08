import React, { Component } from 'react';
import { variables } from './Variables.js';
import './App.css';


export class Pedido extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Pedido:[],
            modalTitle:"",
            ID_Pedido:"",
            Fecha:0,
            estado:"",
            ID_Medicamento:0,
            ID_Usuario:"",
            Total:0.0,
            
        }
    }

    refreshList(){
        fetch(variables.API_URL+'Pedido')
        .then(response=>response.json())
        .then(data=>{
            this.setState({Pedido:data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    deleteClick(id){
        if(window.confirm('¿Estas seguro?')){
        fetch(variables.API_URL+'Pedido/'+id,{
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
            Pedido,
            Fecha,
            estado,
            ID_Medicamento,
            Total,
            ID_Usuario
        }=this.state;
        return (
            <div>
                <table className="table table-dark">
                    <thead>
                        <tr>
                            <th className="table-success">
                                Fecha
                            </th>
                            <th className="table-success">
                                Estado
                            </th >
                            <th className="table-success">
                                ID_Medicamento
                            </th>
                            <th className="table-success">
                                Total
                            </th>
                            <th className="table-success">
                                ID_Usuario
                            </th>
                            <th className="table-success">
                                Opcion
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {Pedido.map(ped =>
                            <tr key={ped.ID_Pedido}>
                                <td>{ped.Fecha}</td>
                                <td>{ped.estado}</td>
                                <td>{ped.ID_Medicamento}</td>
                                <td>{ped.Total}</td>
                                <td>{ped.ID_Usuario}</td>
                                <td>
                                    <button type="button"
                                        className="btn btn-dark btn-outline-light m-1"
                                        onClick={()=>this.deleteClick(ped.ID_Pedido,Fecha,estado,ID_Medicamento,Total,ID_Usuario)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                                        </svg>
                                    </button>
                                </td>
                            </tr>
                        )}

                    </tbody>

                </table>

            </div>
        )
    }
}