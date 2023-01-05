using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Opgave 3
app.MapGet("/api/hello", () => new { Message = $"Hello world!" });


//Opgave 4

app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name} you are {age}!" });


//app.Run();  ---- står nederst i opgaven



//Opgave 5

//Array af strenge
String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

Random rnd = new Random();

app.MapGet("/api/fruit", () => frugter);
app.MapGet("/api/fruit/{index}", (int index) => frugter[index]);
app.MapGet("/api/fruit/random", () => frugter.GetValue(rnd.Next(frugter.Length)));


/*
//Opgave 6 uden bad request


app.MapPost("/api/fruit", (Fruit fruit) =>
{

    frugter = frugter.Append(fruit.name).ToArray();
    Console.WriteLine($"Tilføjet frugt: {fruit.name}");
    return frugter;

});

// husk at dette skal stå nederst for at den virker --- record Fruit(string name); 

*/

//Opgave 6 & 7
app.MapPost("/api/fruit", (Fruit fruit) =>
{
    if (string.IsNullOrEmpty(fruit.name))
    {
        // Return 400 - det en fejl
        return Results.BadRequest();
    }
    else
    {
        // TODO: Tilføj den nye frugt til dit array!
        //Når man bruger append laver den arrayet til en liste da append opererer på lister - derfor skal vi lave det til et array igen via ToArray()
        frugter = frugter.Append(fruit.name).ToArray();
        Console.WriteLine($"Tilføjet frugt: {fruit.name}");
        // TODO: Returnér herefter arrayet med alle frugter
        return Results.Ok(frugter);
    }
});


// husk at dette skal stå nederst for at den virker --- record Fruit(string name); 

app.Run();

//record til fruit hvor vi sætter information ind om hvad vi vil have i vores array. Minder om en klasse, men lidt anderledes.
record Fruit(string name);


