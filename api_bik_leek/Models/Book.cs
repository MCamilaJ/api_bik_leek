namespace api_bik_leek.Models
{
    public class Book
    {
        //Propiedades de la clase Books
        public int id { get; set; } //Id del libro
        public required string title { get; set; } //Titulo del libro
        public required string author { get; set; } //Autor del libro
        public string genre { get; set; } //Genero del libro
        public required int pages { get; set; } //Numero de paginas del libro
        public int editions { get; set; } //Numero de ediciones del libro
        public required int year_publication { get; set; } //Año de publicacion del libro
    }
}
