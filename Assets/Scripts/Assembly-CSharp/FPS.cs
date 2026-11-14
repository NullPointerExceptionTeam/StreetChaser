using UnityEngine;

public class FPS : MonoBehaviour
{
	private float deltaTime;

	private void FixedUpdate()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.fontSize = (int)IGT_UIcommonFunc.ScaleX(20f);
		gUIStyle.fontStyle = FontStyle.BoldAndItalic;
		gUIStyle.normal.textColor = Color.white;
		float num = 1f / deltaTime;
		string text = string.Format("{0:00.00}", num);
		GUI.Label(new Rect(1f, 10f, 50f, 50f), text, gUIStyle);
	}
}
