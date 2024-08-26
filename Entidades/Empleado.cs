namespace Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

       
        public Sector Sector { get; set; }
        public Rol Rol { get; set; }
    }
}
