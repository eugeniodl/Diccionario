using System.Text.RegularExpressions;

Dictionary<string, string> diccionario = CrearDiccionario();
Console.Write("\nEscriba la palabra que desee traducir del inglés al español: ");
string? palabra = Console.ReadLine();

if (palabra != null && palabra.Length != 0)
    Console.WriteLine(Traducir(palabra, diccionario));

Dictionary<string, string> CrearDiccionario()
{
    Dictionary<string, string> diccionario = new Dictionary<string, string>();
    string[] palabras = new string[100];
    Regex miRegex = new Regex(",");

    Console.WriteLine("Escriba las palabras (inglés y español) en el siguiente formato:\nbook:libro,green:verde,mouse:ratón\n");
    string? entrada = Console.ReadLine();

    if (entrada != null && entrada.Length != 0)
        palabras = miRegex.Split(entrada);

    foreach (string palabra in palabras)
    {
        if (palabra != null && palabra.Length != 0)
            diccionario.Add(palabra.Split(":")[0], palabra.Split(":")[1]);
    }

    return diccionario;
}

string Traducir(string? palabra, Dictionary<string, string> diccionario)
{
    string traduccion;
    if (palabra != null && diccionario.ContainsKey(palabra))
        traduccion = diccionario[palabra];
    else
        traduccion = "¡La palabra no se encuentra en el diccionario!";
    return traduccion;
}
