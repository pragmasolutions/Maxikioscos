using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
    public class DatabaseRepository : EFRepository<Entidades.MaxiKiosco>, IDatabaseRepository
    {
        public DatabaseRepository(){}

        public DatabaseRepository(DbContext context) : base(context) { }

        public bool ActualizarEsquema(Guid maxikioscoIdentifier, string scriptsFolderPath)
        {
            if (!Directory.Exists(scriptsFolderPath))
            {
                Directory.CreateDirectory(scriptsFolderPath);
            }
            string[] nombres = Directory.GetFiles(scriptsFolderPath);
            var archivos = new List<KeyValuePair<int, string>>();

            foreach (var nombre in nombres)
            {
                var nombreCorto = nombre.Split('\\').Last();
                var numero = int.Parse(nombreCorto.Split('-')[0]);
                var pair = new KeyValuePair<int, string>(numero, nombreCorto); 
                archivos.Add(pair);
            }


            var ultimoScriptCorrido = ObtenerUltimoScriptCorrido(maxikioscoIdentifier);
            var seCorrioAlgo = false;
            
            foreach (var archivo in archivos.OrderBy(a => a.Key))
            {
                if (ultimoScriptCorrido.GetValueOrDefault() < archivo.Key)
                {
                    var path = Path.Combine(scriptsFolderPath, archivo.Value);
                    var fileInfo = new FileInfo(path);
                    var script = fileInfo.OpenText().ReadToEnd();

                    using (var cxn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchemaUpdater"].ConnectionString))
                    {
                        SqlCommand cmd = cxn.CreateCommand();

                        cmd.CommandText = script;
                        cmd.CommandType = CommandType.Text;

                        cxn.Open();

                        try
                        {
                            cmd.ExecuteNonQuery();
                            seCorrioAlgo = true;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            cxn.Close();
                            cmd.Dispose();
                        }
                    }
                }
            }

            if (seCorrioAlgo)
            {
                SetearUltimoScriptCorrido(maxikioscoIdentifier, archivos.Max(a => a.Key));
            }
            return seCorrioAlgo;
        }

        public int? ObtenerUltimoScriptCorrido(Guid identifier)
        {
            using (var cxn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchemaUpdater"].ConnectionString))
            {
                SqlCommand cmd = cxn.CreateCommand();

                cmd.CommandText = String.Format("SELECT UltimoScriptCorrido FROM MaxiKiosco WHERE Identifier = '{0}'", identifier);
                cmd.CommandType = CommandType.Text;

                cxn.Open();

                try
                {
                    return (int?)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cxn.Close();
                    cmd.Dispose();
                }
            }
        }

        public int SetearUltimoScriptCorrido(Guid identifier, int secuencia)
        {
            using (var cxn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchemaUpdater"].ConnectionString))
            {
                SqlCommand cmd = cxn.CreateCommand();

                cmd.CommandText = String.Format("UPDATE MaxiKiosco SET UltimoScriptCorrido = {0} WHERE Identifier = '{1}'", secuencia, identifier);
                cmd.CommandType = CommandType.Text;

                cxn.Open();

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cxn.Close();
                    cmd.Dispose();
                }
            }
        }
    }
}
