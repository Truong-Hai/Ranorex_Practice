/*
 * Created by Ranorex
 * User: PC
 * Date: 11/8/2021
 * Time: 11:10 AM
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
using MBA_Testing.AddNewProduct;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using MBA_Testing.Helpers;

namespace MBA_Testing
{
    /// <summary>
    /// Description of OpenListProduct.
    /// </summary>
    [TestModule("37F681EE-C7F0-4637-BD95-352B9B37C802", ModuleType.UserCode, 1)]
    public class OpenListProduct : LibFunction,ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenListProduct()
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
            OpenProduct();
        }
        
        public void OpenProduct()
        {
        	//CheckOpenmenuList();
//        	var helpers = new CommonTasks();
//        	helpers.ClickSideMenu("Catalog");
			CheckOpenmenuList();
        	Delay.Seconds(2);
        }
    }
}
