using System;

public abstract class Player{ //abstract é utilizada como molde
public int Moeda {get; protected set;} = 10;
public abstract bool Decidir();
public virtual void Recebe(int valor){
    this.Moeda+=valor;
}

}