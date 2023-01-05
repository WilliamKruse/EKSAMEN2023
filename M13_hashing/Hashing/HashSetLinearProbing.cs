using System;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Hashing;

public class HashSetLinearProbing : HashSet {
    // Et objektarray til at gemme elementerne i hashsettet
    private Object[] buckets;
    // Det aktuelle antal elementer i hashsettet
    private int currentSize;
    // En enum til at repræsentere tilstanden af en bucket. Hvis tilstanden er DELETED, betyder det, at
    // bucketen er blevet slettet fra hashsettet, men bucketen bruges stadig som en del af linear probing-processen. Den viser altså at der har været noget der - det er den nødt til for at fungere.
    private enum State { DELETED }

    // Constuctor, der initialiserer bucketarrayet og sætter den aktuelle størrelse til 0
    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    //Big O - Linære tid O(n) - skal gennemgå hver node med den given hashværdi og afhænger af antallet af noder
    public bool Contains(Object x)
    {
        //Variabler.
        // Beregn hashværdien for elementet
        int h = HashValue(x);
        // Gem startindekset i tilfælde af, at vi skal starte forfra i arrayet
        int startIndex = HashValue(x);
        // En found til at spore, om vi har fundet elementet
        bool found = false;

        // Fortsæt indtil vi finder elementet eller når en tom bucket
        while (!found && buckets[h] != null)
        {
            // Hvis elementet i den aktuelle bucket er lig med x, sæt found til true
            if (buckets[h].Equals(x))
            {
                found = true;
            }
            // Hvis elementet ikke er lig med x, gå til næste bucket
            else
            {
                h = (h + 1) % buckets.Length;

                // Hvis vi har startet forfra i arrayet, betyder det, at vi har gennemsøgt
                // alle bucketene og ikke har fundet elementet, så vi kan returnere
                // found som er false.
                if (h == startIndex)
                {
                    return found;
                }
            }
        }

        //Returner found.
        return found;
    }

    //Big O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder
    public bool Add(Object x)
    {
        //Variabler
        // Beregn hashværdien for det givne objekt
        int h = HashValue(x);
        // Gem den oprindelige hashværdi til senere brug
        int startIndex = HashValue(x);
        bool found = false;


        // Fortsæt med at loope indtil vi finder en tom bucket eller kommer tilbage til starten.
        while (!found)
        {

            //hvis pladsen er tom så tilføjer man værdien til listen og found bliver true --> altså hvis den aktuelle bucket er tom, kan vi tilføje objektet her.
            if (buckets[h] == null)
            {
                buckets[h] = x;
                found = true;
                // Inkrementer den aktuelle størrelse af hashtabellen
                currentSize++;
            }

            //ellers går man en plads frem til der er en ledig plads...
            else
            {
                // Beregn indeks for den næste bucket
                h = (h + 1) % buckets.Length;

                // Hvis vi er vendt tilbage til startindekset, er tabellen fuld og vi skal returnerer found.
                if (h == startIndex)
                {
                    return found;
                }
            }
        }

        //findes der ikke noget returneres found som er false.
        return found;
    }

    //Big O - Linære tid O(n) - skal gennemgå hver node med den given hasværdi og afhænger af antallet af noder.
    public bool Remove(Object x)
    {
        //Variabler.
        //Beregn hashværdien for det givne objekt
        int h = HashValue(x);
        bool found = false;

        //Tjek om bucketen indeholder det givne objekt - Hvis det indeholder hash værdien er if condition opfyldt.
        if (buckets.Contains(x))
        {
            //Fortsæt med at loope indtil objektet er fundet
            while (!found)
            {
                // Hvis den aktuelle bucket indeholder objektet, så slet det og afslut loopet.
                if (buckets[h].Equals(x))
                {
                    buckets[h] = State.DELETED; //"slettes" men laver en speciel markering af at vi har været inde og redigere. Gør sådan at det viser at der har været noget der før sådan at det stadig fungerer. 
                    found = true; // Sæt found til true for at afslutte loopet.
                    currentSize--; // Decrementer den aktuelle størrelse af hashtabellen.
                }

                // Hvis objektet ikke er i den aktuelle bucket, prøv den næste.
                else
                {
                    // Beregn indeks for den næste bucket.
                    h = (h + 1) % buckets.Length;
                }
            }
        }

        // Returner om objektet blev fundet og fjernet --> true hvis objektet bliver fundet og fjernet fra bucketen(i loopet) og false hvis objektet ikke bliver fundet i bucketen. 
        return found;
    }

    //Big O - Konstant tid O(1) - returnere en enkelt værdi som allerede er gemt i en variabel.
    // Returner den aktuelle størrelse af hashtabellen
    public int Size() {
        return currentSize;
    }

    //Big O - Konstant tid O(1).
    private int HashValue(Object x) {

        // Hent hashkoden for det givne objekt
        int h = x.GetHashCode();
        // Hvis hashkoden er negativ, gør den positiv
        if (h < 0) {
            h = -h;
        }
        // Beregn indekset for bucketen for hashkoden
        h = h % buckets.Length;
        // Returner bucketindekset
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
