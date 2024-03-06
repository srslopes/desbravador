class Geracao
{
    public int numero;
    public static int n = 0;
    private int x = 0;
    public int y;

    public static int tamanho = 10;

    public static int n_selecionados = 4;


    public required List<Individuo> sucedidos;
    public required List<Individuo> esgotados;
    public required List<Individuo> mortos;
    public required List<Individuo> selecionados;

    public Geracao()
    {
        sucedidos = new List<Individuo>();
        esgotados = new List<Individuo>();
        mortos = new List<Individuo>();

        for(int i = 0; i<tamanho; i++)
        {
            Individuo individuo = new Individuo();
            individuo.executar();
            switch(individuo.status)
            {
                case 0:
                    mortos.Add(individuo);
                break;

                case 1:
                    esgotados.Add(individuo);
                break;

                case 2:
                    sucedidos.Add(individuo);
                break;
            }
        }
        sucedidos.Sort(i => i.distancia_objetivo);
    }




}
