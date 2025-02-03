using System;
using System.IO; // Importando a biblioteca para manipulação de arquivos

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("+===========================================+");
        Console.WriteLine("|Escolha uma opção para gerar sua senha:    |");
        Console.WriteLine("+===========================================+\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("+===========================================+");
        Console.WriteLine("| 1 - Somente números                       |");
        Console.WriteLine("| 2 - Somente letras                        |");
        Console.WriteLine("| 3 - Letras e números misturados           |");
        Console.WriteLine("| 4 - Letras, números, caractéres Especiais |");
        Console.WriteLine("+===========================================+");
        Console.ResetColor();

        Console.Write("\nDigite sua escolha (1/2/3/4): ");
        string escolha = Console.ReadLine();

        if (escolha != "1" && escolha != "2" && escolha != "3" && escolha != "4")
        {
            Console.WriteLine("Opção inválida. O programa será encerrado.");
            return;  // Encerra o programa se a opção for inválida
        }

        Console.Write("Digite o tamanho da senha: ");

        if (!int.TryParse(Console.ReadLine(), out int tamanho) || tamanho <= 0)
        {
            Console.WriteLine("Tamanho inválido. O programa será encerrado.");
            return; // Encerra o programa se o tamanho for inválido
        }

        string senha = GerarSenha(escolha, tamanho);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Senha gerada:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{senha}");
        Console.ResetColor();

        // Formatar a data e hora atual
        string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        // Caminho do arquivo para salvar
        string caminhoArquivo = "senha.txt";

        // Formatar o texto a ser salvo
        string textoParaSalvar = $"Senha gerada em: {dataHora}\n" +
                                 $"Senha:  \"{senha}\"\n" +
                                 $"===========================================\n";

        // Adiciona a senha gerada no arquivo de forma contínua (sem sobrescrever)
        File.AppendAllText(caminhoArquivo, textoParaSalvar);

        Console.WriteLine($"\nSenha salva em: {caminhoArquivo}");
        Console.WriteLine("\nObrigado por usar o gerador de senhas! Pressione qualquer tecla para sair.");
        Console.ReadKey();  // Aguarda o usuário pressionar uma tecla antes de fechar o programa
    }

    static string GerarSenha(string escolha, int tamanho)
    {
        string numeros = "0123456789";
        string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string especial = "!@#$%¨&*";
        string caracteres = "";

        switch (escolha)
        {
            case "1":
                caracteres = numeros;
                break;
            case "2":
                caracteres = letras;
                break;
            case "3":
                caracteres = numeros + letras;
                break;
            case "4":
                caracteres = numeros + letras + especial;
                break;
            default:
                Console.WriteLine("Opção inválida. Gerando senha com letras e números por padrão.");
                caracteres = numeros + letras;
                break;
        }

        Random random = new Random();
        char[] senha = new char[tamanho];

        for (int i = 0; i < tamanho; i++)
        {
            senha[i] = caracteres[random.Next(caracteres.Length)];
        }

        return new string(senha);
    }
}
