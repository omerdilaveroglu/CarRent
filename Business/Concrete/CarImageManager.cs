using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            string ImagePath = FileHelper.Add(file);
            IResult result = BusinessRules.Run(CheckIfCarImagesCompleted(carImage.CarId));
            if (result == null && ImagePath != null)
            {
                carImage.Date = DateTime.Now; // Resmin eklendiği tarih sistem tarafından alınır.
                carImage.ImagePath = FileHelper.Add(file);
                _carImageDal.Add(carImage);

                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult(Messages.CarImageNotAdded);
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, file);

            _carImageDal.Update(carImage);

            return new SuccessResult();
        }
        public IResult Delete(CarImage carImage)
        {
            var result = this.Get(carImage.CarImageId);
            var Deleted = FileHelper.Delete(result.Data.ImagePath);
            if (Deleted.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        public IDataResult<CarImage> Get(int id) // Arabaya ait resimleri listeledik.
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id), Messages.CarImageListed);
        }

        
        private IResult CheckIfCarImagesCompleted(int carId)  // En fazla 5 tane resim olabilir. 
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CapacityFulled);
            }
            return new SuccessResult();
        }

        // Eğer bir arabaya ait resim yoksa, default bir resim gösteriniz. Bu resim şirket logonuz 
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            var result = _carImageDal.GetAll(i => i.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = id,
                        Date= DateTime.Now,
                        ImagePath = "CarRent.jpg"
                    }
                };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

    }
}
