
    class Problema
    {
        public int[,] mapa = {
            {0, 0, 0, 0, 2, 0, 0, 0, 0, 0}, // 0 - espaço livre
            {0, 0, 0, 0, 0, 0, 5, 1, 1, 0}, // 1 - parede
            {0, 0, 1, 1, 0, 0, 0, 1, 1, 0}, // 2 - inimigo
            {0, 0, 1, 1, 0, 0, 0, 0, 0, 0}, // 3 - ponto de partida
            {0, 0, 0, 0, 0, 2, 0, 0, 0, 0}, // 4 - destino
            {2, 0, 0, 0, 0, 0, 0, 0, 2, 0},
            {0, 0, 0, 2, 0, 0, 0, 0, 0, 0},
            {0, 4, 0, 0, 0, 1, 1, 0, 0, 0},
            {0, 1, 1, 0, 0, 1, 1, 0, 0, 1},
            {0, 1, 1, 0, 0, 0, 0, 0, 0, 1}
        };
         public required int[] ponto_de_partida;
         public required int[] destino;

         public required LinkedList<Geracao> geracoes;

         public static Problema atual;

         public Problema()
         {

            ponto_de_partida = new int[2];
            ponto_de_partida[0] = 7;
            ponto_de_partida[1] = 1;

            destino = new int[2];
            destino[0] = 1;
            destino[1] = 6;

            atual = this;

            geracoes = new LinkedList<Geracao>();
            Geracao primeira = new Geracao();
         }

    }
