using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using DataTier;
using DevExpress.XtraEditors;
using MMS;
using System.IO;
namespace EmailApp
{
    public partial class xEmailApp : DevExpress.XtraEditors.XtraForm
    {
        NotifyIcon mynotifyicon = new NotifyIcon();

        bool startService = false;
        List<EmailsToBeSent> emailtobeSentList = new List<EmailsToBeSent>();
        Int64 interval = 1000 * 60 * 10;////10 min time ..04July2014.roshan..
        delegate void processingTimerElapsedDelege();

        public xEmailApp()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("AHPL_Email_APP_Source"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AHPL_Email_APP_Source", "AHPL_Email_APP_Log");
            }
            eventLog1.Source = "AHPL_Email_APP_Source";
            eventLog1.Log = "AHPL_Email_APP_Log";

        }

        //TimerCallback tcb = t
        //static System.Threading.Timer timer = new  System.Threading.Timer(
        private System.Timers.Timer timer = new System.Timers.Timer();

        private void xEmailApp_Load(object sender, EventArgs e)
        {
            load_data();

            ////To check mail sending issue below method implemented..Comment after testing..roshan..28March2014
            ////using (AHPL_DBEntities context = new AHPL_DBEntities())
            ////{
            ////    Logic(context);
            ////}
        }



        private void load_data()
        {
            try
            {
                eventLog1.WriteEntry("Load Data:" + DateTime.Now);

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {

                    // email to be sent list 

                    ////load_emailtobeSent();////04July2014..coment by roshan..due to not using

                    // -- 

                    // email config
                    var qryConfig = (from c in context.EmailConfigurations
                                     select c).FirstOrDefault();
                    if (qryConfig != null)
                    {
                        chkStart.Checked = qryConfig.StartServiceApp;
                    }
                    else
                    {
                        chkStart.Checked = false;
                    }

                    startService = chkStart.Checked;
                    //////StartEmailService(startService);...previous developer code.he had commented this


                    timer.Interval = interval; //set interval 
                    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                    ////start_timer(startService);////Comment by roshan,No need start timer once application is start..04July2014..roshan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Load_contractExpiry()
        {
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    ////// monthly email list 

                    ////    // contract expiry
                    #region Regular_Contract_Expiry


                    var qryContract = (from c in context.ContractClosures
                                       join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                       where c.IsPromotion == false && c.IsTerminated == false && c.IsActive == true
                                       select c).Distinct().ToList();

                    foreach (var qry in qryContract)
                    {
                        var qryLastOrDefualt = qry.Contract_RentSchemes.LastOrDefault();

                        DateTime dateToday = DateTime.Now.Date;
                        DateTime contractLastDay = qryLastOrDefualt.ToDate;
                        //int laps = dateToday.Subtract(contractLastDay).Days;
                        int laps = contractLastDay.Subtract(dateToday).Days;

                        int companydID = 0; int locationId = 0; int levelId = 0;
                        string shopName = ""; string shopNo = "";
                        int contractClauseId = 0;
                        DateTime expiryDate; DateTime commencedDate;
                        string customerName = "";
                        int lapsDay = 0;

                        if (laps <= 90 && laps > 60)
                        {
                            contractClauseId = qry.ContractClosureID;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            locationId = qryLastOrDefualt.ContractClosure.LocationID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                           // MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Contract Expiring", "", contractClauseId, 1, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"));
                            //contractAgeList.Add(cAge);

                        }

                        if (laps <= 60 && laps > 30)
                        {
                            contractClauseId = qry.ContractClosureID;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                            //MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Contract Expiring", "", contractClauseId, 2, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"));

                        }


                        if (laps <= 30 && laps > 10)
                        {

                            contractClauseId = qry.ContractClosureID;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                            //MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Contract Expiring", "", contractClauseId, 3, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"));
                        }

                        if (laps == 0) // expiring today
                        {

                            contractClauseId = qry.ContractClosureID;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                            //MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Contract Expiring : Today", "", contractClauseId, 3, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"));
                        }


                        if (laps >= -10 && laps < 0)
                        {

                            contractClauseId = qry.ContractClosureID;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                            //MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Contract Expired", "", contractClauseId, 4, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"));
                        }

                        if (laps >= -30 && laps < -10)
                        {

                            contractClauseId = qry.ContractClosureID;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                            //MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Contract Expired", "", contractClauseId, 5, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"));
                        }
                    }

                    #endregion

                    #region Promotional_Contract_Expiry
                    var qryContractPo = (from c in context.ContractClosures
                                         join cr in context.Contract_RentSchemes on c.ContractClosureID equals cr.ContractClosureID
                                         where c.IsPromotion == true && c.IsTerminated == false && c.IsActive == true
                                         select c).Distinct().ToList();

                    foreach (var qry in qryContractPo)
                    {
                        var qryLastOrDefualt = qry.Contract_RentSchemes.LastOrDefault();

                        DateTime dateToday = DateTime.Now.Date;
                        DateTime contractLastDay = qryLastOrDefualt.ToDate;
                        //int laps = dateToday.Subtract(contractLastDay).Days;
                        int laps = contractLastDay.Subtract(dateToday).Days;

                        int companydID = 0; int locationId = 0; int levelId = 0;
                        string shopName = ""; string shopNo = "";
                        string contractName = "";
                        int contractClauseId = 0;
                        DateTime expiryDate; DateTime commencedDate;
                        string customerName = "";
                        int lapsDay = 0;

                        if (laps <= 30 && laps > 9)
                        {
                            contractClauseId = qry.ContractClosureID;
                            contractName = qry.ContractClosureName;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            locationId = qryLastOrDefualt.ContractClosure.LocationID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;
                            //levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            //shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            //shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

                          //  MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Promotional Contract Expiring", "", contractClauseId, 1, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"), true);
                            //contractAgeList.Add(cAge);
                        }

                        if (laps <= 10 && laps > 5)
                        {
                            contractClauseId = qry.ContractClosureID;
                            contractName = qry.ContractClosureName;
                            commencedDate = qryLastOrDefualt.FromDate;
                            companydID = qryLastOrDefualt.ContractClosure.CompanyID;
                            customerName = qryLastOrDefualt.ContractClosure.CustomerName;
                            expiryDate = qryLastOrDefualt.ToDate;
                            lapsDay = laps;

                            //levelId = qryLastOrDefualt.ContractClosure.LevelID;
                            //shopName = qryLastOrDefualt.ContractClosure.ShopName;
                            //shopNo = qryLastOrDefualt.ContractClosure.ShopNo;

//MMS.CustomClasses.cCommon_Functions.AddToEmailListContractExpiry(companydID, locationId, 1, "Promotional Contract Expiring", "", contractClauseId, 2, lapsDay, commencedDate.ToString("dd/MM/yyyy"), expiryDate.ToString("dd/MM/yyyy"), true);

                        }


                    }


                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void load_emailtobeSent()
        {
            try
            {

                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryEmailList = (from em in context.EmailsToBeSents
                                        where em.IsEmailSent == false
                                        select em).ToList();

                    emailtobeSentList = qryEmailList;

                    //emailsToBeSentBindingSource.DataSource = emailtobeSentList;
                    //gridView1.BestFitColumns();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void start_timer(bool pStart)
        {

            if (pStart == true)
            {
                timer.Enabled = true;////04July2014..roshan
                timer.Start();

                eventLog1.WriteEntry("timer is started" + DateTime.Now);
            }
            else
            {
                timer.Stop();
                timer.Enabled = false;
                eventLog1.WriteEntry("timer is stopped" + DateTime.Now);
            }

        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                eventLog1.WriteEntry("timer is in timer_Elapsed:" + DateTime.Now);
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    Logic(context);
                }

            }
            catch (Exception ex)
            {
                ////start_timer(false);////To avoid timer once error occourd .. 04July2014..roshan.
                MessageBox.Show(ex.Message);

                eventLog1.WriteEntry("timer_Elapsed error.." + DateTime.Now + ".." + ex.Message);
            }
        }

        private void Logic(AHPL_DBEntities context)
        {
            Load_contractExpiry();

            List<string> userEmailList = new List<string>();
            List<string> userEmailListContract = new List<string>();
            List<cUserEmailList> userEmailList1 = new List<cUserEmailList>();

            /// hourly email list 
            #region HourlyEmail
            var qryEmailToBeSentHourly = (from em in context.EmailsToBeSents
                                          where em.IsEmailSent == false && em.Selected == true && em.IsHourly == true
                                          select em).ToList();

            int i = 1;


            //geting eligible list of user from the Role Alert         
            foreach (var qry in qryEmailToBeSentHourly)
            {

                var qryAlertItem = (from a in context.EmailAlertRoles
                                    join u in context.Permission_Users on a.RoleID equals u.RoleID
                                    join l in context.UserLocations on u.UserID equals l.UserID
                                    join em in context.EmailsToBeSents on a.EmailAlertItemID equals em.EmailAlertItemID
                                    where a.EmailAlertItemID == qry.EmailAlertItemID && a.IsEnabled == true && em.IsEmailSent == false && l.LocationID == qry.LocationID
                                    select new { u.Email1, em.EmailAlertItemID, em.EmailTobeSendID, em.CompanyID, em.LocationID, em.Subject, em.Body, em.Attachment, em.CreatedBy, u.UserID }).ToList();
                //userEmailList.Clear();
                //userEmailList1.Clear();

                foreach (var qryA in qryAlertItem)
                {
                    //check user in the user location
                    var qryUserlocation = (from ul in context.UserLocations
                                           where ul.UserID == qryA.UserID && ul.LocationID == qryA.LocationID
                                           select ul).ToList();

                    if (qryUserlocation.Count > 0)
                    {

                        cUserEmailList userEmailObj = new cUserEmailList();
                        userEmailObj.EmailAddress = qryA.Email1;
                        userEmailObj.EmailTobeSendID = qryA.EmailTobeSendID;
                        userEmailObj.EmailAlertItemID = qryA.EmailAlertItemID;
                        userEmailObj.CompanyID = qryA.CompanyID;
                        userEmailObj.LocationID = qryA.LocationID;
                        userEmailObj.Subject = qryA.Subject;
                        userEmailObj.Body = qryA.Body;
                        userEmailObj.Attachement = qryA.Attachment;
                        userEmailObj.CreatedBy = qryA.CreatedBy;
                        userEmailObj.UserID = qryA.UserID;
                        userEmailObj.EmailSent = false;

                        userEmailList1.Add(userEmailObj);
                    }
                }

                if (userEmailList1.Count > 100)
                {
                    break;
                }


            }
            //var qryUniqueEmails = (from em in userEmailList1
            //                       where em.EmailSent == false
            //                       select new { em.EmailTobeSendID, em.EmailAddress,em.EmailAlertItemID,em.LocationID,em.CompanyID,em.Subject,em.Body,em.Attachement,em.CreatedBy,em.EmailSent }).Distinct().ToList();


            foreach (var qryemail in userEmailList1)
            {
                bool found = false;

                found = foundItem(qryemail.EmailAddress, qryemail.EmailTobeSendID);

                if (found == false)
                {
                    sendEmail(qryemail.CompanyID, qryemail.LocationID, qryemail.Subject, qryemail.Body, qryemail.CreatedBy, qryemail.Attachement, qryemail.EmailAddress, 0, qryemail.EmailTobeSendID, qryemail.UserID);

                    var qryEmailTobeSend = (from em in context.EmailsToBeSents
                                            where em.EmailTobeSendID == qryemail.EmailTobeSendID
                                            select em).FirstOrDefault();

                    qryemail.EmailSent = true;

                    qryEmailTobeSend.IsEmailSent = true;
                    qryEmailTobeSend.EmailSentDate = DateTime.Now;
                    //System.Threading.Thread.Sleep(5000);
                }

                context.SaveChanges();

            }


            //qryUniqueEmails.Clear();
            userEmailList1.Clear();

            #endregion

            //--
            /// Conntract Expiry email list 
            #region ContractExpiryEmail
            //var qryEmailToBeSentMonthly = (from em in context.EmailsToBeSents
            //                         where em.IsEmailSent == false && em.Selected == true && em.IsMonthly == true
            //                         select em).ToList();


            //geting eligible list of user from the Role Alert         
            //foreach (var qry in qryEmailToBeSentMonthly)
            {

                var qryAlertItem = (from a in context.EmailAlertRoles
                                    join u in context.Permission_Users on a.RoleID equals u.RoleID
                                    join l in context.UserLocations on u.UserID equals l.UserID
                                    join em in context.EmailsToBeSents on a.EmailAlertItemID equals em.EmailAlertItemID
                                    where a.IsEnabled == true && em.IsEmailSent == false && em.IsMonthly == true
                                    select new { u.Email1, em.EmailAlertItemID, em.EmailTobeSendID, em.CompanyID, em.LocationID, em.Subject, em.Body, em.Attachment, em.CreatedBy, em.ContractClauseID, u.UserID }).ToList();
                userEmailListContract.Clear();

                foreach (var qryA in qryAlertItem)
                {
                    //check user in the user location
                    var qryUserlocation = (from ul in context.UserLocations
                                           where ul.UserID == qryA.UserID && ul.LocationID == qryA.LocationID
                                           select ul).ToList();
                    if (qryUserlocation.Count > 0)
                    {

                        cUserEmailList userEmailObj = new cUserEmailList();
                        userEmailObj.EmailAddress = qryA.Email1;
                        userEmailObj.EmailTobeSendID = qryA.EmailTobeSendID;
                        userEmailObj.EmailAlertItemID = qryA.EmailAlertItemID;
                        userEmailObj.CompanyID = qryA.CompanyID;
                        userEmailObj.LocationID = qryA.LocationID;
                        userEmailObj.Subject = qryA.Subject;
                        userEmailObj.Body = qryA.Body;
                        userEmailObj.Attachement = qryA.Attachment;
                        userEmailObj.CreatedBy = qryA.CreatedBy;
                        userEmailObj.ContractClauseID = qryA.ContractClauseID;
                        userEmailObj.EmailSent = false;
                        userEmailObj.UserID = qryA.UserID;
                        userEmailList1.Add(userEmailObj);
                    }
                }
            }


            foreach (var qryemail in userEmailList1)
            {
                bool found = false;

                found = foundItem(qryemail.EmailAddress, qryemail.EmailTobeSendID);


                if (found == false)
                {
                    sendEmail(qryemail.CompanyID, qryemail.LocationID, qryemail.Subject, qryemail.Body, qryemail.CreatedBy, qryemail.Attachement, qryemail.EmailAddress, qryemail.ContractClauseID, qryemail.EmailTobeSendID, qryemail.UserID);

                    var qryEmailTobeSend = (from em in context.EmailsToBeSents
                                            where em.EmailTobeSendID == qryemail.EmailTobeSendID
                                            select em).FirstOrDefault();

                    qryemail.EmailSent = true;

                    qryEmailTobeSend.IsEmailSent = true;
                    qryEmailTobeSend.EmailSentDate = DateTime.Now;
                    //System.Threading.Thread.Sleep(5000);
                }

                context.SaveChanges();

            }



            #endregion

            context.SaveChanges();
        }

        private bool foundItem(string pEmail, long pEmailToBeSendID)
        {
            bool found = false;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryFound = (from em in context.EmailSentItems
                                    where em.Email == pEmail && em.EmailToBeSendID == pEmailToBeSendID
                                    select em).ToList();
                    if (qryFound.Count > 0)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return found;
        }

        private void sendEmail(int pCompanyID, int pLocationID, string pSubject, object pBody, int pCreatedBy, byte[] pAttachment, string pUserEmail, int pContractClauseID = 0, Int64 pEmailTobeSendID = 0, int pUserId = 0)
        {
            //bool emailSent = false;
            try
            {
                using (AHPL_DBEntities context = new AHPL_DBEntities())
                {
                    var qryUserLoc = (from ul in context.UserLocations
                                      where ul.UserID == pUserId && ul.LocationID == pLocationID
                                      select ul).ToList();
                    if (qryUserLoc.Count == 0)
                    { return; }


                    string fromEmail = "";
                    int portno = 0;
                    string clientHost = "";
                    string company = "";
                    string location = "";
                    string createdBy = "";


                    // email config 
                    var qryEmailConfig = (from c in context.EmailConfigurations
                                          select c).FirstOrDefault();
                    if (qryEmailConfig == null)
                    {
                        eventLog1.WriteEntry("sendEmail:" + "Invalid Email Configuration,Contact System Administrator");
                        throw new Exception("Invalid Email Configuration,Contact System Administrator");
                    }

                    fromEmail = qryEmailConfig.FromEmail;
                    portno = int.Parse(qryEmailConfig.PorNo.ToString());
                    clientHost = qryEmailConfig.ClientHost;


                    // email attachment 
                    byte[] buffer = pAttachment;



                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    if (buffer != null)
                    {
                        ms = new System.IO.MemoryStream(buffer);
                        byte[] bytes = new byte[ms.Length];
                        ms.Read(bytes, 0, (int)ms.Length);
                        ms.Position = 0;
                    }



                    //string attachment1 = filePath;

                    //Thread.Sleep(3000);


                    // company
                    var qryComp = (from c in context.Companies
                                   where c.CompanyID == pCompanyID
                                   select new { c.CompanyCode }).FirstOrDefault();
                    if (qryComp != null) { company = qryComp.CompanyCode; }

                    //location 
                    var qryLoc = (from l in context.Locations
                                  where l.LocationID == pLocationID
                                  select new { l.LocationCode }).FirstOrDefault();
                    if (qryLoc != null) { location = qryLoc.LocationCode; }

                    //var User 
                    var qryUser = (from u in context.Permission_Users
                                   where u.UserID == pCreatedBy
                                   select new { u.UserName }).FirstOrDefault();

                    createdBy = qryUser.UserName;

                    // list of emais to be sent                     

                    //foreach (var qry in pUserEmailList)
                    {
                        var userName = context.Permission_Users.Where(x => x.Email1 == pUserEmail).FirstOrDefault().UserName;


                        MailAddress from = new MailAddress(fromEmail, "Shopping Mall System");
                        MailAddress to = new MailAddress(pUserEmail, userName);
                        MailMessage mail = new MailMessage(from, to);

                        SmtpClient client = new SmtpClient();
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Host = clientHost;
                        client.Port = portno;

                        if (buffer != null)
                        {
                            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, "Attachment.xlsx");
                            mail.Attachments.Add(attachment);

                        }

                        mail.Subject = pSubject;

                        if (pContractClauseID == 0)
                        {
                            pBody = "Dear " + userName + ","
                                + System.Environment.NewLine
                                + System.Environment.NewLine
                                + pSubject
                                + System.Environment.NewLine
                                + "Company : " + company
                                + System.Environment.NewLine
                                + "Location : " + location
                                + System.Environment.NewLine
                                + pBody
                                  + System.Environment.NewLine
                                + "Created By : " + createdBy
                                + System.Environment.NewLine
                                + System.Environment.NewLine
                                + System.Environment.NewLine + "This is an automated email generation by Shopping Mall System, If already taken the necessary steps please ignore this email."
                                + System.Environment.NewLine
                                + System.Environment.NewLine
                                + "____________T H A N K  Y O U____________";

                        }
                        else // contract expiry alert
                        {
                            pBody = "Dear " + userName + ","
                               + System.Environment.NewLine
                               + System.Environment.NewLine
                               + pSubject
                               + System.Environment.NewLine
                               + pBody
                                 + System.Environment.NewLine
                               + "Generated By : " + createdBy
                               + System.Environment.NewLine
                               + System.Environment.NewLine
                               + System.Environment.NewLine + "This is an automated email generation by Shopping Mall System, If already taken the necessary steps please ignore this email."
                               + System.Environment.NewLine
                               + System.Environment.NewLine
                               + "____________T H A N K  Y O U____________";

                        }



                        mail.Body = pBody.ToString();

                        client.Send(mail);

                        EmailSentItem emailsentObj = new EmailSentItem();
                        emailsentObj.EmailToBeSendID = pEmailTobeSendID;
                        emailsentObj.Email = pUserEmail;
                        context.EmailSentItems.AddObject(emailsentObj);
                        context.SaveChanges();
                        //emailSent = true;

                        //Thread.Sleep(3000);

                    }


                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("sendEmail:" + ex.Message);
                throw ex;
            }

            //return emailSent;

        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStart.Checked == true)
            {
                chkStart.Text = "Stop Service";
                start_timer(true);

            }
            else
            {
                chkStart.Text = "Start Service";
                start_timer(false);
            }

            startService = chkStart.Checked;
        }

        private void xEmailApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (AHPL_DBEntities context = new AHPL_DBEntities())
            {
                var qryConfig = (from c in context.EmailConfigurations
                                 select c).FirstOrDefault();
                if (qryConfig == null)
                {
                    EmailConfiguration configapp = new EmailConfiguration();
                    configapp.StartServiceApp = chkStart.Checked;
                    context.EmailConfigurations.AddObject(configapp);

                }
                else
                {
                    EmailConfiguration configapp = (from c in context.EmailConfigurations
                                                    select c).FirstOrDefault();
                    configapp.StartServiceApp = chkStart.Checked;


                }

                context.SaveChanges();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load_emailtobeSent();
            run_timer_elapsed();


        }


        private void run_timer_elapsed()
        {
            //try
            //{
            //    using (AHPL_DBEntities context = new AHPL_DBEntities())
            //    {

            //        /// hourly email list 
            //        var qryEmailToBeSent = (from em in context.EmailsToBeSents
            //                                where em.IsEmailSent == false && em.Selected == true  && em.IsHourly == true
            //                                select em).ToList();
            //        foreach (var qry in qryEmailToBeSent)
            //        {
            //            bool emailSent = sendEmail(qry.CompanyID, qry.LocationID, qry.Subject, qry.Body, qry.CreatedBy,qry.Attachment);
            //            qry.IsEmailSent = emailSent;
            //            qry.EmailSentDate = DateTime.Now;
            //            //Application.DoEvents();
            //            //System.Threading.Thread.Sleep(5000);
            //            Thread.Sleep(3000);

            //        }

            //        context.SaveChanges();
            //    }

            //    load_emailtobeSent();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void xEmailApp_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == this.WindowState)
            //{


            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }

            //    mynotifyicon.Visible = true;
            //    mynotifyicon.ShowBalloonTip(500);
            //    this.Hide();
            //}

            //else if (FormWindowState.Normal == this.WindowState)
            //{
            //    mynotifyicon.Visible = false;
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void showEmailServiceApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }

    public class cUserEmailList
    {
        public string EmailAddress { get; set; }
        public Int64 EmailTobeSendID { get; set; }




        public int EmailAlertItemID { get; set; }

        public int CompanyID { get; set; }

        public int LocationID { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public byte[] Attachement { get; set; }

        public int CreatedBy { get; set; }

        public bool EmailSent { get; set; }

        public int ContractClauseID { get; set; }

        public int UserID { get; set; }
    }
}