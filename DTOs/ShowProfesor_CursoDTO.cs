namespace DTOs
{
    public class ShowProfesor_CursoDTO
    {
        public int IdDictado { get; set; }
        public NewCursoDTO Curso { get; set; }
        public ShowUsuarioDTO Profesor { get; set; }
        public int Cargo { get; set; }
    }
}
