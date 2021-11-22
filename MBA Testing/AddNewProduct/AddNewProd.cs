/*
 * Created by Ranorex
 * User: PC
 * Date: 11/15/2021
 * Time: 3:10 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using MBA_Testing.Helpers;
namespace MBA_Testing.AddNewProduct
{
    /// <summary>
    /// Description of AddNewProd.
    /// </summary>
    [TestModule("11E3F889-9A54-46B2-88D7-292243B85EE6", ModuleType.UserCode, 1)]
    public class AddNewProd : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddNewProd()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            AddNewProduct("$10 Truong Hai testingdata","$10 Truong Hai testingdata","AU_161121","500",2021,11,16,2023,11,16,1);
        }
        
        public void AddNewProduct (string proName, string proMetatag, string proModel, string proPrice, int StartYear, int StartMonth, int StartDay,int EndYear, int EndMonth, int EndDay,int StoreValue)
        {
        	MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnAddProduct.Click();
        	LibraryFuntionMBA lib = new LibraryFuntionMBA();
        	lib.SetDataProduct(proName,proMetatag,proModel,proPrice,StartYear,StartMonth,StartDay,EndYear,EndMonth,EndDay,StoreValue);
        	Delay.Seconds(5);
        //	MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnSaveInfo.WaitForExists(3000);
        	MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnSave.Focus();
//        	MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnSave.Click();
			Ranorex.Button btnsave = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnSave;
			btnsave.Click();
        	
        	Delay.Seconds(3);
        	lib.VerifyAddProduct(""+proName);
        	Delay.Seconds(3);
        }
       
    }
}
