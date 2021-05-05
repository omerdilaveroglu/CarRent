﻿using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepository<Brand> // Tip olarak IEntityRepository' e Brand gönderdik.
    {
        
    }
}
