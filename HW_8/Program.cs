class Program
{
    static void Main(string[] args)

    // Пример вызова утилиты: dotnet run cs Main

    {
        string path = Directory.GetCurrentDirectory();
        string name = "cs";
        string text = "Main";

        if (args.Length != 0)
        {
            name = args[0];
            text = args[1];
            path = Directory.GetCurrentDirectory();
        }

        List<string> list = SearchIn(path, name);

        Dictionary<string, string> res = [];

        foreach (string file in list)
        {
            if (Filter(text, ReadFrom(file), out string? target))
            {
                res.Add(file, target!);
            }
        }

        Console.WriteLine($"Ищем по пути ~{path}\nСреди файлов с расширением *.{name} строки содержащие '{text}'\n");

        if (res.Count > 0)
        {
            foreach (var file in res)
            {
                Console.WriteLine($"=> {file}");
            }
        }
        else if (res.Count <= 0)
        {
            Console.WriteLine("Нет результатов!");
        }
    }

    private static List<string> SearchIn(string path, string name)
    {
        var list = new List<string>();
        DirectoryInfo dir = new DirectoryInfo(path);

        DirectoryInfo[] directories = dir.GetDirectories();
        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo item in files)
        {
            if (item.Extension.Contains(name))
            {
                list.Add(item.FullName);
            }
        }
        foreach (var item in directories)
        {
            list.AddRange(SearchIn(item.FullName, name));
        }
        return list;
    }

    static List<string> ReadFrom(string path)
    {
        List<string> result = [];


        using StreamReader sr = new StreamReader(path);
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line != null)
                    result.Add(line);
            }
        }
        return result;
    }

    static bool Filter(string text, List<string> rows, out string? some)
    {
        if (rows.Count > 0)
        {
            foreach (var row in rows)
            {
                if (row.ToLower().Contains(text.ToLower()))
                {
                    some = row;
                    return true;
                }
            }
        }
        some = null;
        return false;
    }
}
