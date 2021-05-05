using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto         // buradaki nesneler veri tabanında direk bir tabloyu temsil etmez, bu sebeple IEntity ye bağlanmaz.
    {
        public string CarName { get; set; }     // buradaki nesneler bizim veri tabanından özel olarak çekmek istediğimiz verilerdir.
        public string BrandName { get; set; }   // _bu nesnler farklı tablolara aitdir, bu sebeple bunları burada bir class da topladık. 
        public string ColorName { get; set; }   // _daha sonra bunları birleştrip sanki tek bir tablonun verisini listeliyormuş gibi kullanıcaz.
        public decimal DailyPrice { get; set; } // _yani aslında biz yeni bir tablo oluşturuyoruz.
    }
}
