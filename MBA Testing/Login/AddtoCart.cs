/*
 * Created by Ranorex
 * User: PC
 * Date: 11/17/2021
 * Time: 2:54 PM
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
using MBA_Testing.Helpers;

namespace MBA_Testing.Login
{
    /// <summary>
    /// Description of LoginAJOA.
    /// </summary>
    [TestModule("E1A76D5D-F305-4F32-A5B9-402D397692FE", ModuleType.UserCode, 1)]
    public class AddtoCart : ITestModule
    {
        LibrariFuntionAJOA libra = new LibrariFuntionAJOA();
    	/// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddtoCart()
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
            //checkLogin();
        }
        
       
        
        public void LoginPage( string userEmail, string password)
        {
        	
        	libra.Login(userEmail,password);
        	Delay.Seconds(2);
        }
        
        
        public void mainProcess()
        {
        	//name of product 
        	Delay.Seconds(10);
        	string _SearchProduct ="$10 Truong Hai testingdata";
        	Delay.Seconds(5);
        	
        	//search name of product
        	libra.SearchPro(""+_SearchProduct);
        	Delay.Seconds(5);
        	
        	//find product in list product found

        	string tmp = string.Format(".//div/img[@title='"+_SearchProduct+"']");
          	ImgTag temp =	MBA_TestingRepository.Instance.AJOA_Page.AddToCart.ListFoundProduct.FindSingle(tmp);
        	temp.Click();
        	Delay.Seconds(5);
        	
			//wait and click button "Add to Cart"
        	MBA_TestingRepository.Instance.AJOA_Page.AddToCart.btnAddToCartInfo.WaitForExists(5000);
        	MBA_TestingRepository.Instance.AJOA_Page.AddToCart.btnAddToCart.Focus();
        	MBA_TestingRepository.Instance.AJOA_Page.AddToCart.btnAddToCart.DoubleClick();
        	Delay.Seconds(5);
        	
        	//verify product in cart
        	libra.VerifyProductCart(""+_SearchProduct);
        	Delay.Seconds(5);
        	
        	//delete product in cart
        	libra.deleteItem(_SearchProduct);
        	Delay.Seconds(5);
        	
        }       
    }
}
