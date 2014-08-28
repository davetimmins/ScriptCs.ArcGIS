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

        public PortalGateway CreateGateway(String rootUrl, String username = "", String password = "")
        {
            Guard.AgainstNullArgument("rootUrl", rootUrl);

            return String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password) ?
                new PortalGateway(rootUrl) :
                CreateGateway(rootUrl, tokenProvider: new TokenProvider(rootUrl, username, password));
        }

        public PortalGateway CreateGateway(String rootUrl, ITokenProvider tokenProvider = null)
        {
            Guard.AgainstNullArgument("rootUrl", rootUrl);

            return new PortalGateway(rootUrl, tokenProvider: tokenProvider);
        }

        public ArcGISOnlineGateway CreateArcGISOnlineGateway(String username = "", String password = "")
        {
            return String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password) ?
                new ArcGISOnlineGateway() :
                CreateArcGISOnlineGateway(tokenProvider: new ArcGISOnlineTokenProvider(username, password));
        }

        public ArcGISOnlineGateway CreateArcGISOnlineGateway(ITokenProvider tokenProvider = null)
        {
            return new ArcGISOnlineGateway(tokenProvider: tokenProvider);
        }
    }
}