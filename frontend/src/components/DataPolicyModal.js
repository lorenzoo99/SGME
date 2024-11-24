
import React from 'react';
import './DataPolicyModal.css'; 

const DataPolicyModal = ({ onClose }) => (
    <div className="modal-overlay">
        <div className="modal-window">
            <h2>Politica de Tratamiento de Datos</h2>
            <p>
                1. Finalidad del Tratamiento
                Recopilamos y tratamos datos personales para:

                Proveer acceso a los servicios de la aplicacion.
                Mejorar la experiencia del usuario mediante analisis y personalizacion.
                Gestionar cuentas y preferencias.
                Enviar notificaciones y promociones, con consentimiento previo del usuario.
            </p>
            <p>
                2. Datos Personales Recopilados
                Recopilamos datos de contacto (nombre, correo), datos de autenticacion e informacion de uso de la aplicacion.
            </p>
            <p>
                3. Consentimiento
                Al registrarse, el usuario consiente el tratamiento de sus datos conforme a esta politica y puede retirar su consentimiento, aunque esto puede limitar el acceso a ciertos servicios.
            </p>
            <p>
                4. Comparticion de Datos
                Podemos compartir datos personales con terceros solo para:

                Proveer servicios esenciales a traves de socios tecnologicos.
                Cumplir con requisitos legales, manteniendo medidas de seguridad estrictas.
            </p>
            <p>
                5. Derechos de los Usuarios
                El usuario tiene derecho a acceder, actualizar, rectificar y eliminar sus datos, y a oponerse al tratamiento en ciertas circunstancias.
            </p>
            <p>
                6. Seguridad de los Datos
                Implementamos medidas de seguridad para proteger los datos personales, aunque no podemos garantizar la seguridad absoluta de los mismos.
            </p>
            <p>
                7. Cambios en la Politica
                Nos reservamos el derecho de modificar esta politica. Notificaremos a los usuarios sobre cambios a traves de la aplicacion.
            </p>
            <button className="close-button" onClick={onClose}>Cerrar</button>
        </div>
    </div>
);

export default DataPolicyModal;
