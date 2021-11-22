/*
 * Created by Ranorex
 * User: PC
 * Date: 11/17/2021
 * Time: 9:10 PM
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

namespace MBA_Testing.Openbrowser
{
    /// <summary>
    /// Description of OpenBrowserAJOA.
    /// </summary>
    [TestModule("CC2DA73F-56BB-4C17-95EA-330683F6A382", ModuleType.UserCode, 1)]
    public class OpenBrowserAJOA : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenBrowserAJOA()
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
            OpenAJOA();
        }
        public void OpenAJOA(){
        	Host.Local.KillBrowser("chorme");
        	
			Host.Local.OpenBrowser("https://ajoa.ptn-test1.oc.mbasrv.com", "Chrome", "--incognito --disable-save-password-bubble --disable-infobars", killExisting:true, maximized:true);
        }
    }
}
