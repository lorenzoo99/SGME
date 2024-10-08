﻿namespace SGME.Model
{
    public class ContentUser
    {
        public int ContentUserID { get; set; } // Clave primaria
        public DateTime ViewDate { get; set; } // Fecha en que el usuario vio el contenido
        public int ViewDuration { get; set; }  // Duración de la visualización en minutos
        public required string InteractionStatus { get; set; } // Estado de interacción (por ejemplo, "completo", "en curso")

        
        

        // Foreign key a la tabla User
        public int UserID { get; set; }
        public required User User { get; set; }



        // Foreign key a la tabla Content
        public int ContentID { get; set; }
        public virtual required Content Contents { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
