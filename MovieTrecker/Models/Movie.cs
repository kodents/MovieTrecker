namespace MovieTrecker.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int ReleaseYear {  get; set; }
        public double Rating { get; set; }
        public Status Status {  get; set; }
        public DateTime? WatchedDate { get; set; }
    }

    public enum Status
    {
        PlanToWatch,
        Watching,
        Watched,
        Dropped
    }
}
