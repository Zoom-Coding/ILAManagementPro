using ILAManagementPro.Bll.WorkScheduleMaintenance;
using System;
using System.Web.UI;

namespace ILAManagementPro.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            var user = "absc";

            // Logs the user into schedule maintenance.
            //SecurityBll.LogInNewUser(user);

            //var shifts = WorkHeaderBll.GetShifts();

            // Logs the user out of schedule maintenance.
            //SecurityBll.LogOutUser(user);
        }
    }
}