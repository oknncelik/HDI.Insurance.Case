﻿using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Partner.Integration.Abstruct
{
    internal interface IPartnerService
    {
        Task<Result<WorkModel>> AddWork(WorkModel work);
        Task<Result<List<PartnerModel>>> GetPartners();
        Task<Result<List<ProductModel>>> GetProducts();
        Task<Result<List<WorkModel>>> GetWorkList();
    }
}