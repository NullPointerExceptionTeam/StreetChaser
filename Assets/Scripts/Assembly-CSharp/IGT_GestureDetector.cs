public interface IGT_GestureDetector
{
	void OnScroll(float x, float y);

	void OnFling(float startx, float starty, float velocityX, float velocityY);

	void OnViewRectBounceChecking();

	void onOutOfRectScroll();
}
