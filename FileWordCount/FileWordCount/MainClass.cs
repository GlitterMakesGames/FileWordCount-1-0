using System.IO;
class MainClass
{
    public static void Main(string[] args)
    {
        string path;
        string literalPath;
        bool fileFound;
        string fileContents;

        Console.Write("Please copy and paste your file path here: ");
        path = Console.ReadLine();
        if (Utility.ValidatePath(path))
        {
            fileFound = true;
            Console.WriteLine("A file was found successfully!");
        }
        else
        {
            fileFound = false;
            Console.WriteLine("Program was unable to find a valid and/or existing file.");
        }

        StreamReader sr = new StreamReader(path);
        fileContents = sr.ReadToEnd();
        Console.WriteLine("The requested file contains " + Utility.numOfWords(fileContents) + " words.");
    }
}