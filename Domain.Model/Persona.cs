

namespace Domain.Model
{

    public class Persona
    {
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public int Legajo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IdPlan { get; set; }

        public Persona(string direccion, string telefono, string tipo, int legajo, DateTime fechaNacimiento, int idPlan)
        {
            Direccion = direccion;
            Telefono = telefono;
            SetTipo(tipo);
            Legajo = legajo;
            FechaNacimiento = fechaNacimiento;
            IdPlan = idPlan;
        }

        protected Persona() // para ef
        {
        }

        // Evitamos tipos que no existan, y aun mas importante, evitamos que generen administradores!
        private void SetTipo(string tipo)
        {
            if (tipo == "profesor" || tipo == "alumno" || tipo == "admin")
                Tipo = tipo;
            else
                throw new ArgumentException("Tipo inexistente");
                
        }
    }
}
