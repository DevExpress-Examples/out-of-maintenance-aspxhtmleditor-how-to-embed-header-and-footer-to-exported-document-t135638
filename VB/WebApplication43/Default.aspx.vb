Imports Microsoft.VisualBasic
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.IO

Namespace WebApplication43
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Private Sub ExporToStream(ByVal html As String, ByVal stream As Stream)
			Using server As New RichEditDocumentServer()
				server.HtmlText = html

				Dim text As String = "<b>SOME SAMPLE TEXT</b>"
				AddHeaderToDocument(server.Document, text)
				AddFooterToDocument(server.Document, text)

				Using ps As New PrintingSystemBase()
					Using pcl As New PrintableComponentLinkBase(ps)
						pcl.Component = server
						pcl.CreateDocument()
						ps.ExportToPdf(stream)
					End Using
				End Using
			End Using
		End Sub

		Private Sub AddHeaderToDocument(ByVal document As DevExpress.XtraRichEdit.API.Native.Document, ByVal htmlText As String)
			Dim doc As SubDocument = document.Sections(0).BeginUpdateHeader()
			doc.AppendHtmlText(htmlText)
			document.Sections(0).EndUpdateHeader(doc)
		End Sub

		Private Sub AddFooterToDocument(ByVal document As DevExpress.XtraRichEdit.API.Native.Document, ByVal htmlText As String)
			Dim doc As SubDocument = document.Sections(0).BeginUpdateFooter()
			doc.AppendHtmlText(htmlText)
			document.Sections(0).EndUpdateFooter(doc)
		End Sub

		Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Using stream As New MemoryStream()

				ExporToStream(ASPxHtmlEditor1.Html, stream)

				Response.Clear()
				Response.Buffer = False
				Response.AppendHeader("Content-Type", "application/pdf")
				Response.AppendHeader("Content-Transfer-Encoding", "binary")
				Response.AppendHeader("Content-Disposition", "attachment; filename=document.pdf")
				Response.BinaryWrite(stream.ToArray())
				Response.End()
			End Using
		End Sub
	End Class
End Namespace