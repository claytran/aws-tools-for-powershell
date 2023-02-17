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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Retrieves partition metadata from the Data Catalog that contains unfiltered metadata.
    /// 
    ///  
    /// <para>
    /// For IAM authorization, the public IAM action associated with this API is <code>glue:GetPartitions</code>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEUnfilteredPartitionsMetadata")]
    [OutputType("Amazon.Glue.Model.UnfilteredPartition")]
    [AWSCmdlet("Calls the AWS Glue GetUnfilteredPartitionsMetadata API operation.", Operation = new[] {"GetUnfilteredPartitionsMetadata"}, SelectReturnType = typeof(Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.UnfilteredPartition or Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.UnfilteredPartition objects.",
        "The service call response (type Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEUnfilteredPartitionsMetadataCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter AuditContext_AdditionalAuditContext
        /// <summary>
        /// <para>
        /// <para>The context for the audit..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuditContext_AdditionalAuditContext { get; set; }
        #endregion
        
        #region Parameter AuditContext_AllColumnsRequested
        /// <summary>
        /// <para>
        /// <para>All columns request for audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AuditContext_AllColumnsRequested { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog where the partitions in question reside. If none is provided,
        /// the AWS account ID is used by default. </para>
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
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the catalog database where the partitions reside.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter Expression
        /// <summary>
        /// <para>
        /// <para>An expression that filters the partitions to be returned.</para><para>The expression uses SQL syntax similar to the SQL <code>WHERE</code> filter clause.
        /// The SQL statement parser <a href="http://jsqlparser.sourceforge.net/home.php">JSQLParser</a>
        /// parses the expression. </para><para><i>Operators</i>: The following are the operators that you can use in the <code>Expression</code>
        /// API call:</para><dl><dt>=</dt><dd><para>Checks whether the values of the two operands are equal; if yes, then the condition
        /// becomes true.</para><para>Example: Assume 'variable a' holds 10 and 'variable b' holds 20. </para><para>(a = b) is not true.</para></dd><dt>&lt; &gt;</dt><dd><para>Checks whether the values of two operands are equal; if the values are not equal,
        /// then the condition becomes true.</para><para>Example: (a &lt; &gt; b) is true.</para></dd><dt>&gt;</dt><dd><para>Checks whether the value of the left operand is greater than the value of the right
        /// operand; if yes, then the condition becomes true.</para><para>Example: (a &gt; b) is not true.</para></dd><dt>&lt;</dt><dd><para>Checks whether the value of the left operand is less than the value of the right operand;
        /// if yes, then the condition becomes true.</para><para>Example: (a &lt; b) is true.</para></dd><dt>&gt;=</dt><dd><para>Checks whether the value of the left operand is greater than or equal to the value
        /// of the right operand; if yes, then the condition becomes true.</para><para>Example: (a &gt;= b) is not true.</para></dd><dt>&lt;=</dt><dd><para>Checks whether the value of the left operand is less than or equal to the value of
        /// the right operand; if yes, then the condition becomes true.</para><para>Example: (a &lt;= b) is true.</para></dd><dt>AND, OR, IN, BETWEEN, LIKE, NOT, IS NULL</dt><dd><para>Logical operators.</para></dd></dl><para><i>Supported Partition Key Types</i>: The following are the supported partition keys.</para><ul><li><para><code>string</code></para></li><li><para><code>date</code></para></li><li><para><code>timestamp</code></para></li><li><para><code>int</code></para></li><li><para><code>bigint</code></para></li><li><para><code>long</code></para></li><li><para><code>tinyint</code></para></li><li><para><code>smallint</code></para></li><li><para><code>decimal</code></para></li></ul><para>If an type is encountered that is not valid, an exception is thrown. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Expression { get; set; }
        #endregion
        
        #region Parameter AuditContext_RequestedColumn
        /// <summary>
        /// <para>
        /// <para>The requested columns for audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuditContext_RequestedColumns")]
        public System.String[] AuditContext_RequestedColumn { get; set; }
        #endregion
        
        #region Parameter Segment
        /// <summary>
        /// <para>
        /// <para>The segment of the table's partitions to scan in this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.Segment Segment { get; set; }
        #endregion
        
        #region Parameter SupportedPermissionType
        /// <summary>
        /// <para>
        /// <para>A list of supported permission types. </para>
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
        [Alias("SupportedPermissionTypes")]
        public System.String[] SupportedPermissionType { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table that contains the partition.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of partitions to return in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is not the first call to retrieve these partitions.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UnfilteredPartitions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UnfilteredPartitions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CatalogId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse, GetGLUEUnfilteredPartitionsMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CatalogId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuditContext_AdditionalAuditContext = this.AuditContext_AdditionalAuditContext;
            context.AuditContext_AllColumnsRequested = this.AuditContext_AllColumnsRequested;
            if (this.AuditContext_RequestedColumn != null)
            {
                context.AuditContext_RequestedColumn = new List<System.String>(this.AuditContext_RequestedColumn);
            }
            context.CatalogId = this.CatalogId;
            #if MODULAR
            if (this.CatalogId == null && ParameterWasBound(nameof(this.CatalogId)))
            {
                WriteWarning("You are passing $null as a value for parameter CatalogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Expression = this.Expression;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Segment = this.Segment;
            if (this.SupportedPermissionType != null)
            {
                context.SupportedPermissionType = new List<System.String>(this.SupportedPermissionType);
            }
            #if MODULAR
            if (this.SupportedPermissionType == null && ParameterWasBound(nameof(this.SupportedPermissionType)))
            {
                WriteWarning("You are passing $null as a value for parameter SupportedPermissionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.GetUnfilteredPartitionsMetadataRequest();
            
            
             // populate AuditContext
            var requestAuditContextIsNull = true;
            request.AuditContext = new Amazon.Glue.Model.AuditContext();
            System.String requestAuditContext_auditContext_AdditionalAuditContext = null;
            if (cmdletContext.AuditContext_AdditionalAuditContext != null)
            {
                requestAuditContext_auditContext_AdditionalAuditContext = cmdletContext.AuditContext_AdditionalAuditContext;
            }
            if (requestAuditContext_auditContext_AdditionalAuditContext != null)
            {
                request.AuditContext.AdditionalAuditContext = requestAuditContext_auditContext_AdditionalAuditContext;
                requestAuditContextIsNull = false;
            }
            System.Boolean? requestAuditContext_auditContext_AllColumnsRequested = null;
            if (cmdletContext.AuditContext_AllColumnsRequested != null)
            {
                requestAuditContext_auditContext_AllColumnsRequested = cmdletContext.AuditContext_AllColumnsRequested.Value;
            }
            if (requestAuditContext_auditContext_AllColumnsRequested != null)
            {
                request.AuditContext.AllColumnsRequested = requestAuditContext_auditContext_AllColumnsRequested.Value;
                requestAuditContextIsNull = false;
            }
            List<System.String> requestAuditContext_auditContext_RequestedColumn = null;
            if (cmdletContext.AuditContext_RequestedColumn != null)
            {
                requestAuditContext_auditContext_RequestedColumn = cmdletContext.AuditContext_RequestedColumn;
            }
            if (requestAuditContext_auditContext_RequestedColumn != null)
            {
                request.AuditContext.RequestedColumns = requestAuditContext_auditContext_RequestedColumn;
                requestAuditContextIsNull = false;
            }
             // determine if request.AuditContext should be set to null
            if (requestAuditContextIsNull)
            {
                request.AuditContext = null;
            }
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.Expression != null)
            {
                request.Expression = cmdletContext.Expression;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Segment != null)
            {
                request.Segment = cmdletContext.Segment;
            }
            if (cmdletContext.SupportedPermissionType != null)
            {
                request.SupportedPermissionTypes = cmdletContext.SupportedPermissionType;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetUnfilteredPartitionsMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetUnfilteredPartitionsMetadata");
            try
            {
                #if DESKTOP
                return client.GetUnfilteredPartitionsMetadata(request);
                #elif CORECLR
                return client.GetUnfilteredPartitionsMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String AuditContext_AdditionalAuditContext { get; set; }
            public System.Boolean? AuditContext_AllColumnsRequested { get; set; }
            public List<System.String> AuditContext_RequestedColumn { get; set; }
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String Expression { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Glue.Model.Segment Segment { get; set; }
            public List<System.String> SupportedPermissionType { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.Glue.Model.GetUnfilteredPartitionsMetadataResponse, GetGLUEUnfilteredPartitionsMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UnfilteredPartitions;
        }
        
    }
}
