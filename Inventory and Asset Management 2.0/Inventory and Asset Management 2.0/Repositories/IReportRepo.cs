using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public interface IReportRepo
    {

        bool insertReport(Report report);
        bool updateReport(Report report);
        bool updateTypeBroken(Report report);
        Report viewReportByReportId(int reportId);
        List<Report> viewAllReport();
        List<Report> viewReportbyTechnicianId(int technicianId);
        List<Report> viewReportbyReporterId(int reporterId);
        List<Report> viewReportbyStatus(int statusComplete);
        List<Report> viewReportByStatusAndUserId(int technicianId, int statusComplete);

        bool updateStatus(Report report);
        Report viewPreviousReport(int reporterId);
    //    List<Report> viewReparationSummary(DateTime timeStart, DateTime timeEnd);

    //    List<List<string>> viewAverageWorkTime(string typeWork);

        List<List<int>> viewTechnicianTask(string typeWork);
        double viewExperienceTechnician(int technicainId);
    //    List<Report> viewWorkInProcess(int technicianId);
    }
}
