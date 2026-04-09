using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao3
{
    public static class D20
    {
        public static void Executar()
        {
            var random = new Random();
            var resultado = random.Next(1, 21);
            Console.WriteLine($"");
        }
    }
}