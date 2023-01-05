
//Array med person-objekter.
Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};



//Opgave 1 - Lav loops om til LINQ
Console.WriteLine("!!!!!!!!Opgave 1!!!!!!");
Console.WriteLine(" ");

// Udregner den samlede alder for alle mennesker.
var totalAge = people.Sum(p => p.Age);
Console.WriteLine(totalAge);

Console.WriteLine(" ");

// Tæller hvor mange der hedder "Nielsen"
var countNielsen = people.Count(p => p.Name.Contains("Nielsen"));
Console.WriteLine(countNielsen);

Console.WriteLine(" ");

// Find den ældste person
var ældstePerson = people.MaxBy(p => p.Age).Name;
Console.WriteLine(ældstePerson);

Console.WriteLine(" ");

/////////////////////////////////////////////////////////
//Opgave 2 - LINQ på et array
Console.WriteLine("!!!!!!!!Opgave 2!!!!!!");
Console.WriteLine(" ");

//Find og udskriv personen med mobilnummer “+4543215687” med Where og first (Peters løsning).
/*Her dannes et nyt array (arrayperson) via Where med personen som har tlf nummeret.
  Da der kun er en person i arrayet bruges First til at få navnet på den person.*/
var arrayperson = people.Where(p => p.Phone.Contains("+4543215687"));
Console.WriteLine(arrayperson.First().Name);

Console.WriteLine(" ");

//Find og udskriv personen med mobilnummer “+4543215687” med first (min løsning - også godkendt).
var tlfnummer = people.First(p => p.Phone.Contains("+4543215687")).Name;
Console.WriteLine(tlfnummer);

Console.WriteLine(" ");

//Vælg alle som er over 30 og udskriv dem.
var over30 = people.Where(p => p.Age > 30);

foreach (Person peoples in over30)
{
    Console.WriteLine(peoples.Name);
}

Console.WriteLine(" ");

//Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
var PeopleNew = people.Select(p => new Person
{
    Name = p.Name,
    Age = p.Age,
    Phone = p.Phone.Replace("+45", "")
});
foreach (Person personerne in PeopleNew)
{
    Console.WriteLine(personerne.Phone);


}

Console.WriteLine(" ");

//Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
//SAMME OPGAVE SOM OVENFOR MED WILLIAMS LØSNING - god da den viser man kan løse opgaven uden et foreach loop.
var PeopleNew2 = people.Select(p => new Person
{
    Name = p.Name,
    Age = p.Age,
    Phone = p.Phone.Replace("+45", "")
});

PeopleNew2.ToList().ForEach(p => Console.WriteLine(p.Name + "\t" + p.Phone));


Console.WriteLine(" ");

//Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma
var NavnOgTlfUnder30 = people.Where(p => p.Age < 30);
Console.WriteLine(string.Join(", ", NavnOgTlfUnder30.Select(p => p.Name + " : " + p.Phone)));


//Console.WriteLine(string.Join(",", telefonNummer));


/////////////////////////////////////////////////////////////////////////

//Opgave 3 - Filter-funktioner til ord

// Den nye funktion tager en tekst som input, fjerner alle ord der matcher et ord i “words”, og returnerer en tekst hvor ordene er fjernet.


// et array
var ord = new string[] { "hej", "sol", "kage" };


//Et input parameter - det er et array af strings
//højere ordens funktion
var CreateWordFilterFn = (string[] words) =>
{
    return (string str) => // Her returneres den nye funktion (det er det som gør at det er en højere ordens)
    {
        string temp = str;
        foreach (var word in words)
        {
            temp = temp.Replace(word, "");
        }
        return temp;
    };
};


//variable som kalder funktionen
var filter = CreateWordFilterFn(ord);

//udskriver funktionen
Console.WriteLine(filter("hej det er sol i dag"));



//Den nye funktion tager en tekst som input, erstatter alle ord der matcher et ord i “words” med “replacementWord”, og returnerer den nye tekst.


//To input parametre - det ene er et array af string og det andet er bare en string
//højere ordens funktion
var CreateWordReplacerFn = (string[] words, string replacementWord) =>
{
    return (string str) =>
    {
        string temp = str;
        foreach (var word in words)
        {
            temp = temp.Replace(word, replacementWord); // Her returneres den nye funktion (det er det som gør at det er en højere ordens)
        }
        return temp;
    };
};


//variable som kalder funktionen
var replace = CreateWordReplacerFn(ord, "kat");

//udskriver funktionen (hej og sol bliver erstattet af kat som er replacementworded - ord er navnet på et array som er i toppen.
Console.WriteLine(replace("hej det er sol i dag"));


//OPGAVE 4 BOUBLE SORT /////////////////////////////////////////////////////////////////////

/*
Bubbelsorteringsalgoritmen fungerer ved at sammenligne hvert par af elementer i en liste og bytte dem rundt, hvis de er i den forkerte rækkefølge.
Denne proces gentages, indtil listen er sorteret.
Tidskompleksiteten for denne algoritme er O(n^2), da den skal gennemgå listen og sammenligne hvert par elementer n gange.
 */


//Funktion man gemme i en variable: Bruges til at sortere efter alder. Hvis person1 er ældst = true / positiv tal, hvis person2 er ældst = false/ negativ tal
Func<Person, Person, int> bubbelSortAlder = (person1, person2) => person1.Age - person2.Age;

//Funktion man gemme i en variable: Bruges til at sorter efter alfabetisk rækkefølge
Func<Person, Person, int> bubbelSortAlfabet = (person1, person2) => {
if (person1.Name.CompareTo(person2.Name) > 0) { return 1; }
else
{
return -1;
}
};

//Funktion man gemme i en variable: Bruges til at sorter efter telefon nr med den mindste først. Man laver en int.Parse fordi det er en streng som parses til int for at kunne sammenligne
Func<Person, Person, int> bubbelSortPhone = (person1, person2) => { return int.Parse(person1.Phone.Replace("+45", "")) - int.Parse(person2.Phone.Replace("+45", "")); };


//Sorter efter alder - bruger BubbleSort klassen og tager people som indput samt funktionen bubbelSortAlder
BubbleSort.Sort(people, bubbelSortAlder);
foreach (Person person in people)
{
Console.WriteLine(person.Name + person.Age);
}

//Sorter efter telefon nr. med det mindste først
/*BubbleSort.Sort(people, bubbelSortPhone);
foreach (Person person in people)
{
    Console.WriteLine(person.Name + person.Phone);
}
*/

//Sorter efter alfabet
/*BubbleSort.Sort(people, bubbelSortAlfabet);
foreach (Person person in people)
{
    Console.WriteLine(person.Name + person.Age);
}
*/


//Klassen til BubbleSort som indeholder metoden swap 
public class BubbleSort
{
    // Bytter om på to elementer i et array
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Laver sortering på array med Bubble Sort. 
    // compareFn bruges til at sammeligne to personer med.
    public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }
}


class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }

}




