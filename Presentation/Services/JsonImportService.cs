using Core.Data.Entities;
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
    internal class JsonImportService : IImportService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public JsonImportService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> ImportAsync(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<IEnumerable<Employee>>(json);

            try
            {
                await _employeeRepository.AddAsync(data.ToArray());
            }
            catch 
            { 
                return false;
            }

            return true;
        }
    }
}
