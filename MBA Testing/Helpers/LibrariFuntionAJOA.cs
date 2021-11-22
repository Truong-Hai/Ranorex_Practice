/*
 * Created by Ranorex
 * User: PC
 * Date: 11/17/2021
 * Time: 3:11 PM
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

namespace MBA_Testing.Helpers
{
    /// <summary>
    /// Description of LibrariFuntionAJOA.
    /// </summary>
    [TestModule("12F256FC-9502-4E6A-B87F-21DE6661BE62", ModuleType.UserCode, 1)]
    public class LibrariFuntionAJOA : ITestModule
    {
        
		//string celltext = "";
    	/// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LibrariFuntionAJOA()
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
        
        public void Login(string userEmail, string Password)
        {
			//declare variable for element
			MBA_TestingRepository.Instance.AJOA_Page.LoginPage.btnLoginInfo.WaitForExists(5000);
        	MBA_TestingRepository.Instance.AJOA_Page.LoginPage.btnLogin.Click();
        	//var btnLogin = MBA_TestingRepository.Instance.AJOA_Page.LoginPage.btnLogin;
        	var txtUserEmail = MBA_TestingRepository.Instance.AJOA_Page.LoginPage.txtEmail;
			var txtPassword = MBA_TestingRepository.Instance.AJOA_Page.LoginPage.txtPassword;
			var btnLgin = MBA_TestingRepository.Instance.AJOA_Page.LoginPage.btnLgin;

			
			//input Username
			txtUserEmail.Focus();
			txtUserEmail.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+userEmail);
			
			//input pass
			txtPassword.Focus();
			txtPassword.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+Password);
			Delay.Seconds(3);
			
			//click button login
			btnLgin.Click();
			
        }
        
        public void SearchPro(string ProName)
        {
        	//declare variable for element
        	MBA_TestingRepository.Instance.AJOA_Page.HomePage.txtSearchInfo.WaitForExists(5000);
        	//MBA_TestingRepository.Instance.AJOA_Page.HomePage.txtSearchInfo.WaitForExists(5000);
        	var txtSearchPro = MBA_TestingRepository.Instance.AJOA_Page.HomePage.txtSearch;
        	var btnSearch = MBA_TestingRepository.Instance.AJOA_Page.HomePage.btnSearch;
        	
        	//input product name to search
        	txtSearchPro.Focus();
        	txtSearchPro.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+ProName);
        	Delay.Seconds(3);
        	
			//click search button
        	btnSearch.Click();
        }
        
        public void VerifyProductCart(string _SearchProduct )
        {
        	//click button "Cart"
        	MBA_TestingRepository.Instance.AJOA_Page.AddToCart.btnCartInfo.WaitForExists(5000);
            MBA_TestingRepository.Instance.AJOA_Page.AddToCart.btnCart.DoubleClick();
           
	    	////declare variable for element
            IList<Ranorex.TrTag> row = new List<Ranorex.TrTag>();
			IList<Ranorex.TdTag> col = new List<Ranorex.TdTag>();
        	row = MBA_TestingRepository.Instance.AJOA_Page.AddToCart.ListProduct.FindChildren<Ranorex.TrTag>();
			
        	//verify product name in list product 
        	for (int c = 0; c < row.Count; c++)
			{
				col = row[c].FindChildren<Ranorex.TdTag>();
				if (col.Count<2)
					{
						Report.Info("Productname","NO result");
					
					}
				else 
					{
						//display reusult verify
			    		Showlistdata(_SearchProduct);
						break;
					}
			}
        }
        
        public void Showlistdata(string SearchProd)
        {
        	//declare variable for element
	    	IList<Ranorex.TrTag> row = new List<Ranorex.TrTag>();
			IList<Ranorex.TdTag> col = new List<Ranorex.TdTag>();
        	
			row = MBA_TestingRepository.Instance.AJOA_Page.AddToCart.ListProduct.FindChildren<Ranorex.TrTag>();
        	int i;
        	//display verify result
			for (i = 0; i < row.Count; i++)
	        	{
	        		col = row[i].FindChildren<Ranorex.TdTag>();
	        		var repo = MBA_TestingRepository.Instance;
	        		repo.parentList = SearchProd;
	        		
	        			if(repo.AJOA_Page.AddToCart.ListProductCartInfo.Exists())
			        		{
						    	Report.Info("Product Name","be found:  "+SearchProd);
						    	break;
						    }
					    
						else if (!repo.AJOA_Page.AddToCart.ListProductCartInfo.Exists())
							{
								Report.Info("Product Name","Not be found: "+SearchProd);
								break;
							}
					
				}
        }
        
        public void deleteItem (string productname)
        {
        	//delete product item in cart 
    		var repo = MBA_TestingRepository.Instance;
        	repo.parentList = productname;
        	
        	//find and click delete button by Product Name
        	string tmp = string.Format(".//ancestor::tr//td[@class='text-center td-qty']//button[@class='btn btn-remove']");
        	Button btnDeleteItem = MBA_TestingRepository.Instance.AJOA_Page.AddToCart.ListProductCart.FindSingle(tmp);
        	Delay.Seconds(5);
        	btnDeleteItem.DoubleClick();
        	Delay.Seconds(5);
        	//verify product deleted in cart
        	VerifyProductCart(productname);
        }
    }
}
