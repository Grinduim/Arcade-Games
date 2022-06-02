using System;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class LogPlayerGame
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public int save()
        {
            using (var context = new Context())
            {
                var player = context.Players.FirstOrDefault(p => p.Id == this.Player.Id);
                var game = context.Games.FirstOrDefault(g=>g.Id == this.Game.Id);
                if(player != null && game != null)
                {
                    this.Player = player;
                    this.Game = game;
                    this.Date = DateTime.Now;
                    context.LogPlayerGames.Add(this);
                    context.SaveChanges();
                    return this.Id;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static List<LogPlayerGame> Top10Score(int id){
           using(var context = new Context()){
                var Query = context.LogPlayerGames.Where(p => p.Game.Id == id).Include(p=>p.Player).Include(p=>p.Game).OrderByDescending(p=>p.Score).Take(10).ToList();
                foreach(var item in Query){
                    item.Player.Password = null;
                    item.Player.Id = 0;
                    item.Game = null;
                }
                return Query;
           }
        }
    }
}