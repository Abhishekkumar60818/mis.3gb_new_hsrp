using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PdfConverterController
/// </summary>
public class PdfConverterController
{
	public PdfConverterController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public MemoryStream createPDF(string html)
    {
        MemoryStream msOutput = new MemoryStream();
        TextReader reader = new StringReader(html);

        // step 1: creation of a document-object
       Document document = new Document(PageSize.A4, 10, 10, 10, 10);
        //Document document = new Document(PageSize.A4, 30, 30, 30, 30);
        //Document document = new Document(new Rectangle(600f, 900f));
        // step 2:
        // we create a writer that listens to the document
        // and directs a XML-stream to a file
        PdfWriter writer = PdfWriter.GetInstance(document, msOutput);

        // step 3: we create a worker parse the document
        HTMLWorker worker = new HTMLWorker(document);

        // step 4: we open document and start the worker on the document
        document.Open();
        worker.StartDocument();

        // step 5: parse the html into the document
        worker.Parse(reader);

        // step 6: close the document and the worker
        worker.EndDocument();
        worker.Close();
        document.Close();

        return msOutput;
    }
}