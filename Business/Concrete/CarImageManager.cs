﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
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
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi.");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfAnyImageExists(carId));
            {
                if (result != null)
                {
                    return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
                }

                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> defaultImage = new List<CarImage>();
            defaultImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(defaultImage);
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAnyImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any()) 
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
