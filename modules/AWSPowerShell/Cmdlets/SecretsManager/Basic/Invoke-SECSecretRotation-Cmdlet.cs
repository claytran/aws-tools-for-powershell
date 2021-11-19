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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Configures and starts the asynchronous process of rotating the secret.
    /// 
    ///  
    /// <para>
    /// If you include the configuration parameters, the operation sets the values for the
    /// secret and then immediately starts a rotation. If you don't include the configuration
    /// parameters, the operation starts a rotation with the values already stored in the
    /// secret. For more information about rotation, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/rotating-secrets.html">Rotate
    /// secrets</a>.
    /// </para><para>
    /// To configure rotation, you include the ARN of an Amazon Web Services Lambda function
    /// and the schedule for the rotation. The Lambda rotation function creates a new version
    /// of the secret and creates or updates the credentials on the database or service to
    /// match. After testing the new credentials, the function marks the new secret version
    /// with the staging label <code>AWSCURRENT</code>. Then anyone who retrieves the secret
    /// gets the new version. For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/rotate-secrets_how.html">How
    /// rotation works</a>.
    /// </para><para>
    /// When rotation is successful, the <code>AWSPENDING</code> staging label might be attached
    /// to the same version as the <code>AWSCURRENT</code> version, or it might not be attached
    /// to any version.
    /// </para><para>
    /// If the <code>AWSPENDING</code> staging label is present but not attached to the same
    /// version as <code>AWSCURRENT</code>, then any later invocation of <code>RotateSecret</code>
    /// assumes that a previous rotation request is still in progress and returns an error.
    /// </para><para>
    /// To run this command, you must have <code>secretsmanager:RotateSecret</code> permissions
    /// and <code>lambda:InvokeFunction</code> permissions on the function specified in the
    /// secret's metadata.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "SECSecretRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.RotateSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager RotateSecret API operation.", Operation = new[] {"RotateSecret"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.RotateSecretResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.RotateSecretResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.RotateSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeSECSecretRotationCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter RotationRules_AutomaticallyAfterDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days between automatic scheduled rotations of the secret.</para><para>Secrets Manager schedules the next rotation when the previous one is complete. Secrets
        /// Manager schedules the date by adding the rotation interval (number of days) to the
        /// actual date of the last rotation. The service chooses the hour within that 24-hour
        /// date window randomly. The minute is also chosen somewhat randomly, but weighted towards
        /// the top of the hour and influenced by a variety of factors that help distribute load.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RotationRules_AutomaticallyAfterDays")]
        public System.Int64? RotationRules_AutomaticallyAfterDay { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the new version of the secret that helps ensure idempotency.
        /// Secrets Manager uses this value to prevent the accidental creation of duplicate versions
        /// if there are failures and retries during rotation. This value becomes the <code>VersionId</code>
        /// of the new version.</para><para>If you use the Amazon Web Services CLI or one of the Amazon Web Services SDK to call
        /// this operation, then you can leave this parameter empty. The CLI or SDK generates
        /// a random UUID for you and includes that in the request for this parameter. If you
        /// don't use the SDK and instead generate a raw HTTP request to the Secrets Manager service
        /// endpoint, then you must generate a <code>ClientRequestToken</code> yourself for new
        /// versions and include that value in the request.</para><para>You only need to specify this value if you implement your own retry logic and you
        /// want to ensure that Secrets Manager doesn't attempt to create a secret version twice.
        /// We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness within the specified secret. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter RotationLambdaARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda rotation function that can rotate the secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RotationLambdaARN { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>The ARN or name of the secret to rotate.</para><para>For an ARN, we recommend that you specify a complete ARN rather than a partial ARN.</para>
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
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.RotateSecretResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.RotateSecretResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecretId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecretId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecretId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecretId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SECSecretRotation (RotateSecret)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.RotateSecretResponse, InvokeSECSecretRotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecretId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.RotationLambdaARN = this.RotationLambdaARN;
            context.RotationRules_AutomaticallyAfterDay = this.RotationRules_AutomaticallyAfterDay;
            context.SecretId = this.SecretId;
            #if MODULAR
            if (this.SecretId == null && ParameterWasBound(nameof(this.SecretId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecretsManager.Model.RotateSecretRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.RotationLambdaARN != null)
            {
                request.RotationLambdaARN = cmdletContext.RotationLambdaARN;
            }
            
             // populate RotationRules
            var requestRotationRulesIsNull = true;
            request.RotationRules = new Amazon.SecretsManager.Model.RotationRulesType();
            System.Int64? requestRotationRules_rotationRules_AutomaticallyAfterDay = null;
            if (cmdletContext.RotationRules_AutomaticallyAfterDay != null)
            {
                requestRotationRules_rotationRules_AutomaticallyAfterDay = cmdletContext.RotationRules_AutomaticallyAfterDay.Value;
            }
            if (requestRotationRules_rotationRules_AutomaticallyAfterDay != null)
            {
                request.RotationRules.AutomaticallyAfterDays = requestRotationRules_rotationRules_AutomaticallyAfterDay.Value;
                requestRotationRulesIsNull = false;
            }
             // determine if request.RotationRules should be set to null
            if (requestRotationRulesIsNull)
            {
                request.RotationRules = null;
            }
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
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
        
        private Amazon.SecretsManager.Model.RotateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.RotateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "RotateSecret");
            try
            {
                #if DESKTOP
                return client.RotateSecret(request);
                #elif CORECLR
                return client.RotateSecretAsync(request).GetAwaiter().GetResult();
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
            public System.String RotationLambdaARN { get; set; }
            public System.Int64? RotationRules_AutomaticallyAfterDay { get; set; }
            public System.String SecretId { get; set; }
            public System.Func<Amazon.SecretsManager.Model.RotateSecretResponse, InvokeSECSecretRotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
