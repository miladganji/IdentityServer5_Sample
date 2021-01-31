// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protoes/data.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcData {
  public static partial class dataService
  {
    static readonly string __ServiceName = "data.dataService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::GrpcData.AddClientRequest> __Marshaller_data_AddClientRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcData.AddClientRequest.Parser));
    static readonly grpc::Marshaller<global::GrpcData.AddClientResponse> __Marshaller_data_AddClientResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcData.AddClientResponse.Parser));

    static readonly grpc::Method<global::GrpcData.AddClientRequest, global::GrpcData.AddClientResponse> __Method_AddClient = new grpc::Method<global::GrpcData.AddClientRequest, global::GrpcData.AddClientResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddClient",
        __Marshaller_data_AddClientRequest,
        __Marshaller_data_AddClientResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcData.DataReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of dataService</summary>
    [grpc::BindServiceMethod(typeof(dataService), "BindService")]
    public abstract partial class dataServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::GrpcData.AddClientResponse> AddClient(global::GrpcData.AddClientRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for dataService</summary>
    public partial class dataServiceClient : grpc::ClientBase<dataServiceClient>
    {
      /// <summary>Creates a new client for dataService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public dataServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for dataService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public dataServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected dataServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected dataServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::GrpcData.AddClientResponse AddClient(global::GrpcData.AddClientRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddClient(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcData.AddClientResponse AddClient(global::GrpcData.AddClientRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddClient, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcData.AddClientResponse> AddClientAsync(global::GrpcData.AddClientRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddClientAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcData.AddClientResponse> AddClientAsync(global::GrpcData.AddClientRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddClient, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override dataServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new dataServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(dataServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddClient, serviceImpl.AddClient).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, dataServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddClient, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcData.AddClientRequest, global::GrpcData.AddClientResponse>(serviceImpl.AddClient));
    }

  }
}
#endregion