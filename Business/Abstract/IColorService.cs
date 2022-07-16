﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
    }
}
