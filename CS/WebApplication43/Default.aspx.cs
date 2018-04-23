using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.IO;

namespace WebApplication43 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        void ExporToStream(string html, Stream stream) {
            using (RichEditDocumentServer server = new RichEditDocumentServer()) {
                server.HtmlText = html;

                string text = "<b>SOME SAMPLE TEXT</b>";
                AddHeaderToDocument(server.Document, text);
                AddFooterToDocument(server.Document, text);

                using (PrintingSystemBase ps = new PrintingSystemBase()) {
                    using (PrintableComponentLinkBase pcl = new PrintableComponentLinkBase(ps)) {
                        pcl.Component = server;
                        pcl.CreateDocument();
                        ps.ExportToPdf(stream);
                    }
                }
            }
        }

        void AddHeaderToDocument(DevExpress.XtraRichEdit.API.Native.Document document, string htmlText) {
            SubDocument doc = document.Sections[0].BeginUpdateHeader();
            doc.AppendHtmlText(htmlText);
            document.Sections[0].EndUpdateHeader(doc);
        }

        void AddFooterToDocument(DevExpress.XtraRichEdit.API.Native.Document document, string htmlText) {
            SubDocument doc = document.Sections[0].BeginUpdateFooter();
            doc.AppendHtmlText(htmlText);
            document.Sections[0].EndUpdateFooter(doc);
        }

        protected void ASPxButton1_Click(object sender, EventArgs e) {
            using (MemoryStream stream = new MemoryStream()) {

                ExporToStream(ASPxHtmlEditor1.Html, stream);

                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", "application/pdf");
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", "attachment; filename=document.pdf");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
        }
    }
}