// See https://aka.ms/new-console-template for more information

//husk db.SaveChanges();

using ef_sjov.Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create
    Console.WriteLine("Indsæt et nyt task");
    //Nyt objekt af typen User.
    User Bruger = new User("Rikke");
    db.Add(new TodoTask("ny opgave - kod en opgave", false, "kategori - kode", Bruger));
    db.SaveChanges();

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");

    //Update
    //Tager den første i listen.
    //Opdaterer tasken til at være sat til true i at tasken er udført.
    //Opdaterer på teksten, så det ændres til "Den her opgave er nu ændret".
    var update = db.Tasks.First();
    update.Done = true;
    update.Text = "Den her opgave er nu lavet";
    db.SaveChanges();


    //Delete virker, men fucker op med det hvis den kører med. 

    //Delete - sletter første i listen hvor TodoTaskId matcher med givne id som her er 2.
    //Der er selvfølgelig kun en i listen med TodoTaskId 2 når man søger det frem eftersom man jeg sorterer via Where på TodoTaksId.
    //Husk at ændre næste gang man vil slette noget da id 2 nu er slettet.
    /* var deleteTask = db.Tasks.Where(t => t.TodoTaskId == 2).First();
     db.Tasks.Remove(deleteTask);
     db.SaveChanges();
    */


    //Delete2 - sletter den første i listen.
    /*
    var deleteTask2 = db.Tasks.First();
    db.Tasks.Remove(deleteTask2);
    db.SaveChanges();
       db.SaveChanges();
    */
}
