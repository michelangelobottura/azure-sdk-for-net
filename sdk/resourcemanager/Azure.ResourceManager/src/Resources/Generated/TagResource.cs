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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a TagResource along with the instance operations that can be performed on it. </summary>
    public partial class TagResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="TagResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string scope)
        {
            var resourceId = $"{scope}/providers/Microsoft.Resources/tags/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _tagResourceTagsClientDiagnostics;
        private readonly TagsRestOperations _tagResourceTagsRestClient;
        private readonly TagResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="TagResource"/> class for mocking. </summary>
        protected TagResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TagResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TagResource(ArmClient client, TagResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="TagResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TagResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tagResourceTagsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string tagResourceTagsApiVersion);
            _tagResourceTagsRestClient = new TagsRestOperations(_tagResourceTagsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, tagResourceTagsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/tags";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual TagResourceData Data
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

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_GetAtScope
        /// <summary> Gets the entire set of tags on a resource or subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<TagResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.Get");
            scope.Start();
            try
            {
                var response = await _tagResourceTagsRestClient.GetAtScopeAsync(Id.Parent, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _tagResourceTagsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TagResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_GetAtScope
        /// <summary> Gets the entire set of tags on a resource or subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.Get");
            scope.Start();
            try
            {
                var response = _tagResourceTagsRestClient.GetAtScope(Id.Parent, cancellationToken);
                if (response.Value == null)
                    throw _tagResourceTagsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TagResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_DeleteAtScope
        /// <summary> Deletes the entire set of tags on a resource or subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<TagResourceDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.Delete");
            scope.Start();
            try
            {
                var response = await _tagResourceTagsRestClient.DeleteAtScopeAsync(Id.Parent, cancellationToken).ConfigureAwait(false);
                var operation = new TagResourceDeleteOperation(response);
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

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_DeleteAtScope
        /// <summary> Deletes the entire set of tags on a resource or subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual TagResourceDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.Delete");
            scope.Start();
            try
            {
                var response = _tagResourceTagsRestClient.DeleteAtScope(Id.Parent, cancellationToken);
                var operation = new TagResourceDeleteOperation(response);
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

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_UpdateAtScope
        /// <summary> This operation allows replacing, merging or selectively deleting tags on the specified resource or subscription. The specified entity can have a maximum of 50 tags at the end of the operation. The &apos;replace&apos; option replaces the entire set of existing tags with a new set. The &apos;merge&apos; option allows adding tags with new names and updating the values of tags with existing names. The &apos;delete&apos; option allows selectively deleting tags based on given names or name/value pairs. </summary>
        /// <param name="parameters"> The TagPatchResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<TagResource>> UpdateAsync(TagPatchResource parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.Update");
            scope.Start();
            try
            {
                var response = await _tagResourceTagsRestClient.UpdateAtScopeAsync(Id.Parent, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TagResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_UpdateAtScope
        /// <summary> This operation allows replacing, merging or selectively deleting tags on the specified resource or subscription. The specified entity can have a maximum of 50 tags at the end of the operation. The &apos;replace&apos; option replaces the entire set of existing tags with a new set. The &apos;merge&apos; option allows adding tags with new names and updating the values of tags with existing names. The &apos;delete&apos; option allows selectively deleting tags based on given names or name/value pairs. </summary>
        /// <param name="parameters"> The TagPatchResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<TagResource> Update(TagPatchResource parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.Update");
            scope.Start();
            try
            {
                var response = _tagResourceTagsRestClient.UpdateAtScope(Id.Parent, parameters, cancellationToken);
                return Response.FromValue(new TagResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_CreateOrUpdateAtScope
        /// <summary> This operation allows adding or replacing the entire set of tags on the specified resource or subscription. The specified entity can have a maximum of 50 tags. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The TagResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TagResourceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, TagResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tagResourceTagsRestClient.CreateOrUpdateAtScopeAsync(Id.Parent, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TagResourceCreateOrUpdateOperation(Client, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// ContextualPath: /{scope}/providers/Microsoft.Resources/tags/default
        /// OperationId: Tags_CreateOrUpdateAtScope
        /// <summary> This operation allows adding or replacing the entire set of tags on the specified resource or subscription. The specified entity can have a maximum of 50 tags. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The TagResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual TagResourceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, TagResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tagResourceTagsRestClient.CreateOrUpdateAtScope(Id.Parent, parameters, cancellationToken);
                var operation = new TagResourceCreateOrUpdateOperation(Client, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
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
            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.GetAvailableLocations");
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
            using var scope = _tagResourceTagsClientDiagnostics.CreateScope("TagResource.GetAvailableLocations");
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
