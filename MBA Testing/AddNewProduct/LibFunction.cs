/*
 * Created by Ranorex
 * User: PC
 * Date: 11/15/2021
 * Time: 1:25 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace MBA_Testing.AddNewProduct
{
    /// <summary>
    /// Description of LibFunction.
    /// </summary>
    [TestModule("516D885A-D03D-42C6-A5D4-62ADDF8194B6", ModuleType.UserCode, 1)]
    public class LibFunction : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LibFunction()
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
        
        
        public void SetDataProduct (string productName , string MetatagTitle, string model, string price, int Ayear,int Amonth, int Aday , int Eyear, int Emonth, int Eday, int storeValue )
        {
        	var btnAddProduct = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnAddProduct;
        	var txtProductname = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.txtProdName;
        	var txtMetatagTitle = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.txtMetatagtitle;
        	var btndata = MBA_TestingRepository .Instance.MBA_Web.AddNewProduct.MenuItemData;
        	var txtmodel = MBA_TestingRepository .Instance.MBA_Web.AddNewProduct.txtModel;
        	var txtPrice = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.txtPrice;
        	var txtAvaiDate = MBA_TestingRepository .Instance.MBA_Web.AddNewProduct.txtDateAvailable;
        	var txtEndDate = MBA_TestingRepository .Instance.MBA_Web.AddNewProduct.txtEndDate;
        	var btnLink = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.MenuItemLink;
        	var CheckStore = MBA_TestingRepository .Instance.MBA_Web.AddNewProduct.CheckBoxAJOA;
        	var btnSave = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.btnSave;
        	
        	btnAddProduct.Click();
        	
        	txtProductname.Focus();
        	Keyboard.Press("{ControlKey down}{akey down}{ControlKey up}{akey up}");
        	txtProductname.PressKeys(""+productName);
        	
        	txtMetatagTitle.Focus();
        	txtMetatagTitle.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+MetatagTitle);
        	
        	btndata.Click();
        	
        	txtmodel.Focus();
        	txtmodel.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+model);
        	
        	txtPrice.Focus();
        	txtPrice.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+price);
        	
        	txtAvaiDate.Focus();
        	Keyboard.Press("{ControlKey down}{akey down}{ControlKey up}{akey up}");
        	txtAvaiDate.PressKeys(Setformatday(Ayear,Amonth,Aday));
        	
        	txtEndDate.Focus();
        	Keyboard.Press("{ControlKey down}{akey down}{ControlKey up}{akey up}");
        	txtEndDate.PressKeys(Setformatday(Eyear,Emonth,Eday));
        	
        	btnLink.Click();
        	
        	SetCheckBoxValue(storeValue); 
        	
        	btnSave.Click();
        }
        
        public string Setformatday ( int year, int month, int day)
        {
        	
        	System.DateTime dt = new System.DateTime(year,month,day);
        	string days = string.Format("{0:yyyy-MM-dd}",dt);
//			string days = dt.ToString("{0:yyyy-MM-dd}");
        	
        	return days;
        }
        
        public int checkcatalog (int check)
        {
        	var checkCatalog = MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuProductInfo.Exists(2000);
        	 check = 0;
        	if (checkCatalog == true)
        	{
        		check = 1 ;
        	}
        	else 
        	{
        		check = 0;
        	}
        	return check;
        }
        
//        public string getCheckBoxValue (string valueData)
//        {
//        	
//        	string Optional = string.Format(".//option[@value = {0}]",valueData);
//        	
//        	return Optional;
//        }
        public string  SetCheckBoxValue (int valueData)
        {
        	string Optional = string.Format(".//input[@value={0}]",valueData);
//        	OptionTag OptionValueCheck = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.MenuCheckbox.FindSingle(Optional);
        	InputTag OptionValueCheck = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.MenuCheckbox.FindSingle(Optional);
        	OptionValueCheck.Click();
        	return Optional;
        }
        
        public bool CheckOpenMenuList()
        {
        	//var isOpen = Host.Current.Find<ATag>(".//nav[#'column-left']//ul[#'menu']//li[#'menu-catalog']//a[@aria-expanded='true']")[0];
        	//ATag isOpen = MBA_TestingRepository.Instance.MBA_Web.HomePage.MenuIsOpenInfo;
        	try 
        	{
        		//MBA_TestingRepository.Instance.MBA_Web.HomePage.MenuIsOpen.WaitForExists(3000);
        		return true;
        	}
        	catch(Exception ex)
        	{
        		Report.Info("user",""+ex);
        		return false;
        	}
//        		
//        	
        }
			public bool CheckOpenmenuList()
			{
				
				if(MBA_TestingRepository.Instance.MBA_Web.Catalog.CheckCatalogOpenInfo.Exists(TimeSpan.FromSeconds(2)))
				{
					MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuProduct.Click();
					return true;
				}
				else
				{
					MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuCatalog.Click();
					Delay.Seconds(2);
					MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuProduct.Click();
					return false;
				}
			}
			
        	
    }
}
