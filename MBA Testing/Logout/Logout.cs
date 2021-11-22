/*
 * Created by Ranorex
 * User: HP
 * Date: 9/11/2021
 * Time: 6:14 PM
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

namespace MBA_Testing.Logout
{
    /// <summary>
    /// Description of Logout.
    /// </summary>
    [TestModule("427983C2-0767-4E4D-9A53-A6D815B1BCA1", ModuleType.UserCode, 1)]
    public class Logout : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Logout()
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
            Signout();
        }
        
        private void Signout() {
        	var btnLogout = MBA_TestingRepository.Instance.MBA_Web.HomePage.btnLogout;
        	
        	if(MBA_TestingRepository.Instance.MBA_Web.HomePage.btnLogoutInfo.Exists()) {
        		btnLogout.Click();
        	}
        }
    }
}
