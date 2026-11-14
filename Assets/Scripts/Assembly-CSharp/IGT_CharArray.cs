public class IGT_CharArray
{
	public char character;

	public bool isEnable;

	public float X;

	public float Y;

	public float fwidth;

	public float fHeight;

	public int fFontSize;

	public IGT_CharArray(char letter, bool bEnable, float x, float y, float wid, float height, int fontSize)
	{
		character = letter;
		isEnable = bEnable;
		X = x;
		Y = y;
		fwidth = wid;
		fHeight = height;
		fFontSize = fontSize;
	}
}
