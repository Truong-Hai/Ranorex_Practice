/*
 * Created by Ranorex
 * User: PC
 * Date: 11/8/2021
 * Time: 10:54 AM
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
    /// Description of Login_TC_001.
    /// </summary>
    [TestModule("892D32BC-AD5C-4633-87F0-F458FD9A439D", ModuleType.UserCode, 1)]
    public class LoginMBA : ITestModule
    {
        
    	/// <summary>
        /// Constructs a new instance.
        /// </summary>
         
        
        public LoginMBA()
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
            Logon("auto","Abcd@123");
        }
               
        private void Logon(string user, string password) {
        	var textUser = MBA_TestingRepository.Instance.MBA_Web.LoginForm.txtUserName;
        	var textPass = MBA_TestingRepository.Instance.MBA_Web.LoginForm.txtPassWord;
        	var btnLogin = MBA_TestingRepository.Instance.MBA_Web.LoginForm.btnLogin;
        	
        	// Set username
        	textUser.Focus();
        	textUser.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+user);
        	
        	Delay.Seconds(2);
        	// Set password
        	textPass.Focus();
        	textPass.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+password);
        	
        	// Click login button
        	btnLogin.Click();
        }
        
    }
}
