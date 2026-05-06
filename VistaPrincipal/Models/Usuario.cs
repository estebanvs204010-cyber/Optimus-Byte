using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VistaPrincipal.Models
{
    [Table("Usuario")]
    public class Usuario 
    {

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nombre_completo")]
        public string NombreCompleto { get; set; } = string.Empty;
        [Column("correo")]
        public string Correo { get; set; } = string.Empty;
        [Column("telefono")]
        public string Telefono { get; set; } = string.Empty;
        [Column("contrasena_hash")]
        public string ContrasenaHash { get; set; } = string.Empty;
        [Column("id_rol")]
        public int IdRol { get; set; }
        [Column("activo")]
        public bool Activo { get; set; }

    }
}
