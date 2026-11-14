using System;
using UnityEngine;

public class IGT_Button
{
	private ButtonClickListner pButtonClickListner;

	private int ID;

	private int ID_index;

	private float X;

	private float Y;

	private float Width;

	private float Height;

	private Texture pTexture;

	private bool isBtnDown;

	private bool isBtnUp;

	private bool isEnable;

	private bool isSameRatio;

	private bool isWidthBased;

	private float fRotationAngle;

	private Vector2 RotationPivot;

	private int nStartupAnimationType;

	private float fStartUpAnimTotTime;

	private int nStaticAnimationType;

	private float fStaticAnimTotTime;

	private float fStaticAnimGap;

	private float fAnimCurTime;

	private float fStaicAnimStartTime;

	private float fEndAnimCurTime;

	private float fStartUpAnimStartTime;

	private float fStartUpAnimEndTime;

	private bool bStartupAnim;

	private bool bStaticAnim;

	private bool bEndingAnimStart;

	private Rect CurrentButtonDimensions;

	private Rect OriginalDimensions;

	private float fSrcPos;

	private float fTarPos;

	private float fRotSpd;

	public IGT_Button(Rect buttonDimension, Texture img, int id, int index, bool bsameRatio, float rotAngle, Vector2 rotPivot, int startAnimType, float strtupAnimTotTime, int staticAnimType, float staticAnimTotTime, float gapBTWstaticAnim)
	{
		X = buttonDimension.x;
		Y = buttonDimension.y;
		Width = buttonDimension.width;
		Height = buttonDimension.height;
		OriginalDimensions = buttonDimension;
		CurrentButtonDimensions = buttonDimension;
		pTexture = img;
		ID = id;
		ID_index = index;
		isSameRatio = bsameRatio;
		isWidthBased = true;
		fRotationAngle = rotAngle;
		RotationPivot = rotPivot;
		nStartupAnimationType = startAnimType;
		fStartUpAnimTotTime = strtupAnimTotTime;
		nStaticAnimationType = staticAnimType;
		fStaticAnimTotTime = staticAnimTotTime;
		fStaticAnimGap = fStaticAnimTotTime + gapBTWstaticAnim;
		isBtnDown = false;
		isBtnUp = false;
		isEnable = true;
		fAnimCurTime = 0f;
		fStaicAnimStartTime = Time.time;
		bStartupAnim = true;
		fStartUpAnimStartTime = Time.time;
		bStaticAnim = false;
		bEndingAnimStart = false;
		fEndAnimCurTime = 0f;
	}

	public IGT_Button(int id, float x, float y, float w, float h)
	{
		ID = id;
		X = x;
		Y = y;
		Width = w;
		Height = h;
		OriginalDimensions = (CurrentButtonDimensions = new Rect(x, y, w, h));
		isBtnDown = false;
		isBtnUp = false;
		isEnable = true;
		pTexture = null;
	}

	public IGT_Button(Texture img, int id, float x, float y, float w, float h)
	{
		pTexture = img;
		ID = id;
		X = x;
		Y = y;
		Width = w;
		Height = h;
		isBtnDown = false;
		isEnable = true;
	}

	public IGT_Button(Texture img, int id, int index, float x, float y, float w, float h)
	{
		pTexture = img;
		ID = id;
		X = x;
		Y = y;
		Width = w;
		Height = h;
		isBtnDown = false;
		isEnable = true;
		ID_index = index;
	}

	public void setListener(ButtonClickListner listener)
	{
		pButtonClickListner = listener;
	}

	public void ResetAnimationDatas()
	{
		fAnimCurTime = 0f;
		fStaicAnimStartTime = Time.time;
		bStartupAnim = true;
		fStartUpAnimStartTime = -1f;
		bStaticAnim = false;
		bEndingAnimStart = false;
		fEndAnimCurTime = 0f;
		isBtnDown = false;
		isBtnUp = false;
	}

	public void setAnimProperties(float srcPos, float tarPos, float rotSpd)
	{
		fSrcPos = srcPos;
		fTarPos = tarPos;
		fRotSpd = rotSpd;
	}

	public void setSameRatioBasedOnHeight()
	{
		isWidthBased = false;
	}

	public void startUpAnimFinshed()
	{
		bStartupAnim = false;
		bStaticAnim = true;
		bEndingAnimStart = false;
		fEndAnimCurTime = 0f;
		isBtnDown = false;
		isBtnUp = false;
		fStartUpAnimEndTime = Time.time;
		if (nStaticAnimationType != 0)
		{
			fAnimCurTime = -1f;
			fStaicAnimStartTime = -1f;
		}
		else
		{
			fAnimCurTime = 0f;
			fStaicAnimStartTime = Time.time;
		}
	}

	public bool isStartupAnimFinished()
	{
		return bStartupAnim;
	}

	public void Draw()
	{
		if (pTexture == null)
		{
			return;
		}
		if (isSameRatio && fRotationAngle != 0f)
		{
			Matrix4x4 matrix = GUI.matrix;
			if (isWidthBased)
			{
				GUIUtility.RotateAroundPivot(fRotationAngle, new Vector2(X + Width * RotationPivot.x, Y + IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Width * RotationPivot.y));
				drawButtonWithAnimtion(X, Y, Width, IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Width);
			}
			else
			{
				GUIUtility.RotateAroundPivot(fRotationAngle, new Vector2(X + IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Height * RotationPivot.x, Y + Height * RotationPivot.y));
				drawButtonWithAnimtion(X, Y, IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Height, Height);
			}
			GUI.matrix = matrix;
		}
		else if (isSameRatio)
		{
			if (isWidthBased)
			{
				drawButtonWithAnimtion(X, Y, Width, IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Width);
			}
			else
			{
				drawButtonWithAnimtion(X, Y, IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Height, Height);
			}
		}
		else if (fRotationAngle != 0f)
		{
			Matrix4x4 matrix2 = GUI.matrix;
			GUIUtility.RotateAroundPivot(fRotationAngle, new Vector2(X + Width * RotationPivot.x, Y + Height * RotationPivot.y));
			drawButtonWithAnimtion(X, Y, Width, Height);
			GUI.matrix = matrix2;
		}
		else
		{
			drawButtonWithAnimtion(X, Y, Width, Height);
		}
	}

	private void drawButtonWithAnimtion(float x, float y, float w, float h)
	{
		float num = 1f;
		if (isBtnDown)
		{
			float num2 = 10f * Mathf.Sin(fAnimCurTime * 2f * (float)Math.PI * 2f) / Mathf.Exp(fAnimCurTime * 1f);
			fAnimCurTime += Time.deltaTime;
			CurrentButtonDimensions.x = x + w * 0.5f - w * 0.5f + num2 * 0.5f + 5f;
			CurrentButtonDimensions.y = y + h * 0.5f - h * 0.5f + num2 * 0.5f + 5f;
			CurrentButtonDimensions.width = w - num2 - 10f;
			CurrentButtonDimensions.height = h - num2 - 10f;
			GUI.DrawTexture(CurrentButtonDimensions, pTexture);
		}
		else if (isBtnUp)
		{
			float num3 = 10f * Mathf.Sin(fEndAnimCurTime * 2f * (float)Math.PI * 2f) / Mathf.Exp(fEndAnimCurTime * 1f);
			fEndAnimCurTime += Time.deltaTime;
			CurrentButtonDimensions.x = x + w * 0.5f - w * 0.5f + num3 * 0.5f;
			CurrentButtonDimensions.y = y + h * 0.5f - h * 0.5f + num3 * 0.5f;
			CurrentButtonDimensions.width = w - num3;
			CurrentButtonDimensions.height = h - num3;
			GUI.DrawTexture(CurrentButtonDimensions, pTexture);
			if (fEndAnimCurTime > 3f)
			{
				isBtnUp = false;
				fEndAnimCurTime = 0f;
				fAnimCurTime = 0f;
			}
		}
		else if (bStartupAnim)
		{
			if (fStartUpAnimStartTime == -1f)
			{
				fStartUpAnimStartTime = Time.time;
			}
			fAnimCurTime = Time.time - fStartUpAnimStartTime;
			switch (nStartupAnimationType)
			{
			case 0:
				GUI.DrawTexture(new Rect(x, y, w, h), pTexture);
				startUpAnimFinshed();
				break;
			case 1:
				if (fAnimCurTime < fStartUpAnimTotTime)
				{
					num = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, 0f, 1f, fStartUpAnimTotTime);
				}
				else
				{
					startUpAnimFinshed();
				}
				CurrentButtonDimensions.x = x + w * 0.5f - w * 0.5f * num;
				CurrentButtonDimensions.y = y + h * 0.5f - h * 0.5f * num;
				CurrentButtonDimensions.width = w * num;
				CurrentButtonDimensions.height = h * num;
				GUI.DrawTexture(CurrentButtonDimensions, pTexture);
				break;
			case 4:
			{
				float num4 = 0f;
				float num5 = x;
				if (fAnimCurTime < fStartUpAnimTotTime)
				{
					num5 = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, fSrcPos, fTarPos, fStartUpAnimTotTime);
					if (num5 >= x * 0.9f)
					{
						bEndingAnimStart = true;
					}
					if (bEndingAnimStart)
					{
						num4 = 20f * Mathf.Sin(fEndAnimCurTime * 2f * (float)Math.PI * 2f) / Mathf.Exp(fEndAnimCurTime * 1f);
						fEndAnimCurTime += Time.deltaTime;
					}
				}
				else
				{
					startUpAnimFinshed();
				}
				CurrentButtonDimensions.x = num5 + num4 * 0.5f;
				CurrentButtonDimensions.y = y - num4 * 0.25f;
				CurrentButtonDimensions.width = w - num4 * 0.5f;
				CurrentButtonDimensions.height = h + num4 * 0.5f;
				GUI.DrawTexture(CurrentButtonDimensions, pTexture);
				break;
			}
			case 5:
			{
				float num4 = 0f;
				float num5 = x;
				if (fAnimCurTime < fStartUpAnimTotTime)
				{
					num5 = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, fSrcPos, fTarPos, fStartUpAnimTotTime);
					if (num5 <= x + w / 4f)
					{
						bEndingAnimStart = true;
					}
					if (bEndingAnimStart)
					{
						num4 = 20f * Mathf.Sin(fEndAnimCurTime * 2f * (float)Math.PI * 2f) / Mathf.Exp(fEndAnimCurTime * 1f);
						fEndAnimCurTime += Time.deltaTime;
					}
				}
				else
				{
					startUpAnimFinshed();
				}
				CurrentButtonDimensions.x = num5 + num4 * 0.5f;
				CurrentButtonDimensions.y = y - num4 * 0.25f;
				CurrentButtonDimensions.width = w - num4 * 0.5f;
				CurrentButtonDimensions.height = h + num4 * 0.5f;
				GUI.DrawTexture(CurrentButtonDimensions, pTexture);
				break;
			}
			case 2:
			{
				float num4 = 0f;
				float num5 = y;
				if (fAnimCurTime < fStartUpAnimTotTime)
				{
					num5 = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, fSrcPos, fTarPos, fStartUpAnimTotTime);
					if (num5 >= y - h)
					{
						bEndingAnimStart = true;
					}
					if (bEndingAnimStart)
					{
						num4 = 20f * Mathf.Sin(fEndAnimCurTime * 2f * (float)Math.PI * 2f) / Mathf.Exp(fEndAnimCurTime * 1f);
						fEndAnimCurTime += Time.deltaTime;
					}
				}
				else
				{
					startUpAnimFinshed();
				}
				CurrentButtonDimensions.x = x + num4 * 0.5f;
				CurrentButtonDimensions.y = num5 - num4 * 0.25f;
				CurrentButtonDimensions.width = w - num4 * 0.5f;
				CurrentButtonDimensions.height = h + num4 * 0.5f;
				GUI.DrawTexture(CurrentButtonDimensions, pTexture);
				break;
			}
			case 3:
			{
				float num4 = 0f;
				float num5 = y;
				if (fAnimCurTime < fStartUpAnimTotTime)
				{
					num5 = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, fSrcPos, fTarPos, fStartUpAnimTotTime);
					if (num5 <= y + h / 4f)
					{
						bEndingAnimStart = true;
					}
					if (bEndingAnimStart)
					{
						num4 = 20f * Mathf.Sin(fEndAnimCurTime * 2f * (float)Math.PI * 2f) / Mathf.Exp(fEndAnimCurTime * 1f);
						fEndAnimCurTime += Time.deltaTime;
					}
				}
				else
				{
					startUpAnimFinshed();
				}
				CurrentButtonDimensions.x = x + num4 * 0.5f;
				CurrentButtonDimensions.y = num5 - num4 * 0.25f;
				CurrentButtonDimensions.width = w - num4 * 0.5f;
				CurrentButtonDimensions.height = h + num4 * 0.5f;
				GUI.DrawTexture(CurrentButtonDimensions, pTexture);
				break;
			}
			}
		}
		else if (bStaticAnim)
		{
			if (fStaicAnimStartTime != -1f)
			{
				switch (nStaticAnimationType)
				{
				case 0:
					GUI.DrawTexture(new Rect(x, y, w, h), pTexture);
					break;
				case 1:
					if (Time.time - fStaicAnimStartTime > fStaticAnimGap)
					{
						fAnimCurTime = 0f;
						fStaicAnimStartTime = Time.time;
					}
					if (fAnimCurTime < fStaticAnimTotTime)
					{
						num = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, 0f, 1f, fStaticAnimTotTime);
						fAnimCurTime = Time.time - fStaicAnimStartTime;
					}
					CurrentButtonDimensions.x = x + w * 0.5f - w * 0.5f * num;
					CurrentButtonDimensions.y = y + h * 0.5f - h * 0.5f * num;
					CurrentButtonDimensions.width = w * num;
					CurrentButtonDimensions.height = h * num;
					GUI.DrawTexture(CurrentButtonDimensions, pTexture);
					break;
				case 2:
					num = IGT_EaseFunction.customeBounce(fAnimCurTime, 8f, 2f, 1f);
					fAnimCurTime = Time.time - fStaicAnimStartTime;
					if (Time.time - fStaicAnimStartTime > fStaticAnimGap)
					{
						fAnimCurTime = 0f;
						fStaicAnimStartTime = Time.time;
					}
					CurrentButtonDimensions.x = x + w * 0.5f - w * 0.5f - num * 0.5f;
					CurrentButtonDimensions.y = y + h * 0.5f - h * 0.5f - num * 0.5f;
					CurrentButtonDimensions.width = w + num;
					CurrentButtonDimensions.height = h + num;
					GUI.DrawTexture(CurrentButtonDimensions, pTexture);
					break;
				case 3:
					if (Time.time - fStaicAnimStartTime > fStaticAnimGap)
					{
						fAnimCurTime = 0f;
						fStaicAnimStartTime = Time.time;
					}
					fRotationAngle = 0f;
					if (fAnimCurTime < fStaticAnimTotTime)
					{
						fRotationAngle = IGT_EaseFunction.Cubic_easeInOut(fAnimCurTime, 0f, 360f * fRotSpd, fStaticAnimTotTime);
						fAnimCurTime = Time.time - fStaicAnimStartTime;
					}
					CurrentButtonDimensions.x = x;
					CurrentButtonDimensions.y = y;
					CurrentButtonDimensions.width = w;
					CurrentButtonDimensions.height = h;
					GUI.DrawTexture(CurrentButtonDimensions, pTexture);
					break;
				}
			}
			else if (fStaicAnimStartTime == -1f && Time.time - fStartUpAnimEndTime > fStaticAnimGap)
			{
				fStaicAnimStartTime = Time.time;
				fAnimCurTime = 0f;
			}
			else
			{
				GUI.DrawTexture(new Rect(x, y, w, h), pTexture);
			}
		}
		else
		{
			Debug.Log("else part ");
		}
	}

	public void checkBounce(float TouchX, float TouchY, TouchPhase touchPhase)
	{
		if (isBtnDown && touchPhase == TouchPhase.Ended)
		{
			if (isEnable && TouchX >= X && TouchX <= X + Width && TouchY >= Y && TouchY <= Y + Height)
			{
				pButtonClickListner.OnButtonClick(this);
			}
			isBtnDown = false;
			isBtnUp = true;
		}
		else if (touchPhase == TouchPhase.Began && isEnable && TouchX >= X && TouchX <= X + Width && TouchY >= Y && TouchY <= Y + Height)
		{
			isBtnDown = true;
			fEndAnimCurTime = 0f;
			fAnimCurTime = 0f;
		}
	}

	public int getID()
	{
		return ID;
	}

	public int getID_Index()
	{
		return ID_index;
	}

	public float getX()
	{
		return X;
	}

	public float getY()
	{
		return Y;
	}

	public float getWidth()
	{
		return Width;
	}

	public float getHeight()
	{
		return Height;
	}

	public Rect getOriginalDimension()
	{
		return OriginalDimensions;
	}

	public Rect getCurrentDimension()
	{
		return CurrentButtonDimensions;
	}

	public void setDimensions(float x, float y, float w, float h)
	{
		X = x;
		Y = y;
		Width = w;
		Height = h;
	}

	public void changeButtonTexture(Texture img)
	{
		pTexture = img;
	}

	public void setEnable(bool isEnable)
	{
		this.isEnable = isEnable;
	}

	public void setX(float x)
	{
		X = x;
		CurrentButtonDimensions.x = x;
	}

	public void setY(float y)
	{
		Y = y;
		CurrentButtonDimensions.y = y;
	}

	public void setWidth(float w)
	{
		Width = w;
		CurrentButtonDimensions.width = w;
	}

	public void setHeight(float h)
	{
		Height = h;
		CurrentButtonDimensions.height = h;
	}

	public void setAngle_Pivot(float ang, Vector2 pivot)
	{
		fRotationAngle = ang;
		RotationPivot = pivot;
	}

	public bool getStartupAnimFinished()
	{
		return bStartupAnim;
	}

	public void Draw_Button()
	{
		if (pTexture == null)
		{
			return;
		}
		if (isEnable)
		{
			if (isBtnDown)
			{
				GUI.DrawTexture(new Rect(X + 5f, Y + 5f, Width - 10f, Height - 10f), pTexture);
			}
			else
			{
				GUI.DrawTexture(new Rect(X, Y, Width, Height), pTexture);
			}
		}
		else
		{
			GUI.color = new Color(1f, 1f, 1f, 0.6f);
			GUI.DrawTexture(new Rect(X, Y, Width, Height), pTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	public void Draw_Button_CenterPoint()
	{
		if (!(pTexture == null))
		{
			if (isBtnDown)
			{
				GUI.DrawTexture(new Rect(X + 5f, Y + 5f, Width - 10f, IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Width - 10f), pTexture);
			}
			else
			{
				GUI.DrawTexture(new Rect(X, Y, Width, IGT_UIcommonFunc.reScaleX(Width) / IGT_UIcommonFunc.reScaleY(Height) * Width), pTexture);
			}
		}
	}

	public void Draw_Button_RotateByAngle(float angle, Vector2 pivot)
	{
		if (!(pTexture == null))
		{
			GUIUtility.RotateAroundPivot(angle, new Vector2(X + Width * pivot.x, Y + Height * pivot.y));
			if (isBtnDown)
			{
				GUI.DrawTexture(new Rect(X + 5f, Y + 5f, Width - 10f, Height - 10f), pTexture);
			}
			else
			{
				GUI.DrawTexture(new Rect(X, Y, Width, Height), pTexture);
			}
			GUI.matrix = Matrix4x4.identity;
		}
	}
}
