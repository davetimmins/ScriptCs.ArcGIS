using System;
using ScriptCs.Contracts;


namespace ScriptCs.ArcGIS
{
    public class ArcGISScriptPack : IScriptPack
    {
        IScriptPackContext IScriptPack.GetContext()
        {
            //Return the ScriptPackContext to be used in your scripts
            return new ArcGISPack();
        }

        void IScriptPack.Initialize(IScriptPackSession session)
        {
            Guard.AgainstNullArgument("session", session);

            session.ImportNamespace("ArcGIS.ServiceModel");
            session.ImportNamespace("ArcGIS.ServiceModel.Common");
            session.ImportNamespace("ArcGIS.ServiceModel.GeoJson");
            session.ImportNamespace("ArcGIS.ServiceModel.Operation");
            session.ImportNamespace("ArcGIS.ServiceModel.Serializers");
        }

        void IScriptPack.Terminate()
        {
            //Cleanup any resources here
        }
    }
}
