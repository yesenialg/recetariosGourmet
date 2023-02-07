// See https://aka.ms/new-console-template for more information
using Gourmet;
using Microsoft.EntityFrameworkCore;

var context = new DBRecetariosContext();
long id = 190;
var recetario = context.Recetarios.Find(id);

var LeerRecetarios = recetario.RecetasDeUnRecetario();

Console.WriteLine("RECETARIOS");
Console.WriteLine(LeerRecetarios.Count);
foreach (var i in LeerRecetarios)
{
    Console.WriteLine(i);
}