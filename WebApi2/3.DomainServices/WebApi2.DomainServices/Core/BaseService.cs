using WebApi2.IDomainServices.Core;
using WebApi2.IRepositories.Core;
using WebApi2.ServiceResponse;
using System;
using System.Linq;
using WebApi2.IDomainServices.AutoMapper;
using WebApi2.Utility;
using StructureMap.Attributes;
using WebApi2.ViewModels.Core;
using WebApi2.EntityModels.Core;

namespace WebApi2.DomainServices.Core
{
    public abstract class BaseService<T,VM> : IBaseService<T,VM> where T:IdentityColumnEntity where VM:IdentityColumnViewModel
    {
        [SetterProperty]
        public IBaseRepository<T> BaseRepository
        {
            get; set;
        }

        [SetterProperty]
        public IUnitOfWork UnitOfWork
        {
            get; set;
        }

        public virtual ResponseResults<VM> GetAll()
        {
            var response = new ResponseResults<VM>() { IsSucceed  =true, Message = AppMessages.Retrieved_Details_Successfully};
            try
            {
                var models = UnitOfWork.SetDbContext(BaseRepository).GetAll();
                response.ViewModels = models.ToViewModel<T, VM>().ToList();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> GetById(long id)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Retrieved_Details_Successfully };
            try
            {
                var model = UnitOfWork.SetDbContext(BaseRepository).FindById(id);
                response.ViewModel = model.ToViewModel<T, VM>();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> Save(VM viewModel)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Saved_Details_Successfully };
            try
            {
                T model = viewModel.ToEntityModel<T,VM>();
            
                if (viewModel.Id == 0)
                {
                    UnitOfWork.SetDbContext(BaseRepository).Add(model);
                }
                else
                {
                    UnitOfWork.SetDbContext(BaseRepository).Update(model);
                }

                UnitOfWork.Commit();
                response.ViewModel = model.ToViewModel<T, VM>();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
