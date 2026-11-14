using UnityEngine;

public class IGT_ObjBouncing : MonoBehaviour
{
	private float bounceAnimTime;

	private float bounceTotAnimTime = 4f;

	private float startY;

	private float yDiff;

	private void Start()
	{
		startY = base.transform.position.y;
	}

	private void Update()
	{
		if (IGT_Hero.bStrtButton && !IGT_Hero.bPauseButton && IGT_Hero.bRobbingSceneFinished && !IGT_Hero.bGameOver && !IGT_Hero.bLevelUp)
		{
			yDiff = sineBounce(bounceAnimTime, 0.1f, 0.75f, 0.25f);
			base.transform.position = new Vector3(base.transform.position.x, startY, base.transform.position.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + yDiff, base.transform.position.z);
			bounceAnimTime += Time.deltaTime;
			if (bounceAnimTime > bounceTotAnimTime)
			{
				bounceAnimTime = 0f;
			}
		}
	}

	public float sineBounce(float t, float amplitude, float frequency, float decay)
	{
		return amplitude * Mathf.Abs(Mathf.Sin(t * frequency * 3.14f * 2f)) / Mathf.Exp(t * decay);
	}
}
