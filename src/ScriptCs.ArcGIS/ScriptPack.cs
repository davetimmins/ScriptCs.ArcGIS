namespace ScriptCs.ArcGIS
{
    using ScriptCs.Contracts;
    using System.Collections.Generic;

    public class ArcGISScriptPack : IScriptPack
    {
        public IScriptPackContext GetContext()
        {
            //Return the ScriptPackContext to be used in your scripts
            return new ArcGISPack();
        }

        public void Initialize(IScriptPackSession session)
        {
            Guard.AgainstNullArgument("session", session);

            var namespaces = new List<string>
            {
                "ArcGIS.ServiceModel",
                "ArcGIS.ServiceModel.Common",
                "ArcGIS.ServiceModel.GeoJson",
                "ArcGIS.ServiceModel.Operation",
                "ArcGIS.ServiceModel.Operation.Admin",
                "ArcGIS.ServiceModel.Serializers",
                "System.Threading"
            };
            namespaces.ForEach(session.ImportNamespace);
        }

        public void Terminate()
        {
        }
    }
}
