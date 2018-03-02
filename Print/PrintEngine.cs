//using statements:
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;

namespace CMSM.Print
{
    /// <summary>
    /// Summary description for PrintEngine.
    /// </summary>
    public class PrintEngine : PrintDocument
    {
        private ArrayList _printObjects = new ArrayList();
        public Font PrintFont = new Font("Arial", 8);
        public Font TitleFont = new Font("Arial", 15);
        public Font SeatFont = new Font("Arial", 15, FontStyle.Bold);
        public Font InfoFont = new Font("Arial", 7, FontStyle.Bold);
        public Font BlackFont = new Font("Arial", 10, FontStyle.Bold);
        public Brush PrintBrush = Brushes.Black;
        public PrintElement Header;
        public PrintElement Footer;
        private ArrayList _printElements;
        private int _printIndex = 0;
        private int _pageNum = 0;
        public PrintEngine(string title)
        {
            Header = new PrintElement(null);
			Header.AddTitle(title);
            Header.AddHorizontalRule();
        }
        public void ShowPreview()
        {
            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = this;

            dialog.ShowDialog();
        }
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            _printElements = new ArrayList();
            _pageNum = 0;
            _printIndex = 0;

            foreach (IPrintable printObject in _printObjects)
            {
                PrintElement element = new PrintElement(printObject);
                _printElements.Add(element);

                printObject.Print(element);
            }
        }


        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            float headerHeight = 20;
            Header.Draw(this, 20, e.Graphics, e.MarginBounds);
            Rectangle pageBounds = new Rectangle(5,
                (int)(e.MarginBounds.Top + headerHeight), e.MarginBounds.Width,
                (int)(e.MarginBounds.Height - headerHeight));
            float yPos = 50;
            int elementsOnPage = 0;
            while (_printIndex < _printElements.Count)
            {
               
                PrintElement element = (PrintElement)_printElements[_printIndex];
               
                float height = element.CalculateHeight(this, e.Graphics);

                element.Draw(this, yPos, e.Graphics, pageBounds);

                yPos += height;

                _printIndex++;
                elementsOnPage++;
            }

        }

        public String ReplaceTokens(String buf)
        {
            buf = buf.Replace("[pagenum]", _pageNum.ToString());

            return buf;
        }
        public void ShowPageSettings()
        {
            PageSetupDialog setup = new PageSetupDialog();
            PageSettings settings = DefaultPageSettings;
            setup.PageSettings = settings;

            if (setup.ShowDialog() == DialogResult.OK)
                DefaultPageSettings = setup.PageSettings;
        }
        public void ShowPrintDialog()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.PrinterSettings = PrinterSettings;
            dialog.Document = this;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PrinterSettings = dialog.PrinterSettings;
                Print();
            }
        }
        public void AddPrintObject(IPrintable printObject)
        {
            _printObjects.Add(printObject);
        }
    }

}
