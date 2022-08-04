using Lab10.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.UOW
{
    public class UnitOfWork : IDisposable
    {
        private ShopDBContext _shopDBContext;
        private Repository<Good> _goodRepository;
        private Repository<Organization> _manufacturerRepository;
        private Repository<TypesEnum> _typeRepository;

        public UnitOfWork()
        {
            _shopDBContext = new ShopDBContext();
        }

        public Repository<Good> GoodRepository
        {
            get
            {
                if( _goodRepository == null )
                    _goodRepository = new Repository<Good>(_shopDBContext); // передаем текущий контекст
                return _goodRepository;
            }
        }

        public Repository<Organization> ManufacturerRepository
        {
            get
            {
                if (_manufacturerRepository == null)
                    _manufacturerRepository = new Repository<Organization>(_shopDBContext); // передаем текущий контекст
                return _manufacturerRepository;
            }
        }

        public Repository<TypesEnum> TypeRepository
        {
            get
            {
                if (_typeRepository == null)
                    _typeRepository = new Repository<TypesEnum>(_shopDBContext); // передаем текущий контекст
                return _typeRepository;
            }
        }

        public void Save()
        {
            _shopDBContext.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if( disposing )
                    _shopDBContext?.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
