using System.IO;
using System.Text.RegularExpressions;
class Utility
{
    public static bool ValidatePath(string path)
    {
        FileInfo? existing_file = null;
        string temp = "";

        int length = path.Length - Path.GetFileName(path).Length;
        string directory = path.Substring(0, length);

        if (!RegexPathValidation(path))
        {
            Console.WriteLine("The requested directory either includes invalid");
            Console.WriteLine("characters or is formatted improperly.\n");
            return false;
        }

        try
        {
            if (Directory.Exists(directory))
            {
                Console.WriteLine("The requested directory has been found.");
                if (File.Exists(path))
                {
                    existing_file = new FileInfo(path);
                    Console.WriteLine("The requested file exists in this directory.");
                }
                else
                {
                    throw new FileNotFoundException("Requested file not found in this directory!");
                }
            }
            else
            {
                throw new DirectoryNotFoundException("The requested directory could not be found!");
            }
        }
        catch (DirectoryNotFoundException DNF)
        {
            Console.WriteLine(DNF.Message);
            return false;
        }
        catch (FileNotFoundException FNF)
        {
            Console.WriteLine(FNF.Message);
            Console.WriteLine("Would you like to create a file at this location");
            Console.WriteLine("using the path provided?");
            while (true)
            {
                Console.Write("Please enter \"yes\" or \"no\": ");
                temp = Console.ReadLine();
                if (String.Equals(temp, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    FileStream new_file = File.Create(path);
                    existing_file = new FileInfo(path);
                    Console.WriteLine("A new file has been created.\n");
                    break;
                }
                else if (String.Equals(temp, "no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("User did not request file creation.\n");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");
                }
            }
        }
        catch (IOException IOE)
        {
            Console.WriteLine("An IOException other than DirectoryNotFoundException");
            Console.WriteLine("or FileNotFoundException has been thrown.");
            Console.WriteLine("Details: " + IOE.Message);
            return false;
        }

        try
        {
            if (String.Equals(existing_file.Extension, ".txt", StringComparison.Ordinal))
            {
                Console.WriteLine("File format has been verified to be plain text.");
                return true;
            }
            else
            {
                throw new FormatException("Invalid Format: Requested file is not plain text.");
            }
        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (FormatException FE)
        {
            Console.WriteLine(FE.Message);
            return false;
        }
    }

    public static bool RegexPathValidation(string path)
    {
        Regex myRegex = new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.$]+)\\\\(?:[\\w]+\\\\)*\\w([\\w.])+$");
        //Source:
        //https://stackoverflow.com/questions/6416065/c-sharp-regex-for-file-paths-e-g-c-test-test-exe
        //agent-j's answer

        if (myRegex.IsMatch(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int numOfWords(string s)
    {
        string[] allWords = s.Trim().Split(new string[] { " ", "\n" },StringSplitOptions.None);
        return allWords.Length;
    }
}