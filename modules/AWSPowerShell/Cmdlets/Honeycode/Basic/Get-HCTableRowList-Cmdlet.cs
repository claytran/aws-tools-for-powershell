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
using Amazon.Honeycode;
using Amazon.Honeycode.Model;

namespace Amazon.PowerShell.Cmdlets.HC
{
    /// <summary>
    /// The ListTableRows API allows you to retrieve a list of all the rows in a table in
    /// a workbook.
    /// </summary>
    [Cmdlet("Get", "HCTableRowList")]
    [OutputType("Amazon.Honeycode.Model.ListTableRowsResponse")]
    [AWSCmdlet("Calls the Amazon Honeycode ListTableRows API operation.", Operation = new[] {"ListTableRows"}, SelectReturnType = typeof(Amazon.Honeycode.Model.ListTableRowsResponse))]
    [AWSCmdletOutput("Amazon.Honeycode.Model.ListTableRowsResponse",
        "This cmdlet returns an Amazon.Honeycode.Model.ListTableRowsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetHCTableRowListCmdlet : AmazonHoneycodeClientCmdlet, IExecutor
    {
        
        #region Parameter RowId
        /// <summary>
        /// <para>
        /// <para> This parameter is optional. If one or more row ids are specified in this list, then
        /// only the specified row ids are returned in the result. If no row ids are specified
        /// here, then all the rows in the table are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RowIds")]
        public System.String[] RowId { get; set; }
        #endregion
        
        #region Parameter TableId
        /// <summary>
        /// <para>
        /// <para>The ID of the table whose rows are being retrieved.</para><para> If a table with the specified id could not be found, this API throws ResourceNotFoundException.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TableId { get; set; }
        #endregion
        
        #region Parameter WorkbookId
        /// <summary>
        /// <para>
        /// <para>The ID of the workbook that contains the table whose rows are being retrieved.</para><para> If a workbook with the specified id could not be found, this API throws ResourceNotFoundException.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WorkbookId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of rows to return in each page of the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> This parameter is optional. If a nextToken is not specified, the API returns the
        /// first page of data. </para><para> Pagination tokens expire after 1 hour. If you use a token that was returned more
        /// than an hour back, the API will throw ValidationException. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Honeycode.Model.ListTableRowsResponse).
        /// Specifying the name of a property of type Amazon.Honeycode.Model.ListTableRowsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Honeycode.Model.ListTableRowsResponse, GetHCTableRowListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.RowId != null)
            {
                context.RowId = new List<System.String>(this.RowId);
            }
            context.TableId = this.TableId;
            #if MODULAR
            if (this.TableId == null && ParameterWasBound(nameof(this.TableId)))
            {
                WriteWarning("You are passing $null as a value for parameter TableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkbookId = this.WorkbookId;
            #if MODULAR
            if (this.WorkbookId == null && ParameterWasBound(nameof(this.WorkbookId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkbookId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Honeycode.Model.ListTableRowsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RowId != null)
            {
                request.RowIds = cmdletContext.RowId;
            }
            if (cmdletContext.TableId != null)
            {
                request.TableId = cmdletContext.TableId;
            }
            if (cmdletContext.WorkbookId != null)
            {
                request.WorkbookId = cmdletContext.WorkbookId;
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
        
        private Amazon.Honeycode.Model.ListTableRowsResponse CallAWSServiceOperation(IAmazonHoneycode client, Amazon.Honeycode.Model.ListTableRowsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Honeycode", "ListTableRows");
            try
            {
                #if DESKTOP
                return client.ListTableRows(request);
                #elif CORECLR
                return client.ListTableRowsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> RowId { get; set; }
            public System.String TableId { get; set; }
            public System.String WorkbookId { get; set; }
            public System.Func<Amazon.Honeycode.Model.ListTableRowsResponse, GetHCTableRowListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
