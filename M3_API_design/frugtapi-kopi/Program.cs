var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
Tidskompleksiteten for disse kodestykker er O(1) for alle GET-routes og O(n) for POST-routen, hvor n er længden af frugter-arrayet.
Dette skyldes, at GET-routes blot returnerer en værdi uden at udføre nogen form for sortering eller iterating gennem arrayet,
mens POST-routen tilføjer et element til arrayet og returnerer det sorterede array, hvilket kræver en iteration gennem arrayet for at sorter det.
*/

String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

app.MapGet("/", () => "Hello World!");

/*
GET /api/fruit: Returnerer hele frugt-arrayet.
GET /api/fruit/{index}: Returnerer navnet på en bestemt frugt. Frugten findes i dit frugt-array under index, som er et tal.
GET /api/fruit/random: Returnerer navnet på en tilfældig frugt, dvs. en frugt med et tilfældigt index i arrayet.
*/

app.MapGet("/api/fruit", () => frugter);
app.MapGet("/api/fruit/{index}", (int index) => frugter[index]);
app.MapGet("/api/fruit/random", () => {
    var random = new Random();
    return frugter[random.Next(frugter.Length)];
});

app.MapPost("/api/fruit", (Fruit fruit) =>
{
    if (string.IsNullOrEmpty(fruit.name)) {
        // Return 400
        return Results.BadRequest();
    } else {
        frugter = frugter.Append(fruit.name).ToArray();
        return Results.Ok(frugter);
    }
});


app.Run();


record Fruit(string name);