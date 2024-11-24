// firebaseConfig.js
import { initializeApp } from 'firebase/app';
import { getAuth, GoogleAuthProvider, signInWithPopup } from 'firebase/auth';

const firebaseConfig = {
    apiKey: "AIzaSyAlR7qK0VfbPA7RqG2OuYGg79srvEebfLs",
    authDomain: "sgme-df916.firebaseapp.com",
    projectId: "sgme-df916",
    storageBucket: "sgme-df916.appspot.com",
    messagingSenderId: "981878033279",
    appId: "1:981878033279:web:f3d3fb08ceceeb844ba84a",
};

// Inicializa Firebase
const app = initializeApp(firebaseConfig);

// Inicializa la autenticación
const auth = getAuth(app);
const googleProvider = new GoogleAuthProvider();

// Exporta los elementos necesarios
export { auth, googleProvider, signInWithPopup };
