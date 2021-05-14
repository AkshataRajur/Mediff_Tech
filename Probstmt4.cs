using System;
using System.Linq;

public class Path
{
    public string CurrentPath { get; private set; }

    public Path(string path)
    {
        CurrentPath = path;
    }

    public void Cd(string newPath)
    {
        if (newPath == "/")
        {
            CurrentPath = "/";
            return;
        }

        while (newPath.Length > 0)
        {
            if (newPath.Length > 1)
            {
                if (newPath.Substring(0, 2) == "..")
                {
                    if (!String.IsNullOrEmpty(CurrentPath))
                    {
                        CurrentPath = CurrentPath.Remove(CurrentPath.LastIndexOf("/", StringComparison.Ordinal));
                      //  if (String.IsNullOrEmpty(CurrentPath))
                        //{
                          //  CurrentPath = "/";
                        //}
                    }

                    newPath = newPath.Remove(0, 2);
                    continue;
                }
            }

            if (newPath[0] == '/')
            {
                newPath = newPath.Remove(0, 1);
                if (newPath[1] == '.')
                {
                    continue; 
                }
            }

            if (CurrentPath.Last() != '/')
            {
                CurrentPath += "/";
            }

            var nextPath = newPath.IndexOf("/", StringComparison.Ordinal);
            if (nextPath == -1)
            {
                CurrentPath += newPath;
                newPath = "";
            }
            else
            {
                CurrentPath += newPath.Substring(0, nextPath); 
                newPath = newPath.Remove(0, nextPath);
            }
        } 
    }

    public static void Main(string[] args)
    {
        Path path = new Path("Modified Path:d/meddifftech/changedirectory/solution");
        path.Cd("../output");
        Console.WriteLine("Original Path:d/meddifftech/changedirectory/solution");

        Console.WriteLine(path.CurrentPath);
        Console.ReadLine(); 
    }
}