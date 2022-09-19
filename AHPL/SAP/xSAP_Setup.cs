using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using DataTier;

namespace MMS
{
    public partial class xSAP_Setup : DevExpress.XtraEditors.XtraForm
    {
        List<cDocType> DocTypeList = new List<cDocType>();
        List<cTaxGL> TaxGLList = new List<cTaxGL>();
        List<cLineItem> LineItemList = new List<cLineItem>();

        BindingSource bsDocType = new BindingSource();
        BindingSource bsTaxGL = new BindingSource();
        BindingSource bsLineItem = new BindingSource();

        public xSAP_Setup()
        {
            InitializeComponent();
        }

        private void xSAP_Setup_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void Load_data()
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                //company 
                companyBindingSource.DataSource = (from c in context.Companies
                                                   select new { c.CompanyID, c.CompanyCode, c.CompanyName }).ToList();
                //-


                /// Document Types 
                //loading invoice types 
                //var qryInvType = (from it in context.Invoice_Types
                //                  select it).ToList();

                //foreach (var qry in qryInvType)
                //{                

                //    if (qry.InvoiceTypeID == 1) // rent invoice type 
                //    {


                //        cDocType oDocType = new cDocType();
                //        oDocType.DocID = qry.InvoiceTypeID;
                //        oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                //        oDocType.InvoiceType = qry.InvoiceTypeName;
                //        oDocType.DocType = qry.DocType;
                //        oDocType.InvTypeCategory = "Rent";
                //        oDocType.InvoicePrefix = "R";
                //        DocTypeList.Add(oDocType);
                //    }

                //    if (qry.InvoiceTypeID == 2) // Utility Invoice types
                //    {
                //        var qryUinv = (from u in context.Utilities
                //                       select u).ToList();
                //        foreach (var qry1 in qryUinv)
                //        {

                //         // querying SAP_DOCTYPE for utilieis 
                //            //var qrySAPDT = (from dt in context.SAP_DocTypes
                //            //                where dt.CompanyID == comp


                //            cDocType oDocType = new cDocType();
                //            oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                //            oDocType.InvoiceType = qry1.UtilityName;
                //            oDocType.DocType = qry1.DocType;
                //            oDocType.InvTypeCategory = "Utilities";
                //            oDocType.InvoicePrefix = qry1.InvoicePrefix;
                //            oDocType.DocID = qry1.UtilityID;
                //            DocTypeList.Add(oDocType);
                //        }
                //    }

                //    if (qry.InvoiceTypeID == 3) // other service invoice types
                //    {
                //        var qryOtherS = (from os in context.OtherServiceCategories
                //                         select os).ToList();
                //        foreach (var qry2 in qryOtherS)
                //        {
                //            cDocType oDocType = new cDocType();
                //            oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                //            oDocType.InvoiceType = qry2.OtherServiceName;
                //            oDocType.DocType = qry2.DocType;
                //            oDocType.InvTypeCategory = "Other Services";
                //            oDocType.InvoicePrefix = qry2.InvoicePrefix;
                //            oDocType.DocID = qry2.OtherServiceID;
                //            DocTypeList.Add(oDocType);
                //        }
                //    }
                //}
                //

                //// Tax GL Codes
                //    var qryTax = (from t in context.Taxes
                //                  orderby t.IsMandatory 
                //                  select t).ToList();
                //    foreach (var qry in qryTax)
                //    {

                //           // querying SAP_TAXGLCODES tables 
                //        var qrySAPTXGL = context.SAP_TAXGLCODES.Where(x => x.TaxID == qry.TaxID).FirstOrDefault();

                //        if (qrySAPTXGL == null) // if not exist 
                //        {
                //            cTaxGL oTaxGL = new cTaxGL();
                //            oTaxGL.TaxID = qry.TaxID;
                //            oTaxGL.TaxCode = qry.TaxCode;
                //            oTaxGL.GL_Code = qry.SAP_GLCode;
                //            TaxGLList.Add(oTaxGL);
                //        }
                //        ///--
                //    }

                //    this.bsTaxGL.DataSource = TaxGLList;
                // 

                /// Line Items 
                //    #region LineItems 
                //    var qryLineItems = (from li in context.Sub_Invoice_Types
                //                        where li.SubInvTypeID != 1
                //                        orderby li.StdOrder ascending
                //                        select li).ToList();
                //    foreach (var qry in qryLineItems)
                //    {
                //        cLineItem oLineItem = new cLineItem();
                //        oLineItem.SubInvTypeID = qry.SubInvTypeID;
                //        oLineItem.StdOrder = qry.StdOrder;
                //        oLineItem.SubInvTypeName = qry.SubInvTypeName;
                //        oLineItem.CustomerLineItem = qry.CustomerLineItem;
                //        oLineItem.GLLineItem = qry.GLLineItem;
                //        LineItemList.Add(oLineItem);                 

                //    }

                //    #endregion



                //}

                // binding Doctype to the datasource
                bsDocType.DataSource = DocTypeList;
                this.gridControlDocType.DataSource = bsDocType;

                // binding TaxGL to the datasource
                bsTaxGL.DataSource = TaxGLList;
                this.gridControlTaxGL.DataSource = TaxGLList;

                //binding LineItem to the datasource
                bsLineItem.DataSource = LineItemList;
                this.gridControlLineItem.DataSource = bsLineItem;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);


                this.bsDocType.EndEdit();
                this.bsLineItem.EndEdit();
                this.bsTaxGL.EndEdit();

                if (string.IsNullOrEmpty(this.lookUpEditCompany.Text.ToString()))
                { return; }

                bool res = false;
                int companyid = 0;
                res = int.TryParse(this.lookUpEditCompany.EditValue.ToString(), out companyid);
                if (res == false) { companyid = 0; }
                if (companyid == 0)
                { return; }

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    //saving doctype 
                    #region DocType

                    // for rent invoice 
                    #region RentInvoice
                    var qryRentInvoice = (from dt in DocTypeList
                                          where dt.InvoiceTypeID == 1 && dt.CompID == companyid
                                          select dt).ToList();

                    foreach (var qry in qryRentInvoice)
                    {
                        SAP_DocTypes qryDT = (from dt in context.SAP_DocTypes
                                              where dt.CompanyID == companyid && dt.InvoiceTypeID == 1
                                              select dt).FirstOrDefault();
                        if (qryDT == null)
                        {
                            SAP_DocTypes oDocType = new SAP_DocTypes();
                            oDocType.CompanyID = companyid;
                            oDocType.DocID = qry.InvoiceTypeID;
                            oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                            oDocType.InvoiceType = qry.InvoiceType;
                            oDocType.InvoiceTypeCategory = qry.InvTypeCategory;
                            oDocType.DOCTYPE = qry.DocType;
                            oDocType.GL_CODE = qry.GL_Code;
                            oDocType.InvoicePrefix = qry.InvoicePrefix;
                            oDocType.PROFIT_CENTER = qry.ProfitCenter;
                            oDocType.COST_CENTER = qry.CostCenter;
                            context.SAP_DocTypes.AddObject(oDocType);
                        }
                        else
                        {
                            qryDT.CompanyID = companyid;
                            qryDT.DocID = qry.InvoiceTypeID;
                            qryDT.InvoiceTypeID = qry.InvoiceTypeID;
                            qryDT.InvoiceType = qry.InvoiceType;
                            qryDT.InvoiceTypeCategory = qry.InvTypeCategory;
                            qryDT.DOCTYPE = qry.DocType;
                            qryDT.GL_CODE = qry.GL_Code;
                            qryDT.InvoicePrefix = qry.InvoicePrefix;
                            qryDT.COST_CENTER = qry.CostCenter;
                            qryDT.PROFIT_CENTER = qry.ProfitCenter;
                            context.SAP_DocTypes.ApplyCurrentValues(qryDT);
                        }
                    }
                    #endregion


                    // Utitlity Invoices 
                    #region UtilityInvoice
                    var qryUInv = (from dt in DocTypeList
                                   where dt.InvoiceTypeID == 2 && dt.CompID == companyid
                                   select dt).ToList();
                    foreach (var qry in qryUInv)
                    {
                        SAP_DocTypes qryDT = (from dt in context.SAP_DocTypes
                                              where dt.CompanyID == companyid && dt.InvoiceTypeID == 2 && dt.DocID == qry.DocID
                                              select dt).FirstOrDefault();

                        if (qryDT == null)
                        {
                            SAP_DocTypes oDocType = new SAP_DocTypes();
                            oDocType.CompanyID = companyid;
                            oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                            oDocType.InvoiceType = qry.InvoiceType;
                            oDocType.InvoiceTypeCategory = qry.InvTypeCategory;
                            oDocType.GL_CODE = qry.GL_Code;
                            oDocType.DOCTYPE = qry.DocType;
                            oDocType.InvoicePrefix = qry.InvoicePrefix;
                            oDocType.DocID = qry.DocID;
                            oDocType.PROFIT_CENTER = qry.ProfitCenter;
                            oDocType.COST_CENTER = qry.CostCenter;
                            context.SAP_DocTypes.AddObject(oDocType);
                        }
                        else
                        {
                            qryDT.CompanyID = companyid;
                            qryDT.DocID = qry.DocID;
                            qryDT.InvoiceTypeID = qry.InvoiceTypeID;
                            qryDT.InvoiceType = qry.InvoiceType;
                            qryDT.InvoiceTypeCategory = qry.InvTypeCategory;
                            qryDT.DOCTYPE = qry.DocType;
                            qryDT.GL_CODE = qry.GL_Code;
                            qryDT.InvoicePrefix = qry.InvoicePrefix;
                            qryDT.COST_CENTER = qry.CostCenter;
                            qryDT.PROFIT_CENTER = qry.ProfitCenter;
                            context.SAP_DocTypes.ApplyOriginalValues(qryDT);
                        }
                    }

                    #endregion

                    /// Other Services 
                    #region OtherServices
                    var qryOtherServices = (from dt in DocTypeList
                                            where dt.InvoiceTypeID == 3 && dt.CompID == companyid
                                            select dt).ToList();
                    foreach (var qry in qryOtherServices)
                    {
                        SAP_DocTypes qryDT = (from c in context.SAP_DocTypes
                                              where c.CompanyID == companyid && c.InvoiceTypeID == 3 && c.DocID == qry.DocID
                                              select c).FirstOrDefault();
                        if (qryDT == null)
                        {
                            SAP_DocTypes oDocType = new SAP_DocTypes();
                            oDocType.CompanyID = companyid;
                            oDocType.InvoiceTypeID = 3; // Other Service InvoiceTypeID =2
                            oDocType.InvoiceType = qry.InvoiceType;
                            oDocType.InvoiceTypeCategory = qry.InvTypeCategory;
                            oDocType.GL_CODE = qry.GL_Code;
                            oDocType.DOCTYPE = qry.DocType;
                            oDocType.InvoicePrefix = qry.InvoicePrefix;
                            oDocType.DocID = qry.DocID;
                            oDocType.PROFIT_CENTER = qry.ProfitCenter;
                            oDocType.COST_CENTER = qry.CostCenter;
                            context.SAP_DocTypes.AddObject(oDocType);
                        }
                        else
                        {
                            qryDT.CompanyID = companyid;
                            qryDT.DocID = qry.DocID;
                            qryDT.InvoiceTypeID = qry.InvoiceTypeID;
                            qryDT.InvoiceType = qry.InvoiceType;
                            qryDT.InvoiceTypeCategory = qry.InvTypeCategory;
                            qryDT.DOCTYPE = qry.DocType;
                            qryDT.GL_CODE = qry.GL_Code;
                            qryDT.InvoicePrefix = qry.InvoicePrefix;
                            qryDT.COST_CENTER = qry.CostCenter;
                            qryDT.PROFIT_CENTER = qry.ProfitCenter;
                            context.SAP_DocTypes.ApplyCurrentValues(qryDT);
                        }
                    }

                    #endregion

                    #endregion

                    // Saving Tax GL Setup 
                    #region Tax_GL

                    foreach (var qryT in TaxGLList)
                    {
                        SAP_TAXGLCODES qryTax = (from tg in context.SAP_TAXGLCODES
                                                 where tg.CompanyID == companyid && tg.TaxID == qryT.TaxID
                                                 select tg).FirstOrDefault();
                        if (qryTax == null)
                        {
                            SAP_TAXGLCODES _sapTaxGL = new SAP_TAXGLCODES();
                            _sapTaxGL.CompanyID = companyid;
                            _sapTaxGL.TaxID = qryT.TaxID;
                            _sapTaxGL.TaxCode = qryT.TaxCode;
                            _sapTaxGL.SAP_GLCode = qryT.GL_Code;
                            context.SAP_TAXGLCODES.AddObject(_sapTaxGL);

                        }
                        else
                        {
                            qryTax.CompanyID = qryT.CompanyID;
                            qryTax.TaxID = qryT.TaxID;
                            qryTax.TaxCode = qryT.TaxCode;
                            qryTax.SAP_GLCode = qryT.GL_Code;
                            context.SAP_TAXGLCODES.ApplyCurrentValues(qryTax);
                        }


                    }

                    #endregion

                    // Saving Line Item
                    #region LineItem
                    foreach (var qryLI in LineItemList)
                    {
                        var qryLitem = (from li in context.SAP_LineItems
                                        where li.CompanyID == companyid && li.SubInvTypeID == qryLI.SubInvTypeID
                                        select li).FirstOrDefault();
                        if (qryLitem == null)
                        {
                            SAP_LineItems oSapLItem = new SAP_LineItems();
                            oSapLItem.CompanyID = companyid;
                            oSapLItem.SubInvTypeID = qryLI.SubInvTypeID;
                            oSapLItem.SubInvType = qryLI.SubInvTypeName;
                            oSapLItem.GL_LineItem = qryLI.GLLineItem;
                            oSapLItem.Customer_LineItem = qryLI.CustomerLineItem;
                            oSapLItem.StdOrder = qryLI.StdOrder;
                            context.SAP_LineItems.AddObject(oSapLItem);

                        }
                        else
                        {
                            qryLitem.CompanyID = companyid;
                            qryLitem.SubInvTypeID = qryLI.SubInvTypeID;
                            qryLitem.SubInvType = qryLI.SubInvTypeName;
                            qryLitem.GL_LineItem = qryLI.GLLineItem;
                            qryLitem.Customer_LineItem = qryLI.CustomerLineItem;
                            qryLitem.StdOrder = qryLI.StdOrder;
                            context.SAP_LineItems.ApplyCurrentValues(qryLitem);
                        }

                    }
                    #endregion

                    int succ = context.SaveChanges();
                    if (succ > 0)
                    {
                        MessageBox.Show("Record Saved Successfully...", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lookUpEditCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lookUpEditCompany.Text.ToString()))
            { return; }

            int companyid = 0;
            bool res = int.TryParse(this.lookUpEditCompany.EditValue.ToString(), out companyid);
            if (res == false) { companyid = 0; }
            if (companyid == 0) { return; }
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {

                #region SAP_DOCTYPE
                //loading invoice types 
                DocTypeList.Clear();
                var qryInvType = (from it in context.Invoice_Types
                                  select it).ToList();

                foreach (var qry in qryInvType)
                {
                    if (qry.InvoiceTypeID == 1) // rent invoice type 
                    {

                        //querying SAP_DOCTYPE table 

                        var qrySAPDT = (from dt in context.SAP_DocTypes
                                        where dt.InvoiceTypeID == qry.InvoiceTypeID && dt.CompanyID == companyid
                                        select dt).ToList();

                        if (qrySAPDT.Count == 0) // if not exist 
                        {
                            cDocType oDocType = new cDocType();
                            oDocType.CompID = companyid;
                            oDocType.DocID = qry.InvoiceTypeID;
                            oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                            oDocType.InvoiceType = qry.InvoiceTypeName;
                            oDocType.DocType = "";
                            oDocType.GL_Code = "";
                            oDocType.InvTypeCategory = "Rent";
                            oDocType.InvoicePrefix = "R";
                            DocTypeList.Add(oDocType);
                        }
                        else // if exist
                        {
                            foreach (var _qry in qrySAPDT)
                            {
                                cDocType oDocType = new cDocType();
                                oDocType.CompID = _qry.CompanyID;
                                oDocType.DocID = _qry.DocID;
                                oDocType.InvoiceTypeID = _qry.DocID;
                                oDocType.InvoiceType = _qry.InvoiceType;
                                oDocType.DocType = _qry.DOCTYPE;
                                oDocType.GL_Code = _qry.GL_CODE;
                                oDocType.ProfitCenter = _qry.PROFIT_CENTER;
                                oDocType.CostCenter = _qry.COST_CENTER;
                                oDocType.InvTypeCategory = _qry.InvoiceTypeCategory;
                                oDocType.InvoicePrefix = _qry.InvoicePrefix;
                                DocTypeList.Add(oDocType);
                            }                       

                        }
                    }
                    if (qry.InvoiceTypeID == 2) // Utility Invoice types
                    {
                                          
                        var qryUinv = (from u in context.Utilities
                                       select u).ToList();
                        foreach (var qry1 in qryUinv)
                        {

                             ////querying SAP_DOCTYPE for utilieis 
                            var qrySAPDT = (from dt in context.SAP_DocTypes
                                            where dt.CompanyID == companyid && dt.InvoiceTypeID == 2 && dt.DocID == qry1.UtilityID
                                            select dt).FirstOrDefault();
                            if (qrySAPDT == null)
                            {
                                cDocType oDocType = new cDocType();
                                oDocType.CompID = companyid;
                                oDocType.InvoiceTypeID = qry.InvoiceTypeID;
                                oDocType.InvoiceType = qry1.UtilityName;
                                oDocType.DocType = "";
                                oDocType.InvTypeCategory = "Utilities";
                                oDocType.InvoicePrefix = qry1.InvoicePrefix;
                                oDocType.DocID = qry1.UtilityID;
                                oDocType.ProfitCenter ="";
                                oDocType.CostCenter = "";
                                DocTypeList.Add(oDocType);
                            }
                            else
                            {
                                    cDocType oDocType = new cDocType();
                                    oDocType.CompID = companyid;
                                    oDocType.InvoiceTypeID = qrySAPDT.InvoiceTypeID.Value;
                                    oDocType.InvoiceType = qrySAPDT.InvoiceType;
                                    oDocType.DocType = qrySAPDT.DOCTYPE;
                                    oDocType.InvTypeCategory = qrySAPDT.InvoiceTypeCategory;
                                    oDocType.InvoicePrefix = qrySAPDT.InvoicePrefix;
                                    oDocType.DocID = qrySAPDT.DocID;
                                    oDocType.GL_Code = qrySAPDT.GL_CODE;
                                    oDocType.ProfitCenter = qrySAPDT.PROFIT_CENTER;
                                    oDocType.CostCenter = qrySAPDT.COST_CENTER;
                                    DocTypeList.Add(oDocType);
                            }

                                
                            
                        }                                                               
                    }

                    if (qry.InvoiceTypeID == 3) // other service invoice types
                    {
                        var qryOtherS = (from os in context.OtherServiceCategories
                                         select os).ToList();
                        foreach (var qry2 in qryOtherS)
                        {
                            ////querying SAP_DOCTYPE for utilieis 
                            var qrySAPDT = (from dt in context.SAP_DocTypes
                                            where dt.CompanyID == companyid && dt.DocID == qry2.OtherServiceID && dt.InvoiceTypeID ==3
                                            select dt).FirstOrDefault();
                            if (qrySAPDT == null)
                            {
                                cDocType oDocType = new cDocType();
                                oDocType.CompID = companyid;
                                oDocType.InvoiceTypeID = 3; // Other Invoice Type ID = 3
                                oDocType.InvoiceType = qry2.OtherServiceName;
                                oDocType.DocType = "";
                                oDocType.InvTypeCategory = "Other Services";
                                oDocType.InvoicePrefix = qry2.InvoicePrefix;
                                oDocType.DocID = qry2.OtherServiceID;

                                DocTypeList.Add(oDocType);
                            }
                            else
                            {
                                cDocType oDocType = new cDocType();
                                oDocType.CompID = companyid;
                                oDocType.InvoiceTypeID = 3;
                                oDocType.InvoiceType = qrySAPDT.InvoiceType;
                                oDocType.DocType = qrySAPDT.DOCTYPE;
                                oDocType.InvTypeCategory = "Other Services";
                                oDocType.InvoicePrefix = qrySAPDT.InvoicePrefix;
                                oDocType.DocID = qrySAPDT.DocID;
                                oDocType.GL_Code = qrySAPDT.GL_CODE;
                                oDocType.ProfitCenter = qrySAPDT.PROFIT_CENTER;
                                oDocType.CostCenter = qrySAPDT.COST_CENTER;
                                DocTypeList.Add(oDocType);


                            }
                        }
                    }

                }
                #endregion

                #region SAP_GL_Tax 
                TaxGLList.Clear();
                var qryTax = (from t in context.Taxes
                              orderby t.IsMandatory
                              select t).ToList();
                foreach (var qry in qryTax)
                {

                    // querying SAP_TAXGLCODES tables 
                    var qrySAPTXGL = (from t in context.SAP_TAXGLCODES
                                      where t.CompanyID == companyid && t.TaxID == qry.TaxID
                                      select t).FirstOrDefault();

                    if (qrySAPTXGL == null) // if not exist 
                    {
                        cTaxGL oTaxGL = new cTaxGL();
                        oTaxGL.CompanyID = companyid;
                        oTaxGL.TaxID = qry.TaxID;
                        oTaxGL.TaxCode = qry.TaxCode;
                        oTaxGL.GL_Code = qry.SAP_GLCode;
                        TaxGLList.Add(oTaxGL);
                    }
                    else
                    {
                        cTaxGL oTaxGL = new cTaxGL();
                        oTaxGL.CompanyID = companyid;
                        oTaxGL.TaxID = qrySAPTXGL.TaxID;
                        oTaxGL.TaxCode = qrySAPTXGL.TaxCode;
                        oTaxGL.GL_Code = qrySAPTXGL.SAP_GLCode;
                        TaxGLList.Add(oTaxGL);

                    }
                    ///--
                }

                this.bsTaxGL.DataSource = TaxGLList;
                #endregion
                /// Line Items 
                #region LineItems
                LineItemList.Clear();
                var qryLineItems = (from li in context.Sub_Invoice_Types
                                    where li.SubInvTypeID != 1
                                    orderby li.StdOrder ascending
                                    select li).ToList();
                foreach (var qry in qryLineItems)
                {
                    //querying line items 
                    var qrySAPLINEITEM = (from li in context.SAP_LineItems
                                          where li.CompanyID == companyid && li.SubInvTypeID == qry.SubInvTypeID
                                          select li).FirstOrDefault();

                    if (qrySAPLINEITEM == null)
                    {
                        cLineItem oLineItem = new cLineItem();
                        oLineItem.SubInvTypeID = qry.SubInvTypeID;
                        oLineItem.StdOrder = qry.StdOrder;
                        oLineItem.SubInvTypeName = qry.SubInvTypeName;
                        oLineItem.CustomerLineItem = qry.CustomerLineItem;
                        oLineItem.GLLineItem = qry.GLLineItem;
                        LineItemList.Add(oLineItem);
                    }
                    else
                    {
                        cLineItem oLineItem = new cLineItem();
                        oLineItem.SubInvTypeID = qrySAPLINEITEM.SubInvTypeID;
                        oLineItem.StdOrder = qrySAPLINEITEM.StdOrder;
                        oLineItem.SubInvTypeName = qrySAPLINEITEM.SubInvType;
                        oLineItem.CustomerLineItem = qrySAPLINEITEM.Customer_LineItem;
                        oLineItem.GLLineItem = qrySAPLINEITEM.GL_LineItem ;
                        LineItemList.Add(oLineItem);
                    }

                }

                #endregion

            }


            this.gridView1.BestFitColumns();
            this.gridView2.BestFitColumns();
            this.gridView3.BestFitColumns();
            this.gridControlDocType.RefreshDataSource();
            this.gridControlLineItem.RefreshDataSource();
            this.gridControlTaxGL.RefreshDataSource();

        }
    }

    class cDocType
    {
        public int DocID { get; set; }
        public int CompID { get; set; }
        public int InvoiceTypeID { get; set; }
        public string InvoiceType { get; set; }
        public string DocType { get; set; }
        public string InvTypeCategory { get; set; }
        public string InvoicePrefix { get; set; }
        public string GL_Code { get; set; } // Income  GL account
        public string CostCenter { get; set; }
        public string ProfitCenter { get; set; }
    }

    class cTaxGL
    {
        public int TaxID { get; set; }
        public int CompanyID { get; set; }
        public string TaxCode { get; set; }
        public string GL_Code { get; set; }
    }

    class cLineItem
    {
        public int StdOrder { get; set; }
        public int CompanyID { get; set; }
        public int SubInvTypeID { get; set; }
        public string SubInvTypeName { get; set; }
        public string CustomerLineItem { get; set; }
        public string GLLineItem { get; set; }

    }
}