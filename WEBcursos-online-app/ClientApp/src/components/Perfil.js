import React, { useEffect, useState } from 'react';
import axios from 'axios'


function Perfil(props) {

    const [paises, obtenerPaises] = useState([]);
    const [status, cambiarStatus] = useState(false);

    useEffect(() => {

        axios.get('https://restcountries.com/v2/all')
            .then(resultado => {
                obtenerPaises(resultado.data);
                cambiarStatus(true);
            })
            .catch(error => {
                cambiarStatus(true);
            })

    }, [])


    if (status) {
        return (

            <ul>
                {paises.map((pais, indice) =>
                    <li key={indice}>
                        {pais.name}
                    </li>

                )}
            </ul>

        );
    }
    else {
        return (<h1> Esta cargando los valores de la rest service....</h1>)
    }


}

export default Perfil;
