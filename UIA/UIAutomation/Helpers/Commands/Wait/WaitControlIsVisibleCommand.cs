﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/12/2014
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
//    using System.Collections;
//    using System.Collections.Generic;
    using UIAutomation.Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of WaitControlIsVisibleCommand.
    /// </summary>
    public class WaitControlIsVisibleCommand : AbstractCommand	// : UiaCommand
    {
        public WaitControlIsVisibleCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
            
        }
        
        public override void Execute()
        {
            var cmdlet =
                (WaitUiaControlIsVisibleCommand)this.Cmdlet;
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                
                // 20140312
                // if (!Equals(cmdlet.ControlType, inputObject.Current.ControlType)) {
                if (!Equals(cmdlet.ControlType, inputObject.GetCurrent().ControlType)) {
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "Control is not of " +
                        cmdlet.ControlType.ProgrammaticName +
                        " type",
                        "WrongControlType",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                cmdlet.WaitIfCondition(inputObject, false);
                
                cmdlet.WriteObject(cmdlet, inputObject);
                
            }
        }
    }
}