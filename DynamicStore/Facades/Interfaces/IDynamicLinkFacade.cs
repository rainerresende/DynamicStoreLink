using System.Threading.Tasks;

namespace DynamicStore.Facades.Interfaces
{
    public interface IDynamicLinkFacade
    {
        string GetStoreLinkByOperationSystem(IHeaderDictionary request);
    }
}
