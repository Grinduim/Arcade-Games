namespace Model
{
    public class LogPlayerGame
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}