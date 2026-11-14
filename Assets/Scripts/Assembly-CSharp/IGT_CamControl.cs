using UnityEngine;

public class IGT_CamControl : MonoBehaviour
{
	public CamFollow pCamFollow;

	private MapLevelCamMove pMapCamMove;

	private bool bSetPos;

	public void _Start()
	{
		pCamFollow = new CamFollow();
		pCamFollow.initCamFollow();
		pMapCamMove = new MapLevelCamMove();
		bSetPos = false;
	}

	private void LateUpdate()
	{
		if (IGT_GameView.nScreenMode != 9)
		{
			bSetPos = false;
			pCamFollow._LateUpdate();
		}
		else if (!IGT_GameView.bNoMoreLiveAlert && !IGT_GameView.bHS_asklife)
		{
			if (!bSetPos)
			{
				pMapCamMove.setCameraStartPos();
				bSetPos = true;
			}
			pMapCamMove.checkLateUpdate();
		}
	}
}
