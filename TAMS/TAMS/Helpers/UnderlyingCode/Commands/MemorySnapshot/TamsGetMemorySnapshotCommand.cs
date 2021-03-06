﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2013
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    using System;
    using System.Management.Automation;
    using Commands;
    using System.Collections;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of TamsGetMemorySnapshotCommand.
    /// </summary>
    internal class TamsGetMemorySnapshotCommand : TamsCommand
    {
        internal TamsGetMemorySnapshotCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTamsMemorySnapshotCommand)Cmdlet;
            
            int[] processIds = null;
            var processIdObjects = new ArrayList();
            
            if (null != cmdlet.InputObject && 0 < cmdlet.InputObject.Length) {
                
                foreach (Process process in cmdlet.InputObject) {
                    processIdObjects.Add(process.Id);
                }
                processIds = (int[])processIdObjects.ToArray(typeof(int));
                
            } else if (null != cmdlet.ProcessName && 0 < cmdlet.ProcessName.Length) {
                
                foreach (string processName in cmdlet.ProcessName) {
                    try {
                        Process[] processes = Process.GetProcessesByName(processName);
                        foreach (Process process in processes) {
                            processIdObjects.Add(process.Id);
                        }
                    }
                    catch (Exception eGetProcess) {
                        cmdlet.WriteError(
                            cmdlet,
                            "Failed to get a process. " +
                            eGetProcess.Message,
                            "FailedToGetProcess",
                            ErrorCategory.InvalidArgument,
                            false);
                    }
                }
                processIds = (int[])processIdObjects.ToArray(typeof(int));
                
            } else if (null != cmdlet.ProcessId && 0 < cmdlet.ProcessId.Length) {
                
                processIds = cmdlet.ProcessId;
            }
            TAMSHelper.GetMemoryShapshot(cmdlet, processIds);
        }
    }
}
