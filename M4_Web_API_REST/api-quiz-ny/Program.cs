
var builder = WebApplication.CreateBuilder(args);

// Åben op for "CORS" i din API.
// Læs om baggrunden her: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0



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



/* Quiz[] quizzes = new Quiz[]
{
    new Quiz (0, "Ved hvilken temperatur koger vand?", new Svar[]
    {
        new Svar(1, "90 grader", false),
        new Svar(2, "85 grader", false),
        new Svar(3, "100 grader", true),
        new Svar(4, "50 grader", false)
    }),
    new Quiz (1, "Hvad står H2O for?", new Svar[]
    {
        new Svar(1, "Vand", true),
        new Svar(2, "Oxygen", false),
        new Svar(3, "Jord", false),
        new Svar(4, "Ild", false)
    })
};
*/


//Array af typen quiz, som indeholder et array med svar. Svaret er det der står mellem spørgsmål og new string[].
Quiz[] quizzes = new Quiz[]
{
    new Quiz(0, "Ved hvilken temperatur koger vand?", "100", new string[]
    {
        "90",
        "85",
        "100",
        "50"
    }),
     new Quiz(1, "Hvad står H2O for?", "vand", new string[]
    {
        "vand",
        "oxygen",
        "jord",
        "ild"
    })

};

//API GET som henter alle spørgsmål, svar osv.
//Tidskompleksiteten er O(1) - konstant tid --> det vil kun tage et enkelt trin at returnere quizzes-arrayet.
app.MapGet("/api/quiz", () => quizzes);

//API GET som henter et bestemt spørgsmål, svar osv. på id.
//Tidskompleksiteten er O(1) - konstant tid --> det tager et enkelt trin at returnere elementet på den angivne index i quizzes-arrayet.
app.MapGet("/api/quiz/{id}", (int id) => quizzes[id]);


// API GET som henter et bestemt spørgsmål på id og svarmulighed - hvis svarmuligheden er den rigtige siger den true eller false.
// O(n) - lineær tid --> skal sammenligne svarmuligheder-værdien med den rigtige svar-værdi for hver element i quizzes-arrayet, indtil det element med det angivne id er fundet.
app.MapGet("api/quiz/{id}/{svarmuligheder}", (int id, string svarmuligheder) =>
{
    List<Quiz> tempQuizList = quizzes.ToList();

    //Tjekker om svarmulighed jeg giver med er korrekt inden for det ID som er givet med.
    if (tempQuizList.Where(x => x.id == id).First().rigtig == svarmuligheder)
    {
        quizzes = tempQuizList.ToArray();
        return true;
    }
    else
    {
        quizzes = tempQuizList.ToArray();
        return false;
    }
});


app.Run();


//record Quiz(int id, string spørgsmål, Svar[] svar);


//record Svar(int id, string svarmulighed, bool rigtig);

//Svarer nogenlunde til det samme som at oprette en klasse.
record Quiz(int id, string spørgsmål, string rigtig, string[] svarmuligheder);