﻿using MRC_API.Payload.Request.Service;
using MRC_API.Payload.Response;
using MRC_API.Payload.Response.Service;
using Repository.Paginate;
using System;
using System.Threading.Tasks;

namespace MRC_API.Service.Interface
{
    public interface IServiceService
    {
        Task<ApiResponse> CreateNewService(CreateNewServiceRequest createNewServiceRequest);
        Task<ApiResponse> GetAllServices(int page, int size);
        Task<ApiResponse> GetService(Guid id);
        Task<ApiResponse> UpdateService(Guid id, UpdateServiceRequest updateServiceRequest);
        Task<ApiResponse> DeleteService(Guid id);
    }
}
