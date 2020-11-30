using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class DocumentoComercialDAO
    {
        public static DocumentoComercialDAO instancia = null;
        public List<DocumentoComercial> documentosComerciales = new List<DocumentoComercial>();

        private DocumentoComercialDAO() { }

        public static DocumentoComercialDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new DocumentoComercialDAO();
            }
            return instancia;
        }

        public void setEgresoId(int idEgreso, string nroId)
        {
            DocumentoComercial doc;

            using (MyDBContext context = new MyDBContext())
            {
                doc = context.DocumentosComerciales.Where(dc => dc.nroIdentificacion == nroId).FirstOrDefault();
                doc.idEgreso = idEgreso;
                context.SaveChanges();
            }
        }

        public List<DocumentoComercial> getDocumentosComerciales()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.DocumentosComerciales.ToList();
            }
        }

        public DocumentoComercial getDocumentoComercial(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DocumentosComerciales.Find(id);
            }
        }

        public DocumentoComercial add(DocumentoComercial documentoComercial)
        {
            DocumentoComercial added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.DocumentosComerciales.Add(documentoComercial);
                context.SaveChanges();
            }

            return added;
        }
    }
} 