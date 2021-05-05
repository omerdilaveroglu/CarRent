using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;                        // CarManager new lendiğininde burası bana bir IcarDal türünde nesne ver dicek.
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))] // Add methodunu doğrula CarValidatordakine göre.
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(10)]

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")] // Herşeyi silme ICarSercice'deki Get'leri sil.
        [PerformanceAspect(10)]
        public IResult Update(Car car)
        {
            if (car.CarName.Length < 2 && car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [PerformanceAspect(10)]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [PerformanceAspect(10)]
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==05)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id)); // p nin brand id si yani BrandIdi benim sana göderdiğim BrandId ye eşit ise filtrele.
        }

        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        [PerformanceAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarDetailDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDetails());
        }

        
    }
}
