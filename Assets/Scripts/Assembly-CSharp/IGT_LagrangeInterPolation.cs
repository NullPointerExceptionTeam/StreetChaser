public class IGT_LagrangeInterPolation
{
	public class Point
	{
		public float x;

		public float y;

		public Point(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
	}

	private Point[] p;

	public void addReferenceValues(params float[] values)
	{
		int num = values.Length / 2;
		p = new Point[num];
		for (int i = 0; i < num; i++)
		{
			p[i] = new Point(values[i * 2], values[i * 2 + 1]);
		}
	}

	public float getResultValue(float input)
	{
		float num = 0f;
		for (int i = 0; i < p.Length; i++)
		{
			num += getProduct(i, input);
		}
		return num;
	}

	private float getProduct(int index, float x)
	{
		float num = 1f;
		for (int i = 0; i < p.Length; i++)
		{
			if (i != index)
			{
				num = num * (x - p[i].x) / (p[index].x - p[i].x);
			}
		}
		return num * p[index].y;
	}
}
