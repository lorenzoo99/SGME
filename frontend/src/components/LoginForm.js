import React, { useState } from 'react';
import { FaEye, FaEyeSlash } from 'react-icons/fa';  // Importa los íconos

function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false);  // Estado para mostrar/ocultar contraseña

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);  // Cambia el estado al contrario de lo que es actualmente
    };

    const handleLogin = (e) => {
        e.preventDefault();
        // Lógica de autenticación aquí
    };

    return (
        <section className="login">
            <h2>Iniciar sesión</h2>
            <form onSubmit={handleLogin}>
                <div className="form-group">
                    <label htmlFor="email">Correo:</label>
                    <input
                        type="email"
                        id="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group" style={{ position: 'relative' }}>
                    <label htmlFor="password">Contraseña:</label>
                    <input
                        type={showPassword ? "text" : "password"}  // Alterna el tipo de input
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                    <div
                        style={{
                            position: 'absolute',
                            right: '10px',
                            top: '50%',
                            transform: 'translateY(-50%)',
                            cursor: 'pointer',
                        }}
                        onClick={togglePasswordVisibility}
                    >
                        {showPassword ? <FaEyeSlash size={20} /> : <FaEye size={20} />} {/* Íconos del ojo */}
                    </div>
                </div>
                <div className="login-actions">
                    <button type="submit">Iniciar sesión</button>
                    <a href="/forgot-password">¿Olvidaste tu contraseña?</a>

                </div>
            </form>
        </section>
    );
}

export default LoginForm;
