/*
Bubbelsorteringsalgoritmen fungerer ved at sammenligne hvert par af elementer i en liste og bytte dem rundt, hvis de er i den forkerte rækkefølge.
Denne proces gentages, indtil listen er sorteret.
Tidskompleksiteten for denne algoritme er O(n^2), da den skal gennemgå listen og sammenligne hvert par elementer n gange.
 */


//Array med personer
Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};


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


//Klasse til person array
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}