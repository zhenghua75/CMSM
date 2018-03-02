using System;
using System.Drawing;
namespace CMSM.Print
{
	public class PrintPairPrimitiveText : IPrintPrimitive
	{
		private string Text1;
		private string Text2;
		public PrintPairPrimitiveText(string buf1, string buf2)
		{
			Text1 = buf1;
			Text2 = buf2;
		}
		public float CalculateHeight(PrintEngine engine, Graphics graphics)
		{            
			return engine.PrintFont.GetHeight(graphics);
		}
		public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			graphics.DrawString(engine.ReplaceTokens(Text1), engine.PrintFont,
				engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());

			graphics.DrawString(engine.ReplaceTokens(Text2), engine.PrintFont,
				engine.PrintBrush, elementBounds.Left+117, yPos, new StringFormat());
		}
	}
}
