/*
 * Created by Ranorex
 * User: PC
 * Date: 11/8/2021
 * Time: 10:44 AM
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
    /// Description of CloseBrowser.
    /// </summary>
    [TestModule("EE39A112-7596-49F9-871C-550065BD042E", ModuleType.UserCode, 1)]
    public class CloseBrowser : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CloseBrowser()
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
            CloseBrowserMBA();
        }
        
        public void CloseBrowserMBA ()
        {
        	Ranorex.WebDocument wd = Host.Local.FindSingle<Ranorex.WebDocument>(MBA_TestingRepository.Instance.MBA_Web.AbsoluteBasePath.ToString());
        	wd.Close();
        	
        	// Kill chrome if exists
        	Host.Local.KillBrowser("chorme");
        }
    }
}
