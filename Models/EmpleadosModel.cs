namespace Prueba_desarrollador_Andres_Cifuentes.Models
{
    public class EmpleadosModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public int Codigo { get; set; }
        public string Posicion { get; set; } = string.Empty;
        public decimal SalarioBase { get; set; }

        // Supervisor (auto referenciado)
        public int? SupervisorId { get; set; }
        public EmpleadosModel? Supervisor { get; set; }

        // Grupo
        public int GrupoId { get; set; }
        public GruposModel? Grupo { get; set; }
    }
}
