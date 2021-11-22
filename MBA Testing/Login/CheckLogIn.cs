/*
 * Created by Ranorex
 * User: PC
 * Date: 11/19/2021
 * Time: 8:49 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace MBA_Testing.Login
{
    /// <summary>
    /// Description of CheckLogIn.
    /// </summary>
    [TestModule("AE0E6D14-F561-47C7-9DD5-9AC94FE0F258", ModuleType.UserCode, 1)]
    public class CheckLogIn :AddtoCart, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckLogIn()
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
            //check login with account 
            checkLogin("jca_duy.tu@ptnglobalcorp.com","123456");
        }
         public void checkLogin(string UserName, string Passwork)
        {
        	//check account is logged or not
        	//MBA_TestingRepository.Instance.AJOA_Page.LoginPage.btnLoginInfo.WaitForExists(5000);
        	if(MBA_TestingRepository.Instance.AJOA_Page.LoginPage.btnLoginInfo.Exists())
        	{
        		// if not logged yet 
        		Delay.Seconds(5);
        		
        		//login
        		LoginPage(UserName,Passwork);
        		Delay.Seconds(3);
        		
        		// Add product to cart
        	   	mainProcess();
        	}
        	else
        	{
        		//If logged, add product to cart
        		mainProcess();
        	}
        }
    }
}
