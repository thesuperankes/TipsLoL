using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Models.Repository
{
    public interface ITipsRepository
    {
        List<TipsEveryDay> GetAllTips();
        List<TipsEveryDay> GetTipById(int id);
    }
}
