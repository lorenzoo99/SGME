import React, { useState } from 'react';
import { FaEye, FaEyeSlash } from 'react-icons/fa'; 
import { auth, googleProvider, signInWithPopup } from '../firebaseConfig';
import DataPolicyModal from './DataPolicyModal';

const RegisterForm = () => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [userType, setUserType] = useState('Usuario');
    const [agreed, setAgreed] = useState(false);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);
    const [showPolicyModal, setShowPolicyModal] = useState(false);

    // Estados para mostrar/ocultar contraseña
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);

    const togglePasswordVisibility = () => setShowPassword(!showPassword);
    const toggleConfirmPasswordVisibility = () => setShowConfirmPassword(!showConfirmPassword);

    const handleGoogleSignIn = async () => {
        setLoading(true);
        setError(null);
        try {
            await signInWithPopup(auth, googleProvider);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        if (!name || !/^[a-zA-Z\s]+$/.test(name)) {
            setError('Por favor, ingresa un nombre válido.');
            return;
        }

        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            setError('El correo debe estar en formato válido.');
            return;
        }

        const passwordPattern = /^(?=.*[A-Z])(?=.*\d).{8,}$/;
        if (!passwordPattern.test(password)) {
            setError('La contraseña debe tener al menos 8 caracteres, una mayúscula y un número.');
            return;
        }

        if (password !== confirmPassword) {
            setError('Las contraseñas no coinciden.');
            return;
        }

        if (!agreed) {
            setError('Debes estar de acuerdo con los términos y condiciones.');
            return;
        }

        try {
            setLoading(true);
            setName('');
            setEmail('');
            setPassword('');
            setConfirmPassword('');
            setUserType('Usuario');
            setAgreed(false);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Registro</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <div>
                    <label>
                        Nombre:
                        <input
                            type="text"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
                    </label>
                </div>
                <div>
                    <label>
                        Correo:
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </label>
                </div>
                <div style={{ position: 'relative' }}>
                    <label>
                        Contraseña:
                        <input
                            type={showPassword ? "text" : "password"}
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
                            {showPassword ? <FaEyeSlash /> : <FaEye />}
                        </div>
                    </label>
                </div>
                <div style={{ position: 'relative' }}>
                    <label>
                        Repetir Contraseña:
                        <input
                            type={showConfirmPassword ? "text" : "password"}
                            value={confirmPassword}
                            onChange={(e) => setConfirmPassword(e.target.value)}
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
                            onClick={toggleConfirmPasswordVisibility}
                        >
                            {showConfirmPassword ? <FaEyeSlash /> : <FaEye />}
                        </div>
                    </label>
                </div>
                <div>
                    <label>
                        Tipo de Usuario:
                        <select value={userType} onChange={(e) => setUserType(e.target.value)}>
                            <option value="Usuario">Usuario</option>
                            <option value="Administrador">Administrador</option>
                        </select>
                    </label>
                </div>
                <div>
                    <label>
                        <input
                            type="checkbox"
                            checked={agreed}
                            onChange={(e) => setAgreed(e.target.checked)}
                            required
                        />
                        Estoy de acuerdo con los{' '}
                        <span onClick={() => setShowPolicyModal(true)} style={{ color: 'blue', textDecoration: 'underline', cursor: 'pointer' }}>
                            términos de uso y políticas de privacidad
                        </span>
                    </label>
                </div>
                <button type="submit" disabled={loading}>
                    {loading ? 'Cargando...' : 'Registrar'}
                </button>
            </form>
            <button onClick={handleGoogleSignIn} disabled={loading} style={{ marginTop: '10px' }}>
                {loading ? 'Cargando...' : 'Iniciar sesión con Google'}
            </button>

            {showPolicyModal && <DataPolicyModal onClose={() => setShowPolicyModal(false)} />}
        </div>
    );
};

export default RegisterForm;
