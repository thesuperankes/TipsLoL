using System.Collections.Generic;
using System.Linq;
using Models.Models;

namespace Models.Repository
{
    public class TipsRepository : ITipsRepository
    {
        public List<TipsEveryDay> GetAllTips()
        {
            using (Entities db = new Entities())
            {
                var query = db.TipsEveryDay.ToList();
                return query;
            }
        }

        public List<TipsEveryDay> GetTipById(int id)
        {
            using (Entities db = new Entities())
            {
                var tipsEveryDay = (from t in db.TipsEveryDay where t.ID == id select t).ToList();
                return tipsEveryDay;
            }
        }
    }
}
