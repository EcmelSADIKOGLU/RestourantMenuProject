using DataAccessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface ITodaysFoodService
    {
        GetTodaysFoodDto Get();
        void Set(SetTodaysFoodDto setTodaysFoodDto);
    }
}
