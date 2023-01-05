using Hashing;

public class HashSetChaining : HashSet
{
    //Array vil gemme noderne i hash-sættet
    private Node[] buckets;
    //holder styr på antallet af elementer i hash-sættet
    private int currentSize;

    //Vi laver en Node-klasse i et HashSetChaining-klassen.
    //Denne indre klasse repræsenterer en node i hash-sættet,
    //som gemmer et objekt og en reference til den næste node
    private class Node
    {
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

    // Dette er constructor for hash-sættet, som tager en integer-størrelse og initialiserer arrayet af noder
    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    //Metode der tjekker om det indeholder objektet man leder efter.
    //Metode søger efter et givent objekt i hash-sættet og returnerer en boolsk værdi, der angiver om det blev fundet eller ej
    //Big-O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder.
    public bool Contains(Object x)
    {
        // Beregn hash-værdien af objektet
        int h = HashValue(x);
        // Hent noden på indekset af hash-værdien
        Node bucket = buckets[h];
        // Sæt en found til at indikere om objektet er blevet fundet eller ej.
        bool found = false;

        // Iterér gennem den linkede liste på indekset indtil objektet er fundet eller enden af listen er nået
        while (!found && bucket != null)
        {
            // Hvis den aktuelle nodes data er lig med objektet, sættes found til true.
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            // Hvis objektet ikke er fundet, gå til den næste node i listen.
            else
            {
                bucket = bucket.Next;
            }
        }

        // Returner værdien af found.
        return found;
    }

    //Denne Add metode er uden Rehash (altså den originale), add længere nede fra opgave 3 er med rehash.
    //Flag er her i kommentarerne det samme som found.
    //Big-O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder.
    /* public bool Add(Object x)
     {
        // Beregn hash-værdien af objektet
         int h = HashValue(x);

        // Hent noden på indekset af hash-værdien
         Node bucket = buckets[h];

        // Sæt en flag til at indikere om objektet allerede er blevet tilføjet til hash-sættet
         bool found = false;

        // Iterér gennem den linkede liste på indekset indtil objektet er fundet eller enden af listen er nået
         while (!found && bucket != null)
         {
            // Hvis den aktuelle nodes data er lig med objektet, sættes flag til sand
             if (bucket.Data.Equals(x))
             {
                 found = true;
             }
            // Hvis objektet ikke er fundet, gå til den næste node i listen
             else
             {
                 bucket = bucket.Next;
             }
         }

        // Hvis objektet ikke blev fundet i hash-sættet, tilføj det til starten af den linkede liste på indekset
         if (!found)
         {
             Node newNode = new Node(x, buckets[h]);
             buckets[h] = newNode;
        // Inkrementer den aktuelle størrelse af hash-sættet
             currentSize++;
         }

        // Returner negationen af found, som vil være sand hvis objektet ikke blev fundet i hash-sættet (dvs. det blev tilføjet)
         return !found;
     }

    /*Negationen af et flag(found) betyder, at den modsatte værdi af flaget returneres.
     I dette tilfælde betyder negationen af flaget "found", at hvis found er sand(dvs.objektet blev fundet i hash-sættet), 
     så returneres falsk.Hvis found er falsk(dvs.objektet ikke blev fundet i hash-sættet), så returneres sand.
    */

    //metode til add opgave 3 Rehasing
    //Big O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder.
    public bool Add(Object x)
    {
        //Varibaler

        // Beregn hash-værdien af objektet
        int h = HashValue(x);
        // Hent noden på indekset af hash-værdien
        Node bucket = buckets[h];
        // Sæt found til at indikere om objektet allerede er blevet tilføjet til hash-sættet
        bool found = false;

        //Hvis currentSize er større end bucket.Length * 0.75 så kalder den Rehash metoden, 
        //da antallet af pladser skal fordobles når load-faktoren bliver større end 0.75 (dvs. 75% af arrayet er fyldt op).
        if (currentSize > buckets.Length * 0.75)
        {
            //Rehash metoden gør arrayet dobbelt så langt(der ganges med 2 i Rehash metoden) og
            //tilføjer de gamle elementer til det nye array(rehasher).
            Rehash();
        }

        // Iterér gennem den linkede liste på indekset indtil objektet er fundet eller enden af listen er nået         
        while (!found && bucket != null)
        {
            // Hvis den aktuelle nodes data er lig med objektet, sættes found til true.
            if (bucket.Data.Equals(x))
            {
                found = true;
            }

            // Hvis objektet ikke er fundet, gå til den næste node i listen.
            else
            {
                bucket = bucket.Next;
            }
        }

        // hvis objektet ikke blev fundet i hash-sættet, tilføj det til starten af den linkede liste på indekset - sættes på den buckets(h).
        if (!found)
        {
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            // Inkrementer den aktuelle størrelse af hash-sættet
            currentSize++;
        }
        // Returner om objektet blev fundet i hash-sættet
        return found;
    }

    //opgave 3
    //Big O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder.
    public void Rehash()
    {
        //Opretter et nyt bucket-array med dobbelt størrelse af pladser end det nuværende.
        int doubleSize = buckets.Length * 2;
        HashSetChaining doubleArray = new HashSetChaining(doubleSize);

        // Gennemløb det nuværende bucket-array og tilføj alle de gamle elementerne til det nye array.
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];

            while (temp != null)
            {
                doubleArray.Add(temp.Data);
                temp = temp.Next;
            }
        }

        // Overskriver buckets variablen
        // Altså tildeler det nye bucket-array til denne hash-sæt instance
        buckets = doubleArray.buckets;
    }

    // Skal returnerer true hvis den finder noget at fjerne.
    //Big O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder.
    public bool Remove(Object x)
    {
        // Beregn hash-værdien af objektet
        int h = HashValue(x);
        // Hent den første node i bucket-arrayet på indekset af hash-værdien.
        Node node = buckets[h];
        // Sæt en reference til den foregående node til null.
        Node previous = null!;
        // Sæt found til at indikere om objektet er blevet fundet.
        bool found = false;

        // Iterér gennem den linkede liste på indekset indtil objektet er fundet eller enden af listen er nået.
        while (!found && node != null)
        {
            // Hvis den aktuelle nodes data er lig med objektet, sættes flag til sand og fjern noden fra listen.
            if (node.Data.Equals(x))
            {
                found = true;
                if (node == buckets[h])
                {
                    buckets[h] = buckets[h].Next;
                }
                //Ellers, sæt den næste node som den næste node af den foregående node
                else
                {
                    previous.Next = node.Next;
                }
                // Decrementer den aktuelle størrelse af hash-sættet --> størrelsen gøres mindre.
                currentSize--;
            }
            //Hvis objektet ikke er fundet, gå til den næste node i listen og sæt den som den foregående node
            else
            {
                previous = node;
                node = node.Next;
            }
        }
        // Returner om objektet blev fundet og fjernet fra hash-sættet
        return found;
    }

    // Big O - Konstant tid O(1) metode udfører beregning og er ikke afhængig af data mængde
    private int HashValue(Object x)
    {
        // Beregn hash-værdien af objektet
        int h = x.GetHashCode();
        // Hvis hash-værdien er negativ, gør den positiv
        if (h < 0)
        {
            h = -h;
        }
        // Modulér hash-værdien med længden af bucket-arrayet for at få en indeksværdi
        h = h % buckets.Length;
        // Returner den modulérede hash-værdi
        return h;
    }

    // Big O - Konstant tid O(1) metode udfører kun en operation --> at returnere størrelsen.
    public int Size()
    {
        // Returner den aktuelle størrelse af hash-sættet.
        return currentSize;
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];
            if (temp != null)
            {
                result += i + "\t";
                while (temp != null)
                {
                    result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                    temp = temp.Next;
                }
                result += "\n";
            }
        }
        return result;
    }
}