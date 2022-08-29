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
using Amazon.SupportApp;
using Amazon.SupportApp.Model;

namespace Amazon.PowerShell.Cmdlets.SUP
{
    /// <summary>
    /// Retrieves the alias from an Amazon Web Services account ID. The alias appears in the
    /// Amazon Web Services Support App page of the Amazon Web Services Support Center. The
    /// alias also appears in Slack messages from the Amazon Web Services Support App.
    /// </summary>
    [Cmdlet("Get", "SUPAccountAlias")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Support App GetAccountAlias API operation.", Operation = new[] {"GetAccountAlias"}, SelectReturnType = typeof(Amazon.SupportApp.Model.GetAccountAliasResponse))]
    [AWSCmdletOutput("System.String or Amazon.SupportApp.Model.GetAccountAliasResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SupportApp.Model.GetAccountAliasResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSUPAccountAliasCmdlet : AmazonSupportAppClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountAlias'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupportApp.Model.GetAccountAliasResponse).
        /// Specifying the name of a property of type Amazon.SupportApp.Model.GetAccountAliasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountAlias";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupportApp.Model.GetAccountAliasResponse, GetSUPAccountAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.SupportApp.Model.GetAccountAliasRequest();
            
            
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
        
        private Amazon.SupportApp.Model.GetAccountAliasResponse CallAWSServiceOperation(IAmazonSupportApp client, Amazon.SupportApp.Model.GetAccountAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support App", "GetAccountAlias");
            try
            {
                #if DESKTOP
                return client.GetAccountAlias(request);
                #elif CORECLR
                return client.GetAccountAliasAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SupportApp.Model.GetAccountAliasResponse, GetSUPAccountAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountAlias;
        }
        
    }
}