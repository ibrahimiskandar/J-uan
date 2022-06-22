using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace J_uan.Helpers
{
    public static class Extension
    {
        public async static Task<string> SaveFileAsync(this IFormFile file, string root, params string[] folders)
        {
            var fileName = Guid.NewGuid().ToString() + file.FileName;
            var resultPath = Path.Combine(Helper.GetPath(root, folders), fileName);
            using (FileStream filestream =
                new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(filestream);

            }
            return fileName;
        }
    }
}
