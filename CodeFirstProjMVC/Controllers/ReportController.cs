using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstProjMVC.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            #region Local Report 所需參數
            string reportType = "Excel"; //Excel, PDF, Word, and Image
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            #endregion

            #region 宣告Report物件
            LocalReport report = new LocalReport();
            report.ReportPath = Server.MapPath("~/Reports/MemberReport.rdlc");  // Report檔案位置 
            #endregion

            #region 取得報表所需資料(*.xsd檔案)
            #region 前置作業
            var ds = new Reports.Company(); // 宣告報表資料物件
            var adapter = new Reports.CompanyTableAdapters.MembersReportTableAdapter(); // 宣告資料接口(adapter)物件
            adapter.Fill(ds.MembersReport); // 利用接口(adapter)處理資料流 
            #endregion

            #region 填入資料
            ReportDataSource rds = new ReportDataSource("MemberReport", ds.MembersReport.ToList()); // 由ds實際取得資料
            report.DataSources.Add(rds);    // 填入Report物件 
            #endregion
            #endregion

            #region 重新定義報表格式內容
            renderedBytes = report.Render(
                                reportType,
                                deviceInfo,
                                out mimeType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings
                            ); 
            #endregion

            //加這一行android下載才會有副檔名
            if (Response != null)
                Response.AddHeader("content-disposition", "attachment; filename=download." + fileNameExtension);

            return File(renderedBytes, mimeType);
        }
    }
}