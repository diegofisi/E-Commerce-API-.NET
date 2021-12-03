﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Dto.Response
{
    public class BaseCollectionResponse<TDtoClass>
        where TDtoClass : class
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int TotalPages { get; set; }
        public ICollection<TDtoClass> Collection { get; set; }
    }
}
