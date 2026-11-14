public class IGT_EncodeDecode
{
	public static byte[] encrypt(byte[] array)
	{
		byte[] array2 = reverseByteArray(array);
		int num = 29;
		int num2 = array.Length;
		int i = num;
		int num3 = 0;
		for (; i < num2; i++)
		{
			byte b = array2[num3];
			array2[num3] = array2[i];
			array2[i] = b;
			num3++;
		}
		return array2;
	}

	public static byte[] decrypt(byte[] array)
	{
		int num = 29;
		int num2 = array.Length - 1;
		int num3 = 0;
		num3 = num2 - num;
		int num4 = num2;
		while (num3 >= 0)
		{
			byte b = array[num4];
			array[num4] = array[num3];
			array[num3] = b;
			num4--;
			num3--;
		}
		return reverseByteArray(array);
	}

	private static byte[] reverseByteArray(byte[] array)
	{
		if (array == null)
		{
			return null;
		}
		int i = 0;
		for (int num = array.Length - 1; num > i; i++)
		{
			byte b = array[num];
			array[num] = array[i];
			array[i] = b;
			num--;
		}
		return array;
	}
}
