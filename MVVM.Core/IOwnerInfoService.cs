using MVVM.Model;
using System.Threading.Tasks;

namespace MVVM.Core
{
    public interface IOwnerInfoService
    {
        Task<bool> IsOwnerAsync(OwnerInfo ownerInfo);
    }
}
