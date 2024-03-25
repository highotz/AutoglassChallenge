using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassChallenge.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<bool> Add(ProductRequest productRequest);
        IAsyncEnumerable<ProductResponse> GetAll();
        Task<ProductResponse> GetId(int productId);
        Task<bool> Update(int productId, ProductRequest request);
        Task<ProductResponse> Delete(int productId);

    }
}
