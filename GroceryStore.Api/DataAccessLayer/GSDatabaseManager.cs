using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Api.DataAccessLayer
{
    public class GSDatabaseManager
    {
        public GSDatabaseManager(DataContext _db)
        {
            db = _db;
        }
        public DataContext db { get; }
        #region UserManagement
        public Models.UserManagement GetUserByCredentials(string email, string password)
        {
            return db.usermanagement.Where(x => x.EmailID.ToLower() == email.ToLower()
            && x.Password == password).FirstOrDefault();
        }
        public Models.UserManagement GetUserById(int id)
        {
            Models.UserManagement user = db.usermanagement.Where(x => x.ID == id).FirstOrDefault();

            return user;
        }
        public bool AddorUpdateUser(Models.UserManagement user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.EmailID) &&
                    !string.IsNullOrEmpty(user.Password))
                {
                    Models.UserManagement userexist = GetUserByCredentials(user.EmailID, user.Password);
                    if (userexist != null)
                    {
                        db.usermanagement.Update(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        //user.ID =0;
                        //string formatForMySql = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        user.DOJ = DateTime.Now;
                        db.usermanagement.Add(user);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteUser(Models.UserManagement user)
        {
            bool IsDeleted = false;
            try
            {
                if (!string.IsNullOrEmpty(user.EmailID) &&
                    !string.IsNullOrEmpty(user.Password))
                {
                    Models.UserManagement userexist = GetUserByCredentials(user.EmailID, user.Password);
                    if (userexist != null)
                    {
                        db.usermanagement.Remove(user);
                        db.SaveChanges();
                        IsDeleted = true;

                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return IsDeleted;
        }
        #endregion

        #region SupplierManagement
        public Models.SupplierManangement GetSupplierById(int id)
        {
            Models.SupplierManangement supplier = db.suppliermanagement.Where(x => x.ID == id).FirstOrDefault();

            return supplier;
        }

        public Models.SupplierManangement GetSupplierByName(string Name)
        {
            Models.SupplierManangement supplier = db.suppliermanagement.Where(x => x.Name == Name).FirstOrDefault();

            return supplier;
        }

        public Models.SupplierManangement GetSupplierByPhone(string phonenumber)
        {
            Models.SupplierManangement supplier = db.suppliermanagement.Where(x => x.Phone == phonenumber).FirstOrDefault();

            return supplier;
        }

        public Models.SupplierManangement GetSupplierByGST(string GST)
        {
            Models.SupplierManangement supplier = db.suppliermanagement.Where(x => x.GST == GST).FirstOrDefault();

            return supplier;
        }
        public bool AddorUpdateSupplier(Models.SupplierManangement supplier)
        {
            try
            {
                if (!string.IsNullOrEmpty(supplier.Name) &&
                    !string.IsNullOrEmpty(supplier.GST) &&
                    !string.IsNullOrEmpty(supplier.Address) &&
                    !string.IsNullOrEmpty(supplier.Phone) &&
                    !string.IsNullOrEmpty(supplier.Bank) &&
                    !string.IsNullOrEmpty(supplier.AccountNumber) &&
                    !string.IsNullOrEmpty(supplier.IFSC_Code))
                {
                    Models.SupplierManangement Supplierexist = GetSupplierByPhone(supplier.Phone);
                    if (Supplierexist != null)
                    {
                        db.suppliermanagement.Update(supplier);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.suppliermanagement.Add(supplier);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteSupplierbyId(int Id)
        {
            bool IsDeleted = false;
            try
            {

                Models.SupplierManangement Supplierexist = GetSupplierById(Id);
                if (Supplierexist != null)
                {
                    db.suppliermanagement.Remove(Supplierexist);
                    db.SaveChanges();
                    IsDeleted = true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return IsDeleted;
        } 
        #endregion
    }

}


