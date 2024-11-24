import './LoginRegister.css';
import React, { useState } from 'react';
import Sidebar from './Sidebar';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';
import { auth, googleProvider, signInWithPopup } from '../firebaseConfig'; 

function LoginRegister() {
    const [rememberMe, setRememberMe] = useState(false);
    const [error, setError] = useState(null);

    const handleGoogleSignIn = async () => {
        try {
            await signInWithPopup(auth, googleProvider);
           
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <>
            <header className="header">
                <h1>Inicio Sesión / Registrarse</h1>
            </header>
            <div className="main-container">
                <Sidebar />
                <main className="content">
                    <LoginForm rememberMe={rememberMe} setError={setError} />
                    {error && <p style={{ color: 'red' }}>{error}</p>}
                    <RegisterForm />
                    <div className="login-footer">
                        <button onClick={handleGoogleSignIn}>Iniciar sesión con Google</button>
                        <div>
                            <input
                                type="checkbox"
                                checked={rememberMe}
                                onChange={() => setRememberMe(!rememberMe)}
                            />
                            <label>Recuérdame</label>
                        </div>
                        <a href="/forgot-password">Olvidaste tu contraseña?</a>
                    </div>
                </main>
            </div>
            <footer className="footer">
                <div className="footer-links">
                    <h4>Topic</h4>
                    <ul>
                        <li><a href="#">Secondary link</a></li>
                        <li><a href="#">Secondary link</a></li>
                        <li><a href="#">Secondary link</a></li>
                    </ul>
                </div>
            </footer>
        </>
    );
}

export default LoginRegister;



