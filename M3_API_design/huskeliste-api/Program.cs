var builder = WebApplication.CreateBuilder(args);


var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);


//Array med typen todos.
Todo[] huskeliste = new Todo[]
{
   new Todo(1,"gøre rent",false), new Todo(2, "vasketøj", true)
};

//API som returnerer hele arrayet
//O(1) - konstant tid - vil kun tage et enkelt trin. 
app.MapGet("/api/huskeliste", () => huskeliste);

//API som returnerer på det valgte index (opmærksom på at index 0 ikke har id 0 (her har index 0 id 1).
//O(1) - konstant tid fordi det kun tager en operation at hente på et index uanset hvad index-inputtet er.
app.MapGet("/api/huskeliste/{index}", (int index) => huskeliste[index]);

//API post som bruges til at oprette en ny opgave.
////O(n) - linæer tid.
app.MapPost("/api/huskeliste", (Todo todo) =>
{
    /* Arrayet huskeliste bliver lavet til en liste som er præcis ligesom arrayet - vi synes det er nemmere at arbejde på en liste.
       Næste linje bruges til at tilføje en ny opgave til templist og giver den et nyt id (det sidste eksistrende id i arrayet plus 1)
       Vi laver derefter listen tilbage til et array. Altså er huskeliste lig med den temp liste lavet om til et array igen */
   
    List<Todo> tempList = huskeliste.ToList();
    tempList.Add(new Todo(tempList.Last().id + 1,todo.text,todo.done));
    huskeliste = tempList.ToArray();
    return huskeliste;

});


//API som sletter på id.
//O(n) - linæer tid.
app.MapDelete("/api/huskeliste/{id}", (int id) =>
{
    //en midertidlig liste
    List<Todo> tempList = huskeliste.ToList();
    //fjerne alle fra listen hvor id er lig det valgte id.
    tempList.RemoveAll(x => x.id == id);
    //huskelisten bliver sat til tempList og lavet om til et array igen.
    huskeliste = tempList.ToArray();
    return huskeliste;
}
);



//API put til at opdatere en opgave via id
//O(n) - linæer tid.
app.MapPut("/api/huskeliste/{id}", (Todo todo, int id) =>
{

    //en midertidlig liste
    List<Todo> tempList = huskeliste.ToList();

    //hvis ID'et ikke eksiterer kan man ikke anvende PUT (man får bad request)
    if (tempList.Where(x => x.id == id).Count() == 0)
    {
        return Results.BadRequest();
    }

    else
    {
        //fjerner alle fra listen hvor id er lig det valgte id
        tempList.RemoveAll(x => x.id == id);
        //tilføjer den opdaterede opgave med det tilhørende id som er skrevet i URL'en.
        tempList.Add(new Todo(id, todo.text, todo.done));
        //huskelisten bliver sat lig med tempList som bliver sorteret på id via OrderBy og lavet om til et array.
        huskeliste = tempList.OrderBy(x => x.id).ToArray();
      
        return Results.Ok(huskeliste);
    }
}
);



/*
app.MapPut("/api/huskeliste/{id}", (int id, Todo todo) =>
{
   foreach (var x in huskeliste)
    {
        if (x.id == id)
        {
            x.text = todo.text;
        }
    }
});
*/


app.Run();

//Record til todo hvor vi sætter informationer ind om det vi vil have i vores array.
record Todo(int id, string text, bool done);