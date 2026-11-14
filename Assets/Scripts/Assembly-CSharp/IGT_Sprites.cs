using UnityEngine;

public class IGT_Sprites
{
	private float cropX;

	private float cropY;

	private float cropWidth;

	private float cropHeight;

	private float imgX;

	private float imgY;

	private float imgWidth;

	private float imgHeigth;

	private int framenumber;

	private int TotalFrames;

	private float frameTime;

	private Texture pSpriteImg;

	private float fTotAnimTime;

	private bool bShowAnim;

	private int nColumnCount;

	private int nRowCount;

	public IGT_Sprites(Texture Img, int TotFrameCnt, float animationTime, int rowCount, int columnCount, Rect imageDimension)
	{
		pSpriteImg = Img;
		TotalFrames = rowCount * columnCount;
		nColumnCount = columnCount;
		nRowCount = rowCount;
		fTotAnimTime = animationTime;
		imgX = imageDimension.x;
		imgY = imageDimension.y;
		imgWidth = imageDimension.width;
		imgHeigth = imageDimension.height;
		framenumber = 0;
		cropWidth = 1f / (float)columnCount;
		cropHeight = 1f / (float)rowCount;
		cropX = 0f;
		cropY = 1f - cropHeight;
		bShowAnim = true;
	}

	public void draw()
	{
		if (bShowAnim)
		{
			frameTime += (float)TotalFrames / fTotAnimTime * Time.deltaTime;
			framenumber = (int)Mathf.Floor(frameTime);
			if (framenumber >= TotalFrames)
			{
				frameTime = 0f;
				framenumber = 0;
				cropWidth = 1f / (float)nColumnCount;
				cropHeight = 1f / (float)nRowCount;
				cropX = 0f;
				cropY = 1f - cropHeight;
			}
			cropX = cropWidth * (float)(framenumber % nColumnCount);
			cropY = framenumber / nColumnCount;
			cropY /= nRowCount;
			cropY = 1f - cropY;
			cropY -= cropHeight;
			GUI.DrawTextureWithTexCoords(new Rect(imgX, imgY, imgWidth, imgHeigth), pSpriteImg, new Rect(cropX, cropY, cropWidth, cropHeight));
		}
	}

	public int getFramNumber()
	{
		return framenumber;
	}

	public void setStop(bool flag)
	{
		bShowAnim = flag;
	}
}
