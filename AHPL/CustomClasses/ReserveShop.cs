using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
//using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using DataTier;
namespace MMS
{
      
   public static class cReserveShop
    {
     
       public static bool  ReserveShop(int pShopID,int pExntendedCustomerID,string pShopName)
       {
           bool reserved = false;
           using (TransactionScope trs = new TransactionScope())
           {
               try
               {
                   using (AHPL_DBEntities context = new AHPL_DBEntities())
                   {

                       var qryShop = (from s in context.Shops
                                      where s.ShopID == pShopID
                                      select s).FirstOrDefault();
                       if (qryShop.CustomerID > 0)
                       { reserved = true; }
                       else
                       {
                           reserved = false;
                           qryShop.CustomerID = pExntendedCustomerID;
                           qryShop.ShopName = pShopName;
                           int succ = context.SaveChanges();
                           trs.Complete(); // completeing transaction
                       }
                   }
               }
               catch (Exception ex)
               {
                  
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   

               }
           }


           return reserved;
       }

       public static bool ReleaseShop(int pShopID)
       {
           bool releaseshop = false;
          
           using (AHPL_DBEntities context = new AHPL_DBEntities())
           {
               var qryShop = (from s in context.Shops
                              where s.ShopID == pShopID
                              select s).FirstOrDefault();
               qryShop.CustomerID = 0;
               qryShop.ShopName = "";

               int succ = context.SaveChanges();
           }
           return releaseshop;

       }

    }
}
