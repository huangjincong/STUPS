﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/24/2013
 * Time: 2:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	using System;
    	
	public interface IValuePatternAdapter
	{
		void SetValue(string value);
		IValuePatternInformation Cached { get; }
		IValuePatternInformation Current { get; }
		
		IMySuperWrapper ParentElement { get; set; }
	}
}
