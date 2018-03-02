using System;
using System.Drawing;
namespace CMSM.Print
{
	public class PrintFourPrimitiveText : IPrintPrimitive
	{
		private string Text1;
		private string Text2;
		private string Text3;
		private string Text4;

		public PrintFourPrimitiveText(string buf1, string buf2, string buf3,string buf4)
		{
			Text1 = buf1;
			Text2 = buf2;
			Text3 = buf3;
			Text4 = buf4;
		}
		public float CalculateHeight(PrintEngine engine, Graphics graphics)
		{
			return engine.PrintFont.GetHeight(graphics);
		}
		public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			//名称、单价、数量、金额
			graphics.DrawString(engine.ReplaceTokens(Text1), engine.PrintFont,
				engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());

			graphics.DrawString(engine.ReplaceTokens(Text2), engine.PrintFont,
				engine.PrintBrush, elementBounds.Left+86, yPos, new StringFormat());

			graphics.DrawString(engine.ReplaceTokens(Text3), engine.PrintFont,
				engine.PrintBrush, elementBounds.Left+86+32, yPos, new StringFormat());

			graphics.DrawString(engine.ReplaceTokens(Text4), engine.PrintFont,
				engine.PrintBrush, elementBounds.Left+86+32+30, yPos, new StringFormat());
		}
	}
}
