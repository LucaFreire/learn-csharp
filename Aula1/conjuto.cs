//using System;
//public class Set{
//    public virtual bool IsIn(Set set){
//        return false;
//    }
//    public abstract Set Union (Set set);
//}
//public class PairSet : Set{
//    public Set A {get;set;}
//    public Set B {get;set;}
//    public override bool IsIn(Set set){
//        return A == set || B == set;
//    }
//}
//public class EmptySet : Set{
//    public Set A {get;set;}
//    public Set B {get;set;}
//    public override bool IsIn (Set set){
//        return A.Equals(set) || B.Equals(set);
//    }
//}
//public class NaturalSet : Set{}
//
//public override bool Equals(object obj){
//    if (obj is PairSet pair ){
//        return (pair.A.Equals((this.A) && pair.B.Equals(this.B))  || 
//        (pair.B.Equals((this.B) && pair.A.Equals(this.A))) ||
//        (pair.A.Equals(this.A) || pair.A.Equals(this.B)));
//    }
//    return false;
//}
//public override set Union(Set set){
//    return A.IsIn(set) || B.IsIn(set);
//}
//
//
//
//
//