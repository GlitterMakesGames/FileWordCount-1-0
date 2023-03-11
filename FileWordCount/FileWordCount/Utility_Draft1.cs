/*using System.IO;
class Utility_Draft1
{
    public static bool ValidatePath(string path)
    {
        FileInfo? existing_file = null;
        string temp = "";
        try
        {
            if(File.Exists(path))
            {
                existing_file = new FileInfo(path);
            }
            else
            {
                throw new FileNotFoundException("The file name you entered could not be found in this directory.");
            }
            Console.WriteLine("A file has been located.");
        }
        catch (FileNotFoundException FNF)
        {
            Console.WriteLine(FNF.Message);
            Console.WriteLine("Would you like to create a new file here?");
            while(true)
            {
                Console.Write("Enter \"yes\" or \"no:\" ");
                temp = Console.ReadLine();
                if (String.Equals(temp, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        FileStream new_file = File.Create(path);
                        existing_file = new FileInfo(path);
                        Console.WriteLine("A new file has been created.\n");
                        break;
                    }
                    catch(DirectoryNotFoundException)
                    {
                        Console.WriteLine("The directory you entered could not be found.");
                        existing_file = null;
                        break;
                    }
                }
                else if (String.Equals(temp, "no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("A file has not been created. Try creating a file or using");
                    Console.WriteLine("a different directory. Then restart this program and try again.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid Response. Please Try Again.\n");
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("A(n) " + e.GetType + " exception has been thrown.");
            Console.WriteLine(e.Message);
            return false;
        }

        try
        {
            if (String.Equals(existing_file.Extension, ".txt", StringComparison.Ordinal))
            {
                Console.WriteLine("It has been verified that the chosen file has a .txt extension.");
                return true;
            }
            else
            {
                Console.WriteLine("The chosen file is not a plain text file!");
                return false;
            }
        }
        catch(NullReferenceException)
        {
            return false;
        }
    }
}*/