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
    /// <summary> A Class representing a SiteVirtualNetworkConnection along with the instance operations that can be performed on it. </summary>
    public partial class SiteVirtualNetworkConnection : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteVirtualNetworkConnection"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteVirtualNetworkConnectionWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteVirtualNetworkConnectionWebAppsRestClient;
        private readonly VnetInfoResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteVirtualNetworkConnection"/> class for mocking. </summary>
        protected SiteVirtualNetworkConnection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteVirtualNetworkConnection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteVirtualNetworkConnection(ArmClient client, VnetInfoResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteVirtualNetworkConnection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteVirtualNetworkConnection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteVirtualNetworkConnectionWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string siteVirtualNetworkConnectionWebAppsApiVersion);
            _siteVirtualNetworkConnectionWebAppsRestClient = new WebAppsRestOperations(_siteVirtualNetworkConnectionWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteVirtualNetworkConnectionWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/virtualNetworkConnections";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VnetInfoResourceData Data
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

        /// <summary> Gets a collection of SiteVirtualNetworkConnectionGateways in the SiteVirtualNetworkConnectionGateway. </summary>
        /// <returns> An object representing collection of SiteVirtualNetworkConnectionGateways and their operations over a SiteVirtualNetworkConnectionGateway. </returns>
        public virtual SiteVirtualNetworkConnectionGatewayCollection GetSiteVirtualNetworkConnectionGateways()
        {
            return new SiteVirtualNetworkConnectionGatewayCollection(Client, Id);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// OperationId: WebApps_GetVnetConnection
        /// <summary> Description for Gets a virtual network the app (or deployment slot) is connected to by name. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteVirtualNetworkConnection>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.Get");
            scope.Start();
            try
            {
                var response = await _siteVirtualNetworkConnectionWebAppsRestClient.GetVnetConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteVirtualNetworkConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// OperationId: WebApps_GetVnetConnection
        /// <summary> Description for Gets a virtual network the app (or deployment slot) is connected to by name. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteVirtualNetworkConnection> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.Get");
            scope.Start();
            try
            {
                var response = _siteVirtualNetworkConnectionWebAppsRestClient.GetVnetConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteVirtualNetworkConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// OperationId: WebApps_DeleteVnetConnection
        /// <summary> Description for Deletes a connection from an app (or deployment slot to a named virtual network. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<SiteVirtualNetworkConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.Delete");
            scope.Start();
            try
            {
                var response = await _siteVirtualNetworkConnectionWebAppsRestClient.DeleteVnetConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SiteVirtualNetworkConnectionDeleteOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// OperationId: WebApps_DeleteVnetConnection
        /// <summary> Description for Deletes a connection from an app (or deployment slot to a named virtual network. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual SiteVirtualNetworkConnectionDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.Delete");
            scope.Start();
            try
            {
                var response = _siteVirtualNetworkConnectionWebAppsRestClient.DeleteVnetConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SiteVirtualNetworkConnectionDeleteOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// OperationId: WebApps_UpdateVnetConnection
        /// <summary> Description for Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH). </summary>
        /// <param name="connectionEnvelope"> Properties of the Virtual Network connection. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionEnvelope"/> is null. </exception>
        public async virtual Task<Response<SiteVirtualNetworkConnection>> UpdateAsync(VnetInfoResourceData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            if (connectionEnvelope == null)
            {
                throw new ArgumentNullException(nameof(connectionEnvelope));
            }

            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.Update");
            scope.Start();
            try
            {
                var response = await _siteVirtualNetworkConnectionWebAppsRestClient.UpdateVnetConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, connectionEnvelope, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SiteVirtualNetworkConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}
        /// OperationId: WebApps_UpdateVnetConnection
        /// <summary> Description for Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH). </summary>
        /// <param name="connectionEnvelope"> Properties of the Virtual Network connection. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionEnvelope"/> is null. </exception>
        public virtual Response<SiteVirtualNetworkConnection> Update(VnetInfoResourceData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            if (connectionEnvelope == null)
            {
                throw new ArgumentNullException(nameof(connectionEnvelope));
            }

            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.Update");
            scope.Start();
            try
            {
                var response = _siteVirtualNetworkConnectionWebAppsRestClient.UpdateVnetConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, connectionEnvelope, cancellationToken);
                return Response.FromValue(new SiteVirtualNetworkConnection(Client, response.Value), response.GetRawResponse());
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
            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.GetAvailableLocations");
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
            using var scope = _siteVirtualNetworkConnectionWebAppsClientDiagnostics.CreateScope("SiteVirtualNetworkConnection.GetAvailableLocations");
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
