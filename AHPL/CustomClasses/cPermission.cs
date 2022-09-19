using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using System.Data.Linq;
using DataTier;

namespace MMS.CustomClasses
{
    public static class cPermission
    {
        public static bool IsCreate(int pUserID, string pFormName)
        {
            bool permission = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryAuth = (from u in context.Permission_Users
                               join p in context.Permission_UserForms on u.RoleID equals p.RoleID
                               join uf in context.Permission_Forms on p.FormID equals uf.FormID
                               where uf.InternalFormName == pFormName && u.UserID == pUserID
                               select new { u.UserName, p.C }).FirstOrDefault();
                if (qryAuth != null)
                {
                    permission = qryAuth.C;
                }

                if (permission == false)
                {
                    Exception ex = new Exception("Hello..." + CustomClasses.cCommon_Functions.LoggedSystemUserName + System.Environment.NewLine + "Sorry..You Dont Have Permission to Add Record");
                    throw ex;
                }


            }
            return permission;
        }

        public static bool IsUpdate(int pUserID, string pFormName)
        {
            bool permission = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryAuth = (from u in context.Permission_Users
                               join p in context.Permission_UserForms on u.RoleID equals p.RoleID
                               join uf in context.Permission_Forms on p.FormID equals uf.FormID
                               where uf.InternalFormName == pFormName && u.UserID == pUserID
                               select new { u.UserName, p.U }).FirstOrDefault();
                if (qryAuth != null)
                {
                    permission = qryAuth.U;
                }

                if (permission == false)
                {
                    Exception ex = new Exception("Hello..." + CustomClasses.cCommon_Functions.LoggedSystemUserName + System.Environment.NewLine + "Sorry..You Dont Have Permission to Update Record");
                    throw ex;
                }


            }
            return permission;
        }

        public static bool IsDelete(int pUserID, string pFormName)
        {
            bool permission = false;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryAuth = (from u in context.Permission_Users
                               join p in context.Permission_UserForms on u.RoleID equals p.RoleID
                               join uf in context.Permission_Forms on p.FormID equals uf.FormID
                               where uf.InternalFormName == pFormName && u.UserID == pUserID
                               select new { u.UserName, p.D }).FirstOrDefault();
                if (qryAuth != null)
                {
                    permission = qryAuth.D;
                }

                if (permission == false)
                {
                    Exception ex = new Exception("Hello..." + CustomClasses.cCommon_Functions.LoggedSystemUserName + System.Environment.NewLine + "Sorry..You Dont Have Permission to Delete Record");
                    throw ex;
                }



            }
            return permission;
        }

    }
}
