using PayProject.Core;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Logic
{
    public class ModulesBll //: LogicBase
    {
        private static ModulesBll modulesBll;
        public static ModulesBll _
        {
            get
            {
                if (modulesBll == null)
                {
                    modulesBll = new ModulesBll();
                }
                return modulesBll;
            }
        }
        public List<Modules> GetAllModules()
        {
            return DbContext._.Db.From<Modules>()
                .OrderBy(Modules._.ParentId.Asc && Modules._.Orderno.Asc)
                .ToList<Modules>();
        }
        public Modules Find(int id)
        {
            return DbContext._.Db.From<Modules>()
                .Where(d => d.Id == id)
                .ToFirstDefault();
        }
        public int Edit(Modules modules)
        {

            //var oldModule = DbContext.GetInstance().Db.From<Modules>().Where(d => d.Id == modules.Id).First();
            //if (oldModule == null)
            //{
            //    return -1;
            //}
            return DbContext._.Db.Update<Modules>(new Modules
            {
                Controller = modules.Controller,
                Action = modules.Action,
                Nullity = modules.Nullity,
                Orderno = modules.Orderno,
                ParentId = modules.ParentId,
                Style = modules.Style,
                Title = modules.Title
            }, d => d.Id == modules.Id);
        }
        public int Create(Modules modules)
        {
            modules.CreateTime = DateTime.Now;
            return DbContext._.Db.Insert<Modules>(modules);
        }
        public int Delete(int id)
        {
            return DbContext._.Db.Delete<Modules>(d => d.Id == id);
        }
    }
}
