using UnityEngine;

public class IGT_CoinRotation : MonoBehaviour
{
	public float RotateSpeed = 20f;

	private void Update()
	{
		if (IGT_Hero.bStrtButton && !IGT_Hero.bPauseButton && IGT_Hero.bRobbingSceneFinished && !IGT_Hero.bGameOver && !IGT_Hero.bLevelUp)
		{
			base.transform.Rotate(new Vector3(0f, RotateSpeed * Time.deltaTime * 6f, 0f));
		}
	}
}
