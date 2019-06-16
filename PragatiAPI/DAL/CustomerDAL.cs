using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PragatiAPI.Models;
using System.Security.Policy;

namespace PragatiAPI.DAL
{
    public class CustomerDAL
    {
        PragatiEntities entities = new PragatiEntities();
        public List<CustomerModel> GetCustomer(int CustomerID = 0)
        {
            List<CustomerModel> lstCustomer = new List<CustomerModel>();
            if (CustomerID > 0)
            {
                lstCustomer = (from cust in entities.Customers
                               join type in entities.CustomerTypes
                               on cust.CustomerType equals type.ID into g
                               from x in g.DefaultIfEmpty()
                               where cust.IsDeleted == false && cust.CustomerID == CustomerID
                               select new CustomerModel
                               {
                                   CustomerID = cust.CustomerID,
                                   CustomerName = cust.CustomerName,
                                   BillingAddress = cust.BillingAddress,
                                   ShippingAddress = cust.ShippingAddress,
                                   VAT = cust.Vat,
                                   GST = cust.Cst,
                                   ISDeleted = cust.IsDeleted,
                                   CustomerType=x.Type,
                                   CustomerTypeID = x.ID,
                                   ImagePath = "http://" + HttpContext.Current.Request.Url.Authority + "/UploadFile/" + cust.ImagePath
                               }).OrderByDescending(x => x.CustomerID).ToList();

            }
            else
            {
                lstCustomer = (from cust in entities.Customers
                               join type in entities.CustomerTypes
                              on cust.CustomerType equals type.ID into g
                               from x in g.DefaultIfEmpty()
                               where cust.IsDeleted == false
                               select new CustomerModel
                               {
                                   CustomerID = cust.CustomerID,
                                   CustomerName = cust.CustomerName,
                                   BillingAddress = cust.BillingAddress,
                                   ShippingAddress = cust.ShippingAddress,
                                   VAT = cust.Vat,
                                   GST = cust.Cst,
                                   CustomerType = x.Type,
                                   CustomerTypeID = x.ID,
                                   ISDeleted = cust.IsDeleted,
                                   ImagePath = "http://" + HttpContext.Current.Request.Url.Authority + "/UploadFile/" + cust.ImagePath
                               }).OrderByDescending(x => x.CustomerID).ToList();
            }
            return lstCustomer.OrderByDescending(x => x.CustomerID).ToList();
        }
        public CustomerModel AddCustomer(CustomerModel model)
        {
            if (model.CustomerID == 0)
            {
                Customer customer = new Customer();
                customer.CustomerName = model.CustomerName;
                customer.BillingAddress = model.BillingAddress;
                customer.ShippingAddress = model.ShippingAddress;
                customer.Vat = model.VAT;
                customer.Cst = model.GST;
                customer.IsDeleted = model.ISDeleted;
                customer.ImagePath = model.ImagePath;
                customer.CustomerType = model.CustomerTypeID;
                entities.Customers.Add(customer);

                entities.SaveChanges();
            }
            else
            {
                Customer customer = entities.Customers.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                customer.CustomerID = model.CustomerID;
                customer.CustomerName = model.CustomerName;
                customer.BillingAddress = model.BillingAddress;
                customer.ShippingAddress = model.ShippingAddress;
                customer.Vat = model.VAT;
                customer.Cst = model.GST;
                customer.IsDeleted = model.ISDeleted;
                customer.ImagePath = model.ImagePath;
                customer.CustomerType = model.CustomerTypeID;
                entities.SaveChanges();
            }
            return model;
        }
        public bool DeleteCustomer(int CustomerID)
        {
            Customer customer = entities.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
            customer.IsDeleted = true;
            entities.SaveChanges();
            return true;
        }
        public List<CustomerTypeModel> GetCustomerType()
        {
            List<CustomerTypeModel> lstCustomerType = new List<CustomerTypeModel>();

            lstCustomerType = (from cust in entities.CustomerTypes
                               select new CustomerTypeModel
                               {
                                   ID = cust.ID,
                                   Type = cust.Type
                               }).ToList();
            return lstCustomerType;

        }
        public List<CustomerModel> GetCustomerByCustomerType(int CustomerTypeID = 0)
        {
            List<CustomerModel> lstCustomer = new List<CustomerModel>();
            if (CustomerTypeID > 0)
            {
                lstCustomer = (from cust in entities.Customers
                               join type in entities.CustomerTypes
                               on cust.CustomerType equals type.ID into g
                               from x in g.DefaultIfEmpty()
                               where cust.IsDeleted == false && x.ID == CustomerTypeID
                               select new CustomerModel
                               {
                                   CustomerID = cust.CustomerID,
                                   CustomerName = cust.CustomerName,
                                   BillingAddress = cust.BillingAddress,
                                   ShippingAddress = cust.ShippingAddress,
                                   VAT = cust.Vat,
                                   GST = cust.Cst,
                                   ISDeleted = cust.IsDeleted,
                                   CustomerType = x.Type,
                                   CustomerTypeID = x.ID,
                                   ImagePath = "http://" + HttpContext.Current.Request.Url.Authority + "/UploadFile/" + cust.ImagePath
                               }).OrderByDescending(x => x.CustomerID).ToList();

            }
            else
            {
                lstCustomer = (from cust in entities.Customers
                               join type in entities.CustomerTypes
                              on cust.CustomerType equals type.ID into g
                               from x in g.DefaultIfEmpty()
                               where cust.IsDeleted == false
                               select new CustomerModel
                               {
                                   CustomerID = cust.CustomerID,
                                   CustomerName = cust.CustomerName,
                                   BillingAddress = cust.BillingAddress,
                                   ShippingAddress = cust.ShippingAddress,
                                   VAT = cust.Vat,
                                   GST = cust.Cst,
                                   CustomerType = x.Type,
                                   CustomerTypeID = x.ID,
                                   ISDeleted = cust.IsDeleted,
                                   ImagePath = "http://" + HttpContext.Current.Request.Url.Authority + "/UploadFile/" + cust.ImagePath
                               }).OrderByDescending(x => x.CustomerID).ToList();
            }
            return lstCustomer.OrderByDescending(x => x.CustomerID).ToList();
        }
    }

}
     

