﻿using _2014118187_ENT.Entities;
using _2014118187_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Repositories
{
    public class RetiroRepository : Repository<Retiro>, IRetiroRepository
    {
        public RetiroRepository(_2014118187DbContext context)
            : base(context)
        {

        }


        /*private readonly _2014118187DbContext _Context;

        public RetiroRepository(_2014118187DbContext context)
        {
            _Context = context;
        }
        
        private RetiroRepository()
        {

        }*/
    }
}
