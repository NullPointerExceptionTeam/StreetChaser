using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
	private Texture2D loadingBarEmpty;

	private Texture2D loadingBarFilled;

	private Texture2D loadingBG;

	private float tempVal;

	private Rect rect_loadingBarFilled;

	private Rect rect_loadingBG;

	private AsyncOperation async;

	private void Start()
	{
		tempVal = 0f;
		loadingBG = Resources.Load<Texture2D>("Images/LoadingScreen_BG");
		loadingBarEmpty = Resources.Load<Texture2D>("Images/Character_White");
		loadingBarFilled = Resources.Load<Texture2D>("Images/Character_Color");
		rect_loadingBarFilled = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f));
		rect_loadingBG = new Rect(IGT_UIcommonFunc.ScaleX(95f), IGT_UIcommonFunc.ScaleY(230f), IGT_UIcommonFunc.ScaleX(184.6f), IGT_UIcommonFunc.ScaleY(170f));
		Object.DontDestroyOnLoad(this);
		async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
		async.allowSceneActivation = true;
		SceneManager.sceneLoaded += sceneLoaded;
	}

	private void FixedUpdate()
	{
		if (tempVal < 1f)
		{
			tempVal += 0.009f;
		}
		if (SceneManager.sceneCount > 0 && tempVal > 0.9f && tempVal >= 0.9f)
		{
			Object.Destroy(GameObject.Find("Loading Camera"), 1f);
		}
	}

	private void sceneLoaded(Scene arg1, LoadSceneMode arg2)
	{
	}

	private void OnGUI()
	{
		GUI.DrawTexture(rect_loadingBarFilled, loadingBG);
		GUI.DrawTexture(rect_loadingBG, loadingBarEmpty);
		if (tempVal < 0.9f)
		{
			Rect position = new Rect(rect_loadingBG.x, rect_loadingBG.y + rect_loadingBG.height - rect_loadingBG.height * tempVal, rect_loadingBG.width, rect_loadingBG.height * tempVal);
			GUI.DrawTextureWithTexCoords(position, loadingBarFilled, new Rect(0f, 0f, 1f, tempVal));
		}
		else
		{
			GUI.DrawTexture(rect_loadingBG, loadingBarFilled);
		}
	}
}
