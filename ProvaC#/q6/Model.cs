using System;
public abstract class Enemy : Entity
{
    public int Column { get; set; }
    public int Line { get; set; }
    public int ColumnRand { get; set; }
    public int LineRand { get; set; }

    public abstract void Move();
    public abstract void Build();
}

public class Rock : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        build(0, 0, 40, 40); // Corpo não deslocado do centro original com tamanho 40x40
    }

    public override void Move()
    {
        Line++; //Cai
    }
}

public class TwoRock : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        build(-60, 0, 40, 40); // Corpo deslocado do centro
        build(60, 0, 40, 40); // Outro corpo deslocado na outra direção
    }

    public override void Move()
    {
        Line += 3; //Cai mais rápido
        Column++; //Cai em diagonal
    }
}

public class Inimigo1 : Enemy
{
    public override void Build()
    {
        Column = 500;
        Line = 500;
        build(0, 0, 40, 40); // Corpo deslocado do centro
    }

    public override void Move()
    {
        Line += 0; 
        Column += 0; 
    }
}
public class Inimigo2 : Enemy
{
    public override void Build()
    {   
        Random randNum = new Random();

        Column = random(1000);
        Line = random(700);
        build(0, 0, 10, 100); // Corpo deslocado do centro
    }
    public override void Move() => Line += 5; 
}
public class Inimigo3 : Enemy
{
    int count = 0;
    public override void Build()
    {
        Column = random(1000);
        Line = 0;
        int r = random(1000);
        build(r - 700, 0, 1200, 40);
        build(r + 700, 0, 1200, 40);
    }
    public override void Move() => Line++;
}

public class Inimigo4 : Enemy
{
    public override void Build()
    {
        Column = random(1000);
        Line = random(1000);
        ColumnRand = random(10);
        LineRand = random(10);
        build(0, 0, 40, 40);
    }

    public override void Move()
    {
        Line += ColumnRand;
        Column += LineRand;
    }
}
public class Inimigo5 : Enemy
{
    int count = 0;
    public override void Build()
    {
        Column = random(1000);
        Line = random(1000);
        build(0, 0, 40, 40);
    }

    public override void Move()
    {
        count++;
        if (count % 40 != 0)
            return;
        Line = random(1000);
        Column = random(1000);
    }
}

public class Inimigo6 : Enemy
{
    public override void Build()
    {
        Random rand = new Random();

        Column = 0;
        Line = random(1000);
        ColumnRand = random(1000);
        LineRand = rand.Next(5,15);
        build(0, 0, 40, 40);
    }
    public override void Move() => Column += LineRand;
}

public class InimigoPoggers : Enemy // Se moviementa em diagonal (mais random do que o do trevisas)
{
    public override void Build()
    {
        Random rand = new Random();

        Column = random(1000);
        Line = Column;
        ColumnRand = random(1000);
        LineRand = rand.Next(5,15);
        build(0, 0, 40, 40);
    }
    public override void Move()
    {
        Line += LineRand;
        if (ColumnRand > 500)
            Column += LineRand;
        else
            Column -= LineRand;
    }
}