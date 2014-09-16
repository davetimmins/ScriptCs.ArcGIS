using ArcGIS.ServiceModel;
using ArcGIS.ServiceModel.Serializers;
using ScriptCs.Contracts;
using System;
using System.Net;

namespace ScriptCs.ArcGIS
{
    public class ArcGISPack : IScriptPackContext
    {
        public ArcGISPack()
        {
            // initialise the default serializer
            JsonDotNetSerializer.Init();

            // don't try to encrypt token requests by default
            EncryptTokenRequests = false;

            // allow self signed certificates
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
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