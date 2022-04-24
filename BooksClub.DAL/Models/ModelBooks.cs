namespace BooksClub.DAL.Models
{
    public class ModelBooks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public bool IsDelete { get; set; }
    }
}
