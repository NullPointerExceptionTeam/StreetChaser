using UnityEngine;

public class IGT_TouchHandler
{
	public Vector3 fstTchPos;

	public Vector3 lstTchPos;

	public int nUserAction;

	private bool bTouchStateCheck;

	public float touchSpeed;

	public void TouchProcessingArea()
	{
		if (IGT_Hero.userInputQueue.Count >= 1)
		{
			return;
		}
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.phase == TouchPhase.Began)
			{
				fstTchPos = touch.position;
				lstTchPos = touch.position;
				bTouchStateCheck = false;
			}
			if (touch.phase == TouchPhase.Moved && !bTouchStateCheck)
			{
				lstTchPos = touch.position;
				float num = angleBtwTwoPts(fstTchPos.x, fstTchPos.y, lstTchPos.x, lstTchPos.y);
				float num2 = Vector2.Distance(new Vector2(fstTchPos.x, fstTchPos.y), new Vector2(lstTchPos.x, lstTchPos.y));
				if (num2 > (float)IGT_Hero.nPixelFrTouchCalc)
				{
					if (num >= 0f && num <= 45f)
					{
						IGT_Hero.userInputQueue.Enqueue(2);
					}
					else if (num > 45f && num <= 135f)
					{
						IGT_Hero.userInputQueue.Enqueue(3);
					}
					else if (num > 135f && num <= 225f)
					{
						IGT_Hero.userInputQueue.Enqueue(1);
					}
					else if (num > 225f && num <= 315f)
					{
						IGT_Hero.userInputQueue.Enqueue(4);
						IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
					}
					else if (num > 315f && num <= 360f)
					{
						IGT_Hero.userInputQueue.Enqueue(2);
						IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
					}
					bTouchStateCheck = true;
					touchSpeed = touch.deltaPosition.magnitude / touch.deltaTime;
				}
			}
			if (touch.phase == TouchPhase.Ended)
			{
				lstTchPos = touch.position;
				float num3 = Vector2.Distance(new Vector2(fstTchPos.x, fstTchPos.y), new Vector2(lstTchPos.x, lstTchPos.y));
				if (touch.tapCount == 1 && num3 < (float)IGT_Hero.nPixelFrTouchCalc && touch.position.y > IGT_UIcommonFunc.ScaleY(45f))
				{
					IGT_Hero.userInputQueue.Enqueue(5);
				}
			}
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			IGT_Hero.userInputQueue.Enqueue(1);
		}
		else if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			IGT_Hero.userInputQueue.Enqueue(2);
		}
		else if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			IGT_Hero.userInputQueue.Enqueue(3);
			IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
			touchSpeed = 500f;
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			IGT_Hero.userInputQueue.Enqueue(4);
			IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			IGT_Hero.userInputQueue.Enqueue(5);
		}
		// PC WASD 支持：W跳跃 S翻滚 A向左 D向右
		else if (Input.GetKeyUp(KeyCode.A))
		{
			IGT_Hero.userInputQueue.Enqueue(1);
		}
		else if (Input.GetKeyUp(KeyCode.D))
		{
			IGT_Hero.userInputQueue.Enqueue(2);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			IGT_Hero.userInputQueue.Enqueue(3);
			IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
			touchSpeed = 500f;
		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
			IGT_Hero.userInputQueue.Enqueue(4);
			IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
		}
		// PC 鼠标模拟触摸（点击=Enqueue(5)，拖拽滑动=方向手势）
		if (Input.GetMouseButtonDown(0))
		{
			fstTchPos = Input.mousePosition;
			lstTchPos = Input.mousePosition;
			bTouchStateCheck = false;
		}
		else if (Input.GetMouseButton(0) && !bTouchStateCheck)
		{
			lstTchPos = Input.mousePosition;
			float numM = angleBtwTwoPts(fstTchPos.x, fstTchPos.y, lstTchPos.x, lstTchPos.y);
			float num2M = Vector2.Distance(new Vector2(fstTchPos.x, fstTchPos.y), new Vector2(lstTchPos.x, lstTchPos.y));
			if (num2M > (float)IGT_Hero.nPixelFrTouchCalc)
			{
				if (numM >= 0f && numM <= 45f)
				{
					IGT_Hero.userInputQueue.Enqueue(2);
				}
				else if (numM > 45f && numM <= 135f)
				{
					IGT_Hero.userInputQueue.Enqueue(3);
				}
				else if (numM > 135f && numM <= 225f)
				{
					IGT_Hero.userInputQueue.Enqueue(1);
				}
				else if (numM > 225f && numM <= 315f)
				{
					IGT_Hero.userInputQueue.Enqueue(4);
					IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
				}
				else if (numM > 315f && numM <= 360f)
				{
					IGT_Hero.userInputQueue.Enqueue(2);
					IGT_AnimStatesCntrler.bAnimstrtNorTime = false;
				}
				bTouchStateCheck = true;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			lstTchPos = Input.mousePosition;
			float num3M = Vector2.Distance(new Vector2(fstTchPos.x, fstTchPos.y), new Vector2(lstTchPos.x, lstTchPos.y));
			if (num3M < (float)IGT_Hero.nPixelFrTouchCalc && Input.mousePosition.y > IGT_UIcommonFunc.ScaleY(45f))
			{
				IGT_Hero.userInputQueue.Enqueue(5);
			}
		}
	}

	public float angleBtwTwoPts(float cenx, float ceny, float ptx, float pty)
	{
		if (cenx == ptx && ceny == pty)
		{
			return -1f;
		}
		if (cenx == ptx && ceny != pty)
		{
			if (ceny - pty > 0f)
			{
				return 270f;
			}
			return 90f;
		}
		if (ceny == pty && cenx != ptx)
		{
			if (cenx - ptx > 0f)
			{
				return 180f;
			}
			return 0f;
		}
		int num = 0;
		num = ((cenx - ptx > 0f) ? ((!(ceny - pty > 0f)) ? 3 : 2) : ((ceny - pty > 0f) ? 1 : 4));
		float f = (ceny - pty) / (cenx - ptx);
		float num2 = Mathf.Atan(f);
		num2 = 57.29578f * num2;
		if (num == 1)
		{
			num2 = 270f + (90f + num2);
		}
		if (num == 2)
		{
			num2 = 180f + num2;
		}
		if (num == 3)
		{
			num2 = 90f + (90f + num2);
		}
		return num2;
	}
}
