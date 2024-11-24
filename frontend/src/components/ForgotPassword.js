
import React, { useState } from 'react';
import { auth } from '../firebaseConfig';
import { sendPasswordResetEmail } from 'firebase/auth';

function ForgotPassword() {
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState('');

    const handlePasswordReset = async (e) => {
        e.preventDefault();
        setError('');
        setMessage('');

        try {
            await sendPasswordResetEmail(auth, email);
            setMessage('Revisa tu correo para las instrucciones de recuperacion.');
        } catch (err) {
            setError('No se pudo enviar el correo de recuperación.');
        }
    };

    return (
        <section className="forgot-password">
            <h2>Recuperar Credenciales</h2>
            <form onSubmit={handlePasswordReset}>
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
                <button type="submit">Enviar Correo de Recuperación</button>
            </form>
            {message && <p className="message">{message}</p>}
            {error && <p className="error">{error}</p>}
        </section>
    );
}

export default ForgotPassword;
