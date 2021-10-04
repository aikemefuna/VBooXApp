using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VBooX.Domain.Entities;

namespace VBooX.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
