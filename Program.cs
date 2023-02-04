/*
 * Implementar um programa que lê um nome e uma senha (entre 4 e 8 caracteres) e 
 * verifica se o usuário está autorizado ou não. 
 * Para essa verificação, o programa deverá solicitar um pré cadastro dos usuários 
 * e suas senhas e armazená-las em uma (ou mais) lista de nomes e respectivas senhas. 
 * O programa mostra mensagens de erro se o nome ou a senha estiverem incorretos. 
 * São permitidas até 3 tentativas. Utilize APENAS ArrayList para as listas nessa implementação.
 */

using System.Collections;

var continueRegistration = false;

var nomes = new ArrayList();
var senhas = new ArrayList();

do
{
    Console.WriteLine("Cadastrar novo usuario: ");
    Console.Write("Nome: ");
    nomes.Add(Console.ReadLine());
    Console.Write("\nSenha (4 a 8 caracteres): ");
    var senha = Console.ReadLine()!;
    while (senha.Length < 4 || senha.Length > 8)
    {
        Console.Write("\nTamanho de senha inválido! Insira nova senha.");
        Console.Write("\nSenha (4 a 8 caracteres: ");
        senha = Console.ReadLine()!;
    }
    senhas.Add(senha);

    Console.Write("Desenha cadastrar mais um usuário (S/N)? ");
    var option = Console.ReadLine()!.ToUpper();
    while (!option.Equals("S") && !option.Equals("N"))
    {
        Console.Write("\nOpção inválida! Escolha S ou N.");
        Console.Write("\nDesenha cadastrar mais um usuário (S/N)? ");
        option = Console.ReadLine()!.ToUpper();
    }

    if (option.Equals("S"))
    {
        continueRegistration = true;
    }
    else
    {
        continueRegistration = false;
    }
}
while (continueRegistration);

var attemps = 3;
string login;
string password;

bool nameFound = false;

do
{
    Console.Write("\nLogin: ");
    login = Console.ReadLine()!.ToLower();

    foreach (string nome in nomes)
    {
        if (nome.ToLower().Equals(login))
        {
            nameFound = true;
            break;
        }
    }

    if (!nameFound)
    {
        Console.WriteLine($"Nome inválido. Restam {--attemps} tentativas.");
    }

}
while (!nameFound && attemps > 0);

attemps = 3;
bool passFound = false;

do
{
    Console.Write("\nPassword: ");
    password = Console.ReadLine()!;

    foreach (string senha in senhas)
    {
        if (senha.Equals(password))
        {
            if (senhas.IndexOf(senha) == nomes.IndexOf(login))
            {
                passFound = true;
                break;
            }
        }
    }

    if (!passFound)
    {
        Console.WriteLine($"Senha inválida. Restam {--attemps} tentativas.");
    }

}
while (!passFound && attemps > 0);

if (!passFound || attemps == 0)
{
    Console.WriteLine("Login inválido. Adeus");

    return;
}

Console.WriteLine("Login realizado com sucesso.");


