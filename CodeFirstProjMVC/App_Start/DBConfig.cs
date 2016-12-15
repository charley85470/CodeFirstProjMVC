using CodeFirstProjMVC.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProjMVC.App_Start
{
    public class DBConfig
    {
        public static void RegisterDB()
        {
            using (var db = new Company())
            {
                // 建立資料庫
                db.Database.CreateIfNotExists();
            }
        }
    }
}