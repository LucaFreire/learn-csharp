public abstract class Personagens
{
    public string Nome{ get; set; }
    protected int Vida{ get; set; }
    protected int Dano{ get; set; }
    protected int Velocidade{ get; set; }
    public void Attack(Personagens inimigo) => inimigo.Vida -= this.Dano;
  
    public class Tanque : Personagens
    {
        public Tanque()
        {
            this.Vida = 150;
            this.Dano = 75;
            this.Velocidade = 30;
        }
    }

    public class Veloz : Personagens
    {
        public Veloz()
        {
            this.Vida = 80;
            this.Dano = 40;
            this.Velocidade = 70;
        }
    }

    public class Comum : Personagens
    {
        public Comum()
        {
            this.Vida = 100;
            this.Dano = 60;
            this.Velocidade = 50;
        }
    }
}