using System;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

string token;

if (args.Length == 0)
{
    Console.Write("Enter Token: ");
    token = Console.ReadLine();
}
else
{
    token = args[0];
}

var handler = new JwtSecurityTokenHandler();

var color = Console.ForegroundColor;

try
{
    if (!handler.CanReadToken(token))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("String is not valid JWT.");
        return;
    }

    var jwtSecurityToken = handler.ReadJwtToken(token);

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(JObject.Parse(jwtSecurityToken.Payload.SerializeToJson()).ToString(Formatting.Indented));
}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Cannot parse JWT. Error message: {0}", e.Message);
}
finally
{
    Console.ForegroundColor = color;
}