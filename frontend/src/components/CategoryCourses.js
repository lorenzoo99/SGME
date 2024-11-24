import React, { useState } from 'react';
import { Link } from 'react-router-dom';  
import './CategoryCourses.css';
import courseImage1 from '../img/net.png';
import courseImage2 from '../img/tiktok.png';
import courseImage3 from '../img/yt.png';
import courseImage4 from '../img/instagram.jpeg';
import courseImage5 from '../img/facebook.jpeg';

function CategoryCourses() {
    const [selectedCourse, setSelectedCourse] = useState(null);

    const handleCourseSelection = (courseId) => {
        setSelectedCourse(courseId === selectedCourse ? null : courseId);
    };

    return (
        <div className="category-courses">
            <div className="content">
                {/* Barra lateral */}
                <aside className="sidebar">
                    <nav>
                        <ul>
                            <li><Link to="/categoria-cursos"><button>📑 Categoria de cursos</button></Link></li>
                            <li><Link to="/curso-en-progreso"><button>📚 Cursos en progreso</button></Link></li>
                            <li><Link to="/user-profile"><button>⚙ Configuracion de usuarios</button></Link></li>
                            <li><Link to="/menu-principal"><button>❓ Ayuda</button></Link></li>
                        </ul>
                    </nav>
                </aside>

               
                <div className="main-content">
                    <header className="header">
                        <h1>Selecciona un Curso</h1>
                    </header>

                    <div className="courses-container">
                       
                        <div className="course-card" onClick={() => handleCourseSelection(1)}>
                            <img src={courseImage1} alt="Curso 1" className="course-image" />
                            <div className="course-title">Curso 1</div>
                            <div
                                className={`check-circle ${selectedCourse === 1 ? 'selected' : ''}`}
                            >
                                {selectedCourse === 1 && <span className="check-icon">&#10003;</span>}
                            </div>
                        </div>

                        <div className="course-card" onClick={() => handleCourseSelection(2)}>
                            <img src={courseImage2} alt="Curso 2" className="course-image" />
                            <div className="course-title">Curso 2</div>
                            <div
                                className={`check-circle ${selectedCourse === 2 ? 'selected' : ''}`}
                            >
                                {selectedCourse === 2 && <span className="check-icon">&#10003;</span>}
                            </div>
                        </div>

                        
                        <div className="course-card" onClick={() => handleCourseSelection(3)}>
                            <img src={courseImage3} alt="Curso 3" className="course-image" />
                            <div className="course-title">Curso 3</div>
                            <div
                                className={`check-circle ${selectedCourse === 3 ? 'selected' : ''}`}
                            >
                                {selectedCourse === 3 && <span className="check-icon">&#10003;</span>}
                            </div>
                        </div>

                       
                        <div className="course-card" onClick={() => handleCourseSelection(4)}>
                            <img src={courseImage4} alt="Curso 4" className="course-image" />
                            <div className="course-title">Curso 4</div>
                            <div
                                className={`check-circle ${selectedCourse === 4 ? 'selected' : ''}`}
                            >
                                {selectedCourse === 4 && <span className="check-icon">&#10003;</span>}
                            </div>
                        </div>

                    
                        <div className="course-card" onClick={() => handleCourseSelection(5)}>
                            <img src={courseImage5} alt="Curso 5" className="course-image" />
                            <div className="course-title">Curso 5</div>
                            <div
                                className={`check-circle ${selectedCourse === 5 ? 'selected' : ''}`}
                            >
                                {selectedCourse === 5 && <span className="check-icon">&#10003;</span>}
                            </div>
                        </div>
                    </div>

                    
                    <footer className="footer">
                        <button className="submit-btn">Enviar selección</button>
                    </footer>
                </div>
            </div>
        </div>
    );
}

export default CategoryCourses;
