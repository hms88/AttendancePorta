using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.MasterPage
{
    DS_Staff.STAFF_SELECTDataTable StaffDT = new DS_Staff.STAFF_SELECTDataTable();
    DS_StaffTableAdapters.STAFF_SELECTTableAdapter staffadpter = new DS_StaffTableAdapters.STAFF_SELECTTableAdapter();

    DS_student.StudentMstDataTable studentdt = new DS_student.StudentMstDataTable();
    DS_studentTableAdapters.StudentMstTableAdapter studentadapter = new DS_studentTableAdapters.StudentMstTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblstafferror.Text = "";
        lblstuerror.Text = "";
    }



    protected void btnstaff_Click(object sender, EventArgs e)
    {
        StaffDT = staffadpter.stafflogin(txtstaffpass.Text, txtstaffuname.Text);
        if (StaffDT.Rows.Count == 1)
        {
            Session["Email"] = txtstaffuname.Text;
            Response.Redirect("staff/Default.aspx");
        }
        else
        {
            lblstafferror.Text = "تسجيل الدخول خطأ";
        }
    }

    protected void btnstuentry_Click(object sender, EventArgs e)
    {
        studentdt = studentadapter.studentlogin(txtstupass.Text, txtstuuname.Text);
        if(studentdt.Rows.Count ==1)
        {
            Session["Uname"] = txtstuuname.Text;
            Response.Redirect("Student/Default.aspx");

        }
        else
        {
            lblstuerror.Text = "خطأ في تسجيل الدخول";
        }
    }
}
