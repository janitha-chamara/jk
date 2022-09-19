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
using System.Net;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using RestClient;
//using  RestSharp;
//using RestSharp.Authenticators;
using System.IO;

namespace MMS
{
    public partial class xSAP_Process : DevExpress.XtraEditors.XtraForm
    {
        //AHPL_DBEntities context = new AHPL_DBEntities();
        List<cSAP_Upload> SAPUPloadList = new List<cSAP_Upload>();
        public xSAP_Process()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
               

                if (string.IsNullOrEmpty(this.lookCompany.Text.ToString()) || string.IsNullOrEmpty(this.lookLocation.Text.ToString()) || string.IsNullOrEmpty(this.dateFromPosting.Text.ToString()) || string.IsNullOrEmpty(this.dateToPosting.Text.ToString()) || string.IsNullOrEmpty(this.lookUpEditInvType.Text.ToString()))
                { return; }


                MMS.CustomClasses.cPermission.IsCreate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);
                //if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
                
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    //location wise security check - only for sap process 
                    var qryUserLoc = (from ul in context.UserLocations
                                      where ul.UserID == MMS.CustomClasses.cCommon_Functions.LoggedUserID
                                      select new { ul.LocationID }).ToList();
                    List<int> locList = new List<int>();
                    foreach (var qry in qryUserLoc)
                    {
                        locList.Add(qry.LocationID);
                    }

                    int locid = int.Parse(this.lookLocation.EditValue.ToString());

                    if (!locList.Contains(locid))
                    {
                        throw new Exception( "Hey..." + System.Environment.NewLine + "You dont have permission to generate sap documents at the selected location.");
                    }
                    // --


                    //bool validated = validateField();

                    if (splashScreenManager2.IsSplashFormVisible == false)
                    {
                        splashScreenManager2.ShowWaitForm();
                        splashScreenManager2.SetWaitFormDescription("Generating SAP Upload Doc");
                    }

                    // invoice type
                    int invoiceTypeId = 0;
                    bool res = false;
                    res = int.TryParse(lookUpEditInvType.EditValue.ToString(), out invoiceTypeId);
                    if (res == false) { invoiceTypeId = 0; }
                    if (invoiceTypeId == 0) { return; }
                    //--

                    // sub invoice type
                    int subinvoicetype = 0;
                    res  = int.TryParse(lookSubInvTypeID.EditValue.ToString(),out subinvoicetype);
                    if (res==false) { subinvoicetype =0;}

                    int otherServiceID = 0; int utilityid = 0;
                    
                    //other service id 
                    if (!string.IsNullOrEmpty(this.lookUType.Text.ToString()))
                    {
                        res = int.TryParse(this.lookUType.EditValue.ToString(), out otherServiceID);
                        if (res == false) { otherServiceID = 0; }


                        // utility id 
                        res = int.TryParse(this.lookUType.EditValue.ToString(), out utilityid);
                        if (res == false) { utilityid = 0; }
                    }


                    //--

                    // company 
                    int compid = 0;
                    res = int.TryParse(this.lookCompany.EditValue.ToString(), out compid);
                    if (res == false) { compid = 0; return; }

                    // validating sap posting from date
                    DateTime fromPostingDate;
                    res = DateTime.TryParse(this.dateFromPosting.DateTime.ToString(), out fromPostingDate);
                    if (fromPostingDate == DateTime.MinValue)
                    {
                        dxErrorProvider1.SetError(this.dateFromPosting, "Invalid Date");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.dateFromPosting, ""); }

                    // validating sap posting to date
                    DateTime topostingDate;
                    res = DateTime.TryParse(this.dateToPosting.DateTime.ToString(), out topostingDate);
                    if (res == false) { topostingDate = DateTime.MinValue; }
                    if (topostingDate == DateTime.MinValue)
                    {
                        dxErrorProvider1.SetError(this.dateToPosting, "Invalid Date");
                        return;
                    }
                    else { dxErrorProvider1.SetError(this.dateToPosting, ""); }





                    if (res == false) { fromPostingDate = DateTime.Now.Date; }


                    
                    // Document Type List
                    IQueryable<SAP_DocTypes> sapDocTypeList = (from s in context.SAP_DocTypes
                                                               select s).AsQueryable();
                    //--

                    IQueryable<Invoice> invoiceList = (from i in context.Invoices
                                                       select i).AsQueryable();

                    #region rentInvoice
                    if (invoiceTypeId == 1 && subinvoicetype == 3) // Invoice
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.CompanyID == compid && i.InvoiceTypeID == 1 && i.SubInvTypeID == 3 && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                    }

                    if (invoiceTypeId == 1 && subinvoicetype == 1) // Adjustment
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.CompanyID == compid && i.InvoiceTypeID == 1 && i.SubInvTypeID == 1 && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                    }

                    if (invoiceTypeId == 1 && subinvoicetype == 2) // Credit Note
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.CompanyID == compid && i.InvoiceTypeID == 1 && i.SubInvTypeID == 2 && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                        //foreach (var qry in invoiceList)
                        //{
                        //    qry.RentPerMonth = qry.RentPerMonth * -1;

                        //}

                    }

                    #endregion

                    #region UtilityInvoice
                    if (invoiceTypeId == 2 && subinvoicetype == 3) // Invoice
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.IsMaintenance == false && i.CompanyID == compid && i.InvoiceTypeID == 2 && i.SubInvTypeID == 3 && i.UtilityID == utilityid && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                    }

                    if (invoiceTypeId == 2 && subinvoicetype == 1) // Adjustment
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.IsMaintenance == false && i.CompanyID == compid && i.InvoiceTypeID == 2 && i.SubInvTypeID == 1 && i.UtilityID == utilityid && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                    }

                    if (invoiceTypeId == 2 && subinvoicetype == 2) // Credit Note
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.IsMaintenance == false && i.CompanyID == compid && i.InvoiceTypeID == 2 && i.SubInvTypeID == 2 && i.UtilityID == utilityid && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                        //foreach (var qry in invoiceList)
                        //{
                        //    qry.RentPerMonth = qry.RentPerMonth * -1;

                        //}
                    }



                    #endregion

                    #region OtherServiceInvoice
                    if (invoiceTypeId == 3 && subinvoicetype == 3) // Invoice
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.CompanyID == compid && i.InvoiceTypeID == 3 && i.SubInvTypeID == 3 && i.OtherServiceID == otherServiceID && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                    }

                    if (invoiceTypeId == 3 && subinvoicetype == 1) // Adjustment
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.CompanyID == compid && i.InvoiceTypeID == 3 && i.SubInvTypeID == 1 && i.OtherServiceID == otherServiceID && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                    }

                    if (invoiceTypeId == 3 && subinvoicetype == 2) // Credit Note
                    {
                        invoiceList = (from i in context.Invoices
                                       where i.IsConfirmed == true && i.CompanyID == compid && i.InvoiceTypeID == 3 && i.SubInvTypeID == 2 && i.OtherServiceID == otherServiceID && i.SAP_PstnDateInDoc >= fromPostingDate && i.SAP_PstnDateInDoc <= topostingDate && i.Is_SAPUploaded == false
                                       select i).AsQueryable();
                        //foreach (var qry in invoiceList)
                        //{
                        //    qry.RentPerMonth = qry.RentPerMonth * -1;

                        //}
                    }


                    #endregion

                    //
 
                    // Rent Adjustment 


                    // Rent Credit Note


                    SAPUPloadList.Clear();



                    foreach (var qry in invoiceList)
                    {
                        decimal customerAmount = 0;
                        decimal incomeAmount = 0;
                        decimal glAmount = 0;                      

                        //// CUSTOMER ENTRY
                        cSAP_Upload _sap = new cSAP_Upload();
                        _sap.InvoiceID = qry.InvoiceID;
                        _sap.RefDocNo = qry.InvoiceNo;
                        
                        _sap.CompanyCode = getSAPCompanyCode(qry.CompanyID);
                        _sap.CurrKey = "LKR";                        
                        _sap.PostingDate = getSapPostingDate(qry.InvoiceID);
                        _sap.DocDate = _sap.PostingDate;
                        _sap.GLaccDesc = "CUSTOMER"; // acc description                    //

                        if (qry.SAP_DocHeaderText.Trim().Length > 25)
                        {
                            _sap.DocHeaderText = qry.SAP_DocHeaderText.Substring(0, 25).Trim();
                        }
                        else
                        {
                            _sap.DocHeaderText = qry.SAP_DocHeaderText.Trim();
                        }
                        _sap.DocType = qry.SAP_DocType;
                        _sap.PostingKey = getCustLineItem(qry.InvoiceTypeID, qry.SubInvTypeID, qry.CompanyID); // Customer Line Item
                        _sap.CustomerCode_GLAccount = SAP_CustomerCode(qry.ExtendedCustomerID);  //get SAP Customer Code from Global Customer 
                        _sap.IsCustomerEntry = true;
                        _sap.IsGLEntriy = false;

                        /// Amount
                       

                        _sap.AmtInDocCur = Math.Round(qry.TotalRentPerMonth, 2);
                        //if (qry.SubInvTypeID == 2)
                        //{ _sap.AmtInDocCur = _sap.AmtInDocCur * -1; }

                        _sap.CusomterAmount = _sap.AmtInDocCur;
                        customerAmount = _sap.AmtInDocCur;

                        _sap.Assignment = qry.SAP_Assignment;
                        _sap.Text = qry.SAP_Text.Trim();
                        if (_sap.Text.Trim().Length > 50)
                        {
                            _sap.Text = _sap.Text.Substring(0, 50).Trim();
                        }
                        _sap.BusinessArea = getBusinessArea(qry.CompanyID);
                        _sap.CostCenter = getCostCenter(qry.CompanyID, qry.InvoiceTypeID, qry.UtilityID);
                        _sap.InternalOrder = "";
                        _sap.ProfitCenter = "";
                        //ref key 1
                        if (qry.SAP_RefKey1.ToString().Trim().Length > 12)
                        {
                            _sap.RefKey1 = qry.SAP_RefKey1.Substring(0, 12).Trim() ;
                        }
                        else
                        {
                            _sap.RefKey1 = qry.SAP_RefKey1.Trim();
                        }

                        //ref key 2
                        if (qry.SAP_RefKey2.ToString().Trim().Length > 12)
                        {
                            _sap.RefKey2 = qry.SAP_RefKey2.Substring(0, 12).Trim();
                        }
                        else
                        {
                            _sap.RefKey2 = qry.SAP_RefKey2.Trim();
                        }

                        // refkey 3

                        if (qry.SAP_RefKey3.ToString().Trim().Length > 20)
                        {
                            _sap.RefKey3 = qry.SAP_RefKey3.Substring(0, 20).Trim();
                        }
                        else
                        {
                            _sap.RefKey3 = qry.SAP_RefKey3.Trim();
                        }
                        SAPUPloadList.Add(_sap);
                        splashScreenManager2.SetWaitFormDescription(_sap.RefDocNo);
                        //----

                        // INCOME ACCOUNT ENTRY 
                        _sap = new cSAP_Upload();

                        // default entries 
                        _sap.InvoiceID = qry.InvoiceID;
                        _sap.RefDocNo = qry.InvoiceNo;
                        _sap.CompanyCode = getSAPCompanyCode(qry.CompanyID); // getting SAP company code
                        _sap.CurrKey = "LKR";                      
                        _sap.PostingDate = getSapPostingDate(qry.InvoiceID); // SAP posting Date
                        _sap.DocDate = _sap.PostingDate;  // Sap Posting Date = Doc Date
                        if (qry.SAP_DocHeaderText.Trim().Length > 25)
                        {
                            _sap.DocHeaderText = qry.SAP_DocHeaderText.Substring(0, 25).Trim();
                        }
                        else
                        {
                            _sap.DocHeaderText = qry.SAP_DocHeaderText.Trim();
                        }

                        _sap.DocType = qry.SAP_DocType;
                        _sap.PostingKey = getGLLineItem(qry.SubInvTypeID, qry.CompanyID);   // get GL Line Item 
                        _sap.IsGLEntriy = true; _sap.IsCustomerEntry = false;
                        _sap.Assignment = qry.SAP_Assignment;
                        _sap.Text = qry.SAP_Text;
                        if (_sap.Text.Trim().Length > 50)
                        {
                            _sap.Text = _sap.Text.Substring(0, 50).Trim();
                        }
                        _sap.BusinessArea = getBusinessArea(qry.CompanyID);
                        _sap.CostCenter = getCostCenter(qry.CompanyID, qry.InvoiceTypeID, qry.UtilityID);
                        _sap.InternalOrder = "";
                        _sap.ProfitCenter = "";
                        //ref key 1
                        if (qry.SAP_RefKey1.ToString().Trim().Length > 12)
                        {
                            _sap.RefKey1 = qry.SAP_RefKey1.Substring(0, 12).Trim();
                        }
                        else
                        {
                            _sap.RefKey1 = qry.SAP_RefKey1.Trim();
                        }

                        //ref key 2
                        if (qry.SAP_RefKey2.ToString().Trim().Length > 12)
                        {
                            _sap.RefKey2 = qry.SAP_RefKey2.Substring(0, 12).Trim();
                        }
                        else
                        {
                            _sap.RefKey2 = qry.SAP_RefKey2.Trim();
                        }

                        // refkey 3

                        if (qry.SAP_RefKey3.ToString().Trim().Length > 20)
                        {
                            _sap.RefKey3 = qry.SAP_RefKey3.Substring(0, 20).Trim();
                        }
                        else
                        {
                            _sap.RefKey3 = qry.SAP_RefKey3.Trim();
                        }
                        //
                       
                        _sap.CustomerCode_GLAccount = getGLAcc(qry.CompanyID, qry.SAP_DocType, qry.InvoiceTypeID, qry.UtilityID,qry.OtherServiceID); // Income Account
                        _sap.GLaccDesc = "INCOME"; // acc description
                        /// Amount

                        if (qry.InvoiceTypeID == 1) // Rent
                        { _sap.AmtInDocCur = Math.Round(qry.RentWithSCPerMonth, 2); }
                        if (qry.InvoiceTypeID == 2 || qry.InvoiceTypeID == 3) // Utility
                        { _sap.AmtInDocCur = Math.Round(qry.RentPerMonth ,2); }

                       
                         _sap.AmtInDocCur = _sap.AmtInDocCur * -1;
                        

                        incomeAmount = _sap.AmtInDocCur;

                        SAPUPloadList.Add(_sap);
                        splashScreenManager2.SetWaitFormDescription(_sap.RefDocNo);

                        // Other Expense (VAT, NBT) GL Account Entries
                        foreach (var qryD in qry.Invoice_Details)
                        {
                            if (qryD.Amount != 0)
                            {
                                _sap = new cSAP_Upload();
                                _sap.RefDocNo = qry.InvoiceNo;
                                _sap.InvoiceID = qry.InvoiceID;
                                _sap.InvDetID = qryD.InvoiceDetailID;
                                //--
                                _sap.CompanyCode = getSAPCompanyCode(qry.CompanyID);
                                _sap.CurrKey = "LKR";
                                _sap.PostingDate = getSapPostingDate(qry.InvoiceID); // SAP posting Date
                                _sap.DocDate = _sap.PostingDate;  // Sap Posting Date = Doc Date

                                if (qry.SAP_DocHeaderText.Trim().Length > 25)
                                {
                                    _sap.DocHeaderText = qry.SAP_DocHeaderText.Substring(0, 25).Trim();
                                }
                                else
                                {
                                    _sap.DocHeaderText = qry.SAP_DocHeaderText.Trim();
                                }
                                _sap.DocType = qry.SAP_DocType;
                                _sap.Assignment = qry.SAP_Assignment;
                                _sap.Text = qry.SAP_Text;
                                if (_sap.Text.Trim().Length > 50)
                                {
                                    _sap.Text = _sap.Text.Substring(0, 50).Trim();
                                }
                                _sap.BusinessArea = getBusinessArea(qry.CompanyID);
                                //_sap.CostCenter = getCostCenter(qry.CompanyID, qry.InvoiceTypeID, qry.UtilityID);
                                _sap.InternalOrder = "";
                                _sap.ProfitCenter = "";
                                //ref key 1
                                if (qry.SAP_RefKey1.ToString().Trim().Length > 12)
                                {
                                    _sap.RefKey1 = qry.SAP_RefKey1.Substring(0, 12).Trim();
                                }
                                else
                                {
                                    _sap.RefKey1 = qry.SAP_RefKey1.Trim();
                                }

                                //ref key 2
                                if (qry.SAP_RefKey2.ToString().Trim().Length > 12)
                                {
                                    _sap.RefKey2 = qry.SAP_RefKey2.Substring(0, 12).Trim();
                                }
                                else
                                {
                                    _sap.RefKey2 = qry.SAP_RefKey2.Trim();
                                }

                                // refkey 3

                                if (qry.SAP_RefKey3.ToString().Trim().Length > 20)
                                {
                                    _sap.RefKey3 = qry.SAP_RefKey3.Substring(0, 20).Trim();
                                }
                                else
                                {
                                    _sap.RefKey3 = qry.SAP_RefKey3.Trim();
                                }
                                //--
                                ////if (qry.SubInvTypeID == 2)
                                //{
                                //    qryD.Amount = qryD.Amount - 1;
                                //}

                                // GL Account Entries
                                _sap.CustomerCode_GLAccount = getGLAccTax(qry.CompanyID, qryD.TaxID);
                                _sap.IsGLEntriy = true; _sap.IsCustomerEntry = false;
                                _sap.PostingKey = getGLLineItem(qry.SubInvTypeID, qry.CompanyID);
                                _sap.GLaccDesc = qryD.TaxCode.ToUpper(); // acc description
                                _sap.AmtInDocCur = Math.Round(qryD.Amount, 2);
                                //if (qry.SubInvTypeID != 2)
                                {
                                    _sap.AmtInDocCur = _sap.AmtInDocCur * -1;
                                }
                                SAPUPloadList.Add(_sap);
                                splashScreenManager2.SetWaitFormDescription(_sap.RefDocNo);
                            }
                        }

                        glAmount = qry.Invoice_Details.Sum(x => x.Amount);
                        glAmount = glAmount * -1;
                        glAmount = Math.Round(glAmount, 2);
                        decimal differenceAmount = customerAmount + incomeAmount + glAmount;
                        //differenceAmount = Math.Round(differenceAmount, 2);
                        //if (differenceAmount > 0 || differenceAmount < 0 ) 
                        //{
                        //    AdjustCusomterAmount(differenceAmount, _sap.RefDocNo, SAPUPloadList);
                        //}

                    }


                    this.cSAP_UploadBindingSource.DataSource = SAPUPloadList;
                    this.cSAP_UploadGridControl.RefreshDataSource();
                    this.gridView1.BestFitColumns();
                    if (splashScreenManager2.IsSplashFormVisible == true)
                    {
                        splashScreenManager2.CloseWaitForm();
                    }
                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true)
                {
                    splashScreenManager2.CloseWaitForm();
                }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AdjustCusomterAmount(decimal differenceAmount, string pRefDocNo, List<cSAP_Upload> SAPUPloadList)
        {
            var qryAdjust = (from c in SAPUPloadList
                             where c.RefDocNo == pRefDocNo && c.GLaccDesc == "INCOME"
                             select c).FirstOrDefault();
            decimal amountinDocCur = qryAdjust.AmtInDocCur;

            qryAdjust.AmtInDocCur = amountinDocCur - differenceAmount;

        }

        private DateTime getSapPostingDate(int pInvoiceID)
        {
            DateTime postingDate = DateTime.Now.Date;

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryPostingDate = (from i in context.Invoices
                                      where i.InvoiceID == pInvoiceID
                                      select new { i.SAP_PstnDateInDoc }).FirstOrDefault();
                if (qryPostingDate != null)
                {
                    postingDate = qryPostingDate.SAP_PstnDateInDoc.Value;
                }

            }


            return postingDate;
          
        }

        private string getBusinessArea(int pCompanyID)
        {
            string busienssArea = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryComp = (from c in context.Companies
                               where c.CompanyID == pCompanyID
                               select new { c.SAP_BusinessArea }).FirstOrDefault();
                if (qryComp != null)
                {
                    busienssArea = qryComp.SAP_BusinessArea;
                }
            }
            return busienssArea;
        }

        private string getCostCenter(int pCompanyID, int pInvoiceTypeID, int pUtilityID)
        {
            string costCenter = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                IQueryable<SAP_DocTypes> sapDocTypes = context.SAP_DocTypes;
                if (pUtilityID > 0)
                {
                    var qrySapDT = (from dt in context.SAP_DocTypes
                                    where dt.CompanyID == pCompanyID && dt.InvoiceTypeID == pInvoiceTypeID && dt.DocID == pUtilityID
                                    select dt).FirstOrDefault();
                    if (qrySapDT != null)
                    {
                        costCenter = qrySapDT.COST_CENTER;
                    }
                }
                else
                {
                    var qrySapDT = (from dt in context.SAP_DocTypes
                                    where dt.CompanyID == pCompanyID && dt.InvoiceTypeID == pInvoiceTypeID
                                    select dt).FirstOrDefault();
                    if (qrySapDT != null)
                    {
                        costCenter = qrySapDT.COST_CENTER;
                    }

                }


            }

            return costCenter;
        }

        private string getSAPCompanyCode(int pCompanyID)
        {
            string _code = "";

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryComp = (from c in context.Companies
                               where c.CompanyID == pCompanyID
                               select new { c.SA_CompanyCode }).FirstOrDefault();
                if (qryComp != null)
                {
                    _code = qryComp.SA_CompanyCode;
                }
            }



            return _code;



        }

        private string getGLLineItem(int pSubInvTypeID, int pCompID)
        {
            string _code = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (pSubInvTypeID == 1)
                { pSubInvTypeID = 3; }

                var qryLT = (from lt in context.SAP_LineItems
                             where lt.CompanyID == pCompID && lt.SubInvTypeID == pSubInvTypeID
                             select new { lt.GL_LineItem }).FirstOrDefault();
                if (qryLT != null)
                {
                    _code = qryLT.GL_LineItem;
                }
            }

            return _code;
        }

        private string getCustLineItem(int pInvoiceTypeid, int pSubInvTypeID, int pCompID)
        {
            string _code = "";
            if (pSubInvTypeID == 1)
            { pSubInvTypeID = 3; }

            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryLT = (from lt in context.SAP_LineItems
                             where lt.CompanyID == pCompID && lt.SubInvTypeID == pSubInvTypeID
                             select new { lt.Customer_LineItem }).FirstOrDefault();
                if (qryLT != null)
                {
                    _code = qryLT.Customer_LineItem;
                }
            }
                         

            return _code;
        }

        private string getGLAccTax(int pCompanyID, int pTaxID)
        {
            string glTaxCode = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryGLAcc = (from glt in context.SAP_TAXGLCODES
                                where glt.CompanyID == pCompanyID && glt.TaxID == pTaxID
                                select new { glt.SAP_GLCode }).FirstOrDefault();
                if (qryGLAcc != null)
                {
                    glTaxCode = qryGLAcc.SAP_GLCode;
                }
                string formatedString = glTaxCode.PadLeft(10, '0');
                glTaxCode = formatedString;
            }

            return glTaxCode;
        }

        private string getGLAcc(int pCompanyID, string pDocType, int pInvoiceTypeID = 0,int pUtilityID=0,int pOtherServiceID = 0)
        {
            string glAccount = "";
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (pInvoiceTypeID == 1) /// rent
                {
                    var qryDT = (from dt in context.SAP_DocTypes
                                 where dt.DOCTYPE == pDocType && dt.CompanyID == pCompanyID && dt.InvoiceTypeID == pInvoiceTypeID
                                 select new { dt.GL_CODE }).FirstOrDefault();
                    if (qryDT != null)
                    {

                        glAccount = qryDT.GL_CODE;
                    }
                }
                if (pInvoiceTypeID == 2) // utility
                {
                    var qryDT = (from dt in context.SAP_DocTypes
                                 where dt.DOCTYPE == pDocType && dt.CompanyID == pCompanyID && dt.InvoiceTypeID == pInvoiceTypeID && dt.DocID == pUtilityID
                                 select new { dt.GL_CODE }).FirstOrDefault();
                    if (qryDT != null)
                    {

                        glAccount = qryDT.GL_CODE;
                    }
                }

                if (pInvoiceTypeID == 3) // Other Services 
                {
                    var qryDT = (from dt in context.SAP_DocTypes
                                 where dt.DOCTYPE == pDocType && dt.CompanyID == pCompanyID && dt.InvoiceTypeID == pInvoiceTypeID && dt.DocID == pOtherServiceID
                                 select new { dt.GL_CODE }).FirstOrDefault();
                    if (qryDT != null)
                    {

                        glAccount = qryDT.GL_CODE;
                    }


                }

                string formatedString = glAccount.PadLeft(10, '0');
                glAccount = formatedString;

            }

            return glAccount;
        }

        private string SAP_CustomerCode(int pExtendedCustomerID)
        {
            string SAP_CustomerCode = "";

            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryCust = (from ec in context.Extended_Customers
                                   join gc in context.Global_Customers on ec.CustomerID equals gc.CustomerID
                                   where ec.ExtendedCustomerID == pExtendedCustomerID
                                   select new { ec.SAPAlternateCode,gc.CustomerName }).FirstOrDefault();
                    if (qryCust != null)
                    {
                        if (string.IsNullOrEmpty(qryCust.SAPAlternateCode))
                        {
                            throw new Exception("SAP Customer Code is not defined For " + qryCust.CustomerName.ToString());
                        }

                        SAP_CustomerCode = qryCust.SAPAlternateCode;
                    }

                    bool res = false;
                    int startingChar =  0;
                    res = int.TryParse(SAP_CustomerCode.Substring(0, 1), out startingChar);
                    if (res == false) { startingChar = 0; }

                    string formatedString = "";
                    if (startingChar > 0)
                    {
                        formatedString = SAP_CustomerCode.Trim().PadLeft(10, '0');
                    }
                    else
                    {
                        formatedString = SAP_CustomerCode.ToString();
                    }

                    SAP_CustomerCode = formatedString;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return SAP_CustomerCode;
        }

        private bool validateField()
        {
            throw new NotImplementedException();
        }

        private void xSAP_Upload_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void load_data()
        {
            // company 
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryComp = (from c in context.Companies
                               select new { c.CompanyID, c.CompanyCode,c.CompanyName }).ToList();
                this.lookCompany.Properties.DataSource = qryComp;
                this.lookCompany.Properties.DisplayMember = "CompanyCode";
                this.lookCompany.Properties.ValueMember = "CompanyID";
                //

                //location
                var qryLoc = (from l in context.Locations
                              select new { l.LocationID, l.LocationCode }).ToList();
                this.lookLocation.Properties.DataSource = qryLoc;
                this.lookLocation.Properties.DisplayMember = "LocationCode";
                this.lookLocation.Properties.ValueMember = "LocationID";

                // Invoice Type 
                var qryInvType = (from it in context.Invoice_Types
                                  select new { it.InvoiceTypeID, it.InvoiceTypeName }).ToList();
                lookUpEditInvType.Properties.DataSource = qryInvType;
                lookUpEditInvType.Properties.DisplayMember = "InvoiceTypeName";
                lookUpEditInvType.Properties.ValueMember = "InvoiceTypeID";
                //-- 



                //// Sub Invoice types 
                var qrySubInvType = (from si in context.Sub_Invoice_Types                                     
                                     select new { si.SubInvTypeID, si.SubInvTypeName }).ToList();
                this.lookSubInvTypeID.Properties.DataSource = qrySubInvType;
                this.lookSubInvTypeID.Properties.DisplayMember = "SubInvTypeName";
                this.lookSubInvTypeID.Properties.ValueMember = "SubInvTypeID";
               //---

                this.dateEditCurDate.DateTime = DateTime.Now.Date;
              

                this.cSAP_UploadBindingSource.DataSource = SAPUPloadList;
            }
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void chkUType_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void lookUpEditInvType_EditValueChanged(object sender, EventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                if (string.IsNullOrEmpty(this.lookUpEditInvType.Text.ToString()))
                { return; }

                bool res = false;
                int invtypeid = 0;
                res = int.TryParse(this.lookUpEditInvType.EditValue.ToString(), out invtypeid);
                if (res == false) { invtypeid = 0; }
                if (invtypeid == 0) { return; }

                if (invtypeid == 1)
                {
                   
                    this.lblUType.Visible = false;
                    this.lookUType.Visible = false;

                }


                if (invtypeid == 2) // utility invoice
                {
                    var qryUType = (from ut in context.Utilities
                                    select new { ut.UtilityID, ut.UtilityName }).ToList();
                    this.lookUType.Properties.DataSource = qryUType;
                    this.lookUType.Properties.Columns["OtherServiceID"].Visible = false;
                    this.lookUType.Properties.Columns["OtherServiceName"].Visible = false;
                    this.lookUType.Properties.Columns["UtilityID"].Visible = false;
                    this.lookUType.Properties.Columns["UtilityName"].Visible = true;


                    this.lookUType.Properties.DisplayMember = "UtilityName";
                    this.lookUType.Properties.ValueMember = "UtilityID";


                    this.lblUType.Text = "Utility Type:";
                    this.lblUType.Visible = true;
                    this.lookUType.Visible = true;
                }
                else if (invtypeid == 3) // other service invoice type
                {
                    var qryOS = (from os in context.OtherServiceCategories
                                 select new { os.OtherServiceID, os.OtherServiceName }).ToList();
                    this.lookUType.Properties.DataSource = qryOS;
                    this.lookUType.Properties.Columns["UtilityID"].Visible = false;
                    this.lookUType.Properties.Columns["UtilityName"].Visible = false;
                    this.lookUType.Properties.Columns["OtherServiceID"].Visible = false;
                    this.lookUType.Properties.Columns["OtherServiceName"].Visible = true;


                    this.lookUType.Properties.DisplayMember = "OtherServiceName";
                    this.lookUType.Properties.ValueMember = "OtherServiceID";

                    this.lblUType.Text = "Other Service Type:";
                    this.lblUType.Visible = true;
                    this.lookUType.Visible = true;


                }
                else
                {
                    this.lookUType.Visible = false;
                    this.lblUType.Visible = false;

                }

            }


        }


        private async void   btnUpload_Click(object sender, EventArgs e)
        {
            //async
            try
            {

                MMS.CustomClasses.cPermission.IsUpdate(MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.Name);

                this.cSAP_UploadBindingSource.EndEdit();

                decimal total = (from s in SAPUPloadList
                                 select new { s.AmtInDocCur }).Sum(x => x.AmtInDocCur);
                if (total != 0)
                {
                    MessageBox.Show("Balance is not 0, please Auto Balance", "Balance is not 0 - Sap Upload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                DialogResult dlg = MessageBox.Show("Are you sure, do you want to upload to the Server", "Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No)
                { return; }

                bool res = false;


                // sap setting 
                int compid = 0;
                res = int.TryParse(lookCompany.EditValue.ToString(), out compid);
                if (res == false) { compid = 0; }
                if (compid == 0) { dxErrorProvider1.SetError(lookCompany, "Invalid Company"); return; }
                else { dxErrorProvider1.SetError(lookCompany, ""); }

                int locid = 0;
                res = int.TryParse(lookLocation.EditValue.ToString(), out locid);
                if (res == false) { locid = 0; }
                if (locid == 0) { dxErrorProvider1.SetError(lookLocation, "Invalid Location"); return; }

                string sapUrl = "";
                string sapUserName = "";
                string sapPassword = "";
                bool IsR3 = false;
                bool IsISR = false;
                //if (splashScreenManager2.IsSplashFormVisible == false) { splashScreenManager2.ShowWaitForm(); splashScreenManager2.SetWaitFormDescription("Connecting......"); }
                //bool chkConn = MMS.CustomClasses.cCommon_Functions.ChekConnection();
                //if (splashScreenManager2.IsSplashFormVisible == true) { splashScreenManager2.CloseWaitForm(); }
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    //sap url / isr / r3
                    var qryComp = (from c in context.Companies
                                   where c.CompanyID == compid
                                   select c).FirstOrDefault();
                    if (qryComp != null)
                    {
                        sapUrl = qryComp.SAP_URL;
                        IsISR = qryComp.SAP_ISR;
                        IsR3 = qryComp.SAP_R3;
                    }

                    // sap user name/password
                    var qryUser = (from u in context.Permission_Users
                                   where u.UserID == MMS.CustomClasses.cCommon_Functions.LoggedUserID
                                   select u).FirstOrDefault();
                    if (qryUser != null)
                    {
                        if (IsISR == true)
                        {
                            sapUserName = qryUser.ISR_UserName;
                            sapPassword = qryUser.ISR_Password;
                        }

                        if (IsR3 == true)
                        {
                            sapUserName = qryUser.R3_UserName;
                            sapPassword = qryUser.R3_Password;
                        }
                    }


                }


                if (splashScreenManager2.IsSplashFormVisible == false)
                {
                    splashScreenManager2.ShowWaitForm();
                    splashScreenManager2.SetWaitFormDescription("Uploading Data...");

                }

                var qrySelected = (from s in SAPUPloadList
                                   where s.IsSelected == true
                                   select s).ToList();

                if (qrySelected.Count == 0) { splashScreenManager2.CloseWaitForm(); MessageBox.Show("Please Select 1 or more  documents to upload", "Document(s) notSelected", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


                var qrySAP = (from s in qrySelected
                              group s by s.RefDocNo into g
                              select new { RefDocNo = g.Key, itemList = g }).ToList();

                foreach (var qryItem in qrySAP)
                {
                    // header
                    var qryHeader = qryItem.itemList.FirstOrDefault();

                    // SAP R3 
                    #region SAP_R3
                    if (IsR3 == true)
                    {


                        R3.ZBAPI_ACC_DOCUMENT_POST _request = new R3.ZBAPI_ACC_DOCUMENT_POST();


                        MMS.R3.ZbapiAccDocumentPostResponse _response = new MMS.R3.ZbapiAccDocumentPostResponse();


                        MMS.R3.ZbapiAccDocumentPost _payload = new MMS.R3.ZbapiAccDocumentPost();

                        ICredentials cred;
                        NetworkCredential ncred = new NetworkCredential();
                        ncred.UserName = sapUserName;   // "PROPERTY_RFC";
                        ncred.Password = sapPassword;   //"pass1word#";
                        cred = ncred;
                        _request.Credentials = cred;
                        _request.Url = sapUrl;
                        _request.Proxy = System.Net.WebRequest.GetSystemWebProxy();


                        MMS.R3.Bapiache09 _Header = new MMS.R3.Bapiache09();
                        _Header.BusAct = "RFBU";
                        _Header.Username = "PROPERTY_RFC";
                        _Header.HeaderTxt = qryHeader.DocHeaderText;
                        _Header.CompCode = qryHeader.CompanyCode;

                        _Header.DocDate = qryHeader.DocDate.ToString("yyyy-MM-dd");
                        _Header.PstngDate = qryHeader.PostingDate.ToString("yyyy-MM-dd");
                        _Header.DocType = qryHeader.DocType;
                        _Header.RefDocNo = qryHeader.RefDocNo;


                        var qrySAPItemDetail = (from s in SAPUPloadList
                                                where s.RefDocNo == qryItem.RefDocNo
                                                select s).ToList();
                        int recordCount = qrySAPItemDetail.Count;
                        int count = 0;
                        MMS.R3.Bapiacgl09[] _AccountGL = new MMS.R3.Bapiacgl09[recordCount];
                        MMS.R3.Bapiacar09[] _AccountReceivable = new MMS.R3.Bapiacar09[recordCount];
                        MMS.R3.Bapiaccr09[] _CurrencyAmount = new MMS.R3.Bapiaccr09[recordCount];
                        foreach (var item in qrySAPItemDetail)
                        {

                            if (item.IsCustomerEntry == true)
                            {
                                // Customer entrry
                                MMS.R3.Bapiacar09 _itemCust = new MMS.R3.Bapiacar09();
                                _itemCust = new MMS.R3.Bapiacar09();
                                _itemCust.ItemnoAcc = (count + 1).ToString();
                                _itemCust.Customer = item.CustomerCode_GLAccount;
                                if (_itemCust.Customer.Substring(0, 1).Trim() == "C")
                                {
                                    _itemCust.SpGlInd = "X";
                                }
                                _itemCust.RefKey1 = item.RefKey1;
                                _itemCust.RefKey2 = item.RefKey2;
                                _itemCust.RefKey3 = item.RefKey3;
                                _itemCust.BusArea = item.BusinessArea.ToString(); ;
                                _itemCust.TaxCode = "";
                                _itemCust.AllocNmbr = item.Assignment;
                                _itemCust.ItemText = item.Text;
                                _AccountReceivable[count] = _itemCust;
                            }
                            else // GL entries 
                            {
                                MMS.R3.Bapiacgl09 _itemGL = new MMS.R3.Bapiacgl09();
                                _itemGL = new MMS.R3.Bapiacgl09();
                                _itemGL.ItemnoAcc = (count + 1).ToString();
                                _itemGL.GlAccount = item.CustomerCode_GLAccount;
                                _itemGL.RefKey1 = item.RefKey1;
                                _itemGL.RefKey2 = item.RefKey2;
                                _itemGL.RefKey3 = item.RefKey3;
                                _itemGL.BusArea = item.BusinessArea.ToString(); ;
                                _itemGL.TaxCode = "";
                                _itemGL.AllocNmbr = item.Assignment;
                                _itemGL.ItemText = item.Text;
                                _itemGL.Costcenter = item.CostCenter;
                                _itemGL.ProfitCtr = item.ProfitCenter;
                                _AccountGL[count] = _itemGL;
                                //--
                            }
                            //// -- Item Currency--///-
                            MMS.R3.Bapiaccr09 _ItemCurrency = new MMS.R3.Bapiaccr09();
                            _ItemCurrency = new MMS.R3.Bapiaccr09();
                            _ItemCurrency.ItemnoAcc = (count + 1).ToString();
                            _ItemCurrency.CurrType = "00";
                            _ItemCurrency.Currency = "LKR";
                            _ItemCurrency.AmtDoccur = item.AmtInDocCur;
                            _ItemCurrency.DiscBase = item.AmtInDocCur;
                            _ItemCurrency.ExchRate = 1;
                            _CurrencyAmount[count] = _ItemCurrency;
                            count++;

                        }


                        MMS.R3.Bapiret2[] _ReturnMessage = new MMS.R3.Bapiret2[0];
                        _payload.Documentheader = _Header;
                        _payload.Accountgl = _AccountGL;
                        _payload.Accountreceivable = _AccountReceivable;
                        _payload.Currencyamount = _CurrencyAmount;
                        _payload.Return = _ReturnMessage;


                        _response = _request.ZbapiAccDocumentPost(_payload);
                        Int64 responseValue = 0;
                        res = Int64.TryParse(_response.ToString(), out responseValue);
                        if (res == false) { responseValue = 0; }


                        string msg = _response.Return[0].Message.ToString();

                        //MessageBox.Show(_response.Return[0].Message, "Response");
                        updateInvoice(_response.Return[0].Message, qryItem.RefDocNo, _response.Return[0]);

                        if (responseValue > 0)
                        {
                            updateInvoice(_response.Return[0].Message, qryItem.RefDocNo, _response.Return[0]);

                            //email alert for SAP ISR 
                            //int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.SapUpload;
                            //this.gridView1.OptionsPrint.ShowPrintExportProgress = false;
                            //MMS.CustomClasses.cCommon_Functions.AddToEmailList(compid, locid, alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.gridView1, "SAP Uploaded : R3");

                        }

                        splashScreenManager2.SetWaitFormDescription(_Header.RefDocNo);
                        qryHeader.SAPUploadMessage = _response.Return[0].Message.ToString();
                    } // if sap r3 end

                    #endregion //R3
                    #region ISR
                    // ISR upload




                    if (IsISR == true)
                    {

                        StringBuilder soaprequest = new StringBuilder();
                        soaprequest.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:sap-com:document:sap:rfc:functions\">");
                        soaprequest.Append("<soapenv:Header/>");
                        soaprequest.Append("<soapenv:Body>");
                        soaprequest.Append("<urn:ZBAPI_ACC_DOCUMENT_POST>");
                        soaprequest.Append("<CONTRACTHEADER></CONTRACTHEADER>");
                        soaprequest.Append("<CUSTOMERCPD></CUSTOMERCPD>");
                        soaprequest.Append("<DOCUMENTHEADER>");


                        MMS.ISR.ZBAPI_ACC_DOCUMENT_POST _request = new MMS.ISR.ZBAPI_ACC_DOCUMENT_POST();


                        ICredentials cred;
                        NetworkCredential ncred = new NetworkCredential();
                        ncred.UserName = sapUserName;   // "PROPERTY_RFC";
                        ncred.Password = sapPassword;   //"pass1word#";
                        cred = ncred;
                        // _request.Credentials = cred;

                        _request.Url = sapUrl;
                        _request.Proxy = System.Net.WebRequest.GetSystemWebProxy();
                        _request.Timeout = 25000;


                        MMS.ISR.Bapiacgl09[] Accountgl;
                        MMS.ISR.Bapiacap09[] Accountpayable = new MMS.ISR.Bapiacap09[0];
                        MMS.ISR.Bapiacar09[] Accountreceivable;
                        MMS.ISR.Bapiactx09[] Accounttax = new MMS.ISR.Bapiactx09[0];
                        MMS.ISR.Bapiacwt09[] Accountwt = new MMS.ISR.Bapiacwt09[0];
                        MMS.ISR.Bapiaccahd Contractheader = new MMS.ISR.Bapiaccahd();
                        MMS.ISR.Bapiaccait[] Contractitem = new MMS.ISR.Bapiaccait[0];
                        MMS.ISR.Bapiackec9[] Criteria = new MMS.ISR.Bapiackec9[0];
                        MMS.ISR.Bapiaccr09[] Currencyamount;
                        MMS.ISR.Bapiacpa09 Customercpd = new MMS.ISR.Bapiacpa09();
                        MMS.ISR.Bapiache09 Documentheader = new MMS.ISR.Bapiache09();
                        MMS.ISR.Bapiacextc[] Extension1 = new MMS.ISR.Bapiacextc[0];
                        MMS.ISR.Bapiparex[] Extension2 = new MMS.ISR.Bapiparex[0];
                        MMS.ISR.Bapiacpc09[] Paymentcard = new MMS.ISR.Bapiacpc09[0];
                        MMS.ISR.Bapiacre09[] Realestate = new MMS.ISR.Bapiacre09[0];
                        MMS.ISR.Bapiret2[] Return = new MMS.ISR.Bapiret2[0];
                        MMS.ISR.Bapiackev9[] Valuefield = new MMS.ISR.Bapiackev9[0];
                        string _ObjSys;
                        string _ObjType;

                        Documentheader.BusAct = "RFBU";
                        Documentheader.Username = sapUserName;
                        Documentheader.HeaderTxt = qryHeader.DocHeaderText;

                        Documentheader.CompCode = qryHeader.CompanyCode;
                        Documentheader.DocDate = qryHeader.DocDate.ToString("yyyy-MM-dd");
                        Documentheader.PstngDate = qryHeader.PostingDate.ToString("yyyy-MM-dd");
                        Documentheader.DocType = qryHeader.DocType;
                        Documentheader.RefDocNo = qryHeader.RefDocNo;

                        //isr sope
                        soaprequest.Append("<BUS_ACT>RFBU</BUS_ACT>");
                        soaprequest.Append("<USERNAME>" + sapUserName + "</USERNAME>");
                        soaprequest.Append("<HEADER_TXT>" + qryHeader.DocHeaderText + "</HEADER_TXT>");
                        soaprequest.Append("<COMP_CODE>" + qryHeader.CompanyCode + "</COMP_CODE>");
                        soaprequest.Append("<DOC_DATE>" + qryHeader.DocDate.ToString("yyyy-MM-dd") + "</DOC_DATE>");
                        soaprequest.Append("<PSTNG_DATE>" + qryHeader.PostingDate.ToString("yyyy-MM-dd") + "</PSTNG_DATE>");
                        soaprequest.Append("<DOC_TYPE>" + qryHeader.DocType + "</DOC_TYPE>");
                        soaprequest.Append("<REF_DOC_NO>" + qryHeader.RefDocNo + "</REF_DOC_NO>");

                        soaprequest.Append("</DOCUMENTHEADER>");

                        var qrySAPItemDetail = (from s in SAPUPloadList
                                                where s.RefDocNo == qryItem.RefDocNo
                                                select s).ToList();
                        int recordCount = qrySAPItemDetail.Count;
                        int count = 0;

                        List<MMS.ISR.Bapiacgl09> accountGLList = new List<ISR.Bapiacgl09>();
                        List<MMS.ISR.Bapiacar09> accountReceivableList = new List<ISR.Bapiacar09>();
                        List<MMS.ISR.Bapiaccr09> currencyAmountList = new List<ISR.Bapiaccr09>();


                        foreach (var item in qrySAPItemDetail)
                        {
                            if (item.IsCustomerEntry == true)
                            {
                                // Customer entrry
                                MMS.ISR.Bapiacar09 _itemCust = new MMS.ISR.Bapiacar09();
                                _itemCust = new MMS.ISR.Bapiacar09();
                                _itemCust.ItemnoAcc = (count + 1).ToString();
                                _itemCust.Customer = item.CustomerCode_GLAccount;
                                _itemCust.RefKey1 = item.RefKey1;
                                _itemCust.RefKey2 = item.RefKey2;
                                _itemCust.RefKey3 = item.RefKey3;
                                _itemCust.BusArea = item.BusinessArea.ToString();
                                _itemCust.TaxCode = "ZN";
                                _itemCust.AllocNmbr = item.Assignment;
                                _itemCust.ItemText = item.Text;
                                accountReceivableList.Add(_itemCust);

                                //// -- Item Currency--///-
                                MMS.ISR.Bapiaccr09 _ItemCurrency = new MMS.ISR.Bapiaccr09();
                                _ItemCurrency = new MMS.ISR.Bapiaccr09();
                                _ItemCurrency.ItemnoAcc = (count + 1).ToString();
                                _ItemCurrency.CurrType = "00";
                                _ItemCurrency.Currency = "LKR";
                                _ItemCurrency.AmtDoccur = item.AmtInDocCur;
                                _ItemCurrency.DiscBase = item.AmtInDocCur;
                                _ItemCurrency.ExchRate = 1;

                                currencyAmountList.Add(_ItemCurrency);



                                count++;


                            }
                            if (item.IsCustomerEntry == false) // GL entries 
                            {
                                MMS.ISR.Bapiacgl09 _itemGL = new MMS.ISR.Bapiacgl09();
                                _itemGL = new MMS.ISR.Bapiacgl09();
                                _itemGL.ItemnoAcc = (count + 1).ToString();
                                _itemGL.GlAccount = item.CustomerCode_GLAccount;
                                _itemGL.TaxCode = "ZN";
                                _itemGL.RefKey1 = item.RefKey1;
                                _itemGL.RefKey2 = item.RefKey2;
                                _itemGL.RefKey3 = item.RefKey3;
                                _itemGL.BusArea = item.BusinessArea.ToString();
                                if (item.CostCenter == null)
                                {
                                    _itemGL.Costcenter = "";
                                }
                                else
                                {
                                    _itemGL.Costcenter = item.CostCenter.Trim();
                                }
                                _itemGL.ProfitCtr = item.ProfitCenter;
                                _itemGL.Orderid = "";
                                _itemGL.AllocNmbr = item.Assignment;
                                _itemGL.ItemText = item.Text;
                                accountGLList.Add(_itemGL);
                                //accountGL


                                //// -- Item Currency--///-
                                MMS.ISR.Bapiaccr09 _ItemCurrency = new MMS.ISR.Bapiaccr09();
                                _ItemCurrency = new MMS.ISR.Bapiaccr09();
                                _ItemCurrency.ItemnoAcc = (count + 1).ToString();
                                _ItemCurrency.CurrType = "00";
                                _ItemCurrency.Currency = "LKR";
                                _ItemCurrency.AmtDoccur = item.AmtInDocCur;
                                _ItemCurrency.DiscBase = item.AmtInDocCur;
                                _ItemCurrency.ExchRate = 1;
                                currencyAmountList.Add(_ItemCurrency);
                                count++;
                            }


                        }

                        Accountgl = accountGLList.ToArray();
                        Accountreceivable = accountReceivableList.ToArray();
                        Currencyamount = currencyAmountList.ToArray();

                        //isr  ACCOUNTRECEIVABLE
                        soaprequest.Append("<ACCOUNTRECEIVABLE>");
                        for (int i = 0; i < accountReceivableList.Count; i++)
                        {
                            soaprequest.Append("<item>");
                            soaprequest.Append("<ITEMNO_ACC>" + accountReceivableList[i].ItemnoAcc + "</ITEMNO_ACC>");
                            soaprequest.Append("<CUSTOMER>" + accountReceivableList[i].Customer + "</CUSTOMER>");
                            soaprequest.Append("<REF_KEY_1>" + accountReceivableList[i].RefKey1 + "</REF_KEY_1>");
                            soaprequest.Append("<REF_KEY_2>" + accountReceivableList[i].RefKey2 + "</REF_KEY_2>");
                            soaprequest.Append("<REF_KEY_3>" + accountReceivableList[i].RefKey3 + "</REF_KEY_3>");
                            soaprequest.Append("<BUS_AREA>" + accountReceivableList[i].BusArea + "</BUS_AREA>");
                            soaprequest.Append("<TAX_CODE>ZN</TAX_CODE>");
                            soaprequest.Append("<ALLOC_NMBR>" + accountReceivableList[i].AllocNmbr + "</ALLOC_NMBR>");
                            soaprequest.Append("<ITEM_TEXT>" + accountReceivableList[i].ItemText + "</ITEM_TEXT>");
                            soaprequest.Append("</item>");

                        }

                        soaprequest.Append("</ACCOUNTRECEIVABLE>");
                        //account GL
                        soaprequest.Append("<ACCOUNTGL>");
                        for (int i = 0; i < Accountgl.Length; i++)
                        {


                            soaprequest.Append("<item>");
                            soaprequest.Append("<ITEMNO_ACC>" + Accountgl[i].ItemnoAcc + "</ITEMNO_ACC>");
                            soaprequest.Append("<GL_ACCOUNT>" + Accountgl[i].GlAccount + "</GL_ACCOUNT>");
                            soaprequest.Append("<REF_KEY_1>" + Accountgl[i].RefKey1 + "</REF_KEY_1>");
                            soaprequest.Append("<REF_KEY_2>" + Accountgl[i].RefKey2 + "</REF_KEY_2>");
                            soaprequest.Append("<REF_KEY_3>" + Accountgl[i].RefKey3 + "</REF_KEY_3>");
                            soaprequest.Append("<BUS_AREA>" + Accountgl[i].BusArea + "</BUS_AREA>");
                            soaprequest.Append("<TAX_CODE>ZN</TAX_CODE>");
                            soaprequest.Append("<ALLOC_NMBR>" + Accountgl[i].AllocNmbr + "</ALLOC_NMBR>");
                            //soaprequest.Append("<ITEMNO_TAX>" + item.Text + "</ITEMNO_TAX>");
                            if (Accountgl[i].Costcenter == null)
                            {
                                soaprequest.Append("<COSTCENTER>" + "" + "</COSTCENTER>");
                            }
                            else
                            {

                                soaprequest.Append("<COSTCENTER>" + Accountgl[i].Costcenter + "</COSTCENTER>");
                            }

                            soaprequest.Append("<PROFIT_CTR>" + Accountgl[i].ProfitCtr + "</PROFIT_CTR>");
                            soaprequest.Append("<ORDERID>" + "" + "</ORDERID>");
                            soaprequest.Append("<ALLOC_NMBR>" + Accountgl[i].AllocNmbr + "</ALLOC_NMBR>");
                            soaprequest.Append("<ITEM_TEXT>" + Accountgl[i].ItemText + "</ITEM_TEXT>");
                            soaprequest.Append("</item>");




                        }
                        soaprequest.Append("</ACCOUNTGL>");
                        //currency 
                        soaprequest.Append("<CURRENCYAMOUNT>");
                        for (int i = 0; i < currencyAmountList.Count; i++)
                        {
                            soaprequest.Append("<item>");
                            soaprequest.Append("<ITEMNO_ACC>" + currencyAmountList[i].ItemnoAcc + "</ITEMNO_ACC>");
                            soaprequest.Append("<CURR_TYPE>00</CURR_TYPE>");
                            soaprequest.Append("<CURRENCY>LKR</CURRENCY>");
                            soaprequest.Append("<AMT_DOCCUR>" + currencyAmountList[i].AmtDoccur + "</AMT_DOCCUR>");
                            soaprequest.Append("<DISC_BASE>" + currencyAmountList[i].AmtDoccur + "</DISC_BASE>");
                            soaprequest.Append("<EXCH_RATE>" + 1 + "</EXCH_RATE>");
                            soaprequest.Append("</item>");

                        }
                        soaprequest.Append("</CURRENCYAMOUNT>");




                        soaprequest.Append("<ACCOUNTPAYABLE></ACCOUNTPAYABLE>");
                        soaprequest.Append("<ACCOUNTTAX></ACCOUNTTAX>");
                        soaprequest.Append("<ACCOUNTWT></ACCOUNTWT>");
                        soaprequest.Append("<CONTRACTITEM></CONTRACTITEM>");
                        soaprequest.Append("<CRITERIA></CRITERIA>");
                        soaprequest.Append("<EXTENSION1></EXTENSION1>");
                        soaprequest.Append("<EXTENSION2></EXTENSION2>");
                        soaprequest.Append("<PAYMENTCARD></PAYMENTCARD>");
                        soaprequest.Append("<REALESTATE></REALESTATE>");
                        soaprequest.Append("<RETURN></RETURN>");
                        soaprequest.Append("<VALUEFIELD></VALUEFIELD>");
                        soaprequest.Append("</urn:ZBAPI_ACC_DOCUMENT_POST>");
                        soaprequest.Append("</soapenv:Body>");
                        soaprequest.Append("</soapenv:Envelope>");

                        HttpClient iclient = new HttpClient();
                        iclient.DefaultRequestHeaders.Add("SOAPAction", "http://sap.com/xi/WebService/soap1.1");
                        iclient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "42c5e1bd9440432f931c020af95e596e");

                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                        HttpResponseMessage response;
                        byte[] byteData = Encoding.UTF8.GetBytes(soaprequest.ToString());
                        using (var content = new ByteArrayContent(byteData))
                        {
                            content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                            response = await iclient.PostAsync(sapUrl, content);
                            


                        }





                        // Task<string> isrresponse = MakeRequestNew(soaprequest.ToString());
                        //MessageBox.Show("successs");

                        // _response = _request.ZbapiAccDocumentPost(ref Accountgl, ref Accountpayable, ref Accountreceivable, ref Accounttax, ref Accountwt, Contractheader, ref Contractitem, ref Criteria, ref Currencyamount, Customercpd, Documentheader, ref Extension1, ref Extension2, ref Paymentcard, ref Realestate, ref Return, ref Valuefield, out _ObjSys, out _ObjType);


                        //Int64 responseValue = 0;
                        //res = Int64.TryParse(isrresponse.ToString(), out responseValue);
                        //if (res == false) { responseValue = 0; }





                        if (response.StatusCode.ToString() == "OK")
                        {
                            updateInvoice("sucess", qryItem.RefDocNo, response.StatusCode.ToString());
                            qryHeader.SAPUploadMessage = "sucsess";
                            MessageBox.Show("SAP upload success..!");

                        }
                        else
                        {
                            updateInvoice("fail", qryItem.RefDocNo, response.StatusCode.ToString());
                            qryHeader.SAPUploadMessage = "fail";
                            MessageBox.Show("SAP upload Fail..!");
                        }

                        splashScreenManager2.SetWaitFormDescription(Documentheader.RefDocNo);

                    } // if sap ISR end




                    #endregion ///SAP R3

                } //loop


                //email alert for SAP ISR 
                int alert = (int)MMS.CustomClasses.cCommon_Functions.AlertItem.SapUpload;
                this.gridView1.OptionsPrint.ShowPrintExportProgress = false;
                this.gridView1.OptionsPrint.AutoWidth = false;
                string sapVer = "";
                if (IsISR == true)
                { sapVer = "ISR"; }
                else { sapVer = "R/3"; }
                MMS.CustomClasses.cCommon_Functions.AddToEmailList(compid, locid, alert, "", MMS.CustomClasses.cCommon_Functions.LoggedUserID, this.gridView1, "SAP Uploaded : " + sapVer);


                this.gridView1.BestFitColumns();
                this.cSAP_UploadGridControl.RefreshDataSource();



                if (splashScreenManager2.IsSplashFormVisible == true)
                { splashScreenManager2.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                if (splashScreenManager2.IsSplashFormVisible == true)
                { splashScreenManager2.CloseWaitForm(); }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
       
       
        private void updateInvoice(string pMessage, string pInvoiceNo,string statuscode)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryInvoice = (from i in context.Invoices
                                      where i.InvoiceNo == pInvoiceNo
                                      select i).FirstOrDefault();
                    if (qryInvoice != null)
                    {
                        if (statuscode =="OK")
                        {
                            qryInvoice.Is_SAPUploaded = true;
                        }
                        else
                        {


                            if (statuscode == "OK")
                            {
                                qryInvoice.SAPUploadMsg = pMessage;
                                qryInvoice.Is_SAPUploaded = true;
                            }
                            else 
                            {
                                qryInvoice.SAPUploadErr = pMessage;
                                qryInvoice.Is_SAPUploaded = false;
                            }
                        }
                    }

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateInvoice(string pMessage, string pInvoiceNo, MMS.R3.Bapiret2 bapiret2)
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    var qryInvoice = (from i in context.Invoices
                                      where i.InvoiceNo == pInvoiceNo
                                      select i).FirstOrDefault();
                    if (qryInvoice != null)
                    {
                        if (bapiret2.Type == "S")
                        {
                            qryInvoice.SAPUploadMsg = pMessage;
                            qryInvoice.Is_SAPUploaded = true;
                        }
                        if (bapiret2.Type == "E")
                        {
                            qryInvoice.SAPUploadErr = pMessage;
                            qryInvoice.Is_SAPUploaded = false;
                        }

                        qryInvoice.LastUpdated = CustomClasses.cCommon_Functions.LoggedUserID;
                        qryInvoice.LastUpdateDate = DateTime.Now;



                    }

                    
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void updateInvoice(string pMessage, string pInvoiceNo)
        //{
        //    try
        //    {
        //        using (AHPL_DBEntities context = new AHPL_DBEntities())
        //        {

        //            var qryInvoice = (from i in context.Invoices
        //                              where i.InvoiceNo == pInvoiceNo
        //                              select i).FirstOrDefault();
        //            if (qryInvoice != null)
        //            {
        //                qryInvoice.SAPUploadMsg = pMessage;
        //                qryInvoice.Is_SAPUploaded = true;
        //            }

        //            context.SaveChanges();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel (*.xlsx)|*.xlsx";
                saveDlg.ShowDialog();
                if (string.IsNullOrEmpty(saveDlg.FileName.ToString()))
                { return; }

                string filename = saveDlg.FileName;
                this.gridView1.OptionsPrint.AutoWidth = false;
                this.gridView1.ExportToXlsx(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            ////SaveFileDialog dlg = new SaveFileDialog();
            ////dlg.ShowDialog();
            ////this.gridView1.OptionsPrint.AutoWidth = false;


            ////string mydocpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ////string filePath = mydocpath + @"\ProcessedContracts.xlsx";
            //this.gridView1.OptionsPrint.AutoWidth = false;
            //this.gridView1.OptionsPrint.ExpandAllDetails = true;
            //this.gridView1.OptionsPrint.PrintDetails = true;
          
            //byte[] buffer;
            //  //this.gridView1.ExportToXlsx(filePath);
            //System.IO.MemoryStream mt = new System.IO.MemoryStream();

            //this.gridView1.HideLoadingPanel();

            // this.gridView1.ExportToXlsx(mt);

           
            ////System.IO.FileStream st = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
         
            
            ////byte[] buffer = new byte[st.Length];
            ////st.Read(buffer, 0, (int)st.Length);
            ////st.Close();

            ////byte[] pdfData = (byte[])filePath;
            ////byte[] data = new byte[st.Length];

            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            //{
            //    var emails = (from em in context.EmailsToBeSents
            //                  select em).FirstOrDefault();
            //    //emails.Attachment = buffer;

            //    byte[] file2 = mt.ToArray();
            //    emails.Attachment = file2;

            //    int succ = context.SaveChanges();
                
                
            //}

            //gridView1.ExportToXlsx(dlg.FileName + ".xlsx");
        }

        private void dateEditYearMonth_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAutoBalance_Click(object sender, EventArgs e)
        {
            try
            {
                var qryRefDoNo = (from c in SAPUPloadList
                                  group c by c.RefDocNo into g
                                  where g.Sum(x=>x.AmtInDocCur) !=0
                                  select new { RefDocNo = g.Key, TotalBalance = g.Sum(p => p.AmtInDocCur) }).ToList();
                foreach (var qry in qryRefDoNo)
                {
                    var qrySapList = (from s in SAPUPloadList
                                      where s.RefDocNo == qry.RefDocNo
                                      select s).FirstOrDefault();
                    qrySapList.AmtInDocCur = qrySapList.AmtInDocCur - qry.TotalBalance;                  
                }

                this.cSAP_UploadGridControl.RefreshDataSource();
                                  

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
            
            //using (AHPL_DBEntities context = new AHPL_DBEntities())
            //{
            //    var emails = (from em in context.EmailsToBeSents
            //                  select em).FirstOrDefault();

            //    byte[] buffer = (byte[])emails.Attachment;

            //    //int succ = context.SaveChanges();
            //    string mydocpath = System.IO.Path.GetTempPath();

            //    //string mydocpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //    string filePath = mydocpath + "ProcessedContracts11.xlsx";

            //    using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            //    {
            //        // use a binary writer to write the bytes to disk
            //        using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
            //        {
            //            bw.Write(buffer);
            //            bw.Close();
            //        }
            //    }
            //}
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                this.chkSelectAll.Text = "Unselect All";
                foreach (var qry in SAPUPloadList)
                {
                    qry.IsSelected = true;

                }

            }
            else
            {
                this.chkSelectAll.Text = "Select All";

                foreach (var qry in SAPUPloadList)
                {
                    qry.IsSelected = false;
                }
            }

            this.cSAP_UploadGridControl.RefreshDataSource();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel (*.xlsx)|*.xlsx";
                saveDlg.ShowDialog();
                string filename = saveDlg.FileName;
                this.gridView1.OptionsPrint.AutoWidth = false;
                this.gridView1.ExportToXlsx(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void dateFromPosting_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dateFromPosting.Text.ToString()))
            { return; }

            DateTime dateFrom = dateFromPosting.DateTime.Date;
            DateTime dateTo = dateFrom.Date.AddMonths(1).AddDays(-1).Date;
            this.dateToPosting.DateTime = dateTo;

        }

        private void lookCompany_EditValueChanged(object sender, EventArgs e)
        {
            //// Location..roshan..06oct2014
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                int comid = 0;
                bool res = false;
                res = int.TryParse(lookCompany.EditValue.ToString(), out comid);
                if (res.Equals(true))
                {
                    var qryLocs = (from c in context.Companies
                                   join l in context.Locations on c.LocationID equals l.LocationID
                                   where c.CompanyID == comid
                                   select new { l.LocationID, l.LocationCode }).ToList();

                    this.lookLocation.Properties.DataSource = qryLocs;
                    this.lookLocation.Properties.DisplayMember = "LocationCode";
                    this.lookLocation.Properties.ValueMember = "LocationID";
                }
            }
        }

        

                     
    }
}