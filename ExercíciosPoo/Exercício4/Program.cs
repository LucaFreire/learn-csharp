
List<Jogador> Time1 = new List<Jogador>();

//                         ID    NOME      POSIÇÃO   APELIDO      DATA       NÚMERO   QUALIDADE  CARTAOAMARELO 
Jogador user = new Jogador(01, "Junior", "Atacante", "Junin", "10/10/1990",    44,       30,             2);
Time1.Add(user);

// user.AplicarCartao(num);
// user.CumprirSuspensao();


for (int k = 0; k<Time1.Count(); k++)
    Time1[k].Mostrar();


