using Motobike.BusinessLogic.ViewModels.Request;
using System.Threading.Tasks;

namespace Motobike.BusinessLogic.Services.Interface
{
    public interface IOrderService
    {
        Task Order(OrderRequest order);
    }
}
