﻿using System.Collections.Generic;

namespace edjCase.JsonRpc.Router.Abstractions
{
	public interface IRpcInvoker
	{
		RpcResponseBase InvokeRequest(RpcRequest request, RpcRoute route);
		List<RpcResponseBase> InvokeBatchRequest(List<RpcRequest> requests, RpcRoute route);
	}
}
