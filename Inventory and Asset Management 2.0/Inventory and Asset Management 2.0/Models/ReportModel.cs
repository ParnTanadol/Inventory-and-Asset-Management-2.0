using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_and_Asset_Management_2._0.Repositories;

namespace Inventory_and_Asset_Management_2._0.Models
{
    public class ReportModel
    {

        public int report_id { get; set; }
        public CAMTUserModel technician_id { get; set; }
        public CAMTUserModel reporter_id { get; set; }
        public ItemModel item_id { get; set; }
        public string report_typeBroken { get; set; }
        public string report_case { get; set; }
        public string report_contact { get; set; }
        public string report_repairDetail { get; set; }
        public System.DateTime report_startDate { get; set; }
        public Nullable<System.DateTime> report_endDate { get; set; }
        public int report_statusComplete { get; set; }
        public bool report_recieveMsg { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ReportModel)
            {
                ReportModel other = (ReportModel)obj;
                return Equals(other.report_id, this.report_id) && Equals(other.technician_id, this.technician_id) && Equals(other.reporter_id, this.reporter_id) && Equals(other.item_id, this.item_id) && Equals(other.report_typeBroken, this.report_typeBroken) && Equals(other.report_case, this.report_case) && Equals(other.report_contact, this.report_contact) && Equals(other.report_repairDetail, this.report_repairDetail) && Equals(other.report_startDate, this.report_startDate) && Equals(other.report_endDate, this.report_endDate) && Equals(other.report_statusComplete, this.report_statusComplete) && Equals(other.report_recieveMsg, this.report_recieveMsg);
            }
            return false;
        }

        
        public bool insertReport(int reporterId, string serialNumber, string reportTypeBroken, string reportCase, string reportContact, bool reportRecieveMsg)
        {
            try
            {
                // Find itemId
                ItemModel itemModel = new ItemModel();
                itemModel.viewItemModelbySerialNum(serialNumber);

                if (itemModel.item_id != 0)
                {
                    // Find Technicial
                    // Report status 1 = wait to receive from technicial
                    // Report ststus 2 = repairing process
                    int technicianId = 0;
                    ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                    List<CAMTUser> camtUserDbList = new List<CAMTUser>();
                    camtUserDbList = camtUserRepo.viewAllUserByUserType(2);
                    if (camtUserDbList.Count != 0)
                    {
                        IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

                        List<Report> reportDbList = new List<Report>();
                        reportDbList = reportRepo.viewAllReport();

                        if (reportDbList.Count != 0)
                        {
                            List<Report> reportDbListComplete = new List<Report>();
                            reportDbListComplete = reportRepo.viewReportbyStatus(3);


                            for (int i = 0; i < reportDbListComplete.Count; i++)
                            {
                                reportDbList.Remove(reportDbListComplete[i]);
                            }

                            //reportDbList is status 1,2
                            //find technicial that don't have works.
                            List<CAMTUser> camtUserDbList2 = new List<CAMTUser>();
                            camtUserDbList2.AddRange(camtUserDbList);

                            for (int j = 0; j < reportDbList.Count; j++)
                            {
                                camtUserDbList2.RemoveAll(item => item.user_id == reportDbList[j].technician_id);
                            }

                            if (camtUserDbList2.Count == 1)
                            {
                                // release work to technicial that don't have works
                                technicianId = camtUserDbList2[0].user_id;
                            }
                            else if (camtUserDbList2.Count > 1)
                            {
                                // release work to technicial that don't have works
                                Random random = new Random();
                                technicianId = camtUserDbList2[random.Next(0, camtUserDbList2.Count)].user_id;
                            }
                            else
                            {
                                // every technician have works 
                                // add technician id
                                List<Technician> technicianList = new List<Technician>();
                                for (int i = 0; i < reportDbList.Count; i++)
                                {
                                    int count = 0;
                                    for (int j = 0; j < technicianList.Count; j++)
                                    {
                                        if (technicianList[j].technicianId == reportDbList[i].technician_id)
                                        {
                                            count++;
                                        }
                                    }
                                    if (count == 0)
                                    {
                                        technicianList.Add(new Technician(reportDbList[i].technician_id));
                                    }
                                }

                                //add report to reportList in technician
                                foreach (Report report in reportDbList)
                                {
                                    for (int i = 0; i < technicianList.Count; i++)
                                    {
                                        if (technicianList[i].technicianId == report.technician_id)
                                        {
                                            technicianList[i].reportIdList.Add(report.report_id);
                                        }
                                    }
                                }

                                // find min report of technicians
                                List<Technician> mintechnicianList = new List<Technician>();
                                int min = int.MaxValue;
                                foreach (Technician technician in technicianList)
                                {

                                    if (technician.reportIdList.Count < min)
                                    {
                                        mintechnicianList.Clear();
                                        mintechnicianList.Add(technician);
                                        min = technician.reportIdList.Count;
                                    }
                                    else if (technician.reportIdList.Count == min)
                                    {
                                        mintechnicianList.Add(technician);
                                    }
                                }

                                // release work to technicial 
                                Random random = new Random();
                                technicianId = mintechnicianList[random.Next(0, mintechnicianList.Count)].technicianId;

                            }
                        }
                        else
                        {
                            // release work
                            Random random = new Random();
                            technicianId = camtUserDbList[random.Next(0, camtUserDbList.Count)].user_id;
                        }

                        string reportRepairDetail = "Wait to accept from technician";
                        Report report1 = new Report();
                        report1.technician_id = technicianId;
                        report1.reporter_id = reporterId;
                        report1.item_id = itemModel.item_id;
                        report1.report_typeBroken = reportTypeBroken;
                        report1.report_case = reportCase;
                        report1.report_contact = reportContact;
                        report1.report_repairDetail = reportRepairDetail;
                        report1.report_startDate = DateTime.Now;
                        report1.report_endDate = null;
                        report1.report_statusComplete = 1;
                        report1.report_recieveMsg = reportRecieveMsg;


                        // IReportRepository reportRepo = new ReportRepository(new INVENTORY_MANAGEMENTEntities());
                        bool status = reportRepo.insertReport(report1);

                        if (status == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }


        public ReportModel viewPreviousReport(int reporterId)
        {
            try
            {
                IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
                Report reportDb = new Report();
                reportDb = reportRepo.viewPreviousReport(reporterId);

                this.report_id = reportDb.report_id;

                CAMTUserModel technicianModel = new CAMTUserModel();
                technicianModel.viewUserByuserId(reportDb.technician_id);
                this.technician_id = technicianModel;

                CAMTUserModel reporterModel = new CAMTUserModel();
                reporterModel.viewUserByuserId(reportDb.reporter_id);
                this.reporter_id = reporterModel;

                ItemModel itemModel = new ItemModel();
                itemModel.viewItemModelByItemId(reportDb.item_id);
                this.item_id = itemModel;

                this.report_typeBroken = reportDb.report_typeBroken;
                this.report_case = reportDb.report_case;
                this.report_contact = reportDb.report_contact;
                this.report_repairDetail = reportDb.report_repairDetail;
                this.report_startDate = reportDb.report_startDate;
                this.report_endDate = reportDb.report_endDate;
                this.report_statusComplete = reportDb.report_statusComplete;
                this.report_recieveMsg = reportDb.report_recieveMsg;
                return this;
            }
            catch
            {
                return this;
            }
        }

        public List<ReportModel> viewReportbyReporterId(int reporterId)
        {
            try
            {
                IReportRepo itemOwnerRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
                List<Report> reportDbList = new List<Report>();
                reportDbList = itemOwnerRepo.viewReportbyReporterId(reporterId);

                List<ReportModel> reportModelList = new List<ReportModel>();
                for (int i = 0; i < reportDbList.Count; i++)
                {
                    ReportModel reportModel = new ReportModel();
                    reportModel.report_id = reportDbList[i].report_id;

                    CAMTUserModel technicianModel = new CAMTUserModel();
                    technicianModel.viewUserByuserId(reportDbList[i].technician_id);
                    reportModel.technician_id = technicianModel;

                    CAMTUserModel reporterModel = new CAMTUserModel();
                    reporterModel.viewUserByuserId(reportDbList[i].reporter_id);
                    reportModel.reporter_id = reporterModel;

                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(reportDbList[i].item_id);
                    reportModel.item_id = itemModel;

                    reportModel.report_typeBroken = reportDbList[i].report_typeBroken;
                    reportModel.report_case = reportDbList[i].report_case;
                    reportModel.report_contact = reportDbList[i].report_contact;
                    reportModel.report_repairDetail = reportDbList[i].report_repairDetail;
                    reportModel.report_startDate = reportDbList[i].report_startDate;
                    reportModel.report_endDate = reportDbList[i].report_endDate;
                    reportModel.report_statusComplete = reportDbList[i].report_statusComplete;
                    reportModel.report_recieveMsg = reportDbList[i].report_recieveMsg;
                    reportModelList.Add(reportModel);
                }
                return reportModelList;
            }
            catch
            {
                List<ReportModel> reportModelList = new List<ReportModel>();
                return reportModelList;
            }
        }
        
        public class Technician
        {
            public int technicianId { get; set; }
            public List<int> reportIdList;
            public Technician(int technicianId)
            {
                this.technicianId = technicianId;
                reportIdList = new List<int>();
            }
        }
    }
}