using PragatiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PragatiAPI.DAL
{
    public class InvoiceDAL
    {
        PragatiEntities entities = new PragatiEntities();
        CustomerDAL custObj = new CustomerDAL();
        public List<InvoiceMasterModel> GetInvoice(int InvoiceID = 0)
        {
            List<InvoiceMasterModel> lstInvoice = new List<InvoiceMasterModel>();
            lstInvoice = (from inv in entities.InvoiceMasters
                          join cust in entities.Customers
                          on inv.CustomerID equals cust.CustomerID
                          select new InvoiceMasterModel
                          {
                              InvoiceID=inv.InvoiceID,
                              InvoiceNo=inv.InvoiceNo,
                              InvoiceDate=inv.InvoiceDate,
                              CustomerID=inv.CustomerID,
                              CustomerName=cust.CustomerName,
                              ChallanNo=inv.ChallanNo,
                              OrderNo=inv.OrderNo,
                              OrderDate=inv.OrderDate,
                              NetTotal=inv.NetToal,
                            
                              IsDeleted=inv.IsDeleted   
                          }).ToList();
            
                //return lstCustomer.OrderByDescending(x => x.CustomerID).ToList();
           
            return lstInvoice;
        }
        public InvoiceMasterModel GetInvoiceWithDetail(int InvoiceID)
        {

            InvoiceMasterModel lstInvoice = new InvoiceMasterModel();
            if (InvoiceID > 0)
            {
                lstInvoice = (from inv in entities.InvoiceMasters
                              join cust in entities.Customers
                              on inv.CustomerID equals cust.CustomerID
                              // where inv.InvoiceID == InvoiceID
                              select new InvoiceMasterModel
                              {
                                  InvoiceID = inv.InvoiceID,
                                  InvoiceNo = inv.InvoiceNo,
                                  InvoiceDate = inv.InvoiceDate,
                                  CustomerID = inv.CustomerID,
                                  CustomerName = cust.CustomerName,
                                  ChallanNo = inv.ChallanNo,
                                  OrderNo = inv.OrderNo,
                                  OrderDate = inv.OrderDate,
                                  NetTotal = inv.NetToal,
                                 
                                
                                  IsDeleted = inv.IsDeleted
                              }).FirstOrDefault();
            }
            lstInvoice.InvoiceDetailList = this.GetInvoiceDetailFromInvoice(InvoiceID);
            lstInvoice.CustomerList = custObj.GetCustomer();
            //return lstCustomer.OrderByDescending(x => x.CustomerID).ToList();

            return lstInvoice;
        }
        private List<InvoiceDetailModel> GetInvoiceDetailFromInvoice(int InvoiceId)
        {
            List<InvoiceDetailModel> lstInvoiceDetail = new List<InvoiceDetailModel>();
            lstInvoiceDetail = (from inv in entities.InvoiceDetails
                          where inv.InvoiceMasterID == InvoiceId
                          select new InvoiceDetailModel
                          {
                              InvoiceDetailID=inv.InvoiceDetailID,
                              InvoiceMasterID=inv.InvoiceMasterID,
                              Particular=inv.Particular,
                              Length=(float)inv.Length,
                              Width=(float)inv.Width,
                              Qty=inv.Qty,
                              Rate=(float)inv.Rate,
                              Amount=inv.Amount,
                              IsDeleted = inv.IsDeleted
                          }).ToList();
            return lstInvoiceDetail;
        }
        public InvoiceMasterModel AddInvoice(InvoiceMasterModel model)
        {
            if (model.InvoiceID == 0)
            {
                InvoiceMaster inv = new InvoiceMaster();
                inv.InvoiceNo = model.InvoiceNo;
                inv.InvoiceDate = model.InvoiceDate;
                inv.OrderNo = model.OrderNo;
                inv.OrderDate = model.OrderDate;
                inv.ChallanNo = model.ChallanNo;
                inv.CustomerID = model.CustomerID;
              
                entities.InvoiceMasters.Add(inv);
                entities.SaveChanges();
                model.InvoiceID = inv.InvoiceID;
                SaveInvoiceDetail(model);

            }
            else
            {
                InvoiceMaster inv = entities.InvoiceMasters.Where(x => x.InvoiceID == model.InvoiceID).FirstOrDefault();
                 inv.InvoiceNo = model.InvoiceNo;
                inv.InvoiceDate = model.InvoiceDate;
                inv.OrderNo = model.OrderNo;
                inv.OrderDate = model.OrderDate;
                inv.ChallanNo = model.ChallanNo;
                inv.CustomerID = model.CustomerID;
               // inv.GrossTotal = model.GrossTotal;
                entities.SaveChanges();
                SaveInvoiceDetail(model);
            }
            return model;
        }
        private void SaveInvoiceDetail(InvoiceMasterModel model)
        {
            InvoiceDetail inv = new InvoiceDetail();
            foreach(var detail in model.InvoiceDetailList)
            {
            inv.InvoiceMasterID = model.InvoiceID;
            inv.Particular = detail.Particular;
            inv.Qty = detail.Qty;
            inv.Length = detail.Length;
            inv.Width = detail.Width;
            inv.Rate = detail.Rate;
            entities.InvoiceDetails.Add(inv);
            entities.SaveChanges();
            }
        }
    }
}