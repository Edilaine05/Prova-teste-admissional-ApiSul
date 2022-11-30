using ElementoPredio99A;
using Newtonsoft.Json;
using provaApiSulCsharp;

namespace elevadorServiceImpl
{
    public class ElevadorServiceImpl : IElevadorService
    {
        private const int NUMERO_ANDARES = 16;
        private const int NUMERO_ELEVADORES = 5;

        private List<Elemento> lista;

        private Dictionary<int, int> andares;
        private Dictionary<char, int> elevadores;

        private float percentualDeUsoElevadorA;
        private float percentualDeUsoElevadorB;
        private float percentualDeUsoElevadorC;
        private float percentualDeUsoElevadorD;
        private float percentualDeUsoElevadorE;

        public ElevadorServiceImpl()
        {
            andares = new Dictionary<int, int>(NUMERO_ANDARES);
            elevadores = new Dictionary<char, int>(NUMERO_ELEVADORES);

            for (int i = 0; i < NUMERO_ANDARES; i++)
            {
                andares.Add(i, 0);
            }

            for (int i = 0; i < NUMERO_ELEVADORES; i++)
            {
                elevadores.Add((char)('A' + i), 0);
            }

            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\input.json");
            lista = JsonConvert.DeserializeObject<List<Elemento>>(json);


            for (int i = 0; i < lista.Count; i++)
            {
                // numero de acessos de cada andar
                andares[lista[i].andar]++;

                // numero de acessos de cada elevador
                elevadores[lista[i].elevador]++;


                // quantidade de usos do ElevadorA
                if (lista[i].elevador.Equals('A'))
                {
                    percentualDeUsoElevadorA++;
                }

                // quantidade de usos do ElevadorB
                if (lista[i].elevador.Equals('B'))
                {
                    percentualDeUsoElevadorB++;
                }

                // quantidade de usos do ElevadorC
                if (lista[i].elevador.Equals('C'))
                {
                    percentualDeUsoElevadorC++;
                }

                // quantidade de usos do ElevadorD
                if (lista[i].elevador.Equals('D'))
                {
                    percentualDeUsoElevadorD++;
                }

                // quantidade de usos do ElevadorE
                if (lista[i].elevador.Equals('E'))
                {
                    percentualDeUsoElevadorE++;
                }
            }

            // calcula percentualDeUsoElevadorA
            percentualDeUsoElevadorA = (float)Math.Round(percentualDeUsoElevadorA * 100.0F / lista.Count, 2);

            // calcula percentualDeUsoElevadorB
            percentualDeUsoElevadorB = (float)Math.Round(percentualDeUsoElevadorB * 100.0F / lista.Count, 2);

            // calcula percentualDeUsoElevadorC
            percentualDeUsoElevadorC = (float)Math.Round(percentualDeUsoElevadorC * 100.0F / lista.Count, 2);

            // calcula percentualDeUsoElevadorD
            percentualDeUsoElevadorD = (float)Math.Round(percentualDeUsoElevadorD * 100.0F / lista.Count, 2);

            // calcula percentualDeUsoElevadorE
            percentualDeUsoElevadorE = (float)Math.Round(percentualDeUsoElevadorE * 100.0F / lista.Count, 2);
        }

        private List<int> getListaAndarMenosUtilizado()
        {
            // Order by values.
            // ... Use LINQ to specify sorting by value.
            var items = from pair in andares
                        orderby pair.Value ascending
                        select pair;

            // fill results.
            int temp = -1;
            List<int> result = new List<int>();

            foreach (KeyValuePair<int, int> pair in items)
            {
                if (temp == -1 || pair.Value == temp)
                {
                    temp = pair.Value;
                    result.Add(pair.Key);
                    // Console.WriteLine("Andar Menos Utilizado: {0}, Numero de vezes: {1}", pair.Key, pair.Value);
                }
            }
            return result;
        }

        private List<char> getListaElevadorMaisFrequentado()
        {
            // Order by values.
            // ... Use LINQ to specify sorting by value.
            var items = from pair in elevadores
                        orderby pair.Value descending
                        select pair;

            // fill results.
            int temp = -1;
            List<char> result = new List<char>();

            foreach (KeyValuePair<char, int> pair in items)
            {
                if (temp == -1 || pair.Value == temp)
                {
                    temp = pair.Value;
                    result.Add(pair.Key);
                    // Console.WriteLine("Elevador Mais Frequentado: {0}, Nemero de Vezes: {1}", pair.Key, pair.Value);
                }
            }
            return result;
        }

        private List<char> getListaElevadorMenosFrequentado()
        {
            // Order by values.
            // ... Use LINQ to specify sorting by value.
            var items = from pair in elevadores
                        orderby pair.Value ascending
                        select pair;

            // fill results.
            int temp = -1;
            List<char> result = new List<char>();

            foreach (KeyValuePair<char, int> pair in items)
            {
                if (temp == -1 || pair.Value == temp)
                {
                    temp = pair.Value;
                    result.Add(pair.Key);
                    // Console.WriteLine("Elevador Menos Frequentado: {0}, Nemero de Vezes: {1}", pair.Key, pair.Value);
                }
            }
            return result;
        }

        private List<char> getListaPeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            // calcula a lista de periodo de maior fluxo do elevador mais frequentado
            List<char> listaElevadorMaisFrequentado = getListaElevadorMaisFrequentado();
            List<char> result = new List<char>();

            for (int i1 = 0; i1 < listaElevadorMaisFrequentado.Count; i1++)
            {
                int m = 0;
                int v = 0;
                int n = 0;
                Dictionary<char, int> turnos = new Dictionary<char, int>();

                char elevadorAtual = listaElevadorMaisFrequentado[i1];

                for (int i2 = 0; i2 < lista.Count; i2++)
                {
                    if (lista[i2].elevador.Equals(elevadorAtual))
                    {
                        switch (lista[i2].turno)
                        {
                            case 'M':
                                m++;
                                break;
                            case 'V':
                                v++;
                                break;
                            case 'N':
                                n++;
                                break;
                        }
                    }
                }
                turnos.Add('M', m);
                turnos.Add('V', v);
                turnos.Add('N', n);

                // Order by values.
                // ... Use LINQ to specify sorting by value.
                var items = from pair in turnos
                            orderby pair.Value descending
                            select pair;

                // fill results.
                int temp = -1;

                foreach (KeyValuePair<char, int> pair in items)
                {
                    if (temp == -1 || pair.Value == temp)
                    {
                        temp = pair.Value;
                        if (!result.Contains(pair.Key))
                        {
                            result.Add(pair.Key);
                        }
                        // Console.WriteLine("Lista Elevador Mais Frequentado - Elevador Atual: {0}, Periodo: {1}, Numero de usos: {2}", elevadorAtual, pair.Key, pair.Value);
                    }
                }
            }
            return result;
        }

        private List<char> getListaPeriodoMenorFluxoElevadorMenosFrequentado()
        {
            // calcula a lista de periodo de maior fluxo do elevador mais frequentado
            List<char> listaElevadorMenosFrequentado = getListaElevadorMenosFrequentado();
            List<char> result = new List<char>();

            for (int i1 = 0; i1 < listaElevadorMenosFrequentado.Count; i1++)
            {
                int m = 0;
                int v = 0;
                int n = 0;
                Dictionary<char, int> turnos = new Dictionary<char, int>();

                char elevadorAtual = listaElevadorMenosFrequentado[i1];

                for (int i2 = 0; i2 < lista.Count; i2++)
                {
                    if (lista[i2].elevador.Equals(elevadorAtual))
                    {
                        switch (lista[i2].turno)
                        {
                            case 'M':
                                m++;
                                break;
                            case 'V':
                                v++;
                                break;
                            case 'N':
                                n++;
                                break;
                        }
                    }
                }
                turnos.Add('M', m);
                turnos.Add('V', v);
                turnos.Add('N', n);

                // Order by values.
                // ... Use LINQ to specify sorting by value.
                var items = from pair in turnos
                            orderby pair.Value ascending
                            select pair;

                // fill results.
                int temp = -1;

                foreach (KeyValuePair<char, int> pair in items)
                {
                    if (temp == -1 || pair.Value == temp)
                    {
                        temp = pair.Value;
                        if (!result.Contains(pair.Key))
                        {
                            result.Add(pair.Key);
                        }
                        // Console.WriteLine("Lista Elevador Menos Frequentado - Elevador Atual: {0}, Periodo: {1}, Numero de usos: {2}", elevadorAtual, pair.Key, pair.Value);
                    }
                }
            }
            return result;
        }

        private List<char> getListaPeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            // calcula a lista do periodo de maior fluxo do conjunto de elevadores
            List<char> result = new List<char>();

            int m = 0;
            int v = 0;
            int n = 0;

            for (int i1 = 0; i1 < lista.Count; i1++)
            {
                char turnoAtual = lista[i1].turno;

                switch (turnoAtual)
                {
                    case 'M':
                        m++;
                        break;
                    case 'V':
                        v++;
                        break;
                    case 'N':
                        n++;
                        break;
                }
            }
            Dictionary<char, int> turnos = new Dictionary<char, int>();
            turnos.Add('M', m);
            turnos.Add('V', v);
            turnos.Add('N', n);

            // Order by values.
            // ... Use LINQ to specify sorting by value.
            var items = from pair in turnos
                        orderby pair.Value descending
                        select pair;

            // fill results.
            int temp = -1;

            foreach (KeyValuePair<char, int> pair in items)
            {
                if (temp == -1 || pair.Value == temp)
                {
                    temp = pair.Value;
                    if (!result.Contains(pair.Key))
                    {
                        result.Add(pair.Key);
                    }
                    // Console.WriteLine("Lista do período de maior fluxo do conjunto de elevadores - Periodo: {0}, Numero de usos: {1}", pair.Key, pair.Value);
                }
            }
            return result;
        }

        //

        List<int> IElevadorService.andarMenosUtilizado()
        {
            return getListaAndarMenosUtilizado();
        }

        List<char> IElevadorService.elevadorMaisFrequentado()
        {
            return getListaElevadorMaisFrequentado();
        }

        List<char> IElevadorService.elevadorMenosFrequentado()
        {
            return getListaElevadorMenosFrequentado();
        }

        float IElevadorService.percentualDeUsoElevadorA()
        {
            return percentualDeUsoElevadorA;
        }

        float IElevadorService.percentualDeUsoElevadorB()
        {
            return percentualDeUsoElevadorB;
        }

        float IElevadorService.percentualDeUsoElevadorC()
        {
            return percentualDeUsoElevadorC;
        }

        float IElevadorService.percentualDeUsoElevadorD()
        {
            return percentualDeUsoElevadorD;
        }

        float IElevadorService.percentualDeUsoElevadorE()
        {
            return percentualDeUsoElevadorE;
        }

        List<char> IElevadorService.periodoMaiorFluxoElevadorMaisFrequentado()
        {
            return getListaPeriodoMaiorFluxoElevadorMaisFrequentado();
        }

        List<char> IElevadorService.periodoMaiorUtilizacaoConjuntoElevadores()
        {
            return getListaPeriodoMaiorUtilizacaoConjuntoElevadores();
        }

        List<char> IElevadorService.periodoMenorFluxoElevadorMenosFrequentado()
        {
            return getListaPeriodoMenorFluxoElevadorMenosFrequentado();
        }
    }
}
