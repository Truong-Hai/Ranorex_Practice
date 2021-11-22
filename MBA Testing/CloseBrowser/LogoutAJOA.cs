/*
 * Created by Ranorex
 * User: PC
 * Date: 11/18/2021
 * Time: 4:28 PM
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

namespace MBA_Testing.CloseBrowser
{
    /// <summary>
    /// Description of LogoutAJOA.
    /// </summary>
    [TestModule("20FA9CCB-C3EC-4A5E-B735-BE03E17DB09E", ModuleType.UserCode, 1)]
    public class LogoutAJOA : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LogoutAJOA()
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
            LogOutPage();
        }
        public void LogOutPage()
        {
        	MBA_TestingRepository.Instance.AJOA_Page.HomePage.btnLogout.Click();
        	Delay.Seconds(3);
        	
        }
    }
}
