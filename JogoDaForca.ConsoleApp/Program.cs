namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = {
                "ABACATE",
                "ABACAXI",
                "ACEROLA",
                "ACAI",
                "ARACA",
                "BACABA",
                "BACURI",
                "BANANA",
                "CAJA",
                "CAJU",
                "CARAMBOLA",
                "CUPUACU",
                "GRAVIOLA",
                "GOIABA",
                "JABUTICABA",
                "JENIPAPO",
                "MACA",
                "MANGABA",
                "MANGA",
                "MARACUJA",
                "MURICI",
                "PEQUI",
                "PITANGA",
                "PITAYA",
                "SAPOTI",
                "TANGERINA",
                "UMBU",
                "UVA",
                "UVAIA"
            };

            Random geradorNumeros = new Random();

            int indiceEscolhido = geradorNumeros.Next(palavras.Length);

            string palavraEscolhida = palavras[indiceEscolhido];

            // exibir dica da palavra oculta
            char[] letrasEncontradas = new char[palavraEscolhida.Length];

            for (int caractereAtual = 0; caractereAtual < letrasEncontradas.Length; caractereAtual++)
            {
                letrasEncontradas[caractereAtual] = '_';
                Console.WriteLine();
            }

            int quantidadeErros = 0;
            bool jogadorVenceu = false;
            bool jogadorPerdeu = false;


            do //faça
            {
                string letrasEncontradasCompleta = String.Join("", letrasEncontradas);

                //operador ternario
                string cabeca = quantidadeErros >= 1 ? " o " : "";
                string troncoSuperior = quantidadeErros >= 3 ? "x" : "";
                string troncoInferior = quantidadeErros >= 3 ? " x " : "";
                string bracoEsquerdo = quantidadeErros >= 2 ? "/" : "";
                string bracoDireito = quantidadeErros >= 4 ? "\\" : "";
                string pernas = quantidadeErros >= 5 ? "/ \\" : "";

                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Jogo da Forca                               ");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(" ___________                                ");
                Console.WriteLine(" |/        |                                ");
                Console.WriteLine(" |        {0}                               ", cabeca);
                Console.WriteLine(" |        {0}{1}{2}                         ", bracoEsquerdo, troncoSuperior, bracoDireito);
                Console.WriteLine(" |        {0}                               ", troncoInferior);
                Console.WriteLine(" |        {0}                               ", pernas);
                Console.WriteLine(" |                                          ");
                Console.WriteLine(" |                                          ");
                Console.WriteLine("_|____                                      ");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Erros do jogador: " + quantidadeErros);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Palavra escolhida: " + letrasEncontradasCompleta);
                Console.WriteLine("--------------------------------------------");

                //dado um caractere
                Console.Write("Digite uma letra: ");
                string palavra = Console.ReadLine()!.ToUpper();

                if (palavra.Length > 1)
                {
                    Console.WriteLine("Informe apenas um caractere.");
                    Console.ReadLine();
                    continue;
                }

                //logica do jogo
                char chute = palavra[0];

                bool letraFoiEncontrada = false;

                for (int contadorCaracteres = 0; contadorCaracteres < palavraEscolhida.Length; contadorCaracteres++)
                {
                    char caractereAtual = palavraEscolhida[contadorCaracteres];

                    if (chute == caractereAtual)
                    {
                        letrasEncontradas[contadorCaracteres] = caractereAtual;
                        letraFoiEncontrada = true;
                    }
                }
                if (letraFoiEncontrada == false)
                    quantidadeErros++;


                string palavraEncontradaCompleta = String.Join("", letrasEncontradas);

                jogadorVenceu = palavraEncontradaCompleta == palavraEscolhida;
                
                if (jogadorVenceu)
                {
                    Console.WriteLine("--------------------------------------------|");
                    Console.WriteLine($"Vocë acertou a palavra {palavraEscolhida}, parabéns!");
                    Console.WriteLine("--------------------------------------------|");

                }

                jogadorPerdeu = quantidadeErros > 5;

                if (jogadorPerdeu)
                {
                    Console.WriteLine("--------------------------------------------|");
                    Console.WriteLine($"Vocë perdeu :( a palavra era {palavraEscolhida}");
                    Console.WriteLine("--------------------------------------------|");
                }
                


            } while (jogadorVenceu == false && jogadorPerdeu == false); //enquanto (condicao)

            Console.ReadLine();
        }
    }
}
