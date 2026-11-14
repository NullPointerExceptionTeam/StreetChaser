using UnityEngine;

public class spriteTesting : MonoBehaviour
{
	public static string goblin = "Images/goblin_joy_256";

	private IGT_Textures pIgt_Textures;

	private float cropX;

	private float cropY;

	private float cropWidth;

	private float cropHeight;

	private float imgX;

	private float imgY;

	private float imgWidth;

	private float imgHeigth;

	private int framenumber = 1;

	private int TotalFrames = 8;

	private float frameTime;

	private void Start()
	{
		pIgt_Textures = new IGT_Textures();
		pIgt_Textures.LoadTexture(goblin);
		imgX = IGT_UIcommonFunc.ScaleX(10f);
		imgY = IGT_UIcommonFunc.ScaleY(240f);
		imgWidth = IGT_UIcommonFunc.ScaleX(256f);
		imgHeigth = IGT_UIcommonFunc.ScaleY(256f);
		cropX = 0f;
		cropY = 0f;
		cropWidth = 1f / (float)TotalFrames;
		cropHeight = 1f;
		framenumber = 0;
		TotalFrames = 8;
	}

	private void Update()
	{
		frameTime += (float)TotalFrames / 0.5f * Time.deltaTime;
		framenumber = (int)Mathf.Floor(frameTime);
		if (framenumber >= TotalFrames)
		{
			frameTime = 0f;
			framenumber = 0;
		}
		cropX = (float)framenumber / (float)TotalFrames;
		Debug.Log("rameTime: " + frameTime + " frame  " + framenumber + " cropX: " + cropX + " cropwid: " + cropWidth);
	}

	private void OnGUI()
	{
		GUI.DrawTextureWithTexCoords(new Rect(imgX, imgY, imgWidth, imgHeigth), pIgt_Textures.GetTexture(goblin), new Rect(cropX, cropY, cropWidth, cropHeight));
	}
}
