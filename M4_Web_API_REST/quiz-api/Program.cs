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



//Liste med spørgsmål, tilhørende svarmuligheder og det korrekt svar.
List<Question> list = new List<Question>();

list.Add(new Question(1, "what is 6 + 3 ? ", new string[] { "9", "8" }, "9"));
list.Add(new Question(2, "what type of animal is tuna sandwitches made from ?", new string[] { "Ham", "tuna" }, "tuna"));
list.Add(new Question(3, "which city is the capital of Denmark?", new string[] { "Hamburg", "Cophenhagen" }, "Cophenhagen"));
list.Add(new Question(4, "when does the moon appear?", new string[] { "Morning", "Evening" }, "Evening"));


//API GET som laver en liste som viser id, spørgsmål og svar og returner dette
app.MapGet("api/quiz/", () =>
{
    List<QuestionCut> temp = new List<QuestionCut>();
    foreach (var q in list)
    {
        temp.Add(new QuestionCut(q.id, q.question, q.answers));
    }
    return temp;
});


//API GET henter et bestemt spørgsmål på id og dets svarmuligheder men ikke hvilke et svar der er det rigtige
app.MapGet("api/quiz/{id}", (int id) =>
{
    return list.Where(x => x.id == id);
});



//API GET som henter et bestemt spørgsmål på id og returnerer true eller false alt efter om det man svarer er true eller false.
app.MapGet("api/quiz/{id}/{svar}", (int id, string svar) =>
{
    if (list.Where(x => x.id == id).First().correct == svar)
    {
        return true;
    }
    else
    {
        return false;
    }
});

//kører API
app.Run();

//Records som gør at vi kan sætte de informationer ind i de to lister som vi gerne vil have med. 
public record Question(int id, string question, string[] answers, string correct);
public record QuestionCut(int id, string question, string[] answers);







