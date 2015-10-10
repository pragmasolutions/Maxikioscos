using System;
using System.ServiceModel;

namespace MaxiKioscos.Services.Contracts
{
    [ServiceContract]
    public interface ISincronizacionService
    {
        [OperationContract]
        ObtenerDatosResponse ObtenerDatos(ObtenerDatosRequest request);

        [OperationContract]
        ObtenerDatosSecuencialResponse ObtenerDatosSecuencial(ObtenerDatosRequest request);

        [OperationContract]
        ActualizarDatosResponse ActualizarDatos(ActualizarDatosRequest request);

        [OperationContract]
        void AcusarExportacion(AcusarExportacionRequest request);

        [OperationContract]
        InicializarKioscoResponse InicializarKiosco();

        [OperationContract]
        KioscoAsignadoResponse MarcarKioscoComoAsignado(string identifier);

        [OperationContract]
        ObtenerSecuenciasResponse ObtenerSecuencias(string identifier);

        [OperationContract]
        void ForzarArmadoDeArchivoExportacion(Guid usuarioIdentifier);

        [OperationContract]
        bool AcusarEstadoConexion(Guid maxikioscoIdentifier, string dateISO);

    }
}
