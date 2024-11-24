import React from 'react';
import './UserProfile.css';
import userImage from '../img/user.png'; 
import logo from '../img/1.png'; 
import { useNavigate } from 'react-router-dom'; 

function UserProfile() {
    const navigate = useNavigate(); 

    
    const handleRegresar = () => {
        navigate('/menu-principal'); 
    };

    return (
        <div className="container">
            
            <div className="sidebar">
                <img src={logo} alt="Logo" className="logo" /> 
                <button onClick={() => navigate('/menu-principal')} className="sidebar-button">Configuración</button>
                <button onClick={() => navigate('/user-profile')} className="sidebar-button">Editar Perfil</button>
                <button onClick={() => navigate('/menu-principal')} className="sidebar-button">Ayuda</button>
                <button onClick={handleRegresar} className="sidebar-button">Regresar</button>
            </div>

           
            <div className="main-content">
               
                <div className="header">
                    Perfil de Usuario
                </div>

               
                <div className="profile-section">
                    {[...Array(3)].map((_, index) => (
                        <div className="user-card" key={index}>
                            <img src={userImage} alt="Usuario" className="user-avatar" /> 
                            <div className="name">Nombre Completo</div>
                            <div className="role">Rol</div>
                            <div className="company">Universidad</div>
                            <div className="edit">Editar</div>
                        </div>
                    ))}
                </div>

              
                <div className="footer">
                    <span className="link">Términos</span> |
                    <span className="link">Privacidad</span> |
                    <span className="link">Enlace Reservado</span>
                </div>
            </div>
        </div>
    );
}

export default UserProfile;
