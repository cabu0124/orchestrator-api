using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Common
{
    public class UploadResult<T> where T : class
    {
        public T Data { get; set; }

        public int Line { get; set; }
        public string Key { get; set; }
        public bool IsDuplicate { get; set; }
        public bool IsValid { get; set; }
        public string Status { get; set; }
        public string Log { get; set; }

        public UploadResult(int line, T data)
        {
            Line = line;
            Data = data;
        }
    }
}
