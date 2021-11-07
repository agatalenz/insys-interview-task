﻿using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<bool> ExistAsync(string name);
    }
}
