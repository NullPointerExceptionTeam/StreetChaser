using UnityEngine;

public class IGT_Rotation_X_axis : MonoBehaviour
{
	public float RotateSpeed = 30f;

	private void Update()
	{
		if (IGT_Hero.bStrtButton && !IGT_Hero.bPauseButton && IGT_Hero.bRobbingSceneFinished && !IGT_Hero.bGameOver && !IGT_Hero.bLevelUp)
		{
			base.transform.Rotate(new Vector3(0f, 0f, RotateSpeed * Time.deltaTime * 8f));
		}
	}
}
