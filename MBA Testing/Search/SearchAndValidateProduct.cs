/*
 * Created by Ranorex
 * User: PC
 * Date: 11/8/2021
 * Time: 11:13 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using HtmlAgilityPack;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace MBA_Testing
{
    /// <summary>
    /// Description of Search_TC_001.
    /// </summary>
    [TestModule("64BC76E6-D053-4087-99D5-3FD044DDE52B", ModuleType.UserCode, 1)]
    public class SearchAndValidateProduct : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SearchAndValidateProduct()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
		string _prodname = "";
		[TestVariable("6ec56a16-6c3a-46a5-95c5-6a6ac24e43a0")]
		public string prodname
		{
			get { return _prodname; }
			set { _prodname = value; }
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
            
            // Input and search product
            Search();
            
            Delay.Seconds(2);
            
            
            List<string> foundProducts = GetResults();
            
            Validate.AreEqual(true,VerifyFoundProduct(foundProducts));
            
        }
        
        private bool VerifyFoundProduct(List<string> foundProducts) {
        	int countFailed = 0;
        	for(int i = 0; i < foundProducts.Count; i++) {
        		if(!foundProducts[i].ToLower().Contains(prodname.ToLower())) {
        			Report.Log(ReportLevel.Error, (i+1) + ". Found invalid product searching: " + foundProducts[i]);
        			countFailed++;
        		} else {
        			Report.Log(ReportLevel.Info, (i+1) + ". Valid product name: " + foundProducts[i]);
        			
        		}
        	}
        	
        	if(countFailed > 0) {
        		return false;
        	} 
        	return true;
        }
        
        private void Search() {
        	var inputSearch = MBA_TestingRepository.Instance.MBA_Web.Catalog.TxtSearchName;
        	var inputSearchInfo = MBA_TestingRepository.Instance.MBA_Web.Catalog.TxtSearchNameInfo;
        	inputSearch.Focus();
        	inputSearch.PressKeys("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}" + prodname);
        	
        	var btnFilter = MBA_TestingRepository.Instance.MBA_Web.Catalog.btnFilter;
        	
        	btnFilter.Click();
        }
        
        private List<string> GetSearchResultsInOnePage() {
        	List<string> listFoundProducts = new List<string>();
        	Ranorex.TBodyTag ProductName = MBA_TestingRepository.Instance.MBA_Web.Catalog.ListNameProduct;
    		IList<Ranorex.TrTag> rows = ProductName.FindChildren<Ranorex.TrTag>();
    		
			if(rows.Count == 1 && rows[1].FindChildren<Ranorex.TdTag>().Count < 2) {
				return listFoundProducts;
			}
			int productIdx = 2;
			
			for(int i = 0; i < rows.Count ; i++) {
				listFoundProducts.Add(rows[i].FindChildren<Ranorex.TdTag>()[productIdx].InnerText);
			}
        	
			return listFoundProducts;
        }
        
        private List<string> GetResults() {
        	List<string> results = new List<string>();
        	
        	//var btnNext = MBA_TestingRepository.Instance.MBA_Web.Catalog.btnNextPage;
        	
        	results.AddRange(GetSearchResultsInOnePage());
        	
        	// Find product in next pages if any
        	while(MBA_TestingRepository.Instance.MBA_Web.Catalog.btnNextPageInfo.Exists(3000)) {
        		MBA_TestingRepository.Instance.MBA_Web.Catalog.btnNextPage.PerformClick();
        		Delay.Seconds(2);
        		results.AddRange(GetSearchResultsInOnePage());
        		
        	}
        	
        	
        	return results;
        }
        
       
    }
}
