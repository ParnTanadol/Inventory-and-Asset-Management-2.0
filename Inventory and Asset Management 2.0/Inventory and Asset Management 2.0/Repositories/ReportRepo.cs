using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public class ReportRepo : IReportRepo
    {
        private INVENTORY_MANAGEMENT_2Entities context;
        public ReportRepo(INVENTORY_MANAGEMENT_2Entities context)
        {
            this.context = context;
        }

        
        public bool insertReport(Report report)
        {
            try
            {
                context.Reports.Add(report);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateReport(Report report)
        {
            try
            {
                Report reportDb = context.Reports.First(i => i.report_id == report.report_id);

                reportDb.report_id = report.report_id;
                reportDb.report_repairDetail = report.report_repairDetail;
                reportDb.report_statusComplete = report.report_statusComplete;


                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public Report viewReportByReportId(int reportId)
        {
            try
            {
                Report report = context.Reports.First(i => i.report_id == reportId);
                context.SaveChanges();
                return report;
            }
            catch
            {
                Report report = new Report();
                return report;
            }
        }


        public List<Report> viewAllReport()
        {
            try
            {
                List<Report> reportDbList = context.Reports.ToList();
                context.SaveChanges();

                return reportDbList;
            }
            catch
            {
                List<Report> reportDbList = new List<Report>();
                return reportDbList;
            }
        }


        public List<Report> viewReportbyTechnicianId(int technicianId)
        {
            try
            {
                var query = from i in context.Reports where i.technician_id == technicianId select i;
                List<Report> reportList = query.ToList();
                context.SaveChanges();
                return reportList;
            }
            catch
            {
                List<Report> reportList = new List<Report>();
                return reportList;
            }
        }

        public List<Report> viewReportbyReporterId(int reporterId)
        {
            try
            {
                var query = from i in context.Reports where i.reporter_id == reporterId select i;
                List<Report> reportList = query.ToList();
                context.SaveChanges();
                return reportList;
            }
            catch
            {
                List<Report> reportList = new List<Report>();
                return reportList;
            }
        }

        public List<Report> viewReportbyStatus(int statusComplete)
        {
            try
            {
                var query = from i in context.Reports where i.report_statusComplete == statusComplete select i;
                List<Report> reportList = query.ToList();
                context.SaveChanges();
                return reportList;
            }
            catch
            {
                List<Report> reportList = new List<Report>();
                return reportList;
            }
        }

        public List<Report> viewReportByStatusAndUserId(int technicianId, int statusComplete)
        {
            try
            {
                var query = from i in context.Reports where i.technician_id == technicianId && i.report_statusComplete == statusComplete select i;
                List<Report> reportList = query.ToList();
                context.SaveChanges();
                return reportList;
            }
            catch
            {
                List<Report> reportList = new List<Report>();
                return reportList;
            }
        }

        public Report viewPreviousReport(int reporterId)
        {
            try
            {
                var query = from i in context.Reports where i.reporter_id == reporterId orderby i.report_id descending select i;
                List<Report> reportList = query.ToList();
                Report reportDb = query.FirstOrDefault<Report>();
                context.SaveChanges();
                return reportDb;
            }
            catch
            {
                Report reportDb = new Report();
                return reportDb;
            }
        }


        public bool updateStatus(Report report)
        {
            try
            {
                Report reportDb = context.Reports.First(i => i.report_id == report.report_id);

                reportDb.report_statusComplete = report.report_statusComplete;

                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Report> viewReparationSummary(DateTime timeStart, DateTime timeEnd)
        {
            try
            {
                /*
                 var events = this.coreDomainContext.Events.Where(
                    e => e.EventDate.Value.Date >= DateTime.Today
                      && e.EventDate.Value.Date <= endPeriod.Date)
                    .OrderByDescending(e => e.EventDate)
                    .ToList();
                 * */
                var query = context.Reports.Where(i => i.report_startDate >= timeStart && i.report_startDate <= timeEnd).OrderByDescending(i => i.report_startDate).ToList();
                List<Report> reportList = query.ToList();
                return reportList;
            }
            catch
            {
                List<Report> reportList = new List<Report>();
                return reportList;
            }
        }
    }
}