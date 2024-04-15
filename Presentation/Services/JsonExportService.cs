using Core.Interfaces;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Services
{
    internal class JsonExportService : IExportService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public JsonExportService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task ExportAsync(string filePath)
        {
            var data = await _employeeRepository.GetAsync();
            var json = JsonSerializer.Serialize(data);

            var folderPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(folderPath);

            File.WriteAllText(filePath, json);
        }
    }
}
