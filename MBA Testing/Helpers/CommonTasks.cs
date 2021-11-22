/*
 * Created by Ranorex
 * User: PC
 * Date: 11/17/2021
 * Time: 2:13 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;

namespace MBA_Testing.Helpers
{
	/// <summary>
	/// Description of CommonTasks.
	/// </summary>
	public class CommonTasks
	{
		public CommonTasks()
		{
		}
		
		public void ClickSideMenu(string menuName) {
			var repo = MBA_TestingRepository.Instance;
			
			// Set menu name 
			repo.parentname = menuName;
			
			repo.MBA_Web.HomePage.parentMenu.Click();
		}
		
	}
}
