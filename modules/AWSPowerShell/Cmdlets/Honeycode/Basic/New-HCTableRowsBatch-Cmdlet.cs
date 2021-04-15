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
    /// The BatchCreateTableRows API allows you to create one or more rows at the end of
    /// a table in a workbook. The API allows you to specify the values to set in some or
    /// all of the columns in the new rows. 
    /// 
    ///  
    /// <para>
    ///  If a column is not explicitly set in a specific row, then the column level formula
    /// specified in the table will be applied to the new row. If there is no column level
    /// formula but the last row of the table has a formula, then that formula will be copied
    /// down to the new row. If there is no column level formula and no formula in the last
    /// row of the table, then that column will be left blank for the new rows. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "HCTableRowsBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Honeycode.Model.BatchCreateTableRowsResponse")]
    [AWSCmdlet("Calls the Amazon Honeycode BatchCreateTableRows API operation.", Operation = new[] {"BatchCreateTableRows"}, SelectReturnType = typeof(Amazon.Honeycode.Model.BatchCreateTableRowsResponse))]
    [AWSCmdletOutput("Amazon.Honeycode.Model.BatchCreateTableRowsResponse",
        "This cmdlet returns an Amazon.Honeycode.Model.BatchCreateTableRowsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewHCTableRowsBatchCmdlet : AmazonHoneycodeClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> The request token for performing the batch create operation. Request tokens help
        /// to identify duplicate requests. If a call times out or fails due to a transient error
        /// like a failed network connection, you can retry the call with the same request token.
        /// The service ensures that if the first call using that request token is successfully
        /// performed, the second call will not perform the operation again. </para><para> Note that request tokens are valid only for a few minutes. You cannot use request
        /// tokens to dedupe requests spanning hours or days. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter RowsToCreate
        /// <summary>
        /// <para>
        /// <para> The list of rows to create at the end of the table. Each item in this list needs
        /// to have a batch item id to uniquely identify the element in the request and the cells
        /// to create for that row. You need to specify at least one item in this list. </para><para> Note that if one of the column ids in any of the rows in the request does not exist
        /// in the table, then the request fails and no updates are made to the table. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Honeycode.Model.CreateRowData[] RowsToCreate { get; set; }
        #endregion
        
        #region Parameter TableId
        /// <summary>
        /// <para>
        /// <para>The ID of the table where the new rows are being added.</para><para> If a table with the specified ID could not be found, this API throws ResourceNotFoundException.
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
        /// <para>The ID of the workbook where the new rows are being added.</para><para> If a workbook with the specified ID could not be found, this API throws ResourceNotFoundException.
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Honeycode.Model.BatchCreateTableRowsResponse).
        /// Specifying the name of a property of type Amazon.Honeycode.Model.BatchCreateTableRowsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-HCTableRowsBatch (BatchCreateTableRows)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Honeycode.Model.BatchCreateTableRowsResponse, NewHCTableRowsBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.RowsToCreate != null)
            {
                context.RowsToCreate = new List<Amazon.Honeycode.Model.CreateRowData>(this.RowsToCreate);
            }
            #if MODULAR
            if (this.RowsToCreate == null && ParameterWasBound(nameof(this.RowsToCreate)))
            {
                WriteWarning("You are passing $null as a value for parameter RowsToCreate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Honeycode.Model.BatchCreateTableRowsRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.RowsToCreate != null)
            {
                request.RowsToCreate = cmdletContext.RowsToCreate;
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
        
        private Amazon.Honeycode.Model.BatchCreateTableRowsResponse CallAWSServiceOperation(IAmazonHoneycode client, Amazon.Honeycode.Model.BatchCreateTableRowsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Honeycode", "BatchCreateTableRows");
            try
            {
                #if DESKTOP
                return client.BatchCreateTableRows(request);
                #elif CORECLR
                return client.BatchCreateTableRowsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.Honeycode.Model.CreateRowData> RowsToCreate { get; set; }
            public System.String TableId { get; set; }
            public System.String WorkbookId { get; set; }
            public System.Func<Amazon.Honeycode.Model.BatchCreateTableRowsResponse, NewHCTableRowsBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
