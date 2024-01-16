using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class VeiculoEstacionado
    {
         public string Placa { get; set; }
        public DateTime HoraEntrada { get; set; }

        public VeiculoEstacionado(string placa, DateTime horaEntrada)
        {
            Placa = placa;
            HoraEntrada = horaEntrada;
        }
    }
    }
