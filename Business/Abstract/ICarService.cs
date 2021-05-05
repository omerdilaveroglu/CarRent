using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetailDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IResult AddTransactionalTest(Car car); //Transaction yönetimi uygulamalarda tutarlılığı korumak için yapılan bir yönetem. 
        // Örneğin : Para gönderirken hata verdi paramızı geri vermesi gerekiyor. aynı anda iki tane veri tabanı işlemi var.

    }
}
