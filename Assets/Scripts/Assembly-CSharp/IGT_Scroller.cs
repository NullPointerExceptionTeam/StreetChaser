using UnityEngine;

public class IGT_Scroller
{
	private IGT_GestureDetector gesture;

	private Vector2 downTouchPos;

	private Vector2 moveTouchPos;

	private Vector2 diffPos;

	private float downTime;

	private float upTime;

	private float diffTime;

	private Vector2 mStartPos;

	private Vector2 mMinMaxX;

	private Vector2 mMinMaxY;

	private Vector2 flingVelocity;

	private Vector2 flingPos;

	private Vector2 mMinVelocity = new Vector2(5f, 5f);

	private bool isFling;

	private float fFlingTimeInterval;

	private float fFlingTotTmeInterval = 5f;

	private float fEdgeTimeInterval;

	private float fEdgeTotTmeInterval = 3f;

	private bool isOutOfEdge;

	private Vector2 edgeStartPos;

	private Vector2 edgeEndPos;

	private float fEdgeDistance = 120f;

	private int nScrollType;

	public IGT_Scroller(float fEdgeDistance, Vector2 minVelocity, int ScrollType)
	{
		this.fEdgeDistance = fEdgeDistance;
		mMinVelocity = minVelocity;
		nScrollType = ScrollType;
	}

	public void setListener(IGT_GestureDetector listener)
	{
		gesture = listener;
	}

	private float reScaleX(float x)
	{
		return x / (float)Screen.width * 320f;
	}

	private float reScaleY(float y)
	{
		return y / (float)Screen.height * 480f;
	}

	private float ScaleX(float x)
	{
		return x / 320f * (float)Screen.width;
	}

	private float ScaleY(float y)
	{
		return y / 480f * (float)Screen.height;
	}

	public void handleTouch(Touch touch, Rect viewRect)
	{
		if (isOutOfEdge)
		{
			return;
		}
		if (touch.position.x >= viewRect.x && touch.position.x <= viewRect.x + viewRect.width && (float)Screen.height - touch.position.y >= viewRect.y && (float)Screen.height - touch.position.y <= viewRect.y + viewRect.height)
		{
			if (touch.phase == TouchPhase.Began)
			{
				downTouchPos = touch.position;
				downTime = Time.time;
				isFling = false;
			}
			if (touch.phase == TouchPhase.Moved)
			{
				moveTouchPos = touch.position;
				diffPos.x = moveTouchPos.x - downTouchPos.x;
				diffPos.y = (float)Screen.height - moveTouchPos.y - ((float)Screen.height - downTouchPos.y);
				downTouchPos = moveTouchPos;
				downTime = Time.time;
				gesture.OnScroll(diffPos.x, diffPos.y);
			}
			if (touch.phase != TouchPhase.Ended)
			{
				return;
			}
			moveTouchPos = touch.position;
			upTime = Time.time;
			diffPos.x = moveTouchPos.x - downTouchPos.x;
			diffPos.y = (float)Screen.height - moveTouchPos.y - ((float)Screen.height - downTouchPos.y);
			diffTime = upTime - downTime;
			switch (nScrollType)
			{
			case 2:
				flingVelocity.x = diffPos.x / diffTime;
				flingVelocity.y = diffPos.y / diffTime;
				if (Mathf.Abs(flingVelocity.y) <= ScaleY(mMinVelocity.y) && Mathf.Abs(flingVelocity.x) <= ScaleX(mMinVelocity.x))
				{
					isFling = false;
					gesture.OnViewRectBounceChecking();
				}
				else
				{
					downTouchPos = moveTouchPos;
					isOutOfEdge = false;
					gesture.OnFling(flingPos.x, flingPos.y, flingVelocity.x, flingVelocity.y);
				}
				break;
			case 0:
				flingVelocity.x = diffPos.x / diffTime;
				if (Mathf.Abs(flingVelocity.x) <= ScaleX(mMinVelocity.x))
				{
					isFling = false;
					gesture.OnViewRectBounceChecking();
				}
				else
				{
					downTouchPos = moveTouchPos;
					isOutOfEdge = false;
					gesture.OnFling(flingPos.x, flingPos.y, flingVelocity.x, 0f);
				}
				break;
			case 1:
				flingVelocity.y = diffPos.y / diffTime;
				if (Mathf.Abs(flingVelocity.y) <= ScaleY(mMinVelocity.y))
				{
					isFling = false;
					gesture.OnViewRectBounceChecking();
				}
				else
				{
					downTouchPos = moveTouchPos;
					isOutOfEdge = false;
					gesture.OnFling(flingPos.x, flingPos.y, 0f, flingVelocity.y);
				}
				break;
			}
		}
		else
		{
			gesture.onOutOfRectScroll();
		}
	}

	public bool CalcEdgeEffect()
	{
		if (!isOutOfEdge)
		{
			return false;
		}
		if (fEdgeTimeInterval >= fEdgeTotTmeInterval)
		{
			fEdgeTimeInterval = fEdgeTotTmeInterval;
			isOutOfEdge = false;
		}
		fEdgeTimeInterval += Time.deltaTime * fEdgeTotTmeInterval;
		if (fEdgeTimeInterval > fEdgeTotTmeInterval)
		{
			fEdgeTimeInterval = fEdgeTotTmeInterval;
		}
		return true;
	}

	public float getEdgeX()
	{
		return easeOutQuad(fEdgeTimeInterval, edgeStartPos.x, edgeEndPos.x, fEdgeTotTmeInterval);
	}

	public float getEdgeY()
	{
		return easeOutQuad(fEdgeTimeInterval, edgeStartPos.y, edgeEndPos.y, fEdgeTotTmeInterval);
	}

	public void checkOutOfEdge(float x, float y, float minX, float maxX, float minY, float maxY)
	{
		bool flag = false;
		if (x < minX)
		{
			edgeEndPos.x = minX;
			flag = true;
		}
		else if (x > maxX)
		{
			edgeEndPos.x = maxX;
			flag = true;
		}
		if (y < minY)
		{
			edgeEndPos.y = minY;
			flag = true;
		}
		else if (y > maxY)
		{
			edgeEndPos.y = maxY;
			flag = true;
		}
		if (flag)
		{
			fEdgeTimeInterval = 0f;
			edgeStartPos.x = x;
			isOutOfEdge = true;
			edgeStartPos.y = y;
		}
	}

	public void fling(float startX, float startY, float velocityX, float velocityY, float minX, float maxX, float minY, float maxY)
	{
		mStartPos.x = startX;
		mStartPos.y = startY;
		mMinMaxX.x = minX;
		mMinMaxX.y = maxX;
		mMinMaxY.x = minY;
		mMinMaxY.y = maxY;
		fFlingTimeInterval = 0f;
		isFling = true;
	}

	public void forceStopFlingAction()
	{
		isFling = false;
		isOutOfEdge = false;
	}

	public bool computeFlingScroller()
	{
		if (!isFling)
		{
			return false;
		}
		if (fFlingTimeInterval >= fFlingTotTmeInterval)
		{
			fFlingTimeInterval = fFlingTotTmeInterval;
			isFling = false;
			checkOutOfEdge(getFlingX(), getFlingY(), mMinMaxX.x, mMinMaxX.y, mMinMaxY.x, mMinMaxY.y);
		}
		fFlingTimeInterval += Time.deltaTime;
		if (fFlingTimeInterval > fFlingTotTmeInterval)
		{
			fFlingTimeInterval = fFlingTotTmeInterval;
		}
		return true;
	}

	public float getFlingX()
	{
		float num = easeOutQuad(fFlingTimeInterval, 0f, flingVelocity.x, fFlingTotTmeInterval);
		num = mStartPos.x + num;
		if (num < mMinMaxX.x - fEdgeDistance)
		{
			num = mMinMaxX.x - fEdgeDistance;
			flingPos.x = num;
			fFlingTimeInterval = fFlingTotTmeInterval;
		}
		else if (num > mMinMaxX.y + fEdgeDistance)
		{
			num = mMinMaxX.y + fEdgeDistance;
			flingPos.x = num;
			fFlingTimeInterval = fFlingTotTmeInterval;
		}
		return num;
	}

	public float getFlingY()
	{
		float num = easeOutQuad(fFlingTimeInterval, 0f, flingVelocity.y, fFlingTotTmeInterval);
		num = mStartPos.y + num;
		if (num < mMinMaxY.x - fEdgeDistance)
		{
			num = mMinMaxY.x - fEdgeDistance;
			fFlingTimeInterval = fFlingTotTmeInterval;
			flingPos.y = num;
		}
		else if (num > mMinMaxY.y + fEdgeDistance)
		{
			num = mMinMaxY.y + fEdgeDistance;
			fFlingTimeInterval = fFlingTotTmeInterval;
			flingPos.y = num;
		}
		return num;
	}

	private float lineartwean(float t, float fCurrentPos, float fTargetPos, float fDuration)
	{
		return (fTargetPos - fCurrentPos) * t / fDuration + fCurrentPos;
	}

	private float easeInQuad(float t, float fBeginPos, float fTargetPos, float fDuration)
	{
		return (fTargetPos - fBeginPos) * (t /= fDuration) * t + fBeginPos;
	}

	private float easeOutQuad(float t, float fBeginPos, float fTargetPos, float fDuration)
	{
		return (0f - (fTargetPos - fBeginPos)) * (t /= fDuration) * (t - 2f) + fBeginPos;
	}
}
