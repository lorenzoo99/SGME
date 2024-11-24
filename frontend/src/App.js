// src/App.js
import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, useNavigate, Navigate } from 'react-router-dom';
import MainMenu from './components/MainMenu';
import CategoryCourses from './components/CategoryCourses';
import UserProfile from './components/UserProfile';
import LoginRegister from './components/LoginRegister';
import CoursesInProgress from './components/CoursesInProgress';
import ForgotPassword from './components/ForgotPassword';

function App() {
    const [isLoggedIn, setIsLoggedIn] = useState(false); // Estado para alternar la vista
    const navigate = useNavigate(); // Hook para navegación

    // Función para manejar login/logout
    const handleLoginLogout = () => {
        setIsLoggedIn(!isLoggedIn);
        if (!isLoggedIn) {
            navigate('/menu-principal'); // Redirigir al Menú Principal
        } else {
            navigate('/register'); // Redirigir al formulario de registro
        }
    };

    return (
        <div>
            <Routes>
                {/* Redirigir la ruta raíz ("/") a "/register" */}
                <Route path="/" element={<Navigate to="/register" />} />

                {/* Definición de rutas */}
                <Route path="/register" element={<LoginRegister setIsLoggedIn={setIsLoggedIn} />} />
                <Route path="/menu-principal" element={isLoggedIn ? <MainMenu /> : <Navigate to="/register" />} />
                <Route path="/categoria-cursos" element={<CategoryCourses />} />
                <Route path="/user-profile" element={<UserProfile />} />
                <Route path="/curso-en-progreso" element={<CoursesInProgress />} />
                <Route path="/forgot-password" element={<ForgotPassword />} />
            </Routes>

            {/* Botón para alternar entre login y logout */}
            <div className="App SGME">
                <button onClick={handleLoginLogout}>
                    {isLoggedIn ? 'Logout' : 'Login'}
                </button>
            </div>
        </div>
    );
}

export default App;
