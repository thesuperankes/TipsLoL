using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumeWebApi.Models;

namespace ConsumeWebApi
{
    public class TutorialEntityFrameworks
    {
        public string GetTipById(int id)
        {
            using (Entities db = new Entities())
            {
                var query = (from t in db.TipsEveryDay where t.ID == id select t).FirstOrDefault();

                return query.Description;
            }
        }
    }
}
