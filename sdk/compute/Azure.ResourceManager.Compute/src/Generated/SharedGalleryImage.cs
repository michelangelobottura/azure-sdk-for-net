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

namespace Azure.ResourceManager.Compute
{
    /// <summary> A Class representing a SharedGalleryImage along with the instance operations that can be performed on it. </summary>
    public partial class SharedGalleryImage : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SharedGalleryImage"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string galleryUniqueName, string galleryImageName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _sharedGalleryImageClientDiagnostics;
        private readonly SharedGalleryImagesRestOperations _sharedGalleryImageRestClient;
        private readonly SharedGalleryImageData _data;

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryImage"/> class for mocking. </summary>
        protected SharedGalleryImage()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SharedGalleryImage"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SharedGalleryImage(ArmClient client, SharedGalleryImageData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryImage"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SharedGalleryImage(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sharedGalleryImageClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string sharedGalleryImageApiVersion);
            _sharedGalleryImageRestClient = new SharedGalleryImagesRestOperations(_sharedGalleryImageClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, sharedGalleryImageApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/sharedGalleries/images";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SharedGalleryImageData Data
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

        /// <summary> Gets a collection of SharedGalleryImageVersions in the SharedGalleryImageVersion. </summary>
        /// <returns> An object representing collection of SharedGalleryImageVersions and their operations over a SharedGalleryImageVersion. </returns>
        public virtual SharedGalleryImageVersionCollection GetSharedGalleryImageVersions()
        {
            return new SharedGalleryImageVersionCollection(Client, Id);
        }

        /// <summary> Get a shared gallery image by subscription id or tenant id. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SharedGalleryImage>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _sharedGalleryImageClientDiagnostics.CreateScope("SharedGalleryImage.Get");
            scope.Start();
            try
            {
                var response = await _sharedGalleryImageRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _sharedGalleryImageClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
                return Response.FromValue(new SharedGalleryImage(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a shared gallery image by subscription id or tenant id. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SharedGalleryImage> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _sharedGalleryImageClientDiagnostics.CreateScope("SharedGalleryImage.Get");
            scope.Start();
            try
            {
                var response = _sharedGalleryImageRestClient.Get(Id.SubscriptionId, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _sharedGalleryImageClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                response.Value.Id = CreateResourceIdentifier(Id.SubscriptionId, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
                return Response.FromValue(new SharedGalleryImage(Client, response.Value), response.GetRawResponse());
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
            using var scope = _sharedGalleryImageClientDiagnostics.CreateScope("SharedGalleryImage.GetAvailableLocations");
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
            using var scope = _sharedGalleryImageClientDiagnostics.CreateScope("SharedGalleryImage.GetAvailableLocations");
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
