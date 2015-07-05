using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
                List<Report> reportList = query.OrderByDescending(i => i.report_id).ToList();
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

        public bool updateTypeBroken(Report report)
        {
            try
            {
                Report reportDb = context.Reports.First(i => i.report_id == report.report_id);

                reportDb.technician_id = report.technician_id;
                reportDb.report_typeBroken = report.report_typeBroken;
                reportDb.report_statusComplete = report.report_statusComplete;
                reportDb.report_startDate = report.report_startDate;

                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public double viewExperienceTechnician(int technicainId)
        {

            try
            {
                var query = (from i in context.Reports
                             where i.technician_id == technicainId && i.report_statusComplete == 3
                             group i by i.report_typeBroken into g
                             select new
                             {
                              //   technicainId = g.Select(i => i.technician_id),
                                 typeBroken = g.Key,
                                 count = g.Count(),
                                 time = g.Sum(i => (double?)SqlFunctions.DateDiff("minute", i.report_startDate, i.report_endDate)) / g.Count()

                             }).ToList();

                double experience = 0.0;

                if (query.Count != 0)
                {
                    foreach (var i in query)
                    {

                        string typeBroken = i.typeBroken.ToString();
                        var query2 = (from j in context.Reports
                                      where j.technician_id == technicainId &&
                                          j.report_typeBroken == typeBroken && j.report_statusComplete != 3
                                      select j).ToList();

                        if (query2.Count != 0)
                        {
                            foreach (var j in query2)
                            {
                                experience = experience + double.Parse(i.time.ToString());
                            }
                        }
                    }
                }
                context.SaveChanges();

                return experience;
            }
            catch
            {
               
                return 0.0;
            }
        }


        public List<List<int>> viewTechnicianTask(string typeWork)
        {
            try
            {
                var query = (from i in context.Reports 
                              where i.report_statusComplete != 0 && i.report_typeBroken == typeWork
                              group i by i.technician_id into g 
                              select new {  technicianId = g.Key, 
                                            amount = g.Count()}).ToList();
                                 
                List<List<int>> technicianTaskList = new List<List<int>>();

                if (query.Count != 0)
                {
                    foreach (var i in query)
                    {
                        List<int> technicianTask = new List<int>();
                        technicianTask.Add(i.technicianId);
                        technicianTask.Add(i.amount);

                        technicianTaskList.Add(technicianTask);
                    }
                }
                return technicianTaskList;
            }
            catch
            {
                List<List<int>> technicianTaskList = new List<List<int>>();
                return technicianTaskList;
            }
        }

    }
}