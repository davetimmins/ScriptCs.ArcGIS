using ArcGIS.ServiceModel;
using ArcGIS.ServiceModel.Serializers;
using ScriptCs.Contracts;
using System;

namespace ScriptCs.ArcGIS
{
    public class ArcGISPack : IScriptPackContext
    {
        public ArcGISPack()
        {
            JsonDotNetSerializer.Init();
        }

        public PortalGateway CreateGateway(String url, TokenProvider tokenProvider = null)
        {
            return new PortalGateway(url, tokenProvider: tokenProvider);
        }
    }
}