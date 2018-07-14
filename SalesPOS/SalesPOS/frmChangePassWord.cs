using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesPOS.BOL;
using SalesPOS.BLL;
using DevExpress.XtraEditors;

namespace SalesPOS
{
    public partial class frmChangePassWord : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePassWord()
        {
            InitializeComponent();
        }

        private void frmChangePassWord_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtOldpass;
            Load_User_Detailes();
        }

        public void Load_User_Detailes()
        {
            txtUserName.Text = bllUtility.LoggedInSystemInformation.UserName;
            txtUserLoginID.Text = bllUtility.LoggedInSystemInformation.LoggedUserName;
            txtUserName.Enabled = false;
            txtUserLoginID.Enabled = false;
            this.txtOldpass.Focus();
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtOldpass.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Current Password", "Warning Message");
                    txtOldpass.Focus();
                }
                else if (txtnewpass.Text == "")
                {
                    XtraMessageBox.Show("Please Enter New Password", "Warning Message");
                    txtnewpass.Focus();
                }
                else if (txtretype.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Re-Type Password", "Warning Message");
                    txtretype.Focus();
                }                
                else
                {
                    if (bllUtility.LoggedInSystemInformation.LoginPass.ToString().Trim() == bllUtility.EncryptPassword(txtOldpass.Text.Trim()))
                    {
                        if (txtnewpass.Text.Trim() == txtretype.Text.Trim())
                        {

                            UserInfo _objUserInfo = new UserInfo();
                            _objUserInfo.UserInfoId = bllUtility.LoggedInSystemInformation.LoggedUserId;
                            _objUserInfo.SoftUser = bllUtility.LoggedInSystemInformation.LoggedUserName;
                            _objUserInfo.SoftPassword = bllUtility.LoggedInSystemInformation.LoginPass.ToString().Trim();
                            _objUserInfo.NewPassword = bllUtility.EncryptPassword(txtnewpass.Text.Trim());

                            if (bllScreenInfo.UpdateUserPassword(_objUserInfo))
                            {
                                XtraMessageBox.Show("Successfully Update.", "Successfull Message");
                                txtnewpass.Clear();
                                txtOldpass.Clear();
                                txtretype.Clear();
                            }
                            else
                            {
                                XtraMessageBox.Show("Your Given Information is not correct.", "Warning Message");
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("New Password & Re-Type Password are not matching....", "Warning Message");
                        }


                    }
                    else
                    {
                        XtraMessageBox.Show("Your Old Password is incorrect.", "Warning Message");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
