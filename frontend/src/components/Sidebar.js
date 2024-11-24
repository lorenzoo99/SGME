
import React from 'react';
import logo1 from '../img/1.png';
import logo2 from '../img/2.png';
import logo3 from '../img/3.png';
import logo4 from '../img/4.png';
import logo5 from '../img/5.png';

function Sidebar() {
    return (
        <aside className="sidebar">
            <div className="logo">
                <img src={logo1} alt="S.G.M.E" />
                <div className="line"></div>
            </div>
            <nav>
                <ul>
                    <li>
                        <div className="logoC">
                            <img src={logo2} alt="Configuracion" className="icon" />
                            <a href="#">Configuracion</a>
                        </div>
                    </li>
                    <li>
                        <div className="logoP">
                            <img src={logo3} alt="Agregar Perfil" className="icon" />
                            <a href="#">Agregar perfil</a>
                        </div>
                    </li>
                    <li>
                        <div className="logoA">
                            <img src={logo4} alt="Ayuda" className="icon" />
                            <a href="#">Ayuda</a>
                        </div>
                    </li>
                </ul>
            </nav>
            <div className="back-button">
                <img src={logo5} alt="Ayuda" className="icon" />
                <button>Regresar</button>
            </div>
        </aside>
    );
}

export default Sidebar;

