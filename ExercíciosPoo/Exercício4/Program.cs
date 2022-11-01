
List<Jogador> Time1 = new List<Jogador>();

//                         ID    NOME     POSIÇÃO      APELIDO       DATA     NUMERO   QUALIDADE  CARTAOAMARELO 
Jogador user = new Jogador(01, "Junin", "Atacante", "ApelidoUser", "101010",    44,       30,             2);
Time1.Add(user);

// user.AplicarCartao(num);
// user.CumprirSuspensao();


for (int k = 0; k<Time1.Count(); k++)
    Time1[k].Mostrar();


