/*
 * Created by Ranorex
 * User: PC
 * Date: 11/18/2021
 * Time: 4:33 PM
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
    /// Description of CloseChormePage.
    /// </summary>
    [TestModule("B9862B90-57C1-4AA8-968D-BAACC8110255", ModuleType.UserCode, 1)]
    public class CloseChormePage : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CloseChormePage()
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
            Killchrome();
        }
        public void Killchrome()
        {
        	Host.Local.KillBrowser("chrome");
        	//Killchrome()
        	//Host.Local.CloseApplications("chrome")//("https://ptn-test1.oc.mbasrv.com/sbe", "Chrome", "--incognito --disable-save-password-bubble --disable-infobars", killExisting:true, maximized:true);
        }
    }
}
