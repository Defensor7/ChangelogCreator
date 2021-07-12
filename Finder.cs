using System;
using System.IO;

namespace ChangelogCreator
{
    public class Finder
    {
        private const string StartChars = "// +";
        private const string EndChars = "// -";
        private const string ModuleFilePattern = "*.bsl";

        private readonly string _selectedPath;
        private readonly string _toFind;
        public event EventHandler<string> LinesAdded;
        public event EventHandler<int> ProgressChanged;

        public Finder(string selectedPath, string toFind)
        {
            _selectedPath = selectedPath;
            _toFind = toFind;
        }

        public void FindChanges()
        {
            ProgressChanged?.Invoke(null, 0);
            var modules = FindAllModules();
            if (modules.Length == 0)
            {
                AddText($"Не найдено файлов с маской {ModuleFilePattern}");
                return;
            }

            var modulesCount = modules.Length;

            for (var index = 0; index < modulesCount; index++)
            {
                var module = modules[index];
                var progress = index / (float)modulesCount * 100;
                ProgressChanged?.Invoke(null, (int)progress);
                FindChanges(module);
                Console.WriteLine("File number: {0} from {1}", index, modulesCount);
            }
            ProgressChanged?.Invoke(null, 0);
        }

        private void FindChanges(string file)
        {
            var fileStream =
                new StreamReader(file);

            string line;
            var counter = 0;

            var currentStart = 0;
            //var currentEnd = 0;

            var code = string.Empty;

            while ((line = fileStream.ReadLine()) != null)
            {
                if (line.Contains(StartChars) && line.Contains(_toFind))
                {
                    if (currentStart != 0)
                    {
                        var (module, type) = GetModuleTypeName(file);
                        AddText($"Строка {counter} модуля {module} документа {type} не содержит закрывающего комментария:\r\n{line}\r\n\r\n\r\n");
                        currentStart = 0;
                        code = string.Empty;
                        continue;
                    }
                    currentStart = counter;
                }

                if (currentStart != 0)
                {
                    code += line + "\r\n";
                }

                if (line.Contains(EndChars) && line.Contains(_toFind))
                {

                    var (module, type) = GetModuleTypeName(file);
                    if (currentStart == 0)
                    {
                        AddText($"Строка {counter} модуля {module} документа {type} не содержит открывающего комментария:\r\n{line}\r\n\r\n\r\n");
                        currentStart = 0;
                        //currentEnd = 0;
                        code = string.Empty;
                        continue;
                    }
                    //currentEnd = counter;

                    AddText($"Изменен модуль {module} объекта {type}.\r\nНачало изменения - строка {currentStart}.\r\nКонец изменения - строка {counter}\r\nКод:\r\n{code}\r\n\r\n\r\n");
                    currentStart = 0;
                    //currentEnd = 0;
                    code = string.Empty;
                    continue;
                }
                counter++;
            }

            fileStream.Close();
        }

        private (string Module, string Type) GetModuleTypeName(string file)
        {
            var path = new DirectoryInfo(file);
            var moduleName = path?.Parent?.Parent?.Name;
            var type = path?.Parent?.Parent?.Parent?.Name;
            return (moduleName, type);
        }

        private string[] FindAllModules()
        {
            var files = Directory.GetFiles(_selectedPath, ModuleFilePattern, SearchOption.AllDirectories);
            return files;
        }

        private void AddText(string text)
        {
            LinesAdded?.Invoke(null, text);
        }
    }
}
