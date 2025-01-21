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

Console.Write("Digite o tamanho da senha: ");

if (!int.TryParse(Console.ReadLine(), out int tamanho) || tamanho <= 0)
{
    Console.WriteLine("Tamanho inválido. O programa será encerrado.");
    return;
}

string senha = GerarSenha(escolha, tamanho);

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"Senha gerada:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Black;
Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.WriteLine($"{senha}");
Console.ResetColor();

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
