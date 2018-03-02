using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSM.CMSMApp;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.Data.SqlClient;
using cc;
using System.Management;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using CMSMData;
using System.Xml;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;

namespace CMSM
{	
	/// <summary>
	/// Summary description for CMSMMain.
	/// </summary>
	public class CMSMMain : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 

		#region �������
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.Timer timerauto;
        log.CMSMLog clog = new CMSM.log.CMSMLog(Application.StartupPath + "\\log\\");
        private System.Windows.Forms.MenuItem mAsso;
        private System.Windows.Forms.MenuItem mAssoInfo;
        private System.Windows.Forms.MenuItem mAssoRecardQy;
        private System.Windows.Forms.MenuItem mAssoUplevel;
        private System.Windows.Forms.MenuItem mCard;
        private System.Windows.Forms.MenuItem mCardFill;
        private System.Windows.Forms.MenuItem mCardLose;
        private System.Windows.Forms.MenuItem mCardRelose;
        private System.Windows.Forms.MenuItem mCardAgain;
		private System.Windows.Forms.MenuItem mCardRecycle;
		private System.Windows.Forms.MenuItem mCardFillError;
		private System.Windows.Forms.MenuItem mCardRollbak;
        private System.Windows.Forms.MenuItem mCons;
        private System.Windows.Forms.MenuItem mConsAss;
        private System.Windows.Forms.MenuItem mConsRetail;
        private System.Windows.Forms.MenuItem mConsBank;
        private System.Windows.Forms.MenuItem mConsBespeak;
		private System.Windows.Forms.MenuItem mConsRemove;
		private System.Windows.Forms.MenuItem mConsRetailRemove;
        private System.Windows.Forms.MenuItem mConsReprint;
        private System.Windows.Forms.MenuItem mConsIgChange;
        private System.Windows.Forms.MenuItem mConsLargess;
        private System.Windows.Forms.MenuItem mConsLargessQy;
        private System.Windows.Forms.MenuItem mQuey;
        private System.Windows.Forms.MenuItem mQueyCons;
        private System.Windows.Forms.MenuItem mQueyFill;
        private System.Windows.Forms.MenuItem mQueyConsKind;
        private System.Windows.Forms.MenuItem mQueyOperLog;
        private System.Windows.Forms.MenuItem mQueyBusiIncome;
        private System.Windows.Forms.MenuItem mQueyConsGoodsTop;
        private System.Windows.Forms.MenuItem mSysm;
        private System.Windows.Forms.MenuItem mSysmGoodsMan;
        private System.Windows.Forms.MenuItem mSysmBasePara;
        private System.Windows.Forms.MenuItem mSysmOperMan;
        private System.Windows.Forms.MenuItem mSysmOperModPwd;
		private System.Windows.Forms.MenuItem mSysmDataToHis;
		private System.Windows.Forms.MenuItem mSysmDataToCenter;
        private System.Windows.Forms.MenuItem mSysmDatabaseBak;
		private System.Windows.Forms.MenuItem mEmpy;
		private System.Windows.Forms.MenuItem mEmpyInfo;
		private System.Windows.Forms.MenuItem mEmpySignIn;
		private System.Windows.Forms.MenuItem mEmpySignOut;
		private System.Windows.Forms.MenuItem mEmpySignSpec;
		private System.Windows.Forms.MenuItem mHelp;
		private System.Windows.Forms.MenuItem mHelpRefreshCardEq;
		private System.Windows.Forms.MenuItem mHelpRegist;
		private System.Windows.Forms.MenuItem mHelpContent;
		private System.Windows.Forms.MenuItem mHelpAbout;
        private System.Windows.Forms.MenuItem mExit;
		private System.Windows.Forms.MenuItem mExitDailyAccount;
		private System.Windows.Forms.MenuItem mExitRelogin;
        private System.Windows.Forms.MenuItem mExitSystem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mCardChargeUnion;
		private System.Windows.Forms.MenuItem mCardFillRemove;
        private System.Windows.Forms.MenuItem mConsSpecialDeal;
		private System.Windows.Forms.MenuItem mProductionInStorage;
		private System.Windows.Forms.MenuItem mSaleCheck;
        private System.Windows.Forms.MenuItem mSaleBalance;
        private ImageList imageList1;
        private Button KCardFill;
        private Label lblMainErr;
        private Button KAssoInfo;
        private Button kConsAss;
        private Button kConsRetail;
        private Button kConsLargess;
        private Button kConsSpecialDeal;
        private Button kProductionInStorage;
        private Button kSaleCheck;
        private Button kSysmDataToCenter;
        private MenuItem mCardChargeUnionRemove;
        private Button kHisSysmDataToCenter;
		#endregion

		public CMSMMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMSMMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mAsso = new System.Windows.Forms.MenuItem();
            this.mAssoInfo = new System.Windows.Forms.MenuItem();
            this.mAssoRecardQy = new System.Windows.Forms.MenuItem();
            this.mAssoUplevel = new System.Windows.Forms.MenuItem();
            this.mCard = new System.Windows.Forms.MenuItem();
            this.mCardFill = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.mCardLose = new System.Windows.Forms.MenuItem();
            this.mCardRelose = new System.Windows.Forms.MenuItem();
            this.mCardAgain = new System.Windows.Forms.MenuItem();
            this.mCardRecycle = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.mCardFillError = new System.Windows.Forms.MenuItem();
            this.mCardChargeUnion = new System.Windows.Forms.MenuItem();
            this.mCardFillRemove = new System.Windows.Forms.MenuItem();
            this.mCardRollbak = new System.Windows.Forms.MenuItem();
            this.mCardChargeUnionRemove = new System.Windows.Forms.MenuItem();
            this.mCons = new System.Windows.Forms.MenuItem();
            this.mConsAss = new System.Windows.Forms.MenuItem();
            this.mConsRetail = new System.Windows.Forms.MenuItem();
            this.mConsBank = new System.Windows.Forms.MenuItem();
            this.mConsBespeak = new System.Windows.Forms.MenuItem();
            this.mConsRemove = new System.Windows.Forms.MenuItem();
            this.mConsRetailRemove = new System.Windows.Forms.MenuItem();
            this.mConsSpecialDeal = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.mConsReprint = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mConsIgChange = new System.Windows.Forms.MenuItem();
            this.mConsLargess = new System.Windows.Forms.MenuItem();
            this.mConsLargessQy = new System.Windows.Forms.MenuItem();
            this.mProductionInStorage = new System.Windows.Forms.MenuItem();
            this.mSaleCheck = new System.Windows.Forms.MenuItem();
            this.mQuey = new System.Windows.Forms.MenuItem();
            this.mQueyCons = new System.Windows.Forms.MenuItem();
            this.mQueyFill = new System.Windows.Forms.MenuItem();
            this.mQueyConsKind = new System.Windows.Forms.MenuItem();
            this.mQueyOperLog = new System.Windows.Forms.MenuItem();
            this.mQueyBusiIncome = new System.Windows.Forms.MenuItem();
            this.mQueyConsGoodsTop = new System.Windows.Forms.MenuItem();
            this.mSaleBalance = new System.Windows.Forms.MenuItem();
            this.mSysm = new System.Windows.Forms.MenuItem();
            this.mSysmGoodsMan = new System.Windows.Forms.MenuItem();
            this.mSysmBasePara = new System.Windows.Forms.MenuItem();
            this.mSysmOperMan = new System.Windows.Forms.MenuItem();
            this.mSysmOperModPwd = new System.Windows.Forms.MenuItem();
            this.mSysmDataToHis = new System.Windows.Forms.MenuItem();
            this.mSysmDataToCenter = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mSysmDatabaseBak = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mEmpy = new System.Windows.Forms.MenuItem();
            this.mEmpyInfo = new System.Windows.Forms.MenuItem();
            this.mEmpySignIn = new System.Windows.Forms.MenuItem();
            this.mEmpySignOut = new System.Windows.Forms.MenuItem();
            this.mEmpySignSpec = new System.Windows.Forms.MenuItem();
            this.mHelp = new System.Windows.Forms.MenuItem();
            this.mHelpRefreshCardEq = new System.Windows.Forms.MenuItem();
            this.mHelpRegist = new System.Windows.Forms.MenuItem();
            this.mHelpContent = new System.Windows.Forms.MenuItem();
            this.mHelpAbout = new System.Windows.Forms.MenuItem();
            this.mExit = new System.Windows.Forms.MenuItem();
            this.mExitDailyAccount = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.mExitRelogin = new System.Windows.Forms.MenuItem();
            this.mExitSystem = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerauto = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.KCardFill = new System.Windows.Forms.Button();
            this.lblMainErr = new System.Windows.Forms.Label();
            this.KAssoInfo = new System.Windows.Forms.Button();
            this.kConsAss = new System.Windows.Forms.Button();
            this.kConsRetail = new System.Windows.Forms.Button();
            this.kConsLargess = new System.Windows.Forms.Button();
            this.kConsSpecialDeal = new System.Windows.Forms.Button();
            this.kProductionInStorage = new System.Windows.Forms.Button();
            this.kSaleCheck = new System.Windows.Forms.Button();
            this.kSysmDataToCenter = new System.Windows.Forms.Button();
            this.kHisSysmDataToCenter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mAsso,
            this.mCard,
            this.mCons,
            this.mQuey,
            this.mSysm,
            this.mEmpy,
            this.mHelp,
            this.mExit});
            // 
            // mAsso
            // 
            this.mAsso.Index = 0;
            this.mAsso.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mAssoInfo,
            this.mAssoRecardQy,
            this.mAssoUplevel});
            this.mAsso.Text = "��Ա��������";
            this.mAsso.Visible = false;
            // 
            // mAssoInfo
            // 
            this.mAssoInfo.Index = 0;
            this.mAssoInfo.Text = "��Ա��������";
            this.mAssoInfo.Visible = false;
            this.mAssoInfo.Click += new System.EventHandler(this.mAssoInfo_Click);
            // 
            // mAssoRecardQy
            // 
            this.mAssoRecardQy.Index = 1;
            this.mAssoRecardQy.Text = "���������";
            this.mAssoRecardQy.Visible = false;
            this.mAssoRecardQy.Click += new System.EventHandler(this.mAssoRecardQy_Click);
            // 
            // mAssoUplevel
            // 
            this.mAssoUplevel.Index = 2;
            this.mAssoUplevel.Text = "��Ա����";
            this.mAssoUplevel.Visible = false;
            this.mAssoUplevel.Click += new System.EventHandler(this.mAssoUplevel_Click);
            // 
            // mCard
            // 
            this.mCard.Index = 1;
            this.mCard.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mCardFill,
            this.menuItem7,
            this.mCardLose,
            this.mCardRelose,
            this.mCardAgain,
            this.mCardRecycle,
            this.menuItem22,
            this.mCardFillError,
            this.mCardChargeUnion,
            this.mCardFillRemove,
            this.mCardRollbak,
            this.mCardChargeUnionRemove});
            this.mCard.Text = "��Ա������";
            // 
            // mCardFill
            // 
            this.mCardFill.Index = 0;
            this.mCardFill.Text = "��Ա����ֵ";
            this.mCardFill.Click += new System.EventHandler(this.mCardFill_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "-";
            // 
            // mCardLose
            // 
            this.mCardLose.Index = 2;
            this.mCardLose.Text = "��Ա����ʧ";
            this.mCardLose.Click += new System.EventHandler(this.mCardLose_Click);
            // 
            // mCardRelose
            // 
            this.mCardRelose.Index = 3;
            this.mCardRelose.Text = "��Ա�����";
            this.mCardRelose.Click += new System.EventHandler(this.mCardRelose_Click);
            // 
            // mCardAgain
            // 
            this.mCardAgain.Index = 4;
            this.mCardAgain.Text = "��Ա������";
            this.mCardAgain.Click += new System.EventHandler(this.mCardAgain_Click);
            // 
            // mCardRecycle
            // 
            this.mCardRecycle.Index = 5;
            this.mCardRecycle.Text = "��Ա������";
            this.mCardRecycle.Click += new System.EventHandler(this.mCardRecycle_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 6;
            this.menuItem22.Text = "-";
            // 
            // mCardFillError
            // 
            this.mCardFillError.Index = 7;
            this.mCardFillError.Text = "����ֵ";
            this.mCardFillError.Click += new System.EventHandler(this.mCardFillError_Click);
            // 
            // mCardChargeUnion
            // 
            this.mCardChargeUnion.Index = 8;
            this.mCardChargeUnion.Text = "��Ա���ϲ�";
            this.mCardChargeUnion.Click += new System.EventHandler(this.mCardChargeUnion_Click);
            // 
            // mCardFillRemove
            // 
            this.mCardFillRemove.Index = 9;
            this.mCardFillRemove.Text = "��ֵ����";
            this.mCardFillRemove.Click += new System.EventHandler(this.mCardFillRemove_Click);
            // 
            // mCardRollbak
            // 
            this.mCardRollbak.Index = 10;
            this.mCardRollbak.Text = "��Ա������(ֱ�ӻ���)";
            this.mCardRollbak.Click += new System.EventHandler(this.mCardRollbak_Click);
            // 
            // mCardChargeUnionRemove
            // 
            this.mCardChargeUnionRemove.Index = 11;
            this.mCardChargeUnionRemove.Text = "ת��������";
            this.mCardChargeUnionRemove.Click += new System.EventHandler(this.mCardChargeUnionRemove_Click);
            // 
            // mCons
            // 
            this.mCons.Index = 2;
            this.mCons.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mConsAss,
            this.mConsRetail,
            this.mConsBank,
            this.mConsBespeak,
            this.mConsRemove,
            this.mConsRetailRemove,
            this.mConsSpecialDeal,
            this.menuItem15,
            this.mConsReprint,
            this.menuItem2,
            this.mConsIgChange,
            this.mConsLargess,
            this.mConsLargessQy,
            this.mProductionInStorage,
            this.mSaleCheck});
            this.mCons.Text = "����";
            this.mCons.Visible = false;
            // 
            // mConsAss
            // 
            this.mConsAss.Index = 0;
            this.mConsAss.Text = "��Ա����";
            this.mConsAss.Click += new System.EventHandler(this.mConsAss_Click);
            // 
            // mConsRetail
            // 
            this.mConsRetail.Index = 1;
            this.mConsRetail.Text = "�ǻ�Ա����";
            this.mConsRetail.Click += new System.EventHandler(this.mConsRetail_Click);
            // 
            // mConsBank
            // 
            this.mConsBank.Index = 2;
            this.mConsBank.Text = "���п�����";
            this.mConsBank.Click += new System.EventHandler(this.mConsBank_Click);
            // 
            // mConsBespeak
            // 
            this.mConsBespeak.Index = 3;
            this.mConsBespeak.Text = "����";
            this.mConsBespeak.Click += new System.EventHandler(this.mConsBespeak_Click);
            // 
            // mConsRemove
            // 
            this.mConsRemove.Index = 4;
            this.mConsRemove.Text = "��Ա���ѳ���";
            this.mConsRemove.Click += new System.EventHandler(this.mConsRemove_Click);
            // 
            // mConsRetailRemove
            // 
            this.mConsRetailRemove.Index = 5;
            this.mConsRetailRemove.Text = "�ǻ�Ա���ѳ���";
            this.mConsRetailRemove.Click += new System.EventHandler(this.mConsRetailRemove_Click);
            // 
            // mConsSpecialDeal
            // 
            this.mConsSpecialDeal.Index = 6;
            this.mConsSpecialDeal.Text = "��Ʒ��������";
            this.mConsSpecialDeal.Click += new System.EventHandler(this.mConsSpecialDeal_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 7;
            this.menuItem15.Text = "-";
            // 
            // mConsReprint
            // 
            this.mConsReprint.Index = 8;
            this.mConsReprint.Text = "���´�ӡСƱ";
            this.mConsReprint.Click += new System.EventHandler(this.mConsReprint_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 9;
            this.menuItem2.Text = "-";
            // 
            // mConsIgChange
            // 
            this.mConsIgChange.Index = 10;
            this.mConsIgChange.Text = "��Ա���ֶһ�";
            this.mConsIgChange.Click += new System.EventHandler(this.mConsIgChange_Click);
            // 
            // mConsLargess
            // 
            this.mConsLargess.Index = 11;
            this.mConsLargess.Text = "���ͻ�Ա��Ʒ";
            this.mConsLargess.Click += new System.EventHandler(this.mConsLargess_Click);
            // 
            // mConsLargessQy
            // 
            this.mConsLargessQy.Index = 12;
            this.mConsLargessQy.Text = "���ͻ�Ա��ѯ";
            this.mConsLargessQy.Click += new System.EventHandler(this.mConsLargessQy_Click);
            // 
            // mProductionInStorage
            // 
            this.mProductionInStorage.Index = 13;
            this.mProductionInStorage.Text = "�������";
            this.mProductionInStorage.Click += new System.EventHandler(this.mProductionInStorage_Click);
            // 
            // mSaleCheck
            // 
            this.mSaleCheck.Index = 14;
            this.mSaleCheck.Text = "�����̵�";
            this.mSaleCheck.Click += new System.EventHandler(this.mSaleCheck_Click);
            // 
            // mQuey
            // 
            this.mQuey.Index = 3;
            this.mQuey.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mQueyCons,
            this.mQueyFill,
            this.mQueyConsKind,
            this.mQueyOperLog,
            this.mQueyBusiIncome,
            this.mQueyConsGoodsTop,
            this.mSaleBalance});
            this.mQuey.Text = "ͳ�Ʋ�ѯ";
            // 
            // mQueyCons
            // 
            this.mQueyCons.Index = 0;
            this.mQueyCons.Text = "����ͳ�Ʊ���";
            this.mQueyCons.Click += new System.EventHandler(this.mQueyCons_Click);
            // 
            // mQueyFill
            // 
            this.mQueyFill.Index = 1;
            this.mQueyFill.Text = "��Ա��ֵ��ѯ";
            this.mQueyFill.Click += new System.EventHandler(this.mQueyFill_Click);
            // 
            // mQueyConsKind
            // 
            this.mQueyConsKind.Index = 2;
            this.mQueyConsKind.Text = "���ѷ���ͳ��";
            this.mQueyConsKind.Click += new System.EventHandler(this.mQueyConsKind_Click);
            // 
            // mQueyOperLog
            // 
            this.mQueyOperLog.Index = 3;
            this.mQueyOperLog.Text = "����Ա��־";
            this.mQueyOperLog.Click += new System.EventHandler(this.mQueyOperLog_Click);
            // 
            // mQueyBusiIncome
            // 
            this.mQueyBusiIncome.Index = 4;
            this.mQueyBusiIncome.Text = "ҵ��������";
            this.mQueyBusiIncome.Click += new System.EventHandler(this.mQueyBusiIncome_Click);
            // 
            // mQueyConsGoodsTop
            // 
            this.mQueyConsGoodsTop.Index = 5;
            this.mQueyConsGoodsTop.Text = "����������";
            this.mQueyConsGoodsTop.Click += new System.EventHandler(this.mQueyConsGoodsTop_Click);
            // 
            // mSaleBalance
            // 
            this.mSaleBalance.Index = 6;
            this.mSaleBalance.Text = "����ƽ���";
            this.mSaleBalance.Click += new System.EventHandler(this.mSaleBalance_Click);
            // 
            // mSysm
            // 
            this.mSysm.Index = 4;
            this.mSysm.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mSysmGoodsMan,
            this.mSysmBasePara,
            this.mSysmOperMan,
            this.mSysmOperModPwd,
            this.mSysmDataToHis,
            this.mSysmDataToCenter,
            this.menuItem5,
            this.mSysmDatabaseBak,
            this.menuItem1});
            this.mSysm.Text = "ϵͳ����";
            // 
            // mSysmGoodsMan
            // 
            this.mSysmGoodsMan.Index = 0;
            this.mSysmGoodsMan.Text = "��Ʒ����";
            this.mSysmGoodsMan.Click += new System.EventHandler(this.mSysmGoodsMan_Click);
            // 
            // mSysmBasePara
            // 
            this.mSysmBasePara.Index = 1;
            this.mSysmBasePara.Text = "ϵͳ����";
            this.mSysmBasePara.Click += new System.EventHandler(this.mSysmBasePara_Click);
            // 
            // mSysmOperMan
            // 
            this.mSysmOperMan.Index = 2;
            this.mSysmOperMan.Text = "����Ա����";
            this.mSysmOperMan.Click += new System.EventHandler(this.mSysmOperMan_Click);
            // 
            // mSysmOperModPwd
            // 
            this.mSysmOperModPwd.Index = 3;
            this.mSysmOperModPwd.Text = "�����޸�";
            this.mSysmOperModPwd.Visible = false;
            this.mSysmOperModPwd.Click += new System.EventHandler(this.mSysmOperModPwd_Click);
            // 
            // mSysmDataToHis
            // 
            this.mSysmDataToHis.Index = 4;
            this.mSysmDataToHis.Text = "����ת��";
            this.mSysmDataToHis.Visible = false;
            this.mSysmDataToHis.Click += new System.EventHandler(this.mSysmDataToHis_Click);
            // 
            // mSysmDataToCenter
            // 
            this.mSysmDataToCenter.Index = 5;
            this.mSysmDataToCenter.Text = "����ͬ��";
            this.mSysmDataToCenter.Click += new System.EventHandler(this.mSysmDataToCenter_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.Text = "-";
            // 
            // mSysmDatabaseBak
            // 
            this.mSysmDatabaseBak.Index = 7;
            this.mSysmDatabaseBak.Text = "���ݿⱸ��";
            this.mSysmDatabaseBak.Visible = false;
            this.mSysmDatabaseBak.Click += new System.EventHandler(this.mSysmDatabaseBak_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 8;
            this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.AltF8;
            this.menuItem1.Text = "ͬ����ʷ����";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mEmpy
            // 
            this.mEmpy.Index = 5;
            this.mEmpy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mEmpyInfo,
            this.mEmpySignIn,
            this.mEmpySignOut,
            this.mEmpySignSpec});
            this.mEmpy.Text = "Ա������";
            // 
            // mEmpyInfo
            // 
            this.mEmpyInfo.Index = 0;
            this.mEmpyInfo.Text = "Ա����������";
            this.mEmpyInfo.Click += new System.EventHandler(this.mEmpyInfo_Click);
            // 
            // mEmpySignIn
            // 
            this.mEmpySignIn.Index = 1;
            this.mEmpySignIn.Text = "ǩ��";
            this.mEmpySignIn.Click += new System.EventHandler(this.mEmpySignIn_Click);
            // 
            // mEmpySignOut
            // 
            this.mEmpySignOut.Index = 2;
            this.mEmpySignOut.Text = "ǩ��";
            this.mEmpySignOut.Click += new System.EventHandler(this.mEmpySignOut_Click);
            // 
            // mEmpySignSpec
            // 
            this.mEmpySignSpec.Index = 3;
            this.mEmpySignSpec.Text = "�������";
            this.mEmpySignSpec.Click += new System.EventHandler(this.mEmpySignSpec_Click);
            // 
            // mHelp
            // 
            this.mHelp.Index = 6;
            this.mHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mHelpRefreshCardEq,
            this.mHelpRegist,
            this.mHelpContent,
            this.mHelpAbout});
            this.mHelp.Text = "����";
            // 
            // mHelpRefreshCardEq
            // 
            this.mHelpRefreshCardEq.Index = 0;
            this.mHelpRefreshCardEq.Text = "ˢ�¶�����ʱ��";
            this.mHelpRefreshCardEq.Click += new System.EventHandler(this.mHelpRefreshCardEq_Click);
            // 
            // mHelpRegist
            // 
            this.mHelpRegist.Index = 1;
            this.mHelpRegist.Text = "ע��";
            this.mHelpRegist.Click += new System.EventHandler(this.mHelpRegist_Click);
            // 
            // mHelpContent
            // 
            this.mHelpContent.Index = 2;
            this.mHelpContent.Text = "��������";
            this.mHelpContent.Click += new System.EventHandler(this.mHelpContent_Click);
            // 
            // mHelpAbout
            // 
            this.mHelpAbout.Index = 3;
            this.mHelpAbout.Text = "����";
            this.mHelpAbout.Click += new System.EventHandler(this.mHelpAbout_Click);
            // 
            // mExit
            // 
            this.mExit.Index = 7;
            this.mExit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mExitDailyAccount,
            this.menuItem9,
            this.mExitRelogin,
            this.mExitSystem});
            this.mExit.Text = "�˳�ϵͳ";
            // 
            // mExitDailyAccount
            // 
            this.mExitDailyAccount.Index = 0;
            this.mExitDailyAccount.Text = "�������";
            this.mExitDailyAccount.Click += new System.EventHandler(this.mExitDailyAccount_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // mExitRelogin
            // 
            this.mExitRelogin.Index = 2;
            this.mExitRelogin.Text = "ע��";
            this.mExitRelogin.Click += new System.EventHandler(this.mExitRelogin_Click);
            // 
            // mExitSystem
            // 
            this.mExitSystem.Index = 3;
            this.mExitSystem.Text = "�˳�";
            this.mExitSystem.Click += new System.EventHandler(this.mExitSystem_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 615);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel4,
            this.statusBarPanel5,
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1196, 22);
            this.statusBar1.TabIndex = 9;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "��ӭʹ�õ�Ѷ�Ƽ���Ա����ϵͳ";
            this.statusBarPanel4.Width = 235;
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Text = "�ŵ꣺";
            this.statusBarPanel5.Width = 235;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "����Ա��";
            this.statusBarPanel1.Width = 235;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "��ǰλ�ã�";
            this.statusBarPanel2.Width = 235;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "ʱ�䣺";
            this.statusBarPanel3.Width = 235;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1196, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerauto
            // 
            this.timerauto.Enabled = true;
            this.timerauto.Tick += new System.EventHandler(this.timerauto_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "��Ա����48.png");
            this.imageList1.Images.SetKeyName(1, "��ֵ1.png");
            this.imageList1.Images.SetKeyName(2, "��Ա����.png");
            this.imageList1.Images.SetKeyName(3, "����.png");
            this.imageList1.Images.SetKeyName(4, "��Ա����.png");
            this.imageList1.Images.SetKeyName(5, "�����Ʒ����.png");
            this.imageList1.Images.SetKeyName(6, "�������.png");
            this.imageList1.Images.SetKeyName(7, "�̵�.png");
            this.imageList1.Images.SetKeyName(8, "��ʷ�����ϴ�.png");
            this.imageList1.Images.SetKeyName(9, "�����ϴ�.png");
            // 
            // KCardFill
            // 
            this.KCardFill.ImageIndex = 1;
            this.KCardFill.ImageList = this.imageList1;
            this.KCardFill.Location = new System.Drawing.Point(423, 10);
            this.KCardFill.Name = "KCardFill";
            this.KCardFill.Size = new System.Drawing.Size(48, 48);
            this.KCardFill.TabIndex = 16;
            this.KCardFill.UseVisualStyleBackColor = true;
            this.KCardFill.Click += new System.EventHandler(this.KCardFill_Click);
            // 
            // lblMainErr
            // 
            this.lblMainErr.BackColor = System.Drawing.SystemColors.Control;
            this.lblMainErr.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainErr.ForeColor = System.Drawing.Color.Red;
            this.lblMainErr.Location = new System.Drawing.Point(-3, 24);
            this.lblMainErr.Name = "lblMainErr";
            this.lblMainErr.Size = new System.Drawing.Size(144, 23);
            this.lblMainErr.TabIndex = 12;
            this.lblMainErr.Visible = false;
            // 
            // KAssoInfo
            // 
            this.KAssoInfo.BackColor = System.Drawing.Color.Transparent;
            this.KAssoInfo.ImageIndex = 0;
            this.KAssoInfo.ImageList = this.imageList1;
            this.KAssoInfo.Location = new System.Drawing.Point(372, 10);
            this.KAssoInfo.Name = "KAssoInfo";
            this.KAssoInfo.Size = new System.Drawing.Size(48, 48);
            this.KAssoInfo.TabIndex = 17;
            this.KAssoInfo.UseVisualStyleBackColor = false;
            this.KAssoInfo.Click += new System.EventHandler(this.KAssoInfo_Click);
            // 
            // kConsAss
            // 
            this.kConsAss.ImageIndex = 2;
            this.kConsAss.ImageList = this.imageList1;
            this.kConsAss.Location = new System.Drawing.Point(475, 10);
            this.kConsAss.Name = "kConsAss";
            this.kConsAss.Size = new System.Drawing.Size(48, 48);
            this.kConsAss.TabIndex = 19;
            this.kConsAss.UseVisualStyleBackColor = true;
            this.kConsAss.Click += new System.EventHandler(this.kConsAss_Click);
            // 
            // kConsRetail
            // 
            this.kConsRetail.ImageIndex = 3;
            this.kConsRetail.ImageList = this.imageList1;
            this.kConsRetail.Location = new System.Drawing.Point(527, 10);
            this.kConsRetail.Name = "kConsRetail";
            this.kConsRetail.Size = new System.Drawing.Size(48, 48);
            this.kConsRetail.TabIndex = 20;
            this.kConsRetail.UseVisualStyleBackColor = true;
            this.kConsRetail.Click += new System.EventHandler(this.kConsRetail_Click);
            // 
            // kConsLargess
            // 
            this.kConsLargess.ImageIndex = 4;
            this.kConsLargess.ImageList = this.imageList1;
            this.kConsLargess.Location = new System.Drawing.Point(578, 10);
            this.kConsLargess.Name = "kConsLargess";
            this.kConsLargess.Size = new System.Drawing.Size(48, 48);
            this.kConsLargess.TabIndex = 21;
            this.kConsLargess.UseVisualStyleBackColor = true;
            this.kConsLargess.Click += new System.EventHandler(this.kConsLargess_Click);
            // 
            // kConsSpecialDeal
            // 
            this.kConsSpecialDeal.ImageIndex = 5;
            this.kConsSpecialDeal.ImageList = this.imageList1;
            this.kConsSpecialDeal.Location = new System.Drawing.Point(648, 10);
            this.kConsSpecialDeal.Name = "kConsSpecialDeal";
            this.kConsSpecialDeal.Size = new System.Drawing.Size(48, 48);
            this.kConsSpecialDeal.TabIndex = 23;
            this.kConsSpecialDeal.UseVisualStyleBackColor = true;
            this.kConsSpecialDeal.Click += new System.EventHandler(this.kConsSpecialDeal_Click);
            // 
            // kProductionInStorage
            // 
            this.kProductionInStorage.ImageIndex = 6;
            this.kProductionInStorage.ImageList = this.imageList1;
            this.kProductionInStorage.Location = new System.Drawing.Point(698, 11);
            this.kProductionInStorage.Name = "kProductionInStorage";
            this.kProductionInStorage.Size = new System.Drawing.Size(48, 48);
            this.kProductionInStorage.TabIndex = 24;
            this.kProductionInStorage.UseVisualStyleBackColor = true;
            this.kProductionInStorage.Click += new System.EventHandler(this.kProductionInStorage_Click);
            // 
            // kSaleCheck
            // 
            this.kSaleCheck.ImageIndex = 7;
            this.kSaleCheck.ImageList = this.imageList1;
            this.kSaleCheck.Location = new System.Drawing.Point(749, 11);
            this.kSaleCheck.Name = "kSaleCheck";
            this.kSaleCheck.Size = new System.Drawing.Size(48, 48);
            this.kSaleCheck.TabIndex = 25;
            this.kSaleCheck.UseVisualStyleBackColor = true;
            this.kSaleCheck.Click += new System.EventHandler(this.kSaleCheck_Click);
            // 
            // kSysmDataToCenter
            // 
            this.kSysmDataToCenter.ImageIndex = 9;
            this.kSysmDataToCenter.ImageList = this.imageList1;
            this.kSysmDataToCenter.Location = new System.Drawing.Point(799, 11);
            this.kSysmDataToCenter.Name = "kSysmDataToCenter";
            this.kSysmDataToCenter.Size = new System.Drawing.Size(48, 48);
            this.kSysmDataToCenter.TabIndex = 26;
            this.kSysmDataToCenter.UseVisualStyleBackColor = true;
            this.kSysmDataToCenter.Click += new System.EventHandler(this.kSysmDataToCenter_Click);
            // 
            // kHisSysmDataToCenter
            // 
            this.kHisSysmDataToCenter.ImageIndex = 8;
            this.kHisSysmDataToCenter.ImageList = this.imageList1;
            this.kHisSysmDataToCenter.Location = new System.Drawing.Point(850, 11);
            this.kHisSysmDataToCenter.Name = "kHisSysmDataToCenter";
            this.kHisSysmDataToCenter.Size = new System.Drawing.Size(48, 48);
            this.kHisSysmDataToCenter.TabIndex = 27;
            this.kHisSysmDataToCenter.UseVisualStyleBackColor = true;
            this.kHisSysmDataToCenter.Click += new System.EventHandler(this.kHisSysmDataToCenter_Click);
            // 
            // CMSMMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1196, 637);
            this.Controls.Add(this.kHisSysmDataToCenter);
            this.Controls.Add(this.kSysmDataToCenter);
            this.Controls.Add(this.kSaleCheck);
            this.Controls.Add(this.kProductionInStorage);
            this.Controls.Add(this.kConsSpecialDeal);
            this.Controls.Add(this.kConsLargess);
            this.Controls.Add(this.kConsRetail);
            this.Controls.Add(this.kConsAss);
            this.Controls.Add(this.KAssoInfo);
            this.Controls.Add(this.KCardFill);
            this.Controls.Add(this.lblMainErr);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusBar1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "CMSMMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "������Ա����ϵͳ";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CMSMMain_Closing);
            this.Load += new System.EventHandler(this.CMSMMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
#if !DEBUG
            System.Diagnostics.Process[] proCM = System.Diagnostics.Process.GetProcessesByName("CMSM");
            //System.Diagnostics.Process[] proCM = System.Diagnostics.Process.GetProcessesByName("CMSM.vshost");
#else

            System.Diagnostics.Process[] proCM = System.Diagnostics.Process.GetProcessesByName("CMSM.vshost");
#endif
            if (proCM.Length==1)
			{
				//DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new CMSM.Report.ChineaseReportLocalizer();
				Application.Run(new CMSMMain());
			}
		}

		
		#region encode Column convert to Chinise
		protected string GetColCh(string strCode,string tabName)
		{
			string colch="";
			DataView dv = new DataView(SysInitial.dsSys.Tables[tabName]);
			dv.Sort = "vcCommCode";
			colch = dv[dv.Find(strCode)]["vcCommName"].ToString().Trim();
			return colch;
		}
		#endregion

		#region �������
		private void CMSMMain_Load(object sender, System.EventArgs e)
		{
			if(IsUpdate())
			{
				//this.Close();
				Application.Exit();				
				Process.Start("AutoUpdate.exe");
				return;
			}

			this.Visible=false;

			if(File.Exists(Application.StartupPath+@"\BatchScript_1433.bat"))
			{
				Process.Start("BatchScript_1433.bat");
			}

			if(File.Exists(Application.StartupPath+@"\BatchScript.bat")&&File.Exists(Application.StartupPath+@"\Script.sql"))
			{
				Process.Start("BatchScript.bat");
			}

			if(File.Exists(Application.StartupPath+@"\AutoUpdate.exe.delete"))
			{
				File.Delete(Application.StartupPath+@"\AutoUpdate.exe.delete");
			}
			
			//ϵͳ��ʼ��
			Exception err=null;
			SysInitial.desConstring(Application.StartupPath);

			if(IsAmsSync())
			{
				//���±�ṹ 20140311 zhh
				UpdateSqlServer(SysInitial.ConString);
			}
			string aa=SysInitial.Local;

			if(IsAmsSync())
			{
                SysInitial.GetLocalDept(out err);
				Form formdown=new frmAfterStartDown();
				formdown.ShowDialog();
			}
			if(SysInitial.strTmp=="ExitApp")
			{
				SysInitial.strTmp="";
				Application.Exit();
				return;
			}
			if(SysInitial.strTmp=="EnterSys")
			{
				SysInitial.strTmp="";
			}

			SysInitial.CreatDS(out err);
			if(err!=null)
			{
				MessageBox.Show("ϵͳ��ʼ�������������Ա��ϵ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				Application.Exit();
				return;
			}

			if(SysInitial.LocalDept=="")
			{
				Form form1=new frmDeptSet();
				form1.ShowDialog();
                this.Close();
                Application.Exit();
			}

            //while(SysInitial.dsSys.Tables["Oper"].Rows.Count==0)
            //{
            //    MessageBox.Show("û���κβ���Ա��¼�����ȴ�������Ա��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
            //    Form formfirst=new frmOperFirst();
            //    formfirst.ShowDialog();
            //}

			//��¼
            Form form = new frmLogin();
            form.ShowDialog();

			if(SysInitial.CurOps.strOperID==null||SysInitial.CurOps.strOperID=="")
			{
				Application.Exit();
				return;
			}

			//���������壬��֤ע����Ϣ
			statusBarPanel1.Text="����Ա��" + SysInitial.CurOps.strOperName;
			statusBarPanel2.Text="��ǰλ�ã�������";
			statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
			statusBarPanel5.Text="�ŵ꣺" + this.GetColCh(SysInitial.CurOps.strDeptID,"MD");
			this.Text=SysInitial.CP + "������Ա����ϵͳ";
			#region Ĭ�ϲ���ʾ����
            mAsso.Visible = false;
            this.mAssoInfo.Visible = false;
			mAssoRecardQy.Visible=false;
			mAssoUplevel.Visible=false;
			mCard.Visible=false;
			this.mCardAgain.Visible=false;
			this.mCardFill.Visible=false;
			this.mCardFillError.Visible=false;
			this.mCardLose.Visible=false;
			this.mCardRecycle.Visible=false;
			this.mCardRelose.Visible=false;
			this.mCardRollbak.Visible=false;
            this.mCardFillRemove.Visible = false;
            this.mCardChargeUnionRemove.Visible = false;
			mCons.Visible=false;
			this.mConsAss.Visible=false;
			this.mConsBank.Visible=false;
			this.mConsBespeak.Visible=false;
			this.mConsIgChange.Visible=false;
			this.mConsLargess.Visible=false;
			this.mConsLargessQy.Visible=false;
			this.mConsRemove.Visible=false;
			this.mConsReprint.Visible=false;
			this.mConsRetail.Visible=false;
			this.mConsRetailRemove.Visible=false;
			this.mConsSpecialDeal.Visible=false;
			mQuey.Visible=false;
			this.mQueyBusiIncome.Visible=false;
			this.mQueyCons.Visible=false;
			this.mQueyConsGoodsTop.Visible=false;
			this.mQueyConsKind.Visible=false;
			this.mQueyFill.Visible=false;
			this.mQueyOperLog.Visible=false;
			mSysm.Visible=true;
			this.mSysmBasePara.Visible=false;
			this.mSysmDatabaseBak.Visible=false;
			this.mSysmDataToCenter.Visible=true;
			this.mSysmDataToHis.Visible=false;
			this.mSysmGoodsMan.Visible=false;
			this.mSysmOperMan.Visible=false;
			this.mSysmOperModPwd.Visible=false;
			mEmpy.Visible=false;
			this.mEmpyInfo.Visible=false;
			this.mEmpySignIn.Visible=false;
			this.mEmpySignOut.Visible=false;
			this.mEmpySignSpec.Visible=false;
			mExitDailyAccount.Visible=false;
            
            this.kConsAss.Visible = false;
            this.kConsLargess.Visible = false;
            this.kConsRetail.Visible = false;
            this.KCardFill.Visible = false;
            this.KAssoInfo.Visible = false;
            this.kConsSpecialDeal.Visible = false;
            this.kProductionInStorage.Visible = false;
            this.kSaleCheck.Visible = false;
            
			
			#endregion

			#region ��Ϣ
			bool _exist=false;
            string strInfo="";
            string strMyName = "";
            string strMyNameTmp = "";
			string str_nb1,str_nb2,str_nb3,str_nb4,str_nb5;
			string str_ss1,str_ss2,str_ss3,str_ss4,str_ss5;
			if (statusBarPanel1.Text=="����Ա���޻���OOOOO"||statusBarPanel1.Text=="����Ա��ϵͳ����ԱOOO")
			{
                strInfo = "5VD3Slhg";
				_exist=true;
			}
			else
			{
                //HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); 
                //str_SerialNumber=hdd.SerialNumber.ToString();
                ManagementClass cimobject = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = cimobject.GetInstances();
                
                foreach (ManagementObject mo in moc)
                {
                    strInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                strMyName = Dns.GetHostName();
                strMyNameTmp = strMyName + strInfo;
                strMyName = "ynkm" + strMyName + strInfo + "dxkj";
			}

            str_nb1 = strMyName.Substring(28, 1);
            str_nb2 = strMyName.Substring(21, 1);
            str_nb3 = strMyName.Substring(14, 1);
            str_nb4 = strMyName.Substring(7, 1);
            str_nb5 = strMyName.Substring(0, 1);
            strMyName = str_nb1 + str_nb2 + str_nb3 + str_nb4 + str_nb5;

			
            string strsn = "";

            //��ȡע����
            DESEncryptor dese1 = new DESEncryptor();
            dese1.InputString = strMyNameTmp;
            dese1.EncryptKey = "lhgynkm0";
            dese1.DesEncrypt();
            string miWenSerial = dese1.OutString;
            dese1 = null;
            CommAccess access = new CommAccess(SysInitial.ConString);
            strsn = access.GetRegister(miWenSerial, out err);
            if (strsn != "")
            {
                _exist = true;
            }
			if (_exist)
			{
				string mingWen="";
				if (statusBarPanel1.Text=="����Ա������Ա"||statusBarPanel1.Text=="����Ա��ϵͳ����Ա")
				{
					mingWen="H3259-7L240-71S44-47936-9176D";
				}
				else
				{
                    DESEncryptor dese2= new DESEncryptor();
					dese2.InputString=strsn;
					dese2.DecryptKey="lhgynkm0";
					dese2.DesDecrypt();
					mingWen=dese2.OutString;
					dese1=null;
				}
				if(mingWen==null)
				{
                    MessageBox.Show("��δע�ᣬ��Щ���ܻ�������002��", "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					str_ss1=mingWen.Substring(28,1);
					str_ss2=mingWen.Substring(21,1);
					str_ss3=mingWen.Substring(14,1);
					str_ss4=mingWen.Substring(7,1);
					str_ss5=mingWen.Substring(0,1);
                    mingWen = str_ss1 + str_ss2 + str_ss3 + str_ss4 + str_ss5;
                    if (strMyName == mingWen)
					{
						mHelpRegist.Enabled=false;
						if(!SysInitial.hsOperFunc.ContainsKey(SysInitial.CurOps.strOperID))
						{
							MessageBox.Show("����ԱȨ����ϢΪ�գ��������������Ƿ������Ȩ�ޣ����������ظ��£�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						}
						else
						{
							Hashtable hsmenuhead=new Hashtable();
							ArrayList alfunc=(ArrayList)SysInitial.hsOperFunc[SysInitial.CurOps.strOperID];
							foreach(MenuItem mi1 in this.mainMenu1.MenuItems)
							{
								foreach(MenuItem mi2 in mi1.MenuItems)
								{
									for(int k=0;k<alfunc.Count;k++)
									{
										CMSMStruct.OperFuncStruct ops=(CMSMStruct.OperFuncStruct)alfunc[k];
										if(mi2.Text==ops.strFuncName)
										{
											mi2.Visible=true;
                                            clsShortcut clsshcut = new clsShortcut();
                                            if (clsshcut.hsshortcut.ContainsKey(mi2.Text.ToString()))
                                            {
                                                switch (clsshcut.hsshortcut[mi2.Text.ToString()].ToString())
                                                {
                                                    case "Alt0":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt0;
                                                        this.KAssoInfo.Visible = true;
                                                        break;
                                                    case "Alt1":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt1;
                                                        this.KCardFill.Visible = true;
                                                        break;
                                                    case "Alt2":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt2;
                                                        this.kConsAss.Visible = true;
                                                        break;
                                                    case "Alt3":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt3;
                                                        this.kConsRetail.Visible = true;
                                                        break;
                                                    case "Alt4":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt4;
                                                        this.kConsLargess.Visible = true;
                                                        break;
                                                    case "Alt5":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt5;
                                                        this.kConsSpecialDeal.Visible = true;
                                                        break;
                                                    case "Alt6":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt6;
                                                        this.kProductionInStorage.Visible = true;
                                                        break;
                                                    case "Alt7":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt7;
                                                        this.kSaleCheck.Visible = true;
                                                        break;
                                                    case "Alt8":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt8;
                                                        this.kHisSysmDataToCenter.Visible = true;
                                                        break;
                                                    case "Alt9":
                                                        mi2.Shortcut = System.Windows.Forms.Shortcut.Alt9;
                                                        this.kSysmDataToCenter.Visible = true;
                                                        break;
                                                }
                                            }
                                            

											if(!hsmenuhead.ContainsKey(ops.strFuncAddress.Substring(0,5)))
											{
												hsmenuhead.Add(ops.strFuncAddress.Substring(0,5),ops.strFuncAddress.Substring(0,5));
											}
										}
									}
								}
							}
							foreach(DictionaryEntry de in hsmenuhead)
							{
								switch(de.Key.ToString())
								{
									case "mAsso":
										this.mAsso.Visible=true;
										break;
									case "mCard":
										this.mCard.Visible=true;
										break;
									case "mCons":
										this.mCons.Visible=true;
										break;
									case "mQuey":
										this.mQuey.Visible=true;
										break;
									case "mSysm":
										this.mSysm.Visible=true;
										break;
									case "mEmpy":
										this.mEmpy.Visible=true;
										break;
								}
							}
							
						}
					}
					else
					{
                        MessageBox.Show("��δע�ᣬ��Щ���ܻ�������003��", "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
					}
				}
			}
			else
			{
                MessageBox.Show("��δע�ᣬ��Щ���ܻ�������001��", "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
			#endregion

			CommAccess ca=new CommAccess(SysInitial.ConString);
			err=null;
			ca.CreatRetailAss(SysInitial.LocalDept,out err);
			if(err!=null)
			{
				MessageBox.Show("û�����ۿͻ���Ϣ�����������г���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			this.WindowState=System.Windows.Forms.FormWindowState.Maximized;
			this.Visible=true;
			
			string filedown=@"c:\\BreadDataBak\\DownLoad\\";
			string fileup=@"c:\\BreadDataBak\\UpLoad\\";
			if (statusBarPanel1.Text!="����Ա��ϵͳ����Ա")
			{
				if(!System.IO.Directory.Exists(filedown))
				{
					System.IO.Directory.CreateDirectory(filedown);
				}
				if(!System.IO.Directory.Exists(fileup))
				{
					System.IO.Directory.CreateDirectory(fileup);
				}

			}

			if(IsAmsSync())
			{
				this.timerauto.Interval=10*60*1000;
				this.timerauto.Enabled=true;
				this.timerauto.Start();
			}
		}
		#endregion

		#region ��ʾ�Ӵ��庯��
		private void formShow(Form form)
		{
			if(form!=null)
			{
				if(this.ActiveMdiChild != form)
				{
					if(this.ActiveMdiChild!=null)
					{
						this.ActiveMdiChild.Close();
					}
					statusBarPanel2.Text="��ǰλ�ã�" + form.Text.Trim();
					form.MdiParent=this;
					form.StartPosition = FormStartPosition.CenterScreen;
                    if(form.WindowState== FormWindowState.Maximized)
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.Show();
                        form.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        form.Show();
                    }
                    
					//form.Focus();
				}
			}
		}
		#endregion

		#region �˵��͵������¼�
        
		private void mExitSystem_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Application.Exit();
		}

        private void mCardChargeUnionRemove_Click(object sender, EventArgs e)
        {
            Form form = new frmCardChargeUnionRemove();
            formShow(form);
        }

		private void mAssoRecardQy_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRollAssInfo();
			formShow(form);
		}
		private void mConsSpecialDeal_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSpecialCons();
			formShow(form);
		}
		private void mCardChargeUnion_Click(object sender, System.EventArgs e)
		{
			Form form=new frmCardChargeUnion();
			formShow(form);	
		}

		private void mAssoInfo_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssInfo();
			formShow(form);
		}

		private void mCardFill_Click(object sender, System.EventArgs e)
		{
			Form form=new frmFillFeeByCard();
			formShow(form);
		}

		private void mCardLose_Click(object sender, System.EventArgs e)
		{
			Form form=new frmCardLose();
			formShow(form);
		}

		private void mCardAgain_Click(object sender, System.EventArgs e)
		{
			Form form=new frmCardAgain();
			formShow(form);
		}


		private void mConsAss_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssCons();
			formShow(form);
		}

		private void mSysmGoodsMan_Click(object sender, System.EventArgs e)
		{
			Form form=new frmGoods();
			formShow(form);
		}

		private void mConsReprint_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRepeatPrint();
			formShow(form);
		}

		private void mConsRetail_Click(object sender, System.EventArgs e)
		{
			frmRetailCons form=new frmRetailCons("PT002");
			formShow(form);
		}

		private void mConsRemove_Click(object sender, EventArgs e)
		{
			Form form=new frmAssConsRemove();
			formShow(form);
		}

		private void mSysmBasePara_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSysSet();
			form.ShowDialog();
		}

		private void mSysmOperMan_Click(object sender, System.EventArgs e)
		{
			Form form=new frmOper();
			formShow(form);
		}

		private void mCardRecycle_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRollCard();
			formShow(form);
		}

		private void mConsIgChange_Click(object sender, System.EventArgs e)
		{
			Form form=new frmIntegralChange();
			formShow(form);
		}

		private void mQueyCons_Click(object sender, System.EventArgs e)
		{
			Form form=new frmConsQuery();
			formShow(form);
		}

		private void mQueyFill_Click(object sender, System.EventArgs e)
		{
			Form form=new frmFillQuery();
			formShow(form);
		}
		private void mCardRelose_Click(object sender, System.EventArgs e)
		{
			Form form=new FrmCardRelease();
			formShow(form);
		}
        private void KCardFill_Click(object sender, EventArgs e)
        {
            Form form = new frmFillFeeByCard();
            formShow(form);
        }

        private void KAssoInfo_Click(object sender, EventArgs e)
        {
            Form form = new frmAssInfo();
            formShow(form);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void kConsAss_Click(object sender, EventArgs e)
        {
            Form form = new frmAssCons();
            formShow(form);
        }

        private void kConsRetail_Click(object sender, EventArgs e)
        {
            frmRetailCons form = new frmRetailCons("PT002");
            formShow(form);
        }

        private void kConsLargess_Click(object sender, EventArgs e)
        {
            Form form = new frmAssLargess();
            formShow(form);
        }

		

		#region ע��
		private void mExitRelogin_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close();
			}
			Form form=new frmLogin();
			form.ShowDialog();
			if(SysInitial.ReLoginFlag)
			{
				if(SysInitial.CurOps.strOperID!=SysInitial.NewOps.strOperID)
				{
					SysInitial.NewOps.strOperID=SysInitial.CurOps.strOperID;
					SysInitial.NewOps.strOperName=SysInitial.CurOps.strOperName;
					SysInitial.NewOps.strLimit=SysInitial.CurOps.strLimit;
					SysInitial.NewOps.strPwd=SysInitial.CurOps.strPwd;
					SysInitial.NewOps.strDeptID=SysInitial.CurOps.strDeptID;
					statusBarPanel1.Text="����Ա��" + SysInitial.CurOps.strOperName;
					statusBarPanel2.Text="��ǰλ�ã�������";
					statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
					statusBarPanel5.Text="�ŵ꣺" + this.GetColCh(SysInitial.CurOps.strDeptID,"MD");
					#region Ĭ�ϲ���ʾ����
                    mAsso.Visible = false;
                    this.mAssoInfo.Visible = false;
                    mAssoRecardQy.Visible = false;
                    mAssoUplevel.Visible = false;
                    mCard.Visible = false;
                    this.mCardAgain.Visible = false;
                    this.mCardFill.Visible = false;
                    this.mCardFillError.Visible = false;
                    this.mCardLose.Visible = false;
                    this.mCardRecycle.Visible = false;
                    this.mCardRelose.Visible = false;
                    this.mCardRollbak.Visible = false;
                    this.mCardChargeUnionRemove.Visible = false;
                    mCons.Visible = false;
                    this.mConsAss.Visible = false;
                    this.mConsBank.Visible = false;
                    this.mConsBespeak.Visible = false;
                    this.mConsIgChange.Visible = false;
                    this.mConsLargess.Visible = false;
                    this.mConsLargessQy.Visible = false;
                    this.mConsRemove.Visible = false;
                    this.mConsReprint.Visible = false;
                    this.mConsRetail.Visible = false;
                    this.mConsRetailRemove.Visible = false;
                    this.mConsSpecialDeal.Visible = false;
                    mQuey.Visible = false;
                    this.mQueyBusiIncome.Visible = false;
                    this.mQueyCons.Visible = false;
                    this.mQueyConsGoodsTop.Visible = false;
                    this.mQueyConsKind.Visible = false;
                    this.mQueyFill.Visible = false;
                    this.mQueyOperLog.Visible = false;
                    mSysm.Visible = true;
                    this.mSysmBasePara.Visible = false;
                    this.mSysmDatabaseBak.Visible = false;
                    this.mSysmDataToCenter.Visible = true;
                    this.mSysmDataToHis.Visible = false;
                    this.mSysmGoodsMan.Visible = false;
                    this.mSysmOperMan.Visible = false;
                    this.mSysmOperModPwd.Visible = false;
                    mEmpy.Visible = false;
                    this.mEmpyInfo.Visible = false;
                    this.mEmpySignIn.Visible = false;
                    this.mEmpySignOut.Visible = false;
                    this.mEmpySignSpec.Visible = false;
                    mExitDailyAccount.Visible = false;

                    this.kConsAss.Visible = false;
                    this.kConsLargess.Visible = false;
                    this.kConsRetail.Visible = false;
                    this.KCardFill.Visible = false;
                    this.KAssoInfo.Visible = false;
                    this.kConsSpecialDeal.Visible = false;
                    this.kProductionInStorage.Visible = false;
                    this.kSaleCheck.Visible = false;
					#endregion
					mHelpRegist.Enabled=false;
					if(!SysInitial.hsOperFunc.ContainsKey(SysInitial.CurOps.strOperID))
					{
						MessageBox.Show("����ԱȨ����ϢΪ�գ��������������Ƿ������Ȩ�ޣ����������ظ��£�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
					else
					{
						Hashtable hsmenuhead=new Hashtable();
						ArrayList alfunc=(ArrayList)SysInitial.hsOperFunc[SysInitial.CurOps.strOperID];
						foreach(MenuItem mi1 in this.mainMenu1.MenuItems)
						{
							foreach(MenuItem mi2 in mi1.MenuItems)
							{
								for(int k=0;k<alfunc.Count;k++)
								{
									CMSMStruct.OperFuncStruct ops=(CMSMStruct.OperFuncStruct)alfunc[k];
									if(mi2.Text==ops.strFuncName)
									{
										mi2.Visible=true;
                                        clsShortcut clsshcut = new clsShortcut();
                                        if (clsshcut.hsshortcut.ContainsKey(mi2.Text.ToString()))
                                        {
                                            switch (clsshcut.hsshortcut[mi2.Text.ToString()].ToString())
                                            {
                                                case "Alt0":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt0;
                                                    this.KAssoInfo.Visible = true;
                                                    break;
                                                case "Alt1":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt1;
                                                    this.KCardFill.Visible = true;
                                                    break;
                                                case "Alt2":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt2;
                                                    this.kConsAss.Visible = true;
                                                    break;
                                                case "Alt3":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt3;
                                                    this.kConsRetail.Visible = true;
                                                    break;
                                                case "Alt4":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt4;
                                                    this.kConsLargess.Visible = true;
                                                    break;
                                                case "Alt5":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt5;
                                                    this.kConsSpecialDeal.Visible = true;
                                                    break;
                                                case "Alt6":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt6;
                                                    this.kProductionInStorage.Visible = true;
                                                    break;
                                                case "Alt7":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt7;
                                                    this.kSaleCheck.Visible = true;
                                                    break;
                                                case "Alt8":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt8;
                                                    this.kHisSysmDataToCenter.Visible = true;
                                                    break;
                                                case "Alt9":
                                                    mi2.Shortcut = System.Windows.Forms.Shortcut.Alt9;
                                                    this.kSysmDataToCenter.Visible = true;
                                                    break;
                                            }
                                        }
										if(!hsmenuhead.ContainsKey(ops.strFuncAddress.Substring(0,5)))
										{
											hsmenuhead.Add(ops.strFuncAddress.Substring(0,5),ops.strFuncAddress.Substring(0,5));
										}
									}
								}
							}
						}
						foreach(DictionaryEntry de in hsmenuhead)
						{
							switch(de.Key.ToString())
							{
								case "mAsso":
									this.mAsso.Visible=true;
									break;
								case "mCard":
									this.mCard.Visible=true;
									break;
								case "mCons":
									this.mCons.Visible=true;
									break;
								case "mQuey":
									this.mQuey.Visible=true;
									break;
								case "mSysm":
									this.mSysm.Visible=true;
									break;
								case "mEmpy":
									this.mEmpy.Visible=true;
									break;
							}
						}
					}
				}
			}
		}
		#endregion

		#region ���ݱ���
		private void mSysmDatabaseBak_Click(object sender, System.EventArgs e)
		{
			DialogResult strres=MessageBox.Show("�Ƿ�������ݱ��ݣ�","ϵͳȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(strres==DialogResult.No)
			{
				return;
			}
			string ConnectionString = SysInitial.ConString;
			SqlConnection conn = new SqlConnection(ConnectionString);
			SqlCommand cmd = null;
			
			string str1 = DateTime.Now.ToString("yyyyMMddHHmmss");
			string fileName="";
			string str="";
			string strsql = "select vcCommName from tbCommCode where vcCommSign='DbBak' and vcCommCode='Pre'";
			try
����		{
				if( conn.State != ConnectionState.Open)
				{
����				conn.Open();
				}
				cmd = new SqlCommand(strsql,conn);
				
				object obj = cmd.ExecuteScalar();
				if(obj!=null)
				{
					str = obj.ToString();
					fileName = str+"_"+str1+".bak";
				}
				string filePath=@"E:\BreadDataBak\";
				if(!System.IO.Directory.Exists(filePath))
					System.IO.Directory.CreateDirectory(filePath);
				if(System.IO.File.Exists(fileName))
					System.IO.File.Delete(fileName);
			
				string sql1="";
				sql1=" declare @DbBak varchar(100) ";
				sql1+=" set @DbBak=(select vcCommName from tbCommCode where vcCommSign='DbBak' and vcCommCode='Pre')";
				sql1+="exec('BACKUP DATABASE '+@DbBak+' TO DISK =N''" + filePath +  fileName + "'' WITH NOINIT,NOUNLOAD,NAME=N''" + fileName + "����'',NOSKIP,STATS=10,NOFORMAT')";
����			cmd = new SqlCommand(sql1,conn);
����		
����			cmd.ExecuteNonQuery();
				MessageBox.Show("�������ݿ�ɹ�������E:\\BreadHotDataBak\\!�ļ���");
����		}
����		catch(SqlException sex)
����		{
����			MessageBox.Show(sex.Message.ToString()+"�������ݿ�ʧ�ܣ�");  
����		}
			finally
			{
				conn.Close();
			}
		}
		#endregion

		private void mHelpRegist_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRegister();
			form.ShowDialog();
		}


		private void mQueyConsKind_Click(object sender, System.EventArgs e)
		{
			Form form=new frmConsItemQuery();
			formShow(form);
		}


		private void mCardFillRemove_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssFillRemove();
			formShow(form);
		}

		private void mHelpAbout_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAbout();
			form.ShowDialog();
		}


		private void mSysmOperModPwd_Click(object sender, EventArgs e)
		{
			Form form=new frmModPwd();
			formShow(form);
		}

		private void mQueyOperLog_Click(object sender, System.EventArgs e)
		{
			Form form=new frmOperQuery();
			formShow(form);
		}


		private void mExitDailyAccount_Click(object sender, System.EventArgs e)
		{
			CommAccess ca=new CommAccess(SysInitial.ConString);
			Exception err;
			DataTable dtoper=ca.GetOperToday(out err);
			if(dtoper==null||dtoper.Rows.Count<=0)
			{
				MessageBox.Show("����û���κ����Ѻͳ�ֵ��¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			Form form=new frmChangeCheck();
			form.ShowDialog();
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			Form form=new frmMainDataDownLoad();
			form.ShowDialog();
		}

		private void mQueyBusiIncome_Click(object sender, System.EventArgs e)
		{
			Form form=new frmBusiIncomeReport();
			formShow(form);
		}

		private void mQueyConsGoodsTop_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSaleTop();
			formShow(form);
		}

		private void mConsLargess_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssLargess();
			formShow(form);
		}
		private void mConsLargessQy_Click(object sender, System.EventArgs e)
		{
			Form form=new frmLargQuery();
			formShow(form);
		}

		#region ˢ�¶�����ʱ��
		private void mHelpRefreshCardEq_Click(object sender, System.EventArgs e)
		{
			//���ö�����ʱ��
			string strtotime=DateTime.Now.Year.ToString().Substring(2,2);
			string strtmp=DateTime.Now.DayOfWeek.ToString();
			switch(strtmp)
			{
				case "Monday":
					strtotime+="01";
					break;
				case "Tuesday":
					strtotime+="02";
					break;
				case "Wednesday":
					strtotime+="03";
					break;
				case "Thursday":
					strtotime+="04";
					break;
				case "Friday":
					strtotime+="05";
					break;
				case "Saturday":
					strtotime+="06";
					break;
				case "Sunday":
					strtotime+="07";
					break;
			}
			strtmp=DateTime.Now.Month.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Day.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Hour.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Minute.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			strtmp=DateTime.Now.Second.ToString();
			if(strtmp.Length<2)
			{
				strtotime+="0" + strtmp;
			}
			else
			{
				strtotime+=strtmp;
			}
			CardCommon.CardRef.CardM1 rftmp=new CardCommon.CardRef.CardM1(SysInitial.intCom);
			rftmp.SetRFTime(strtotime);
		}
		#endregion

		private void navBarControl1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mConsBespeak_Click(object sender, System.EventArgs e)
		{
			Form form=new frmBespeakLog();
			formShow(form);
		}


		private void mSysmDataToHis_Click(object sender, System.EventArgs e)
		{
			Form form=new frmDataToHis();
			formShow(form);
		}

		private void mCardFillError_Click(object sender, System.EventArgs e)
		{
			Form form=new frmFillError();
			formShow(form);
		}

		private void mEmpyInfo_Click(object sender, System.EventArgs e)
		{
			Form form=new frmEmpInfo();
			formShow(form);
		}
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Form form=new frmDataManuUpdate_His();
			formShow(form);
		}

		private void mEmpySignIn_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSignIn();
			form.ShowDialog();
		}

		private void mEmpySignOut_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSignOut();
			form.ShowDialog();
		}

		private void mEmpySignSpec_Click(object sender, System.EventArgs e)
		{
			Form form=new frmSignSpec();
			form.ShowDialog();
		}

		private void mConsRetailRemove_Click(object sender, System.EventArgs e)
		{
			Form form=new frmNonAssConsRemove();
			form.ShowDialog();
		}

		private void mHelpContent_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this,"AMShelp.chm");
		}

		private void mSysmDataToCenter_Click(object sender, System.EventArgs e)
		{
			Form form=new frmDataManuUpdate();
			form.ShowDialog();
		}

		private void mAssoUplevel_Click(object sender, System.EventArgs e)
		{
			Form form=new frmAssUpLevel();
			formShow(form);
		}

		private void mCardRollbak_Click(object sender, System.EventArgs e)
		{
			CommAccess cs=new CommAccess(SysInitial.ConString);
			string strRes=cs.RecycleCard();
			if((!strRes.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				string colch="";
				DataView dv = new DataView(SysInitial.dsSys.Tables["ERR"]);
				dv.Sort = "vcCommCode";
				colch = dv[dv.Find(strRes)]["vcCommName"].ToString().Trim();
				MessageBox.Show("���ջ�Ա��ʧ�ܣ�\n" + colch,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("���ջ�Ա���ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
			}
		}


		private void mConsBank_Click(object sender, System.EventArgs e)
		{
			Form form=new frmRetailCons("PT008");//frmRetailConsBank();
			formShow(form);
		}
		private void mProductionInStorage_Click(object sender, System.EventArgs e)
		{
            //nmProductionInStorage_LinkClicked(null,null);�������
            Form form = new frmProductionInStorage(FormType.ProductionInStorage);
            formShow(form);
		}	

		private void mSaleCheck_Click(object sender, System.EventArgs e)
		{
            //nmSaleCheck_LinkClicked(null,null);�����̵�
            Form form = new frmProductionInStorage(FormType.SaleCheck);
            formShow(form);
		}

		private void mSaleBalance_Click(object sender, System.EventArgs e)
		{
            //nmSaleBalance_LinkClicked(null,null);����ƽ���
            Form form = new frmSaleBalance();
            formShow(form);
		}
        private void kConsSpecialDeal_Click(object sender, EventArgs e)
        {
            Form form = new frmSpecialCons();
            formShow(form);
        }

        private void kProductionInStorage_Click(object sender, EventArgs e)
        {
            //nmProductionInStorage_LinkClicked(null, null);�������
            Form form = new frmProductionInStorage(FormType.ProductionInStorage);
            formShow(form);
        }

        private void kSaleCheck_Click(object sender, EventArgs e)
        {
            //nmSaleCheck_LinkClicked(null, null);�����̵�
            Form form = new frmProductionInStorage(FormType.SaleCheck);
            formShow(form);
        }

        private void kSysmDataToCenter_Click(object sender, EventArgs e)
        {
            Form form = new frmDataManuUpdate();
            form.ShowDialog();
        }

        private void kHisSysmDataToCenter_Click(object sender, EventArgs e)
        {
            Form form = new frmDataManuUpdate_His();
            formShow(form);
        }

		#endregion

		#region ������ʱ��ˢ�º���
		private void timer1_Tick(object sender, EventArgs e)
		{
			statusBarPanel3.Text="ʱ�䣺" + DateTime.Now.ToString();
		}
		#endregion

		#region �������ʵʱͬ������timer�¼�
		private bool IsAmsSync()
		{
			bool isAmsSync = true;
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,"AMSSync")>0)
			{
				isAmsSync = Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["AMSSync"]);
			}
			return isAmsSync;
		}
		private void timerauto_Tick(object sender, System.EventArgs e)
		{			
			try
			{
				System.Diagnostics.Process[] proSync=System.Diagnostics.Process.GetProcessesByName("AMSSync");
				if(proSync.Length<=0)
				{
					Process newSync=new Process();
					newSync.StartInfo.FileName=Application.StartupPath+@"\AMSSync.exe";
					newSync.StartInfo.UseShellExecute=true;
					newSync.Start();
					newSync.WaitForInputIdle(10000);
					this.lblMainErr.Text="";
					this.lblMainErr.Visible=false;
				}
				else
				{
					this.lblMainErr.Text="";
					this.lblMainErr.Visible=false;
				}
			}
			catch(Exception ex)
			{
				this.clog.WriteLine(ex);
				this.lblMainErr.Visible=true;
				this.lblMainErr.Text="�޷�������Ա����ʵʱͬ������";
			}
		}
		#endregion

		#region ����ر����¼�
		private void CMSMMain_Closing(object sender, CancelEventArgs e)
		{
			System.Diagnostics.Process[] proSync=System.Diagnostics.Process.GetProcessesByName("AMSSync");
			if(proSync.Length>0)
			{
				foreach ( System.Diagnostics.Process p in proSync)
����			{
����				p.Kill();
����			}
			}
		}
		#endregion

		#region ���������жϺ���
		public bool IsUpdate()
		{
			string updateUrl = string.Empty;
			string tempUpdatePath = string.Empty;
			XmlFiles updaterXmlFiles = null;
			int availableUpdate = 0;
			//			if (!CheckInetConnection())
			//			{
			//				MessageBox.Show("����������!", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//				//this.Close();
			//				return false;
			//			}
			
			//panel2.Visible = false;
			//btnFinish.Visible = false;

			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			string serverXmlFile = string.Empty;

			
			try
			{
				//�ӱ��ض�ȡ���������ļ���Ϣ
				updaterXmlFiles = new XmlFiles(localXmlFile );
			}
			catch
			{
				MessageBox.Show("�Զ����������ļ�����!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				//this.Close();
				return false;
			}
			//��ȡ��������ַ
			updateUrl = updaterXmlFiles.GetNodeValue("//Url");

			AppUpdater appUpdater = new AppUpdater();
			appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";

			//�����������,���ظ��������ļ�
			try
			{
				tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\"+ "_"+ updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value+"_"+"y"+"_"+"x"+"_"+"m"+"_"+"\\";
				appUpdater.DownAutoUpdateFile(tempUpdatePath);
			}
			catch
			{
				MessageBox.Show("�����������ʧ��,������ʱ!","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				//this.Close();
				return false;

			}

			//��ȡ�����ļ��б�
			Hashtable htUpdateFile = new Hashtable();

			serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
			if(!File.Exists(serverXmlFile))
			{
				return false;
			}

			availableUpdate = appUpdater.CheckForUpdate(serverXmlFile,localXmlFile,out htUpdateFile);
			if (availableUpdate > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region ���ݿ�ű�ִ�� 20140311 zhh
		private static string SqlVersion="3.1";
		private bool Contains(string[] strs,string val)
		{
			foreach(string str in strs)
			{
				if(str==val)
				{
					return true;
				}
			}
			return false;
		}
		private void UpdateSqlVersionConfig()
		{
			XmlDocument doc=new XmlDocument();
			doc.Load(Application.StartupPath+@"\CMSM.exe.config");
			XmlNode keyNode=null;
			keyNode=doc.SelectSingleNode("/configuration/appSettings/add[@key='SqlVersion']");
			if(keyNode==null)
			{
				XmlElement element = doc.CreateElement("add");
				element.SetAttribute("key", "SqlVersion");
				element.SetAttribute("value", SqlVersion);
				doc.SelectSingleNode("//configuration/appSettings").AppendChild(element);
			}
			else
			{
				keyNode.Attributes["value"].Value=SqlVersion;
			}
			doc.Save(Application.StartupPath+@"\CMSM.exe.config");
		}
		private bool JudgeSqlUpdate()
		{
			bool update = true;
			string[] strs = System.Configuration.ConfigurationSettings.AppSettings.AllKeys;
			if(Contains(strs,"SqlVersion"))
			{
				string sqlversion = System.Configuration.ConfigurationSettings.AppSettings["SqlVersion"];
				if (sqlversion == SqlVersion)
				{
					update = false;
				}
			}
			return update;
		}
		private void UpdateSqlServer(string strConsStr)
		{
			if(JudgeSqlUpdate())
			{
                try
                {
                    CMSMData.SyncTableStruct.Update(strConsStr);
                    UpdateSqlVersionConfig();
                }
                catch (Exception er)
                {
                    MessageBox.Show("�����������ʧ��,������ʱ!"+er.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
			}
		}
		#endregion
        
        
	}
}
