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
            EncryptTokenRequests = false;
        }

        public bool EncryptTokenRequests
        {
            get { return !CryptoProviderFactory.Disabled; }
            set { CryptoProviderFactory.Disabled = !value; }
        }

        public PortalGateway CreateGateway(String rootUrl, String username = "", String password = "")
        {
            Guard.AgainstNullArgument("rootUrl", rootUrl);

            return String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password) ?
                new PortalGateway(rootUrl) :
                CreateGateway(rootUrl, tokenProvider: new TokenProvider(rootUrl, username, password));
        }

        public PortalGateway CreateGateway(String rootUrl, ITokenProvider tokenProvider)
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

        public ArcGISOnlineGateway CreateArcGISOnlineGateway(ITokenProvider tokenProvider)
        {
            Guard.AgainstNullArgument("tokenProvider", tokenProvider);

            return new ArcGISOnlineGateway(tokenProvider: tokenProvider);
        }
    }
}