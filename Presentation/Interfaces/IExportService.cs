﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    internal interface IExportService
    {
        Task ExportAsync(string filePath);
    }
}
