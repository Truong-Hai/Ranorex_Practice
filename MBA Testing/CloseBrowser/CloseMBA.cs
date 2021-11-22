/*
 * Created by Ranorex
 * User: PC
 * Date: 11/17/2021
 * Time: 2:47 PM
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
    /// Description of CloseMBA.
    /// </summary>
    [TestModule("0785C636-5053-46F2-A0E2-43C9D7C78391", ModuleType.UserCode, 1)]
    public class CloseMBA : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CloseMBA()
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
        }
    }
}
