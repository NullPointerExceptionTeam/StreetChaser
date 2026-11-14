using UnityEngine;

public class IGT_PrograssBar
{
	private float containerX;

	private float containerY;

	private float containerWidth;

	private float containerHeight;

	private float fillerX;

	private float fillerY;

	private float fillerCurWidth;

	private float fillerCurHeight;

	private float Initial_fillerWidth;

	private float Initial_fillerX;

	private Texture containerTexture;

	private Texture fillerTexture;

	private bool isLeftToRight;

	private float curPrograssVal;

	private float totPrograssVal;

	private float ratio;

	private float ImgCropX;

	private float ImgCropY;

	private float ImgCropWidth = 1f;

	private float ImgCropHeight = 1f;

	private float minPrograssValue;

	private float maxPrograssValue = 1f;

	private Rect mirroredRect;

	public IGT_PrograssBar(Texture containerTex, Rect containerDimension, Texture fillerTex, Rect fillerDimension, bool isStrtfrmLeft, float curPercent_0_to_1, float totPercent_0_to_1, Rect mirrorRect)
	{
		containerTexture = containerTex;
		containerX = containerDimension.x;
		containerY = containerDimension.y;
		containerWidth = containerDimension.width;
		containerHeight = containerDimension.height;
		fillerTexture = fillerTex;
		fillerX = fillerDimension.x;
		fillerY = fillerDimension.y;
		fillerCurWidth = fillerDimension.width;
		fillerCurHeight = fillerDimension.height;
		Initial_fillerX = fillerDimension.x;
		Initial_fillerWidth = fillerDimension.width;
		isLeftToRight = isStrtfrmLeft;
		curPrograssVal = curPercent_0_to_1;
		totPrograssVal = totPercent_0_to_1;
		mirroredRect = mirrorRect;
	}

	public void draw(float curPrograss)
	{
		curPrograssVal = curPrograss;
		if (curPrograssVal < minPrograssValue)
		{
			curPrograssVal = minPrograssValue;
		}
		if (curPrograssVal > maxPrograssValue)
		{
			curPrograssVal = maxPrograssValue;
		}
		ratio = curPrograssVal / totPrograssVal;
		ImgCropWidth = ratio;
		fillerCurWidth = ratio * Initial_fillerWidth;
		if (!isLeftToRight)
		{
			ImgCropX = 1f - ratio;
			fillerX = Initial_fillerX + Initial_fillerWidth * ImgCropX;
		}
		GUI.DrawTextureWithTexCoords(new Rect(containerX, containerY, containerWidth, containerHeight), containerTexture, mirroredRect);
		GUI.DrawTextureWithTexCoords(new Rect(fillerX, fillerY, fillerCurWidth, fillerCurHeight), fillerTexture, new Rect(ImgCropX * mirroredRect.width, ImgCropY * mirroredRect.y, ImgCropWidth * mirroredRect.width, ImgCropHeight * mirroredRect.height));
	}

	public Rect getFillerdimensions()
	{
		return new Rect(fillerX, fillerY, fillerCurWidth, fillerCurHeight);
	}

	public Rect getContainerDimensions()
	{
		return new Rect(containerX, containerY, containerWidth, containerHeight);
	}

	public void setDimensions(Rect containerDimension, Rect fillerDimension)
	{
		containerX = containerDimension.x;
		containerY = containerDimension.y;
		containerWidth = containerDimension.width;
		containerHeight = containerDimension.height;
		fillerX = fillerDimension.x;
		fillerY = fillerDimension.y;
		fillerCurWidth = fillerDimension.width;
		fillerCurHeight = fillerDimension.height;
	}
}
