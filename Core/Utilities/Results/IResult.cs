using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult // işlem sonucu ve kullanıcı bilgilendirme mesajı
    { // Temel voidler için yazıyoru. Data yok içinde bişey döndürmücek 
        bool Success { get; }
        string Message { get; }
    }
}
