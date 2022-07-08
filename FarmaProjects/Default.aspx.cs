﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(
        @"Data Source=EN-MORALES05\SQLEXPRESS;Initial Catalog=ProjectoFarmacia;Integrated Security=True;"
        );
        SqlCommand cmd = new SqlCommand("SELECT * FROM vw_Medicamentos_Pedido",cn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet(); 
        adapter.Fill(ds);

        ReportDocument rp = new ReportDocument();
        rp.Load(Server.MapPath("CrystalReport1.rpt"));
        rp.SetDataSource(ds.Tables["table1"]);


        CrystalReportViewer1.ReportSource = rp;
        rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false,"ventas detalles");
    }
}