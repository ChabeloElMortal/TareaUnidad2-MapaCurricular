namespace TareaUnidad2.Models.ViewModels
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Plan { get; set; } = null!;

        public int Creditos { get; set; } = 0;
        public IEnumerable<SemestreModel> Semestres { get; set; } = null;

    }
    public class SemestreModel
    {
        public int NumSemestre { get; set; }
        public string Semestre { get; set; } = string.Empty;
        public IEnumerable<MateriasModel> Materias { get; set; } = null;
    }
    public class MateriasModel
    {
        public string Clave { get; set; } = null;
        public string Nombre { get;set; } = null!;
        public sbyte HorasTeoricas { get; set; }
        public sbyte HorasPracticas { get; set; }
        public int Creditos { get; set; } 
    }
}
