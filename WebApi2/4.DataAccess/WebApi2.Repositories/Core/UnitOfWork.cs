﻿using WebApi2.IRepositories.Core;
using WebApi2.IRepositories.Identity;
using WebApi2.IRepositories.Queues;
using StructureMap.Attributes;
using System;
using System.Threading.Tasks;
using WebApi2.EntityModels.Core;
using WebApi2.IRepositories.Localization;
using WebApi2.IRepositories.Location;

namespace WebApi2.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private DataContext dataContext;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IEmailQueueRepository _emailQueueRepository;
        private IPdfQueueRepository _pdfQueueRepository;
        private IRequestQueueRepository _requestQueueRepository;
        private IClientRepository _clientRepository;

        private IKeyGroupRepository _keyGroupRepository;
        private ILocalizationKeyRepository _localizationKeyRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;

        #endregion

        #region Constructors

        public UnitOfWork()
        {
            this.dataContext = new DataContext();
        }

        #endregion

        #region IUnitOfWork Members

        [SetterProperty]
        public ICountryRepository CountryRepository
        {
            get { return _countryRepository; }
            set
            {
                _countryRepository = value;
                _countryRepository.DbContext = dataContext;
            }
        }

        [SetterProperty]
        public ICityRepository CityRepository
        {
            get { return _cityRepository; }
            set
            {
                _cityRepository = value;
                _cityRepository.DbContext = dataContext;
            }
        }


        [SetterProperty]
        public IKeyGroupRepository KeyGroupRepository
        {
            get { return _keyGroupRepository; }
            set
            {
                _keyGroupRepository = value;
                _keyGroupRepository.DbContext = dataContext;
            }
        }


        [SetterProperty]
        public ILocalizationKeyRepository LocalizationKeyRepository
        {
            get { return _localizationKeyRepository; }
            set
            {
                _localizationKeyRepository = value;
                _localizationKeyRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IClientRepository ClientRepository
        {
            get { return _clientRepository; }
            set
            {
                _clientRepository = value;
                _clientRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IRefreshTokenRepository RefreshTokenRepository
        {
            get { return _refreshTokenRepository; }
            set
            {
                _refreshTokenRepository = value;
                _refreshTokenRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository; }
            set
            {
                _externalLoginRepository = value;
                _externalLoginRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IRoleRepository RoleRepository
        {
            get { return _roleRepository; }
            set
            {
                _roleRepository = value;
                _roleRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set
            {
                _userRepository = value;
                _userRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IEmailQueueRepository EmailQueueRepository
        {
            get { return _emailQueueRepository; }
            set
            {
                _emailQueueRepository = value;
                _emailQueueRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IPdfQueueRepository PdfQueueRepository
        {
            get { return _pdfQueueRepository; }
            set
            {
                _pdfQueueRepository = value;
                _pdfQueueRepository.DbContext = dataContext;
            }
        }

        //[Dependency]
        [SetterProperty]
        public IRequestQueueRepository RequestQueueRepository
        {
            get { return _requestQueueRepository; }
            set
            {
                _requestQueueRepository = value;
                _requestQueueRepository.DbContext = dataContext;
            }
        }

        public IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : IdentityColumnEntity
        {
            repository.DbContext = dataContext;
            return repository;
        }

        public int Commit()
        {
            return dataContext.Commit();
        }

        public Task<int> CommitAsync()
        {
            return dataContext.CommitAsync();
        }

        public Task<int> CommitAsync(System.Threading.CancellationToken cancellationToken)
        {
            return dataContext.CommitAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
