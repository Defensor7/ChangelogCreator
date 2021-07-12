using System;
using System.Drawing;
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
        public event EventHandler<(string Text, Color color)> LinesAdded;
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
                        AddText($"ОШИБКА: Строка {counter} модуля {module} категории объекта {type} не содержит закрывающего комментария:\r\n{line}\r\n\r\n\r\n", Color.Red);
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
                        AddText($"ОШИБКА: Строка {counter} модуля {module} категории объекта {type} не содержит открывающего комментария:\r\n{line}\r\n\r\n\r\n", Color.Red);
                        currentStart = 0;
                        //currentEnd = 0;
                        code = string.Empty;
                        continue;
                    }
                    //currentEnd = counter;

                    AddText($"Изменен модуль {module} категории объекта {type}\r\nНачало изменения - строка {currentStart}\r\nКонец изменения - строка {counter}\r\nКод:\r\n{code}\r\n\r\n\r\n");
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
            var name = path?.Parent?.Parent?.Name;
            var type = GetModuleTypeTranslation(path?.Parent?.Parent?.Parent?.Name);
            return (name, type);
        }

        private string GetModuleTypeTranslation(string type)
        {
            switch (type)
            {
                case "AccountingRegister":
                {
                    return "РегистрБухгалтерии";
                }
                case "AccumulationRegister":
                {
                    return "РегистрНакопления";
                }
                case "BusinessProcess":
                {
                    return "БизнесПроцесс";
                }
                case "CalculationRegister":
                {
                    return "РегистрРасчета";
                }
                case "Catalog":
                {
                    return "Справочник";
                }
                case "ChartOfAccounts":
                {
                    return "ПланСчетов";
                }
                case "ChartOfCalculationTypes":
                {
                    return "ПланВидовРасчета";
                }
                case "ChartOfCharacteristicTypes":
                {
                    return "ПланВидовХарактеристик";
                }
                case "CommonModules":
                {
                    return "ОбщийМодуль";
                }
                case "Constant":
                {
                    return "Константа";
                }
                case "Document":
                {
                    return "Документ";
                }
                case "ExchangePlan":
                {
                    return "ПланОбмена";
                }
                case "InformationRegister":
                {
                    return "РегистрСведений";
                }
                case "Task":
                {
                    return "Задача";
                }
                case "Sequence":
                {
                    return "Последовательность";
                }
                case "Report":
                {
                    return "Отчет";
                }
                default:
                {
                    return type;
                }
            }
        }

        private string[] FindAllModules()
        {
            var files = Directory.GetFiles(_selectedPath, ModuleFilePattern, SearchOption.AllDirectories);
            return files;
        }

        private void AddText(string text)
        {
          AddText(text, Color.Black);
        }
        private void AddText(string text, Color color)
        {
            LinesAdded?.Invoke(null, (text, color));
        }
    }
}
