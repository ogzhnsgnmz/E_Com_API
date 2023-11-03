﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> uploadAsync(string path, IFormFileCollection files);
        Task<bool> copyFileAsync(string path, IFormFile file);
    }
}
