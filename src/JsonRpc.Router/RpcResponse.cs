﻿using System;
using edjCase.JsonRpc.Router.JsonConverters;
using Newtonsoft.Json;

namespace edjCase.JsonRpc.Router
{
	[JsonObject]
	public class RpcErrorResponse : RpcResponseBase
	{
		[JsonConstructor]
		private RpcErrorResponse()
		{

		}

		public RpcErrorResponse(object id, RpcError error) : base(id)
		{
			this.Error = error;
		}

		[JsonProperty("error", Required = Required.Always)]
		public RpcError Error { get; private set; }
	}

	[JsonObject]
	public class RpcResultResponse : RpcResponseBase
	{
		[JsonConstructor]
		private RpcResultResponse()
		{

		}

		public RpcResultResponse(object id, object result) : base(id)
		{
			this.Result = result;
		}
		[JsonProperty("result", Required = Required.Always)]
		public object Result { get; private set; }
	}
	
	[JsonObject]
	public abstract class RpcResponseBase
	{
		[JsonConstructor]
		protected RpcResponseBase()
		{

		}

		protected RpcResponseBase(object id)
		{
			this.Id = id;
		}

		[JsonProperty("id", Required = Required.AllowNull)]
		[JsonConverter(typeof(RpcIdJsonConverter))]
		public object Id { get; private set; }
		[JsonProperty("jsonrpc", Required = Required.Always)]
		public string JsonRpc { get; private set; } = "2.0";
	}

	[JsonObject]
	public class RpcError
	{
		[JsonConstructor]
		private RpcError()
		{

		}

		public RpcError(RpcException exception)
		{
			if(exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			this.Code = (int)exception.ErrorCode;
			this.Message = exception.Message;
			this.Data = exception.RpcData;
		}

		public RpcError(int code, string message, object data = null)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentNullException(nameof(message));
			}
			this.Code = code;
			this.Message = message;
			this.Data = data;
		}

		[JsonProperty("code", Required = Required.Always)]
		public int Code { get; private set; }
		[JsonProperty("message", Required = Required.Always)]
		public string Message { get; private set; }
		[JsonProperty("data")]
		public object Data { get; private set; }
	}
}
