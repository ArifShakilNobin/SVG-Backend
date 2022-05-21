using Svg.DataAccess;
using Svg.DataAccess.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svg.Service
{
    public interface IRectangularRepo
    {
        IEnumerable<Rectangular> GetAllRectangular();
        Rectangular GetRectangularById(int id);

        void AddRectangular(Rectangular rectangular);

        IEnumerable<Rectangular> GetRectangularByPagination(PagedResponse pagedResponse);

        void Delete(int id);

        void UpdateRectangular(int id, Rectangular rectangular);
    }
}
