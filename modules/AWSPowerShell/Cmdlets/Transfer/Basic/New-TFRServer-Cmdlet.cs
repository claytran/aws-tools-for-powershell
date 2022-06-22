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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Instantiates an auto-scaling virtual server based on the selected file transfer protocol
    /// in Amazon Web Services. When you make updates to your file transfer protocol-enabled
    /// server or when you work with users, use the service-generated <code>ServerId</code>
    /// property that is assigned to the newly created server.
    /// </summary>
    [Cmdlet("New", "TFRServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP CreateServer API operation.", Operation = new[] {"CreateServer"}, SelectReturnType = typeof(Amazon.Transfer.Model.CreateServerResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.CreateServerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.CreateServerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTFRServerCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointDetails_AddressAllocationId
        /// <summary>
        /// <para>
        /// <para>A list of address allocation IDs that are required to attach an Elastic IP address
        /// to your server's endpoint.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>
        /// and it is only valid in the <code>UpdateServer</code> API.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_AddressAllocationIds")]
        public System.String[] EndpointDetails_AddressAllocationId { get; set; }
        #endregion
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Certificate Manager (ACM)
        /// certificate. Required when <code>Protocols</code> is set to <code>FTPS</code>.</para><para>To request a new public certificate, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-request-public.html">Request
        /// a public certificate</a> in the <i> Amazon Web Services Certificate Manager User Guide</i>.</para><para>To import an existing certificate into ACM, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/import-certificate.html">Importing
        /// certificates into ACM</a> in the <i> Amazon Web Services Certificate Manager User
        /// Guide</i>.</para><para>To request a private certificate to use FTPS through private IP addresses, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-request-private.html">Request
        /// a private certificate</a> in the <i> Amazon Web Services Certificate Manager User
        /// Guide</i>.</para><para>Certificates with the following cryptographic algorithms and key sizes are supported:</para><ul><li><para>2048-bit RSA (RSA_2048)</para></li><li><para>4096-bit RSA (RSA_4096)</para></li><li><para>Elliptic Prime Curve 256 bit (EC_prime256v1)</para></li><li><para>Elliptic Prime Curve 384 bit (EC_secp384r1)</para></li><li><para>Elliptic Prime Curve 521 bit (EC_secp521r1)</para></li></ul><note><para>The certificate must be a valid SSL/TLS X.509 version 3 certificate with FQDN or IP
        /// address specified and information about the issuer.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Certificate { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Web Services Directory Service directory that you want
        /// to stop sharing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_DirectoryId { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The domain of the storage system that is used for file transfers. There are two domains
        /// available: Amazon Simple Storage Service (Amazon S3) and Amazon Elastic File System
        /// (Amazon EFS). The default value is S3.</para><note><para>After the server is created, the domain cannot be changed.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.Domain")]
        public Amazon.Transfer.Domain Domain { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint that you want your server to use. You can choose to make your
        /// server's endpoint publicly accessible (PUBLIC) or host it inside your VPC. With an
        /// endpoint that is hosted in a VPC, you can restrict access to your server and resources
        /// only within your VPC or choose to make it internet facing by attaching Elastic IP
        /// addresses directly to it.</para><note><para> After May 19, 2021, you won't be able to create a server using <code>EndpointType=VPC_ENDPOINT</code>
        /// in your Amazon Web Services account if your account hasn't already done so before
        /// May 19, 2021. If you have already created servers with <code>EndpointType=VPC_ENDPOINT</code>
        /// in your Amazon Web Services account on or before May 19, 2021, you will not be affected.
        /// After this date, use <code>EndpointType</code>=<code>VPC</code>.</para><para>For more information, see https://docs.aws.amazon.com/transfer/latest/userguide/create-server-in-vpc.html#deprecate-vpc-endpoint.</para><para>It is recommended that you use <code>VPC</code> as the <code>EndpointType</code>.
        /// With this endpoint type, you have the option to directly associate up to three Elastic
        /// IPv4 addresses (BYO IP included) with your server's endpoint and use VPC security
        /// groups to restrict traffic by the client's public IP address. This is not possible
        /// with <code>EndpointType</code> set to <code>VPC_ENDPOINT</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.EndpointType")]
        public Amazon.Transfer.EndpointType EndpointType { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_Function
        /// <summary>
        /// <para>
        /// <para>The ARN for a lambda function to use for the Identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_Function { get; set; }
        #endregion
        
        #region Parameter HostKey
        /// <summary>
        /// <para>
        /// <para>The RSA, ECDSA, or ED25519 private key to use for your server.</para><para>Use the following command to generate an RSA 2048 bit key with no passphrase:</para><para><code>ssh-keygen -t rsa -b 2048 -N "" -m PEM -f my-new-server-key</code>.</para><para>Use a minimum value of 2048 for the <code>-b</code> option: you can create a stronger
        /// key using 3072 or 4096.</para><para>Use the following command to generate an ECDSA 256 bit key with no passphrase:</para><para><code>ssh-keygen -t ecdsa -b 256 -N "" -m PEM -f my-new-server-key</code>.</para><para>Valid values for the <code>-b</code> option for ECDSA are 256, 384, and 521.</para><para>Use the following command to generate an ED25519 key with no passphrase:</para><para><code>ssh-keygen -t ed25519 -N "" -f my-new-server-key</code>.</para><para>For all of these commands, you can replace <i>my-new-server-key</i> with a string
        /// of your choice.</para><important><para>If you aren't planning to migrate existing users from an existing SFTP-enabled server
        /// to a new server, don't update the host key. Accidentally changing a server's host
        /// key can be disruptive.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/edit-server-config.html#configuring-servers-change-host-key">Change
        /// the host key for your SFTP-enabled server</a> in the <i>Amazon Web Services Transfer
        /// Family User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostKey { get; set; }
        #endregion
        
        #region Parameter IdentityProviderType
        /// <summary>
        /// <para>
        /// <para>Specifies the mode of authentication for a server. The default value is <code>SERVICE_MANAGED</code>,
        /// which allows you to store and access user credentials within the Amazon Web Services
        /// Transfer Family service.</para><para>Use <code>AWS_DIRECTORY_SERVICE</code> to provide access to Active Directory groups
        /// in Amazon Web Services Managed Active Directory or Microsoft Active Directory in your
        /// on-premises environment or in Amazon Web Services using AD Connectors. This option
        /// also requires you to provide a Directory ID using the <code>IdentityProviderDetails</code>
        /// parameter.</para><para>Use the <code>API_GATEWAY</code> value to integrate with an identity provider of your
        /// choosing. The <code>API_GATEWAY</code> setting requires you to provide an API Gateway
        /// endpoint URL to call for authentication using the <code>IdentityProviderDetails</code>
        /// parameter.</para><para>Use the <code>AWS_LAMBDA</code> value to directly use a Lambda function as your identity
        /// provider. If you choose this value, you must specify the ARN for the lambda function
        /// in the <code>Function</code> parameter for the <code>IdentityProviderDetails</code>
        /// data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.IdentityProviderType")]
        public Amazon.Transfer.IdentityProviderType IdentityProviderType { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_InvocationRole
        /// <summary>
        /// <para>
        /// <para>Provides the type of <code>InvocationRole</code> used to authenticate the user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_InvocationRole { get; set; }
        #endregion
        
        #region Parameter LoggingRole
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the Amazon Web Services Identity and Access
        /// Management (IAM) role that allows a server to turn on Amazon CloudWatch logging for
        /// Amazon S3 or Amazon EFS events. When set, user activity can be viewed in your CloudWatch
        /// logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingRole { get; set; }
        #endregion
        
        #region Parameter WorkflowDetails_OnUpload
        /// <summary>
        /// <para>
        /// <para>A trigger that starts a workflow: the workflow begins to execute after a file is uploaded.</para><para>To remove an associated workflow from a server, you can provide an empty <code>OnUpload</code>
        /// object, as in the following example.</para><para><code>aws transfer update-server --server-id s-01234567890abcdef --workflow-details
        /// '{"OnUpload":[]}'</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Transfer.Model.WorkflowDetail[] WorkflowDetails_OnUpload { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_PassiveIp
        /// <summary>
        /// <para>
        /// <para> Indicates passive mode, for FTP and FTPS protocols. Enter a single IPv4 address,
        /// such as the public IP address of a firewall, router, or load balancer. For example:
        /// </para><para><code> aws transfer update-server --protocol-details PassiveIp=<i>0.0.0.0</i></code></para><para>Replace <code><i>0.0.0.0</i></code> in the example above with the actual IP address
        /// you want to use.</para><note><para> If you change the <code>PassiveIp</code> value, you must stop and then restart your
        /// Transfer Family server for the change to take effect. For details on using passive
        /// mode (PASV) in a NAT environment, see <a href="http://aws.amazon.com/blogs/storage/configuring-your-ftps-server-behind-a-firewall-or-nat-with-aws-transfer-family/">Configuring
        /// your FTPS server behind a firewall or NAT with Transfer Family</a>. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtocolDetails_PassiveIp { get; set; }
        #endregion
        
        #region Parameter PostAuthenticationLoginBanner
        /// <summary>
        /// <para>
        /// <para>Specify a string to display when users connect to a server. This string is displayed
        /// after the user authenticates.</para><note><para>The SFTP protocol does not support post-authentication display banners.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostAuthenticationLoginBanner { get; set; }
        #endregion
        
        #region Parameter PreAuthenticationLoginBanner
        /// <summary>
        /// <para>
        /// <para>Specify a string to display when users connect to a server. This string is displayed
        /// before the user authenticates. For example, the following banner displays details
        /// about using the system.</para><para><code>This system is for the use of authorized users only. Individuals using this
        /// computer system without authority, or in excess of their authority, are subject to
        /// having all of their activities on this system monitored and recorded by system personnel.</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreAuthenticationLoginBanner { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>Specifies the file transfer protocol or protocols over which your file transfer protocol
        /// client can connect to your server's endpoint. The available protocols are:</para><ul><li><para><code>SFTP</code> (Secure Shell (SSH) File Transfer Protocol): File transfer over
        /// SSH</para></li><li><para><code>FTPS</code> (File Transfer Protocol Secure): File transfer with TLS encryption</para></li><li><para><code>FTP</code> (File Transfer Protocol): Unencrypted file transfer</para></li></ul><note><para>If you select <code>FTPS</code>, you must choose a certificate stored in Amazon Web
        /// Services Certificate Manager (ACM) which is used to identify your server when clients
        /// connect to it over FTPS.</para><para>If <code>Protocol</code> includes either <code>FTP</code> or <code>FTPS</code>, then
        /// the <code>EndpointType</code> must be <code>VPC</code> and the <code>IdentityProviderType</code>
        /// must be <code>AWS_DIRECTORY_SERVICE</code> or <code>API_GATEWAY</code>.</para><para>If <code>Protocol</code> includes <code>FTP</code>, then <code>AddressAllocationIds</code>
        /// cannot be associated.</para><para>If <code>Protocol</code> is set only to <code>SFTP</code>, the <code>EndpointType</code>
        /// can be set to <code>PUBLIC</code> and the <code>IdentityProviderType</code> can be
        /// set to <code>SERVICE_MANAGED</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocols")]
        public System.String[] Protocol { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security groups IDs that are available to attach to your server's endpoint.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>.</para><para>You can edit the <code>SecurityGroupIds</code> property in the <a href="https://docs.aws.amazon.com/transfer/latest/userguide/API_UpdateServer.html">UpdateServer</a>
        /// API only if you are changing the <code>EndpointType</code> from <code>PUBLIC</code>
        /// or <code>VPC_ENDPOINT</code> to <code>VPC</code>. To change security groups associated
        /// with your server's VPC endpoint after creation, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ModifyVpcEndpoint.html">ModifyVpcEndpoint</a>
        /// API.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_SecurityGroupIds")]
        public System.String[] EndpointDetails_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityPolicyName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the security policy that is attached to the server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityPolicyName { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_SetStatOption
        /// <summary>
        /// <para>
        /// <para>Use the <code>SetStatOption</code> to ignore the error that is generated when the
        /// client attempts to use <code>SETSTAT</code> on a file you are uploading to an S3 bucket.</para><para>Some SFTP file transfer clients can attempt to change the attributes of remote files,
        /// including timestamp and permissions, using commands, such as <code>SETSTAT</code>
        /// when uploading the file. However, these commands are not compatible with object storage
        /// systems, such as Amazon S3. Due to this incompatibility, file uploads from these clients
        /// can result in errors even when the file is otherwise successfully uploaded.</para><para>Set the value to <code>ENABLE_NO_OP</code> to have the Transfer Family server ignore
        /// the <code>SETSTAT</code> command, and upload files without needing to make any changes
        /// to your SFTP client. While the <code>SetStatOption</code><code>ENABLE_NO_OP</code>
        /// setting ignores the error, it does generate a log entry in Amazon CloudWatch Logs,
        /// so you can determine when the client is making a <code>SETSTAT</code> call.</para><note><para>If you want to preserve the original timestamp for your file, and modify other file
        /// attributes using <code>SETSTAT</code>, you can use Amazon EFS as backend storage with
        /// Transfer Family.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.SetStatOption")]
        public Amazon.Transfer.SetStatOption ProtocolDetails_SetStatOption { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs that are required to host your server endpoint in your VPC.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_SubnetIds")]
        public System.String[] EndpointDetails_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to group and search for servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Transfer.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_TlsSessionResumptionMode
        /// <summary>
        /// <para>
        /// <para>A property used with Transfer Family servers that use the FTPS protocol. TLS Session
        /// Resumption provides a mechanism to resume or share a negotiated secret key between
        /// the control and data connection for an FTPS session. <code>TlsSessionResumptionMode</code>
        /// determines whether or not the server resumes recent, negotiated sessions through a
        /// unique session ID. This property is available during <code>CreateServer</code> and
        /// <code>UpdateServer</code> calls. If a <code>TlsSessionResumptionMode</code> value
        /// is not specified during <code>CreateServer</code>, it is set to <code>ENFORCED</code>
        /// by default.</para><ul><li><para><code>DISABLED</code>: the server does not process TLS session resumption client
        /// requests and creates a new TLS session for each request. </para></li><li><para><code>ENABLED</code>: the server processes and accepts clients that are performing
        /// TLS session resumption. The server doesn't reject client data connections that do
        /// not perform the TLS session resumption client processing.</para></li><li><para><code>ENFORCED</code>: the server processes and accepts clients that are performing
        /// TLS session resumption. The server rejects client data connections that do not perform
        /// the TLS session resumption client processing. Before you set the value to <code>ENFORCED</code>,
        /// test your clients.</para><note><para>Not all FTPS clients perform TLS session resumption. So, if you choose to enforce
        /// TLS session resumption, you prevent any connections from FTPS clients that don't perform
        /// the protocol negotiation. To determine whether or not you can use the <code>ENFORCED</code>
        /// value, you need to test your clients.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.TlsSessionResumptionMode")]
        public Amazon.Transfer.TlsSessionResumptionMode ProtocolDetails_TlsSessionResumptionMode { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_Url
        /// <summary>
        /// <para>
        /// <para>Provides the location of the service endpoint used to authenticate users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_Url { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC endpoint.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC_ENDPOINT</code>.</para><para>For more information, see https://docs.aws.amazon.com/transfer/latest/userguide/create-server-in-vpc.html#deprecate-vpc-endpoint.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointDetails_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_VpcId
        /// <summary>
        /// <para>
        /// <para>The VPC ID of the VPC in which a server's endpoint will be hosted.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointDetails_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.CreateServerResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.CreateServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TFRServer (CreateServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.CreateServerResponse, NewTFRServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Certificate = this.Certificate;
            context.Domain = this.Domain;
            if (this.EndpointDetails_AddressAllocationId != null)
            {
                context.EndpointDetails_AddressAllocationId = new List<System.String>(this.EndpointDetails_AddressAllocationId);
            }
            if (this.EndpointDetails_SecurityGroupId != null)
            {
                context.EndpointDetails_SecurityGroupId = new List<System.String>(this.EndpointDetails_SecurityGroupId);
            }
            if (this.EndpointDetails_SubnetId != null)
            {
                context.EndpointDetails_SubnetId = new List<System.String>(this.EndpointDetails_SubnetId);
            }
            context.EndpointDetails_VpcEndpointId = this.EndpointDetails_VpcEndpointId;
            context.EndpointDetails_VpcId = this.EndpointDetails_VpcId;
            context.EndpointType = this.EndpointType;
            context.HostKey = this.HostKey;
            context.IdentityProviderDetails_DirectoryId = this.IdentityProviderDetails_DirectoryId;
            context.IdentityProviderDetails_Function = this.IdentityProviderDetails_Function;
            context.IdentityProviderDetails_InvocationRole = this.IdentityProviderDetails_InvocationRole;
            context.IdentityProviderDetails_Url = this.IdentityProviderDetails_Url;
            context.IdentityProviderType = this.IdentityProviderType;
            context.LoggingRole = this.LoggingRole;
            context.PostAuthenticationLoginBanner = this.PostAuthenticationLoginBanner;
            context.PreAuthenticationLoginBanner = this.PreAuthenticationLoginBanner;
            context.ProtocolDetails_PassiveIp = this.ProtocolDetails_PassiveIp;
            context.ProtocolDetails_SetStatOption = this.ProtocolDetails_SetStatOption;
            context.ProtocolDetails_TlsSessionResumptionMode = this.ProtocolDetails_TlsSessionResumptionMode;
            if (this.Protocol != null)
            {
                context.Protocol = new List<System.String>(this.Protocol);
            }
            context.SecurityPolicyName = this.SecurityPolicyName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Transfer.Model.Tag>(this.Tag);
            }
            if (this.WorkflowDetails_OnUpload != null)
            {
                context.WorkflowDetails_OnUpload = new List<Amazon.Transfer.Model.WorkflowDetail>(this.WorkflowDetails_OnUpload);
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
            var request = new Amazon.Transfer.Model.CreateServerRequest();
            
            if (cmdletContext.Certificate != null)
            {
                request.Certificate = cmdletContext.Certificate;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate EndpointDetails
            var requestEndpointDetailsIsNull = true;
            request.EndpointDetails = new Amazon.Transfer.Model.EndpointDetails();
            List<System.String> requestEndpointDetails_endpointDetails_AddressAllocationId = null;
            if (cmdletContext.EndpointDetails_AddressAllocationId != null)
            {
                requestEndpointDetails_endpointDetails_AddressAllocationId = cmdletContext.EndpointDetails_AddressAllocationId;
            }
            if (requestEndpointDetails_endpointDetails_AddressAllocationId != null)
            {
                request.EndpointDetails.AddressAllocationIds = requestEndpointDetails_endpointDetails_AddressAllocationId;
                requestEndpointDetailsIsNull = false;
            }
            List<System.String> requestEndpointDetails_endpointDetails_SecurityGroupId = null;
            if (cmdletContext.EndpointDetails_SecurityGroupId != null)
            {
                requestEndpointDetails_endpointDetails_SecurityGroupId = cmdletContext.EndpointDetails_SecurityGroupId;
            }
            if (requestEndpointDetails_endpointDetails_SecurityGroupId != null)
            {
                request.EndpointDetails.SecurityGroupIds = requestEndpointDetails_endpointDetails_SecurityGroupId;
                requestEndpointDetailsIsNull = false;
            }
            List<System.String> requestEndpointDetails_endpointDetails_SubnetId = null;
            if (cmdletContext.EndpointDetails_SubnetId != null)
            {
                requestEndpointDetails_endpointDetails_SubnetId = cmdletContext.EndpointDetails_SubnetId;
            }
            if (requestEndpointDetails_endpointDetails_SubnetId != null)
            {
                request.EndpointDetails.SubnetIds = requestEndpointDetails_endpointDetails_SubnetId;
                requestEndpointDetailsIsNull = false;
            }
            System.String requestEndpointDetails_endpointDetails_VpcEndpointId = null;
            if (cmdletContext.EndpointDetails_VpcEndpointId != null)
            {
                requestEndpointDetails_endpointDetails_VpcEndpointId = cmdletContext.EndpointDetails_VpcEndpointId;
            }
            if (requestEndpointDetails_endpointDetails_VpcEndpointId != null)
            {
                request.EndpointDetails.VpcEndpointId = requestEndpointDetails_endpointDetails_VpcEndpointId;
                requestEndpointDetailsIsNull = false;
            }
            System.String requestEndpointDetails_endpointDetails_VpcId = null;
            if (cmdletContext.EndpointDetails_VpcId != null)
            {
                requestEndpointDetails_endpointDetails_VpcId = cmdletContext.EndpointDetails_VpcId;
            }
            if (requestEndpointDetails_endpointDetails_VpcId != null)
            {
                request.EndpointDetails.VpcId = requestEndpointDetails_endpointDetails_VpcId;
                requestEndpointDetailsIsNull = false;
            }
             // determine if request.EndpointDetails should be set to null
            if (requestEndpointDetailsIsNull)
            {
                request.EndpointDetails = null;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            if (cmdletContext.HostKey != null)
            {
                request.HostKey = cmdletContext.HostKey;
            }
            
             // populate IdentityProviderDetails
            var requestIdentityProviderDetailsIsNull = true;
            request.IdentityProviderDetails = new Amazon.Transfer.Model.IdentityProviderDetails();
            System.String requestIdentityProviderDetails_identityProviderDetails_DirectoryId = null;
            if (cmdletContext.IdentityProviderDetails_DirectoryId != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_DirectoryId = cmdletContext.IdentityProviderDetails_DirectoryId;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_DirectoryId != null)
            {
                request.IdentityProviderDetails.DirectoryId = requestIdentityProviderDetails_identityProviderDetails_DirectoryId;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_Function = null;
            if (cmdletContext.IdentityProviderDetails_Function != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_Function = cmdletContext.IdentityProviderDetails_Function;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_Function != null)
            {
                request.IdentityProviderDetails.Function = requestIdentityProviderDetails_identityProviderDetails_Function;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_InvocationRole = null;
            if (cmdletContext.IdentityProviderDetails_InvocationRole != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_InvocationRole = cmdletContext.IdentityProviderDetails_InvocationRole;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_InvocationRole != null)
            {
                request.IdentityProviderDetails.InvocationRole = requestIdentityProviderDetails_identityProviderDetails_InvocationRole;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_Url = null;
            if (cmdletContext.IdentityProviderDetails_Url != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_Url = cmdletContext.IdentityProviderDetails_Url;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_Url != null)
            {
                request.IdentityProviderDetails.Url = requestIdentityProviderDetails_identityProviderDetails_Url;
                requestIdentityProviderDetailsIsNull = false;
            }
             // determine if request.IdentityProviderDetails should be set to null
            if (requestIdentityProviderDetailsIsNull)
            {
                request.IdentityProviderDetails = null;
            }
            if (cmdletContext.IdentityProviderType != null)
            {
                request.IdentityProviderType = cmdletContext.IdentityProviderType;
            }
            if (cmdletContext.LoggingRole != null)
            {
                request.LoggingRole = cmdletContext.LoggingRole;
            }
            if (cmdletContext.PostAuthenticationLoginBanner != null)
            {
                request.PostAuthenticationLoginBanner = cmdletContext.PostAuthenticationLoginBanner;
            }
            if (cmdletContext.PreAuthenticationLoginBanner != null)
            {
                request.PreAuthenticationLoginBanner = cmdletContext.PreAuthenticationLoginBanner;
            }
            
             // populate ProtocolDetails
            var requestProtocolDetailsIsNull = true;
            request.ProtocolDetails = new Amazon.Transfer.Model.ProtocolDetails();
            System.String requestProtocolDetails_protocolDetails_PassiveIp = null;
            if (cmdletContext.ProtocolDetails_PassiveIp != null)
            {
                requestProtocolDetails_protocolDetails_PassiveIp = cmdletContext.ProtocolDetails_PassiveIp;
            }
            if (requestProtocolDetails_protocolDetails_PassiveIp != null)
            {
                request.ProtocolDetails.PassiveIp = requestProtocolDetails_protocolDetails_PassiveIp;
                requestProtocolDetailsIsNull = false;
            }
            Amazon.Transfer.SetStatOption requestProtocolDetails_protocolDetails_SetStatOption = null;
            if (cmdletContext.ProtocolDetails_SetStatOption != null)
            {
                requestProtocolDetails_protocolDetails_SetStatOption = cmdletContext.ProtocolDetails_SetStatOption;
            }
            if (requestProtocolDetails_protocolDetails_SetStatOption != null)
            {
                request.ProtocolDetails.SetStatOption = requestProtocolDetails_protocolDetails_SetStatOption;
                requestProtocolDetailsIsNull = false;
            }
            Amazon.Transfer.TlsSessionResumptionMode requestProtocolDetails_protocolDetails_TlsSessionResumptionMode = null;
            if (cmdletContext.ProtocolDetails_TlsSessionResumptionMode != null)
            {
                requestProtocolDetails_protocolDetails_TlsSessionResumptionMode = cmdletContext.ProtocolDetails_TlsSessionResumptionMode;
            }
            if (requestProtocolDetails_protocolDetails_TlsSessionResumptionMode != null)
            {
                request.ProtocolDetails.TlsSessionResumptionMode = requestProtocolDetails_protocolDetails_TlsSessionResumptionMode;
                requestProtocolDetailsIsNull = false;
            }
             // determine if request.ProtocolDetails should be set to null
            if (requestProtocolDetailsIsNull)
            {
                request.ProtocolDetails = null;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocols = cmdletContext.Protocol;
            }
            if (cmdletContext.SecurityPolicyName != null)
            {
                request.SecurityPolicyName = cmdletContext.SecurityPolicyName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate WorkflowDetails
            var requestWorkflowDetailsIsNull = true;
            request.WorkflowDetails = new Amazon.Transfer.Model.WorkflowDetails();
            List<Amazon.Transfer.Model.WorkflowDetail> requestWorkflowDetails_workflowDetails_OnUpload = null;
            if (cmdletContext.WorkflowDetails_OnUpload != null)
            {
                requestWorkflowDetails_workflowDetails_OnUpload = cmdletContext.WorkflowDetails_OnUpload;
            }
            if (requestWorkflowDetails_workflowDetails_OnUpload != null)
            {
                request.WorkflowDetails.OnUpload = requestWorkflowDetails_workflowDetails_OnUpload;
                requestWorkflowDetailsIsNull = false;
            }
             // determine if request.WorkflowDetails should be set to null
            if (requestWorkflowDetailsIsNull)
            {
                request.WorkflowDetails = null;
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
        
        private Amazon.Transfer.Model.CreateServerResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.CreateServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "CreateServer");
            try
            {
                #if DESKTOP
                return client.CreateServer(request);
                #elif CORECLR
                return client.CreateServerAsync(request).GetAwaiter().GetResult();
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
            public System.String Certificate { get; set; }
            public Amazon.Transfer.Domain Domain { get; set; }
            public List<System.String> EndpointDetails_AddressAllocationId { get; set; }
            public List<System.String> EndpointDetails_SecurityGroupId { get; set; }
            public List<System.String> EndpointDetails_SubnetId { get; set; }
            public System.String EndpointDetails_VpcEndpointId { get; set; }
            public System.String EndpointDetails_VpcId { get; set; }
            public Amazon.Transfer.EndpointType EndpointType { get; set; }
            public System.String HostKey { get; set; }
            public System.String IdentityProviderDetails_DirectoryId { get; set; }
            public System.String IdentityProviderDetails_Function { get; set; }
            public System.String IdentityProviderDetails_InvocationRole { get; set; }
            public System.String IdentityProviderDetails_Url { get; set; }
            public Amazon.Transfer.IdentityProviderType IdentityProviderType { get; set; }
            public System.String LoggingRole { get; set; }
            public System.String PostAuthenticationLoginBanner { get; set; }
            public System.String PreAuthenticationLoginBanner { get; set; }
            public System.String ProtocolDetails_PassiveIp { get; set; }
            public Amazon.Transfer.SetStatOption ProtocolDetails_SetStatOption { get; set; }
            public Amazon.Transfer.TlsSessionResumptionMode ProtocolDetails_TlsSessionResumptionMode { get; set; }
            public List<System.String> Protocol { get; set; }
            public System.String SecurityPolicyName { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public List<Amazon.Transfer.Model.WorkflowDetail> WorkflowDetails_OnUpload { get; set; }
            public System.Func<Amazon.Transfer.Model.CreateServerResponse, NewTFRServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerId;
        }
        
    }
}
