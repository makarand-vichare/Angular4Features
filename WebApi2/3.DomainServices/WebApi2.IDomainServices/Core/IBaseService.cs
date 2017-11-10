using WebApi2.ServiceResponse;
using WebApi2.EntityModels.Core;
using WebApi2.ViewModels.Core;

namespace WebApi2.IDomainServices.Core
{
    public interface IBaseService<T,VM>  where T : IdentityColumnEntity where VM : IdentityColumnViewModel
    {
        ResponseResults<VM> GetAll();
        ResponseResult<VM> GetById(long id);
        ResponseResult<VM> Save(VM viewModel);
    }
}
