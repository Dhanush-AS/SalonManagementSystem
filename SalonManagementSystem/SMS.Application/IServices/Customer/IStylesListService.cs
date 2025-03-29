using SMS.Domain;
using SMS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Common
{
    public interface IStylesListService
    {
        Task<IEnumerable<StylesListDto>> GetAllStylesListAsync();

    }
}
