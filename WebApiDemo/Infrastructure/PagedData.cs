﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Infrastructure
{
    public class PagedData<TData>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; } //TODO: get rid of this property
        public int TotalItems { get; set; }
        public List<TData> Data { get; set; }
    }
}