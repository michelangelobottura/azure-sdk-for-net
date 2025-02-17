// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a DeploymentScript along with the instance operations that can be performed on it. </summary>
    public partial class DeploymentScript : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DeploymentScript"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentScripts/{scriptName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _deploymentScriptClientDiagnostics;
        private readonly DeploymentScriptsRestOperations _deploymentScriptRestClient;
        private readonly ClientDiagnostics _scriptLogDeploymentScriptsClientDiagnostics;
        private readonly DeploymentScriptsRestOperations _scriptLogDeploymentScriptsRestClient;
        private readonly DeploymentScriptData _data;

        /// <summary> Initializes a new instance of the <see cref="DeploymentScript"/> class for mocking. </summary>
        protected DeploymentScript()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DeploymentScript"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DeploymentScript(ArmClient client, DeploymentScriptData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DeploymentScript"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DeploymentScript(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deploymentScriptClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string deploymentScriptApiVersion);
            _deploymentScriptRestClient = new DeploymentScriptsRestOperations(_deploymentScriptClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deploymentScriptApiVersion);
            _scriptLogDeploymentScriptsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ScriptLog.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ScriptLog.ResourceType, out string scriptLogDeploymentScriptsApiVersion);
            _scriptLogDeploymentScriptsRestClient = new DeploymentScriptsRestOperations(_scriptLogDeploymentScriptsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, scriptLogDeploymentScriptsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/deploymentScripts";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DeploymentScriptData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets an object representing a ScriptLog along with the instance operations that can be performed on it in the DeploymentScript. </summary>
        /// <returns> Returns a <see cref="ScriptLog" /> object. </returns>
        public virtual ScriptLog GetScriptLog()
        {
            return new ScriptLog(Client, new ResourceIdentifier(Id.ToString() + "/logs/default"));
        }

        /// <summary> Gets a deployment script with a given name. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DeploymentScript>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.Get");
            scope.Start();
            try
            {
                var response = await _deploymentScriptRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _deploymentScriptClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeploymentScript(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a deployment script with a given name. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentScript> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.Get");
            scope.Start();
            try
            {
                var response = _deploymentScriptRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _deploymentScriptClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentScript(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a deployment script. When operation completes, status code 200 returned without content. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<DeploymentScriptDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.Delete");
            scope.Start();
            try
            {
                var response = await _deploymentScriptRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new DeploymentScriptDeleteOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a deployment script. When operation completes, status code 200 returned without content. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual DeploymentScriptDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.Delete");
            scope.Start();
            try
            {
                var response = _deploymentScriptRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new DeploymentScriptDeleteOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates deployment script tags with specified values. </summary>
        /// <param name="tags"> Resource tags to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DeploymentScript>> UpdateAsync(IDictionary<string, string> tags = null, CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.Update");
            scope.Start();
            try
            {
                var response = await _deploymentScriptRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, tags, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DeploymentScript(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates deployment script tags with specified values. </summary>
        /// <param name="tags"> Resource tags to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentScript> Update(IDictionary<string, string> tags = null, CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.Update");
            scope.Start();
            try
            {
                var response = _deploymentScriptRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, tags, cancellationToken);
                return Response.FromValue(new DeploymentScript(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets deployment script logs for a given deployment script name. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ScriptLog" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ScriptLog> GetLogsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ScriptLog>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _scriptLogDeploymentScriptsClientDiagnostics.CreateScope("DeploymentScript.GetLogs");
                scope.Start();
                try
                {
                    var response = await _scriptLogDeploymentScriptsRestClient.GetLogsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ScriptLog(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Gets deployment script logs for a given deployment script name. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ScriptLog" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ScriptLog> GetLogs(CancellationToken cancellationToken = default)
        {
            Page<ScriptLog> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _scriptLogDeploymentScriptsClientDiagnostics.CreateScope("DeploymentScript.GetLogs");
                scope.Start();
                try
                {
                    var response = _scriptLogDeploymentScriptsRestClient.GetLogs(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ScriptLog(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.GetAvailableLocations");
            scope.Start();
            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentScriptClientDiagnostics.CreateScope("DeploymentScript.GetAvailableLocations");
            scope.Start();
            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
