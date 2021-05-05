using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T> // başarılı data sonuç
    {
        public SuccessDataResult(T data,string message):base(data,true,message) // data ve mesaj verebilirsin
        {

        }
        public SuccessDataResult(T data):base(data,true) // bana sadece data verebilirsin.
        {

        }
        public SuccessDataResult(string message):base(default,true,message) // sadece mesaj verebilirsin 
        {

        }
        public SuccessDataResult():base(default,true) // hiçbirşey vermeyedebilirsin
        {

        }
    }
}
