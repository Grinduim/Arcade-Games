namespace Model;
public class Player
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password {get;set;}
    
    public int save(){
        using (var context = new Context())
        {
            context.Players.Add(this);
            context.SaveChanges();
            return this.Id;
        }
    }

    public int VerifyLogin(){
        using(var context = new Context()){
            var Query = context.Players.Where(p => p.Name == this.Name && p.Password == this.Password).FirstOrDefault();

            if(Query != null){
                return Query.Id;
            }
            else{
                return -1;
            }
        }
    }
}

