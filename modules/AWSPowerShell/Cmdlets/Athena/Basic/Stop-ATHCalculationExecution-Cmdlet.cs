/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Requests the cancellation of a calculation. A <code>StopCalculationExecution</code>
    /// call on a calculation that is already in a terminal state (for example, <code>STOPPED</code>,
    /// <code>FAILED</code>, or <code>COMPLETED</code>) succeeds but has no effect.
    /// 
    ///  <note><para>
    /// Cancelling a calculation is done on a best effort basis. If a calculation cannot be
    /// cancelled, you can be charged for its completion. If you are concerned about being
    /// charged for a calculation that cannot be cancelled, consider terminating the session
    /// in which the calculation is running.
    /// </para></note>
    /// </summary>
    [Cmdlet("Stop", "ATHCalculationExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Athena.CalculationExecutionState")]
    [AWSCmdlet("Calls the Amazon Athena StopCalculationExecution API operation.", Operation = new[] {"StopCalculationExecution"}, SelectReturnType = typeof(Amazon.Athena.Model.StopCalculationExecutionResponse))]
    [AWSCmdletOutput("Amazon.Athena.CalculationExecutionState or Amazon.Athena.Model.StopCalculationExecutionResponse",
        "This cmdlet returns an Amazon.Athena.CalculationExecutionState object.",
        "The service call response (type Amazon.Athena.Model.StopCalculationExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopATHCalculationExecutionCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter CalculationExecutionId
        /// <summary>
        /// <para>
        /// <para>The calculation execution UUID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CalculationExecutionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'State'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.StopCalculationExecutionResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.StopCalculationExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "State";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CalculationExecutionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CalculationExecutionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CalculationExecutionId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CalculationExecutionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-ATHCalculationExecution (StopCalculationExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.StopCalculationExecutionResponse, StopATHCalculationExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CalculationExecutionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CalculationExecutionId = this.CalculationExecutionId;
            #if MODULAR
            if (this.CalculationExecutionId == null && ParameterWasBound(nameof(this.CalculationExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculationExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Athena.Model.StopCalculationExecutionRequest();
            
            if (cmdletContext.CalculationExecutionId != null)
            {
                request.CalculationExecutionId = cmdletContext.CalculationExecutionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Athena.Model.StopCalculationExecutionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.StopCalculationExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "StopCalculationExecution");
            try
            {
                #if DESKTOP
                return client.StopCalculationExecution(request);
                #elif CORECLR
                return client.StopCalculationExecutionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String CalculationExecutionId { get; set; }
            public System.Func<Amazon.Athena.Model.StopCalculationExecutionResponse, StopATHCalculationExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.State;
        }
        
    }
}