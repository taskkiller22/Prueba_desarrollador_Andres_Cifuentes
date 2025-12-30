namespace Prueba_desarrollador_Andres_Cifuentes.Models
{
    public class GruposModel
    {
        public int Id { get; set; }

        public string OficinaNombre { get; set; } = string.Empty;
        public int CodigoArea { get; set; }

        public ICollection<EmpleadosModel> Empleados { get; set; }
            = new List<EmpleadosModel>();
    }
}
