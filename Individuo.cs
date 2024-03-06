
class Individuo
{
    public int[] posicao;
    public double distancia_objetivo;
    public int distancia_percorrida;
    public int[] gene;

    public int status; // 0 - Morto / 1 - Executando / 2 - Esgotado / 3 - Sucesso


    public Individuo()
    {
        posicao = new int[2];
        posicao[0] = Problema.atual.ponto_de_partida[0];
        posicao[1] = Problema.atual.ponto_de_partida[1];
        distancia_percorrida = 0;
        status = 1;
        gene = new int [200];
        gerar_genes();

    }

    public void executar()
    {
        int[,] mapa = Problema.atual.mapa;
        int cont = 0;
        do
        {
            int direcao = 0;
            for (int j=0; j<2; j++)
            {
                direcao+= (int)Math.Pow(2, j) * gene[cont];
                cont++;
            }
            int distancia = 1;
            for (int j=0; j<2; j++)
            {
                distancia+= (int)Math.Pow(2, j) * gene[cont];
                cont++;
            }

            for (int j=0; j<distancia; j++)
            {
                bool avancar = false;
                switch(direcao)
                {
                    case 0:
                        avancar = posicao[1]+1 <10 && mapa[posicao[0], posicao[1]+1] != 1;
                        if(avancar) posicao[1]++;
                    break;

                    case 1:
                        avancar = posicao[0]+1 <10 && mapa[posicao[0]+1, posicao[1]] != 1;
                        if(avancar) posicao[0]++;
                    break;

                    case 2:
                        avancar = posicao[1]-1 >=0 && mapa[posicao[0], posicao[1]-1] != 1;
                        if(avancar) posicao[1]--;
                    break;

                    case 3:
                        avancar = posicao[0]-1 >=0 && mapa[posicao[0]-1, posicao[1]] != 1;
                        if(avancar) posicao[0]--;
                    break;
                }
                if(avancar)
                {
                    distancia_percorrida++;
                    distancia_objetivo = Math.Sqrt(Math.Pow(Math.Abs(posicao[0] - Problema.atual.destino[0]), 2) + Math.Pow(Math.Abs(posicao[0] - Problema.atual.destino[0]), 2));
                    if (mapa[posicao[0], posicao[1]] == 2)
                    {
                        status = 0;
                        return;
                    }
                    else if (mapa[posicao[0], posicao[1]] == 4)
                    {
                        status = 3;
                        return;
                    }
                }
                else break;

            }

        } while (cont<200);
        status = 2;
    }

    public void gerar_genes()
    {
        Random gen = new Random();
        for (int i=0; i<200; i++)
        {
            gene[i] = gen.Next(0, 1);
        }
    }
}
