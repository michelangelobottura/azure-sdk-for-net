// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteSlotFunction along with the instance operations that can be performed on it. </summary>
    public partial class SiteSlotFunction : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteSlotFunction"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string functionName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteSlotFunctionWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotFunctionWebAppsRestClient;
        private readonly FunctionEnvelopeData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotFunction"/> class for mocking. </summary>
        protected SiteSlotFunction()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteSlotFunction"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteSlotFunction(ArmClient client, FunctionEnvelopeData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotFunction"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteSlotFunction(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotFunctionWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string siteSlotFunctionWebAppsApiVersion);
            _siteSlotFunctionWebAppsRestClient = new WebAppsRestOperations(_siteSlotFunctionWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotFunctionWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/slots/functions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FunctionEnvelopeData Data
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_GetInstanceFunctionSlot
        /// <summary> Description for Get function information by its ID for web site, or a deployment slot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteSlotFunction>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotFunctionWebAppsRestClient.GetInstanceFunctionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotFunctionWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotFunction(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_GetInstanceFunctionSlot
        /// <summary> Description for Get function information by its ID for web site, or a deployment slot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteSlotFunction> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.Get");
            scope.Start();
            try
            {
                var response = _siteSlotFunctionWebAppsRestClient.GetInstanceFunctionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotFunctionWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotFunction(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_DeleteInstanceFunctionSlot
        /// <summary> Description for Delete a function for web site, or a deployment slot. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<SiteSlotFunctionDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.Delete");
            scope.Start();
            try
            {
                var response = await _siteSlotFunctionWebAppsRestClient.DeleteInstanceFunctionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SiteSlotFunctionDeleteOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_DeleteInstanceFunctionSlot
        /// <summary> Description for Delete a function for web site, or a deployment slot. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual SiteSlotFunctionDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.Delete");
            scope.Start();
            try
            {
                var response = _siteSlotFunctionWebAppsRestClient.DeleteInstanceFunctionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SiteSlotFunctionDeleteOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_CreateOrUpdateFunctionSecretSlot
        /// <summary> Description for Add or update a function secret. </summary>
        /// <param name="keyName"> The name of the key. </param>
        /// <param name="key"> The key to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> or <paramref name="key"/> is null. </exception>
        public async virtual Task<Response<KeyInfo>> CreateOrUpdateFunctionSecretSlotAsync(string keyName, KeyInfo key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.CreateOrUpdateFunctionSecretSlot");
            scope.Start();
            try
            {
                var response = await _siteSlotFunctionWebAppsRestClient.CreateOrUpdateFunctionSecretSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, keyName, key, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_CreateOrUpdateFunctionSecretSlot
        /// <summary> Description for Add or update a function secret. </summary>
        /// <param name="keyName"> The name of the key. </param>
        /// <param name="key"> The key to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> or <paramref name="key"/> is null. </exception>
        public virtual Response<KeyInfo> CreateOrUpdateFunctionSecretSlot(string keyName, KeyInfo key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.CreateOrUpdateFunctionSecretSlot");
            scope.Start();
            try
            {
                var response = _siteSlotFunctionWebAppsRestClient.CreateOrUpdateFunctionSecretSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, keyName, key, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_DeleteFunctionSecretSlot
        /// <summary> Description for Delete a function secret. </summary>
        /// <param name="keyName"> The name of the key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public async virtual Task<Response> DeleteFunctionSecretSlotAsync(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.DeleteFunctionSecretSlot");
            scope.Start();
            try
            {
                var response = await _siteSlotFunctionWebAppsRestClient.DeleteFunctionSecretSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, keyName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_DeleteFunctionSecretSlot
        /// <summary> Description for Delete a function secret. </summary>
        /// <param name="keyName"> The name of the key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public virtual Response DeleteFunctionSecretSlot(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.DeleteFunctionSecretSlot");
            scope.Start();
            try
            {
                var response = _siteSlotFunctionWebAppsRestClient.DeleteFunctionSecretSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, keyName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listkeys
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_ListFunctionKeysSlot
        /// <summary> Description for Get function keys for a function in a web site, or a deployment slot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<StringDictionary>> GetFunctionKeysSlotAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.GetFunctionKeysSlot");
            scope.Start();
            try
            {
                var response = await _siteSlotFunctionWebAppsRestClient.ListFunctionKeysSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listkeys
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_ListFunctionKeysSlot
        /// <summary> Description for Get function keys for a function in a web site, or a deployment slot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StringDictionary> GetFunctionKeysSlot(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.GetFunctionKeysSlot");
            scope.Start();
            try
            {
                var response = _siteSlotFunctionWebAppsRestClient.ListFunctionKeysSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listsecrets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_ListFunctionSecretsSlot
        /// <summary> Description for Get function secrets for a function in a web site, or a deployment slot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<FunctionSecrets>> GetFunctionSecretsSlotAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.GetFunctionSecretsSlot");
            scope.Start();
            try
            {
                var response = await _siteSlotFunctionWebAppsRestClient.ListFunctionSecretsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listsecrets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}
        /// OperationId: WebApps_ListFunctionSecretsSlot
        /// <summary> Description for Get function secrets for a function in a web site, or a deployment slot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FunctionSecrets> GetFunctionSecretsSlot(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.GetFunctionSecretsSlot");
            scope.Start();
            try
            {
                var response = _siteSlotFunctionWebAppsRestClient.ListFunctionSecretsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
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
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.GetAvailableLocations");
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
            using var scope = _siteSlotFunctionWebAppsClientDiagnostics.CreateScope("SiteSlotFunction.GetAvailableLocations");
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
