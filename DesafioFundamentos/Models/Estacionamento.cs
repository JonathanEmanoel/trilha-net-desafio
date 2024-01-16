namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<VeiculoEstacionado> veiculos = new List<VeiculoEstacionado>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa = Console.ReadLine();

            if (!veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                veiculos.Add(new VeiculoEstacionado(placa, DateTime.Now));
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Veículo com placa {placa} já está estacionado!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            VeiculoEstacionado veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());

            if (veiculo != null)
            {
                Console.WriteLine("Digite a hora de saída (formato HH:mm):");
                if (DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime horaSaida))
                {
                    TimeSpan tempoEstacionado = horaSaida - veiculo.HoraEntrada;
                    decimal valorTotal = precoInicial + (precoPorHora * (decimal)tempoEstacionado.TotalHours);

                    veiculos.Remove(veiculo);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Digite uma hora válida no formato HH:mm.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo.Placa} - Estacionado em: {veiculo.HoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

