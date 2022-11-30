using elevadorServiceImpl;
using provaApiSulCsharp;

namespace elevadortest
{
    class Program
    {
        IElevadorService elevadorService;

        public static void Main(string[] args)
        {
            new Program();
        }

        private Program()
        {
            elevadorService = new ElevadorServiceImpl();
            listarEstatisticas();
        }

        private void listarEstatisticas()
        {
            // a.Qual é o andar menos utilizado pelos usuários;
            // b.Qual é o elevador mais frequentado e o período que se encontra maior fluxo;
            // c.Qual é o elevador menos frequentado e o período que se encontra menor fluxo;
            // d.Qual o período de maior utilização do conjunto de elevadores;
            // e.Qual o percentual de uso de cada elevador com relação a todos os serviços prestados

            //
            Console.WriteLine("ELEVADOR SERVICE - ESTATÍSTICAS:");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            // a.Qual é o andar menos utilizado pelos usuários;
            List<int> andarMenosUtilizado = elevadorService.andarMenosUtilizado();
            Console.Write("Andar Menos Utilizado pelos Usuários: ");
            for (int i = 0; i < andarMenosUtilizado.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", andarMenosUtilizado[i]);
            }
            Console.WriteLine();

            // b.1 Qual é o elevador mais frequentado e o período que se encontra maior fluxo;
            List<char> elevadorMaisFrequentado = elevadorService.elevadorMaisFrequentado();
            Console.Write("Elevador Mais Frequentado: ");
            for (int i = 0; i < elevadorMaisFrequentado.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", elevadorMaisFrequentado[i]);
            }
            Console.WriteLine();

            // b.2 Qual é o período que se encontra maior fluxo do elevador mais frequentado
            List<char> periodoMaiorFluxoElevadorMaisFrequentado = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();
            Console.Write("Período que se encontra maior fluxo do elevador mais frequentado: ");
            for (int i = 0; i < periodoMaiorFluxoElevadorMaisFrequentado.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", periodoMaiorFluxoElevadorMaisFrequentado[i]);
            }
            Console.WriteLine();

            // c.1 Qual é o elevador menos frequentado e o período que se encontra menor fluxo
            List<char> elevadorMenosFrequentado = elevadorService.elevadorMenosFrequentado();
            Console.Write("Elevador Menos Frequentado: ");
            for (int i = 0; i < elevadorMenosFrequentado.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", elevadorMenosFrequentado[i]);
            }
            Console.WriteLine();

            // c.2 Qual é o período que se encontra menor fluxo do elevador menos frequentado
            List<char> periodoMenorFluxoElevadorMenosFrequentado = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();
            Console.Write("Período que se encontra menor fluxo do elevador menos frequentado: ");
            for (int i = 0; i < periodoMenorFluxoElevadorMenosFrequentado.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", periodoMenorFluxoElevadorMenosFrequentado[i]);
            }
            Console.WriteLine();

            // d.Qual o período de maior utilização do conjunto de elevadores;
            List<char> periodoMaiorUtilizacaoConjuntoElevadores = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
            Console.Write("Período de maior utilização do conjunto de elevadores: ");
            for (int i = 0; i < periodoMaiorUtilizacaoConjuntoElevadores.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write("{0}", periodoMaiorUtilizacaoConjuntoElevadores[i]);
            }
            Console.WriteLine();

            // e.Qual o percentual de uso de cada elevador com relação a todos os serviços prestados
            Console.WriteLine("Percentual de Uso do Elevador A: " + elevadorService.percentualDeUsoElevadorA());
            Console.WriteLine("Percentual de Uso do Elevador B: " + elevadorService.percentualDeUsoElevadorB());
            Console.WriteLine("Percentual de Uso do Elevador C: " + elevadorService.percentualDeUsoElevadorC());
            Console.WriteLine("Percentual de Uso do Elevador D: " + elevadorService.percentualDeUsoElevadorD());
            Console.WriteLine("Percentual de Uso do Elevador E: " + elevadorService.percentualDeUsoElevadorE());
            Console.WriteLine();
        }
    }
}