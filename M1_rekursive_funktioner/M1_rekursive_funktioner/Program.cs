//TESTS////////////////////////////////////////////////////////////////////////////////////////

//Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
//Console.WriteLine(Opgave3.euclid(210,45));
//Console.WriteLine(Opgave3.opløft(4, 5));
//Console.WriteLine(Opgave3.gange(3, 10));
//Console.WriteLine(Opgave3.reverse("jeh"));
//Console.WriteLine(Opgave5.ScanDirCount("/Users/williamkruse/Projects/SoftwareArkitektur"));
//Opgave5.ScanDir("/Users/williamkruse/Projects/SoftwareArkitektur", 0);

//---//////////////////////////////////////////////////////////////////////////////////////////

class Opgave3
{
    //udregner fakulitet rekursivt
    public static int Faculty(int n)
    {
        if (n == 1) { return 1; }
        return n * Faculty(n - 1);

    }

    //OPG 4
    //delopgave 1
    public static int euclid(int a, int b)
    {


        if (a > b) { if (a % b == 0) { return b; } return euclid(b, a % b); }
        if (b > a) { if (b % a == 0) { return a; } return euclid(a, b % a); }
        return Math.Min(a, b);
    }

    //delopgave 2
    public static int opløft(int n, int p)
    {
        if (n == 1)
        {
            return p;
        }
        return p * opløft(n - 1, p);
    }


    //delopgve 3
    public static int gange(int a, int b)
    {
        if (b == 1)
        {
            return a;
        }
        return a + gange(a, b - 1);
    }


    //delopgave 4
    public static string reverse(string s)
    {
        if (s.Length == 1) { return s; }

        return "" + s[s.Length - 1] + reverse(s.Substring(0, s.Length - 1));
    }

}

class Opgave5
{
    public static void ScanDir(string path, int depth)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        string space = new string(' ', depth);

        // Udskriver alle filerne
        foreach (FileInfo file in files)
        {
            Console.WriteLine(space + file.Name);
        }
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDir(subdir.FullName, depth + 1);
        }
    }


    public static int ScanDirCount(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();
        int value = 0;

        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs)
        {
            value++;
            value += ScanDirCount(subdir.FullName);
        }
        return value;
    }
}



