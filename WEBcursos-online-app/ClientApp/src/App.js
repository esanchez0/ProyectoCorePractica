//import React, { Component } from 'react';
import React, { useState } from 'react'
//import './custom.css'
import Perfil from './components/Perfil'

//export default class App extends Component {
//    static displayName = App.name;

//    render() {
//        const [nombre, cambiarNombre] = useState('No tiene nombre');

//        return (
//            <div>
//                <h1>
//                    Bienvenidos al curso de asp net y react hook
//                </h1>
//                <input name="nombre" type="text" />
//            </div>
//        );
//    }
//}

function App() {
    var [nombre, cambiarNombre] = useState('No tiene nombre'); //Nombre de la variable, nombre del metodo con el que va cambiar, valor inicializado

    function eventoCajaTexto(e) {
        cambiarNombre(e.target.value)
    }

    return (
        <div>
            <h1>
                Bienvenidos al curso de asp net y react hook {nombre}
            </h1>
            <input name="nombre" type="text" value={nombre} onChange={eventoCajaTexto} />

            <Perfil/>

        </div>
    );

}

export default App;