using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult 
    {
        // IDataResult'ı ICarService'de döndürmek için <T> verdik. <T> = List<Car> aslında.
        // Bu yapı sayesinde hem IDataResult'ı yani mesajı döndörüdük hem listeyi döndörüdük.
        T Data { get; }
    }
}
