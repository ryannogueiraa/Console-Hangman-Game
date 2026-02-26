using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true) 
            {
                var categorias = new Dictionary<string, string[]>()
                {
                    { "Eletrônicos", new string[] { "televisao", "carregador", "monitor", "teclado", "telefone", "microfone", "chuveiro", "controlador" } },
                    { "Escola", new string[] { "caderno", "borracha", "escola", "universidade", "dicionario", "pincel" } },
                    { "Comida", new string[] { "batata", "maracuja", "sorvete", "hamburguer", "abacaxi", "churrasco" } },
                    { "Animais", new string[] { "cachorro", "tartaruga", "girafa", "elefante", "pinguim", "formigueiro" } },
                    { "Tecnologia", new string[] { "programacao", "internet", "computacao", "algoritmo", "tecnologia", "engrenagem" } },
                    { "Natureza", new string[] { "montanha", "floresta", "oceano", "vulcao", "girassol" } },
                    { "Aventura", new string[] { "foguete", "astronauta", "viagem", "heroi", "labirinto", "aventureiro", "teleporte" } },
                    { "Objetos Variados", new string[] { "paralelepipedo", "eletricidade", "bicicleta", "diamante", "janela", "porta", "ferramenta" } }
                };

                Random rnd = new Random();

                List<string> listaTemas = categorias.Keys.ToList();
                string temaSorteado = listaTemas[rnd.Next(listaTemas.Count)];
                string[] palavrasSecretas = categorias[temaSorteado];
                string palavraSecreta = palavrasSecretas[rnd.Next(palavrasSecretas.Length)];

                string letraDigitada;

                Console.Clear();
                Console.WriteLine("Bem-Vindo ao Jogo da Forca! Feito por Ryan!");
                Console.WriteLine("Tema: " + temaSorteado);
                Console.WriteLine("Você terá 15 tentativas.");

                char[] letrasDescobertas = new char[palavraSecreta.Length];

                for (int i = 0; i < letrasDescobertas.Length; i++)
                {
                    letrasDescobertas[i] = '_';
                }

                Console.WriteLine("Letras Descobertas: " + new string(letrasDescobertas));

                int tentativas = 0;

                while (tentativas < 15)
                {
                    Console.WriteLine("Digite uma letra: ");
                    letraDigitada = Console.ReadLine();
                    if (letraDigitada == "")
                    {
                        Console.Clear();
                        Console.WriteLine("Digite uma letra válida.");
                        Console.WriteLine("Tema: " + temaSorteado);
                        Console.WriteLine(letrasDescobertas);
                        continue;
                    }

                    char letra = letraDigitada[0];

                    if (letrasDescobertas.Contains(letra))
                    {
                        Console.Clear();
                        Console.WriteLine("Você já digitou a letra " + "(" + letra.ToString().ToUpper() + ")");
                        Console.WriteLine("Tema: " + temaSorteado);
                        Console.WriteLine(letrasDescobertas);
                        continue;
                    }

                    if (palavraSecreta.ToUpper().Contains(letraDigitada.ToUpper()))
                    {
                        Console.Clear();
                        Console.WriteLine("Parabéns, você acertou uma letra!");
                        Console.WriteLine("Tema: " + temaSorteado);


                        for (int i = 0; i < palavraSecreta.Length; i++)
                        {
                            if (palavraSecreta[i].ToString().ToUpper() == letraDigitada.ToUpper())
                            {
                                letrasDescobertas[i] = palavraSecreta[i];
                            }
                        }

                        Console.WriteLine(letrasDescobertas);

                        string palavraFormada = new string(letrasDescobertas);

                        if (palavraFormada.ToUpper() == palavraSecreta.ToUpper())
                        {
                            Console.Clear();
                            Console.WriteLine("Parabéns! Você ganhou!");
                            Console.WriteLine("Palavra Correta: " + palavraFormada);
                            break;
                        }
                    }
                    else
                    {
                        tentativas++;
                        Console.Clear();
                        Console.WriteLine("Você errou, restam apenas " + (15 - tentativas) + " tentativas.");
                        Console.WriteLine("Tema: " + temaSorteado);
                        Console.WriteLine(letrasDescobertas);

                        if (tentativas == 15)
                        {
                            Console.Clear();
                            Console.WriteLine("Você Perdeu :( ");
                            Console.WriteLine("A palavra correta era: " + palavraSecreta);
                        }
                    }
                }

                while (true)
                {
                    string resposta;
                    Console.WriteLine("Deseja jogar novamente? (S/N)");
                    resposta = Console.ReadLine().ToUpper();

                    if (resposta == "S")
                    {
                      
                        break;
                    }
                    else if (resposta == "N")
                    {
                        Console.WriteLine("Obrigado por Jogar!");
                        Console.ReadKey();
                        Environment.Exit(0); 
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Digite apenas S ou N...");
                    }
                }

            }
        }
    }
}
