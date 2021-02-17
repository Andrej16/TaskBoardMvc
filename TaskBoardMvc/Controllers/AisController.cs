using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assistant;
using ParametersCollection = System.Collections.Generic.Dictionary<string, object>;

namespace TaskBoardMvc.Controllers
{
    public class AisController : Controller
    {
        private BaseFactory db = new BaseFactory(Assistant.DbType.Test);
        // GET: Ais
        public ActionResult Index(string id)
        {
            var pars = new ParametersCollection() {
                { "p_ag_id", id },
            };
            DataTable agreementsTable = db.SelectToTable("pack_agreement.find_agreement", pars);
            List<dynamic> agreements = SerializeToDynamic(agreementsTable);
            return View(agreements);
        }
        private List<dynamic> SerializeToDynamic(DataTable agreementsTable)
        {
            var agreements = new List<dynamic>();
            foreach (DataRow row in agreementsTable.Rows)
            {
                IDictionary<string, object> obj = new ExpandoObject();
                foreach (DataColumn col in agreementsTable.Columns)
                    obj.Add(col.ColumnName, row[col.ColumnName]);

                agreements.Add(obj);
            }

            return agreements;
        }
    }
}