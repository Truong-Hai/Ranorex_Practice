/*
 * Created by Ranorex
 * User: PC
 * Date: 11/17/2021
 * Time: 2:36 PM
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
    /// Description of LibraryFuntion.
    /// </summary>
    [TestModule("A8338BFE-3BB5-4773-95F9-3CE887989DCF", ModuleType.UserCode, 1)]
    public class LibraryFuntionMBA : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LibraryFuntionMBA()
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
        	//delcare variable 
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
        	
        	//click  "AddProduct" button
        	btnAddProduct.Click();
        	
        	//input product name
        	txtProductname.Focus();
        	Keyboard.Press("{ControlKey down}{akey down}{ControlKey up}{akey up}");
        	txtProductname.PressKeys(""+productName);
        	
        	//input metatag
        	txtMetatagTitle.Focus();
        	txtMetatagTitle.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+MetatagTitle);
        	
        	//click tab "Data"
        	btndata.Click();
        	
        	//input Model 
        	txtmodel.Focus();
        	txtmodel.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+model);
        	
        	//input price
        	txtPrice.Focus();
        	txtPrice.PressKeys("{ControlKey down}{akey down}{ControlKey up}{akey up}"+price);
        	
			//input Start Day
        	txtAvaiDate.Focus();
        	Keyboard.Press("{ControlKey down}{akey down}{ControlKey up}{akey up}");
        	txtAvaiDate.PressKeys(Setformatday(Ayear,Amonth,Aday));
        	
        	
        	//input End Day
        	txtEndDate.Focus();
        	Keyboard.Press("{ControlKey down}{akey down}{ControlKey up}{akey up}");
        	txtEndDate.PressKeys(Setformatday(Eyear,Emonth,Eday));
        	
        	//click tab "Link"
        	btnLink.Click();
        	
        	//choose Store
        	SetCheckBoxValue(storeValue); 
        	
        	//click "Save" button
         	btnSave.Click();
        }
        
        public string Setformatday ( int year, int month, int day)
        {
        	
        	System.DateTime dt = new System.DateTime(year,month,day);
        	string days = string.Format("{0:yyyy-MM-dd}",dt);

        	
        	return days;
        }
        public string  SetCheckBoxValue (int valueData)
        {
        	string Optional = string.Format(".//input[@value={0}]",valueData);
        	InputTag OptionValueCheck = MBA_TestingRepository.Instance.MBA_Web.AddNewProduct.MenuCheckbox.FindSingle(Optional);
        	OptionValueCheck.Click();
        	return Optional;
        }
        public bool CheckOpenmenuList()
			{
				if(MBA_TestingRepository.Instance.MBA_Web.HomePage.MenuIsOpenInfo.Exists(3000))
				{
					MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuProduct.Click();
					return true;
				}
				else
				{
					MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuCatalog.Click();
					MBA_TestingRepository.Instance.MBA_Web.Catalog.MenuProduct.Click();
					return false;
				}
			}
        
        
         public void VerifyAddProduct(string _SearchProduct )
        {
         	Report.Log(ReportLevel.Info, "Start verifying added product");
         	
        	
         	List<string> lstProducts = GetAllProducts();
         	
         	bool foundProduct = lstProducts.Contains(_SearchProduct);
         	
         	if(!foundProduct) {
         		Report.Log(ReportLevel.Error, "Product was not added");
         	}
         	
         	Validate.AreEqual(true,foundProduct);
         	
         	Report.Log(ReportLevel.Info, "Product was added successfully");
         	/*
	    	////declare variable for element
            IList<Ranorex.TrTag> row = new List<Ranorex.TrTag>();
			IList<Ranorex.TdTag> col = new List<Ranorex.TdTag>();
        	row = MBA_TestingRepository.Instance.MBA_Web.Catalog.ListNameProduct.FindChildren<Ranorex.TrTag>();
			
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
			*/
        }
         
         private List<string> GetAllProducts() {
         	
         	var results = new List<string>();
         	var repo = MBA_TestingRepository.Instance;
         	var rows = repo.MBA_Web.Catalog.ListNameProduct.FindChildren<Ranorex.TrTag>();
         	
         	if(rows.Count == 1 && rows[1].FindChildren<Ranorex.TdTag>().Count < 2) {
         		return results;
         	}
         	
         	for (int i = 0; i < rows.Count; i++) {
         		string prodName = rows[i].FindChildren<Ranorex.TdTag>()[2].InnerText;
         		results.Add(prodName);
         	}
         	   
         	return results;
         }
        
        public void Showlistdata(string SearchProd)
        {
        	//declare variable for element
	    	IList<Ranorex.TrTag> row = new List<Ranorex.TrTag>();
			IList<Ranorex.TdTag> col = new List<Ranorex.TdTag>();
        	
			row = MBA_TestingRepository.Instance.MBA_Web.Catalog.ListNameProduct.FindChildren<Ranorex.TrTag>();
        	int i;
        	int countPro=0;
        	string celltext;
        	//display verify result
			for (i = 0; i < row.Count; i++)
        	{
        		col = row[i].FindChildren<Ranorex.TdTag>();
        		celltext = col[2].InnerText;
					if (celltext.ToLower().Equals(SearchProd.ToLower()))
				    {
				    	Report.Info("Product Name"," "+celltext);
				    	countPro+=1;
				    }
				    

			}
			if(countPro<1)
			{
				Report.Failure("Product Name",""+SearchProd+"not be added");
			}
			else
			{
				Report.Info("Product Name",""+SearchProd+"be added");
			}
        }
    }
}
