using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDomain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public Decimal Valor { get; set; } = 0;
        public int Quantidade { get; set; } = 0;
    }
}
