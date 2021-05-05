using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> // IDataResult<T> aslında CarManager class'ındaki "IDataResult<List<Car>>" dırç
    {
        public DataResult(T data,bool success,string message):base(success,message) // Sen; data, sonuç ve mesaj döndürceksin bunuda base'deki success ve message isteyen constructor'a göndericeksin.
        {
            Data = data; 
        }
        public DataResult(T data,bool success):base(success) // sen bir data ve sonuç döndürceksin bunuda Result class'ıdnaki sadece sonuç isteyen constructor'a göndereceksin.
        {
            Data = data;
        }
        public T Data { get; }
    }
}
