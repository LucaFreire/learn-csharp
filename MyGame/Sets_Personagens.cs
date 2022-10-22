public abstract class Personagens{
    public string Nome{get;set;}
    public int Vida{get;set;}
    public int Dano{get;set;}
    public int Velocidade{get;set;}
}

public class Tanque : Personagens{
    public Tanque(){
        this.Vida = 150;
        this.Dano = 75;
        this.Velocidade = 30;
    }
}

public class Veloz : Personagens{
    public Veloz(){
        this.Vida = 80;
        this.Dano = 40;
        this.Velocidade = 70;
    }
}

public class Comum : Personagens{
    Comum(){
        this.Vida = 100;
        this.Dano = 60;
        this.Velocidade = 50;
    }
}
