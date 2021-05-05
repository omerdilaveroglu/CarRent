using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result // Başarılı sonuç 
    {
        public SuccessResult(string message) : base(true, message) // base mesaj yolluyoruz.
        {

        }

        public SuccessResult():base(true) // mesaj vermeden de yollabilmesi için burayı yazdık.
        {

        }
    }
}
