using System;
using System.Collections.Generic;

namespace Sessao3
{
    public static class D20
    {
        public static void Executar()
        {
            string zombieWalkes = "Corredor";
            string zombieSmoker = "Linguarudo";
            string zombieRotters = "Infectado";
            string skeletonCaptain = "Capitão Esqueleto";
            string skeletonWarrior = "Guerreiro Esqueleto";
            string skeletonGunner = "Esqueleto atirador";
            string mageWater = "Mago de Água";
            string mageFire = "Mago de Fogo";
            string mageLightning = "Mago de Raio";

            int vidaInimigo = 100;
            int vidaJogador = 100;

            int danoMinimo = 5;
            int danoMaximo = 20;

            int defesaMinimo = 2;
            int defesaMaxima = 10;

            int curaMinima = 5;
            int curaMaxima = 20;

            var messages = new Dictionary<int, string>
            {
                {1, "falhou miseravelmente!"},
                {2, "falhou miseravelmente!"},
                {3, "falhou!"},
                {4, "falhou!"},
                {5, "resultado mediano."},
                {6, "resultado mediano."},
                {7, "resultado bom."},
                {8, "resultado bom."},
                {9, "excelente!"},
                {10, "excelente!"},
                {11, "incrível!"},
                {12, "incrível!"},
                {13, "extraordinário!"},
                {14, "extraordinário!"},
                {15, "épico!"},
                {16, "épico!"},
                {17, "lendário!"},
                {18, "lendário!"},
                {19, "Perfeito!"},
                {20, "PERFEITO!"}
            };

            Random random = new Random();

            double GetMultiplicador(int d)
            {
                if (d <= 5) return 0.5;
                if (d <= 14) return 1.0;
                if (d <= 19) return 1.5;
                return 2.0;
            }

            while (vidaJogador > 0 && vidaInimigo > 0)
            {
                Console.Clear();

                Console.WriteLine("===== BATALHA =====\n");
                Console.WriteLine($"Sua vida: {vidaJogador}");
                Console.WriteLine($"Vida do inimigo: {vidaInimigo}");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defender");
                Console.WriteLine("3. Curar");

                int escolha = int.Parse(Console.ReadLine()!);

                int dadoJogador = random.Next(1, 21);
                string messageJogador = messages[dadoJogador];
                double multJogador = GetMultiplicador(dadoJogador);

                int defesaJogador = 0;

                if (escolha == 1)
                {
                    int dano = (int)(random.Next(danoMinimo, danoMaximo + 1) * multJogador);
                    vidaInimigo -= dano;
                    Console.WriteLine($"Você atacou e causou {dano} de dano! (D{dadoJogador}, {messageJogador})");
                }
                else if (escolha == 2)
                {
                    defesaJogador = (int)(random.Next(defesaMinimo, defesaMaxima + 1) * multJogador);
                    Console.WriteLine($"Você se preparou e vai bloquear {defesaJogador} de dano! (D{dadoJogador}, {messageJogador})");
                }
                else if (escolha == 3)
                {
                    int cura = (int)(random.Next(curaMinima, curaMaxima + 1) * multJogador);
                    vidaJogador += cura;
                    if (vidaJogador > 100) vidaJogador = 100;
                    Console.WriteLine($"Você se curou em {cura} de vida! (D{dadoJogador}, {messageJogador})");
                }

                if (vidaInimigo <= 0)
                    break;

                int escolhaInimigo;

                if (vidaInimigo <= 30)
                {
                    escolhaInimigo = random.Next(1, 4);
                }
                else
                {
                    escolhaInimigo = random.Next(1, 3);
                }

                int dadoInimigo = random.Next(1, 21);
                string messageInimigo = messages[dadoInimigo];
                double multInimigo = GetMultiplicador(dadoInimigo);

                if (escolhaInimigo == 1)
                {
                    int dano = (int)(random.Next(danoMinimo, danoMaximo + 1) * multInimigo);
                    dano -= defesaJogador;
                    if (dano < 0) dano = 0;
                    vidaJogador -= dano;
                    Console.WriteLine($"O inimigo te atacou e causou {dano} de dano! (D{dadoInimigo}, {messageInimigo})");
                }
                else if (escolhaInimigo == 2)
                {
                    int efeito = (int)(random.Next(curaMinima, curaMaxima + 1) * multInimigo);
                    vidaJogador -= efeito;
                    Console.WriteLine($"O inimigo se defendeu e causou {efeito} de dano indireto! (D{dadoInimigo}, {messageInimigo})");
                }
                else if (escolhaInimigo == 3)
                {
                    int cura = (int)(random.Next(curaMinima, curaMaxima + 1) * multInimigo);
                    vidaInimigo += cura;
                    if (vidaInimigo > 100) vidaInimigo = 100;
                    Console.WriteLine($"O inimigo se curou em {cura}! (D{dadoInimigo}, {messageInimigo})");
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }

            Console.Clear();

            if (vidaJogador > 0)
                Console.WriteLine("Você venceu o inimigo!");
            else
                Console.WriteLine("Você foi derrotado...");
        }
    }
}