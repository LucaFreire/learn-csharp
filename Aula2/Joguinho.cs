using System;

// public abstract class Entity{
//     public string Name {get; protected set;}
//     public int Life{get; protected set;}
//     public int Damage{get;set;}
//     public Weapon Weapon {get;set;}
//     public abstract void Attack(Entity target);
//     public abstract void ReciveDamage(int damage);
// }

//     public abstract class Weapon{
//         public string Name{get;set;}
//         public int Damage{get;set;}
//     }

//     public class Lucas : Entity{
//         public int Shield{get; private set;}
//         public Lucas(){
//             this.Name = "Player";
//             this.Life = 200;
//             this.Damage = 10;
//             this.Shield = 40;
//         }
        
//         public override void Attack(Entity target){
//             int damage = 2 * (Weapon?.Damage ?? 0) + 2 * this.Damage;
//             target.ReciveDamage(damage);
//     }
//     public override void ReciveDamage(int damage){
//         if (0<this.Shield){
//             if(this.Shield>damage){
//                 this.Shield = 0;
//                 return;
//             }
//             else{
//                 damage -= this.Shield;
//                 this.Shield = 0;
//                 return;
//             }
//         }
//         this.Life -= damage;
//     }
// }

//     public class Pessoa : Entity{
//         public Pessoa(){
//             this.Name = "Pessoa";
//             this.Life = 100;
//             this.Damage = 50;
//         }
//         public override void ReciveDamage(int damage){
//         if (damage > 5)
//             return;
//         this.Life -= damage;}

//         public override void Attack(Entity target){
//             int damage = 2 * (Weapon?.Damage ?? 0) + 2 * this.Damage;
//             target.ReciveDamage(damage);
//         }
//     }

//     public class Sword : Weapon{
//         public Sword(){
//             this.Name = "Espada";
//             this.Damage = 5;
//         }
//     }

//     public class LongSword : Weapon{
//         public Sword(){
//             this.Name = "Espada Longa";
//             this.Damage = 10;
//         }
//     }

// Edjalma edjalma = new Edjalma();
// Lucas lucas = new Lucas();
// Sword sword = new Sword();
// edjalma.Weapon = sword;
// edjalma.Attack(lucas);
// Console.WriteLine(lucas.Life);

// public abstract class Entity
// {
//     public string Name {get; protected set;} //Dano da arma não pode ser altarada fora
//     public int Life {get;protected set;}
//     public int Damage {get; protected set;}
//     public Weapon Weapon {get;set;}
    
//     public abstract void Attack(Entity target);
//     public abstract void ReceiveDamage(int damage);
// }

// public abstract class Weapon
// {
//     public string Name {get; protected set;}
//     public int Damage {get; protected set;}
// }

// public class Lucas : Entity{
//     public int Armadura {get; private set;}

//     public Lucas(){
//         this.Damage = 100;
//         this.Life = 100;
//         this.Name = "Lucas";
//         this.Armadura = 200;
//     }
//     public override void Attack(Entity target)
//     {
//         int damage = this.Damage / 2 + this.Weapon.Damage*2;
//         target.ReceiveDamage(damage);
//     }
//     public override void ReceiveDamage(int damage)
//     {
//         if (this.Armadura > damage){
//             this.Armadura -= damage;
//         }
//         else{
//             damage-=Armadura;
//             this.Life-=damage;
//         }

//     }


// }
// public class Edjalma : Entity
// {

//     public int Shield { get; private set; }

//     public Edjalma()
//     {
//         this.Name = "Edjalma";
//         this.Life = 180;
//         this.Damage = 10;
//         this.Shield = 40;
//     }

//     public override void Attack(Entity target)
//     {
//         int damage = this.Damage / 2
//             + this.Weapon.Damage * 2;
//         target.ReceiveDamage(damage);
//     }
//     public override void ReceiveDamage(int damage)
//     {
//         if(this.Shield > damage)
//         {
//             this.Shield = 0;
//             return;
//         }
//         else
//         {
//             damage -= this.Shield;
//             this.Shield = 0;
//         }
//         if (damage < 5)
//             return;
//         this.Life -= damage;
//     }
// }

// public class Travis : Entity
// {
//     public Travis()
//     {
//         this.Name = "Travis";
//         this.Life = 20;
//         this.Damage = 80;
//     }

//     public override void Attack(Entity target)
//     {
//         int damage = 2*(Weapon?.Damage?? 0)
//             +2*this.Damage
//             + this.Weapon.Damage * 2;
//         target.ReceiveDamage(damage);
//     }
//     public override void ReceiveDamage(int damage)
//     {
//         if (damage < 5)
//             return;
//         this.Life -= damage;
//     }
// }

// public class Sword : Weapon
// {
//     public Sword()
//     {
//         this.Name = "Espada";
//         this.Damage = 100;
//     }
// }