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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Updates the stack set, and associated stack instances in the specified accounts and
    /// Regions.
    /// 
    ///  
    /// <para>
    /// Even if the stack set operation created by updating the stack set fails (completely
    /// or partially, below or above a specified failure tolerance), the stack set is updated
    /// with your changes. Subsequent <a>CreateStackInstances</a> calls on the specified stack
    /// set use the updated stack set.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFNStackSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateStackSet API operation.", Operation = new[] {"UpdateStackSet"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.UpdateStackSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.UpdateStackSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFNStackSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>[Self-managed permissions] The accounts in which to update associated stack instances.
        /// If you specify accounts, you must also specify the Regions in which to update stack
        /// set instances.</para><para>To update <i>all</i> the stack instances associated with this stack set, do not specify
        /// the <code>Accounts</code> or <code>Regions</code> properties.</para><para>If the stack set update includes changes to the template (that is, if the <code>TemplateBody</code>
        /// or <code>TemplateURL</code> properties are specified), or the <code>Parameters</code>
        /// property, CloudFormation marks all stack instances with a status of <code>OUTDATED</code>
        /// prior to updating the stack instances in the specified accounts and Regions. If the
        /// stack set update does not include changes to the template or parameters, CloudFormation
        /// updates the stack instances in the specified accounts and Regions, while leaving all
        /// other stack instances with their existing stack instance status. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_Account
        /// <summary>
        /// <para>
        /// <para>The names of one or more Amazon Web Services accounts for which you want to deploy
        /// stack set updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_Accounts")]
        public System.String[] DeploymentTargets_Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_AccountsUrl
        /// <summary>
        /// <para>
        /// <para>Returns the value of the <code>AccountsUrl</code> property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentTargets_AccountsUrl { get; set; }
        #endregion
        
        #region Parameter ManagedExecution_Active
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, StackSets performs non-conflicting operations concurrently
        /// and queues conflicting operations. After conflicting operations finish, StackSets
        /// starts queued operations in request order.</para><note><para>If there are already running or queued operations, StackSets queues all incoming operations
        /// even if they are non-conflicting.</para><para>You can't modify your stack set's execution configuration while there are running
        /// or queued operations for that stack set.</para></note><para>When <code>false</code> (default), StackSets performs one operation at a time in request
        /// order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedExecution_Active { get; set; }
        #endregion
        
        #region Parameter AdministrationRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the IAM role to use to update this stack set.</para><para>Specify an IAM role only if you are using customized administrator roles to control
        /// which users or groups can manage specific stack sets within the same administrator
        /// account. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs.html">Granting
        /// Permissions for Stack Set Operations</a> in the <i>CloudFormation User Guide</i>.</para><para>If you specified a customized administrator role when you created the stack set, you
        /// must specify a customized administrator role, even if it is the same customized administrator
        /// role used with this stack set previously.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdministrationRoleARN { get; set; }
        #endregion
        
        #region Parameter CallAs
        /// <summary>
        /// <para>
        /// <para>[Service-managed permissions] Specifies whether you are acting as an account administrator
        /// in the organization's management account or as a delegated administrator in a member
        /// account.</para><para>By default, <code>SELF</code> is specified. Use <code>SELF</code> for stack sets with
        /// self-managed permissions.</para><ul><li><para>If you are signed in to the management account, specify <code>SELF</code>.</para></li><li><para>If you are signed in to a delegated administrator account, specify <code>DELEGATED_ADMIN</code>.</para><para>Your Amazon Web Services account must be registered as a delegated administrator in
        /// the management account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-delegated-admin.html">Register
        /// a delegated administrator</a> in the <i>CloudFormation User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.CallAs")]
        public Amazon.CloudFormation.CallAs CallAs { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>In some cases, you must explicitly acknowledge that your stack template contains certain
        /// capabilities in order for CloudFormation to update the stack set and its associated
        /// stack instances.</para><ul><li><para><code>CAPABILITY_IAM</code> and <code>CAPABILITY_NAMED_IAM</code></para><para>Some stack templates might include resources that can affect permissions in your Amazon
        /// Web Services account; for example, by creating new Identity and Access Management
        /// (IAM) users. For those stacks sets, you must explicitly acknowledge this by specifying
        /// one of these capabilities.</para><para>The following IAM resources require you to specify either the <code>CAPABILITY_IAM</code>
        /// or <code>CAPABILITY_NAMED_IAM</code> capability.</para><ul><li><para>If you have IAM resources, you can specify either capability. </para></li><li><para>If you have IAM resources with custom names, you <i>must</i> specify <code>CAPABILITY_NAMED_IAM</code>.
        /// </para></li><li><para>If you don't specify either of these capabilities, CloudFormation returns an <code>InsufficientCapabilities</code>
        /// error.</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-accesskey.html">
        /// AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-group.html">
        /// AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">
        /// AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-policy.html">
        /// AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">
        /// AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-user.html">
        /// AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-addusertogroup.html">
        /// AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in CloudFormation Templates</a>.</para></li><li><para><code>CAPABILITY_AUTO_EXPAND</code></para><para>Some templates reference macros. If your stack set template references one or more
        /// macros, you must update the stack set directly from the processed template, without
        /// first reviewing the resulting changes in a change set. To update the stack set directly,
        /// you must acknowledge this capability. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Using
        /// CloudFormation Macros to Perform Custom Processing on Templates</a>.</para><important><para>Stack sets with service-managed permissions do not currently support the use of macros
        /// in templates. (This includes the <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/create-reusable-transform-function-snippets-and-add-to-your-template-with-aws-include-transform.html">AWS::Include</a>
        /// and <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by CloudFormation.) Even if you specify this capability
        /// for a stack set with service-managed permissions, if you reference a macro in your
        /// template the stack set operation will fail.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of updates that you are making.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_Enabled
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, StackSets automatically deploys additional stack instances
        /// to Organizations accounts that are added to a target organization or organizational
        /// unit (OU) in the specified Regions. If an account is removed from a target organization
        /// or OU, StackSets deletes stack instances from the account in the specified Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoDeployment_Enabled { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM execution role to use to update the stack set. If you do not specify
        /// an execution role, CloudFormation uses the <code>AWSCloudFormationStackSetExecutionRole</code>
        /// role for the stack set operation.</para><para>Specify an IAM role only if you are using customized execution roles to control which
        /// stack resources users and groups can include in their stack sets. </para><para> If you specify a customized execution role, CloudFormation uses that role to update
        /// the stack. If you do not specify a customized execution role, CloudFormation performs
        /// the update using the role previously associated with the stack set, so long as you
        /// have permissions to perform operations on the stack set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleName { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique ID for this stack set operation. </para><para>The operation ID also functions as an idempotency token, to ensure that CloudFormation
        /// performs the stack set operation only once, even if you retry the request multiple
        /// times. You might retry stack set operation requests to ensure that CloudFormation
        /// successfully received them.</para><para>If you don't specify an operation ID, CloudFormation generates one automatically.</para><para>Repeating this stack set operation with a new operation ID retries all stack instances
        /// whose status is <code>OUTDATED</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>Preferences for how CloudFormation performs this stack set operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The organization root ID or organizational unit (OU) IDs to which StackSets deploys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_OrganizationalUnitIds")]
        public System.String[] DeploymentTargets_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of input parameters for the stack set template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter PermissionModel
        /// <summary>
        /// <para>
        /// <para>Describes how the IAM roles required for stack set operations are created. You cannot
        /// modify <code>PermissionModel</code> if there are stack instances associated with your
        /// stack set.</para><ul><li><para>With <code>self-managed</code> permissions, you must create the administrator and
        /// execution roles required to deploy to target accounts. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs-self-managed.html">Grant
        /// Self-Managed Stack Set Permissions</a>.</para></li><li><para>With <code>service-managed</code> permissions, StackSets automatically creates the
        /// IAM roles required to deploy to accounts managed by Organizations. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs-service-managed.html">Grant
        /// Service-Managed Stack Set Permissions</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.PermissionModels")]
        public Amazon.CloudFormation.PermissionModels PermissionModel { get; set; }
        #endregion
        
        #region Parameter StackRegion
        /// <summary>
        /// <para>
        /// <para>The Regions in which to update associated stack instances. If you specify Regions,
        /// you must also specify accounts in which to update stack set instances.</para><para>To update <i>all</i> the stack instances associated with this stack set, do not specify
        /// the <code>Accounts</code> or <code>Regions</code> properties.</para><para>If the stack set update includes changes to the template (that is, if the <code>TemplateBody</code>
        /// or <code>TemplateURL</code> properties are specified), or the <code>Parameters</code>
        /// property, CloudFormation marks all stack instances with a status of <code>OUTDATED</code>
        /// prior to updating the stack instances in the specified accounts and Regions. If the
        /// stack set update does not include changes to the template or parameters, CloudFormation
        /// updates the stack instances in the specified accounts and Regions, while leaving all
        /// other stack instances with their existing stack instance status. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StackRegion { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_RetainStacksOnAccountRemoval
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, stack resources are retained when an account is removed
        /// from a target organization or OU. If set to <code>false</code>, stack resources are
        /// deleted. Specify only if <code>Enabled</code> is set to <code>True</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoDeployment_RetainStacksOnAccountRemoval { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set that you want to update.</para>
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
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to associate with this stack set and the stacks created from it.
        /// CloudFormation also propagates these tags to supported resources that are created
        /// in the stacks. You can specify a maximum number of 50 tags.</para><para>If you specify tags for this parameter, those tags replace any list of tags that are
        /// currently associated with this stack set. This means:</para><ul><li><para>If you don't specify this parameter, CloudFormation doesn't modify the stack's tags.
        /// </para></li><li><para>If you specify <i>any</i> tags using this parameter, you must specify <i>all</i> the
        /// tags that you want associated with this stack set, even tags you've specifed before
        /// (for example, when creating the stack set or during a previous update of the stack
        /// set.). Any tags that you don't include in the updated list of tags are removed from
        /// the stack set, and therefore from the stacks and resources as well. </para></li><li><para>If you specify an empty value, CloudFormation removes all currently associated tags.</para></li></ul><para>If you specify new tags as part of an <code>UpdateStackSet</code> action, CloudFormation
        /// checks to see if you have the required IAM permission to tag resources. If you omit
        /// tags that are currently associated with the stack set from the list of tags you specify,
        /// CloudFormation assumes that you want to remove those tags from the stack set, and
        /// checks to see if you have permission to untag resources. If you don't have the necessary
        /// permission(s), the entire <code>UpdateStackSet</code> action fails with an <code>access
        /// denied</code> error, and the stack set is not updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The structure that contains the template body, with a minimum length of 1 byte and
        /// a maximum length of 51,200 bytes. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the template body. The URL must point to a
        /// template (maximum size: 460,800 bytes) that is located in an Amazon S3 bucket or a
        /// Systems Manager document. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Use the existing template that's associated with the stack set that you're updating.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UsePreviousTemplate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.UpdateStackSetResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.UpdateStackSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackSetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackSetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackSetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStackSet (UpdateStackSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.UpdateStackSetResponse, UpdateCFNStackSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackSetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Account != null)
            {
                context.Account = new List<System.String>(this.Account);
            }
            context.AdministrationRoleARN = this.AdministrationRoleARN;
            context.AutoDeployment_Enabled = this.AutoDeployment_Enabled;
            context.AutoDeployment_RetainStacksOnAccountRemoval = this.AutoDeployment_RetainStacksOnAccountRemoval;
            context.CallAs = this.CallAs;
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            if (this.DeploymentTargets_Account != null)
            {
                context.DeploymentTargets_Account = new List<System.String>(this.DeploymentTargets_Account);
            }
            context.DeploymentTargets_AccountsUrl = this.DeploymentTargets_AccountsUrl;
            if (this.DeploymentTargets_OrganizationalUnitId != null)
            {
                context.DeploymentTargets_OrganizationalUnitId = new List<System.String>(this.DeploymentTargets_OrganizationalUnitId);
            }
            context.Description = this.Description;
            context.ExecutionRoleName = this.ExecutionRoleName;
            context.ManagedExecution_Active = this.ManagedExecution_Active;
            context.OperationId = this.OperationId;
            context.OperationPreference = this.OperationPreference;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            context.PermissionModel = this.PermissionModel;
            if (this.StackRegion != null)
            {
                context.StackRegion = new List<System.String>(this.StackRegion);
            }
            context.StackSetName = this.StackSetName;
            #if MODULAR
            if (this.StackSetName == null && ParameterWasBound(nameof(this.StackSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            context.UsePreviousTemplate = this.UsePreviousTemplate;
            
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
            var request = new Amazon.CloudFormation.Model.UpdateStackSetRequest();
            
            if (cmdletContext.Account != null)
            {
                request.Accounts = cmdletContext.Account;
            }
            if (cmdletContext.AdministrationRoleARN != null)
            {
                request.AdministrationRoleARN = cmdletContext.AdministrationRoleARN;
            }
            
             // populate AutoDeployment
            var requestAutoDeploymentIsNull = true;
            request.AutoDeployment = new Amazon.CloudFormation.Model.AutoDeployment();
            System.Boolean? requestAutoDeployment_autoDeployment_Enabled = null;
            if (cmdletContext.AutoDeployment_Enabled != null)
            {
                requestAutoDeployment_autoDeployment_Enabled = cmdletContext.AutoDeployment_Enabled.Value;
            }
            if (requestAutoDeployment_autoDeployment_Enabled != null)
            {
                request.AutoDeployment.Enabled = requestAutoDeployment_autoDeployment_Enabled.Value;
                requestAutoDeploymentIsNull = false;
            }
            System.Boolean? requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval = null;
            if (cmdletContext.AutoDeployment_RetainStacksOnAccountRemoval != null)
            {
                requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval = cmdletContext.AutoDeployment_RetainStacksOnAccountRemoval.Value;
            }
            if (requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval != null)
            {
                request.AutoDeployment.RetainStacksOnAccountRemoval = requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval.Value;
                requestAutoDeploymentIsNull = false;
            }
             // determine if request.AutoDeployment should be set to null
            if (requestAutoDeploymentIsNull)
            {
                request.AutoDeployment = null;
            }
            if (cmdletContext.CallAs != null)
            {
                request.CallAs = cmdletContext.CallAs;
            }
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            
             // populate DeploymentTargets
            var requestDeploymentTargetsIsNull = true;
            request.DeploymentTargets = new Amazon.CloudFormation.Model.DeploymentTargets();
            List<System.String> requestDeploymentTargets_deploymentTargets_Account = null;
            if (cmdletContext.DeploymentTargets_Account != null)
            {
                requestDeploymentTargets_deploymentTargets_Account = cmdletContext.DeploymentTargets_Account;
            }
            if (requestDeploymentTargets_deploymentTargets_Account != null)
            {
                request.DeploymentTargets.Accounts = requestDeploymentTargets_deploymentTargets_Account;
                requestDeploymentTargetsIsNull = false;
            }
            System.String requestDeploymentTargets_deploymentTargets_AccountsUrl = null;
            if (cmdletContext.DeploymentTargets_AccountsUrl != null)
            {
                requestDeploymentTargets_deploymentTargets_AccountsUrl = cmdletContext.DeploymentTargets_AccountsUrl;
            }
            if (requestDeploymentTargets_deploymentTargets_AccountsUrl != null)
            {
                request.DeploymentTargets.AccountsUrl = requestDeploymentTargets_deploymentTargets_AccountsUrl;
                requestDeploymentTargetsIsNull = false;
            }
            List<System.String> requestDeploymentTargets_deploymentTargets_OrganizationalUnitId = null;
            if (cmdletContext.DeploymentTargets_OrganizationalUnitId != null)
            {
                requestDeploymentTargets_deploymentTargets_OrganizationalUnitId = cmdletContext.DeploymentTargets_OrganizationalUnitId;
            }
            if (requestDeploymentTargets_deploymentTargets_OrganizationalUnitId != null)
            {
                request.DeploymentTargets.OrganizationalUnitIds = requestDeploymentTargets_deploymentTargets_OrganizationalUnitId;
                requestDeploymentTargetsIsNull = false;
            }
             // determine if request.DeploymentTargets should be set to null
            if (requestDeploymentTargetsIsNull)
            {
                request.DeploymentTargets = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleName != null)
            {
                request.ExecutionRoleName = cmdletContext.ExecutionRoleName;
            }
            
             // populate ManagedExecution
            var requestManagedExecutionIsNull = true;
            request.ManagedExecution = new Amazon.CloudFormation.Model.ManagedExecution();
            System.Boolean? requestManagedExecution_managedExecution_Active = null;
            if (cmdletContext.ManagedExecution_Active != null)
            {
                requestManagedExecution_managedExecution_Active = cmdletContext.ManagedExecution_Active.Value;
            }
            if (requestManagedExecution_managedExecution_Active != null)
            {
                request.ManagedExecution.Active = requestManagedExecution_managedExecution_Active.Value;
                requestManagedExecutionIsNull = false;
            }
             // determine if request.ManagedExecution should be set to null
            if (requestManagedExecutionIsNull)
            {
                request.ManagedExecution = null;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.OperationPreference != null)
            {
                request.OperationPreferences = cmdletContext.OperationPreference;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.PermissionModel != null)
            {
                request.PermissionModel = cmdletContext.PermissionModel;
            }
            if (cmdletContext.StackRegion != null)
            {
                request.Regions = cmdletContext.StackRegion;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateURL != null)
            {
                request.TemplateURL = cmdletContext.TemplateURL;
            }
            if (cmdletContext.UsePreviousTemplate != null)
            {
                request.UsePreviousTemplate = cmdletContext.UsePreviousTemplate.Value;
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
        
        private Amazon.CloudFormation.Model.UpdateStackSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateStackSet");
            try
            {
                #if DESKTOP
                return client.UpdateStackSet(request);
                #elif CORECLR
                return client.UpdateStackSetAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Account { get; set; }
            public System.String AdministrationRoleARN { get; set; }
            public System.Boolean? AutoDeployment_Enabled { get; set; }
            public System.Boolean? AutoDeployment_RetainStacksOnAccountRemoval { get; set; }
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public List<System.String> Capability { get; set; }
            public List<System.String> DeploymentTargets_Account { get; set; }
            public System.String DeploymentTargets_AccountsUrl { get; set; }
            public List<System.String> DeploymentTargets_OrganizationalUnitId { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleName { get; set; }
            public System.Boolean? ManagedExecution_Active { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
            public Amazon.CloudFormation.PermissionModels PermissionModel { get; set; }
            public List<System.String> StackRegion { get; set; }
            public System.String StackSetName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tag { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
            public System.Func<Amazon.CloudFormation.Model.UpdateStackSetResponse, UpdateCFNStackSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
