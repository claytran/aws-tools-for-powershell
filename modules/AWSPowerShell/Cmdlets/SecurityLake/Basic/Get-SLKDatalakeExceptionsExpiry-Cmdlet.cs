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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Retrieves the expiration period and time-to-live (TTL) for which the exception message
    /// will remain. Exceptions are stored by default, for a 2 week period of time from when
    /// a record was created in Security Lake. This API does not take input parameters. This
    /// API does not take input parameters.
    /// </summary>
    [Cmdlet("Get", "SLKDatalakeExceptionsExpiry")]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the Amazon Security Lake GetDatalakeExceptionsExpiry API operation.", Operation = new[] {"GetDatalakeExceptionsExpiry"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse",
        "This cmdlet returns a System.Int64 object.",
        "The service call response (type Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSLKDatalakeExceptionsExpiryCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExceptionMessageExpiry'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExceptionMessageExpiry";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse, GetSLKDatalakeExceptionsExpiryCmdlet>(Select) ??
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
            var request = new Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryRequest();
            
            
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
        
        private Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "GetDatalakeExceptionsExpiry");
            try
            {
                #if DESKTOP
                return client.GetDatalakeExceptionsExpiry(request);
                #elif CORECLR
                return client.GetDatalakeExceptionsExpiryAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SecurityLake.Model.GetDatalakeExceptionsExpiryResponse, GetSLKDatalakeExceptionsExpiryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExceptionMessageExpiry;
        }
        
    }
}