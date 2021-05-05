using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message) // base mesaj yolluyoruz.
        {

        }
        public ErrorResult() : base(false) // mesaj vermeden de yollabilmesi için burayı yazdık.
        {

        }
    }
}
