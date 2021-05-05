using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // Get read only'dir. Read only ler constructor'da set edilebilir.   
        public Result(bool success, string message):this(success)
        {
            Message = message; // Message'deki mesajı message olarak set et.
            
        }
        public Result(bool success)
        {
            Success = success;  
        }
        
        public bool Success { get; }  // True false döndürceksin, baraşılımı değilmi onu söyliceksin.

        public string Message { get; } // mesaj döndürüceksin 
    }
}
