/*
 * Created by Ranorex
 * User: PC
 * Date: 11/8/2021
 * Time: 9:48 AM
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

namespace MBA_Testing
{
    /// <summary>
    /// Description of OpenBrowser.
    /// </summary>
    [TestModule("EC65491D-A3D1-45FD-9CA6-98B2C09727AA", ModuleType.UserCode, 1)]
    public class OpenBrowser : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenBrowser()
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
            OpenBrowserMBA();
        }
        
        public void OpenBrowserMBA ()
        {
        	// Kill existing chrome before open new chrome
        	Host.Local.KillBrowser("chorme");
        	
			//Host.Local.OpenBrowser("https://ptn-test1.oc.mbasrv.com/sbe", "Chrome", "", killExisting:true, maximized:true);
			Host.Local.OpenBrowser("https://ptn-test1.oc.mbasrv.com/sbe", "Chrome", "--incognito --disable-save-password-bubble --disable-infobars", killExisting:true, maximized:true);
			
			// Wait for chrome exist
			//MBA_TestingRepository.Instance.ChromeBrowser.SelfInfo.WaitForExists(10);

        }
    }
}
