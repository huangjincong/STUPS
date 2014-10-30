﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 8:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Tmx.Client;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of NewTestRunCommand.
    /// </summary>
    class NewTestRunCommand : TmxCommand
    {
        internal NewTestRunCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewTmxTestRunCommand)Cmdlet;
            var testRunCreator = new TestRunCreator(new RestRequestCreator());
            var result = testRunCreator.CreateTestRun(cmdlet.WorkflowName, cmdlet.Status, cmdlet.Name);
            cmdlet.WriteObject(cmdlet, result);
        }
    }
}