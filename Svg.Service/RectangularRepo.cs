using Resturant.Repository;
using Svg.DataAccess;
using Svg.DataAccess.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svg.Service
{
    public class RectangularRepo : IRectangularRepo
    {
        private IRepository<Rectangular>? _repository;

        public RectangularRepo(IRepository<Rectangular>? repository)
        {
            _repository = repository;
        }

        public void AddRectangular(Rectangular rectangular)
        {
            _repository?.Add(rectangular);
        }

        public IEnumerable<Rectangular> GetAllRectangular()
        {
            return _repository.GetAll().OrderByDescending(c => c.height).ThenBy(c => c.AddedDate);
            //return _context.Companies.Distinct().ToList();

        }

        public Rectangular GetRectangularById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Rectangular> GetRectangularByPagination(PagedResponse pagedResponse)
        {
            return _repository.FindAll()
                .OrderBy(on => on.height)
                .Skip((pagedResponse.PageNumber - 1) * pagedResponse.PageSize)
                .Take(pagedResponse.PageSize)
                .ToList();
        }

        public void Delete(int id)
        {
            _repository?.Delete(id);
        }

        public void UpdateRectangular(int id, Rectangular rectangular)
        {
            _repository?.Update(rectangular);
        }
    }
}
