using System;
using UnityEngine;

public class IGT_Math
{
	public static Vector3 RotatePoint_ByAxis(Vector3 dSrcPt, float dRotAngle, Vector3 dRotAxis, Vector3 dRotCenter)
	{
		float[] array = new float[9];
		Vector3 vector = default(Vector3);
		vector.x = dSrcPt.x;
		vector.y = dSrcPt.y;
		vector.z = dSrcPt.z;
		vector.x -= dRotCenter.x;
		vector.y -= dRotCenter.y;
		vector.z -= dRotCenter.z;
		vds_getRotationMatrix(dRotAxis, dRotAngle, array);
		Vector3 result = default(Vector3);
		result.x = array[0] * vector.x + array[3] * vector.y + array[6] * vector.z;
		result.y = array[1] * vector.x + array[4] * vector.y + array[7] * vector.z;
		result.z = array[2] * vector.x + array[5] * vector.y + array[8] * vector.z;
		result.x += dRotCenter[0];
		result.y += dRotCenter[1];
		result.z += dRotCenter[2];
		return result;
	}

	private static void vds_getRotationMatrix(Vector3 axis, float angle, float[] rotMatrix)
	{
		float[] array = new float[3];
		float[] array2 = new float[3];
		float[] array3 = new float[3];
		float[] array4 = new float[9];
		float[] array5 = new float[9];
		float[] array6 = new float[9];
		float[] array7 = new float[9];
		float num = 0f;
		num = angle * 3.1416f / 180f;
		array[0] = axis.x;
		array[1] = axis.y;
		array[2] = axis.z;
		if (array[0] >= array[1] && array[0] >= array[2])
		{
			array2[0] = 0f - (array[1] + array[2]);
			array2[1] = array[0];
			array2[2] = array[0];
		}
		else if (array[1] >= array[0] && array[1] >= array[2])
		{
			array2[0] = array[1];
			array2[1] = 0f - (array[0] + array[2]);
			array2[2] = array[1];
		}
		else
		{
			array2[0] = array[2];
			array2[1] = array[2];
			array2[2] = 0f - (array[0] + array[1]);
		}
		vds_vectCrossProduct(array, array2, array3);
		vds_vectNormalize(array);
		vds_vectNormalize(array2);
		vds_vectNormalize(array3);
		array4[0] = 1f;
		array4[1] = 0f;
		array4[2] = 0f;
		array4[3] = 0f;
		array4[4] = Mathf.Cos(num);
		array4[5] = Mathf.Sin(num);
		array4[6] = 0f;
		array4[7] = 0f - Mathf.Sin(num);
		array4[8] = Mathf.Cos(num);
		array5[0] = array[0];
		array5[1] = array2[0];
		array5[2] = array3[0];
		array5[3] = array[1];
		array5[4] = array2[1];
		array5[5] = array3[1];
		array5[6] = array[2];
		array5[7] = array2[2];
		array5[8] = array3[2];
		vds_matrixInverse(3, array5, array6);
		float[] outMatrix = new float[9];
		vds_matrixMultiply(3, 3, array5, 3, 3, array6, outMatrix);
		vds_matrixMultiply(3, 3, array5, 3, 3, array4, array7);
		vds_matrixMultiply(3, 3, array7, 3, 3, array6, rotMatrix);
	}

	private static float vds_matrixDeterminent(int order, float[] matrix)
	{
		float num = 0f;
		if (order < 1)
		{
			return 0f;
		}
		switch (order)
		{
		case 1:
			return matrix[0];
		case 2:
			return matrix[0] * matrix[3] - matrix[1] * matrix[2];
		case 3:
			return matrix[0] * (matrix[4] * matrix[8] - matrix[5] * matrix[7]) - matrix[1] * (matrix[3] * matrix[8] - matrix[5] * matrix[6]) + matrix[2] * (matrix[3] * matrix[7] - matrix[4] * matrix[6]);
		default:
		{
			int num2 = 0;
			float[][] array = new float[order][];
			for (int i = 0; i < order; i++)
			{
				array[i] = new float[order];
			}
			for (int j = 0; j < order; j++)
			{
				for (int k = 0; k < order; k++)
				{
					array[j][k] = matrix[num2++];
				}
			}
			return vds_nXnDeterminant(array, order);
		}
		}
	}

	private static void vds_matrixInverse(int order, float[] inMatrix, float[] outMatrix)
	{
		float num = 0f;
		float num2 = 0f;
		if (order < 1)
		{
			return;
		}
		num = vds_matrixDeterminent(order, inMatrix);
		if (num != 0f)
		{
			num2 = 1f / num;
			if (order == 1)
			{
				outMatrix[0] = num2;
			}
			switch (order)
			{
			case 2:
				outMatrix[0] = inMatrix[3] * num2;
				outMatrix[1] = (0f - inMatrix[1]) * num2;
				outMatrix[2] = (0f - inMatrix[2]) * num2;
				outMatrix[3] = inMatrix[0] * num2;
				break;
			case 3:
				outMatrix[0] = (inMatrix[4] * inMatrix[8] - inMatrix[5] * inMatrix[7]) * num2;
				outMatrix[1] = (inMatrix[2] * inMatrix[7] - inMatrix[1] * inMatrix[8]) * num2;
				outMatrix[2] = (inMatrix[1] * inMatrix[5] - inMatrix[2] * inMatrix[4]) * num2;
				outMatrix[3] = (inMatrix[5] * inMatrix[6] - inMatrix[3] * inMatrix[8]) * num2;
				outMatrix[4] = (inMatrix[0] * inMatrix[8] - inMatrix[2] * inMatrix[6]) * num2;
				outMatrix[5] = (inMatrix[2] * inMatrix[3] - inMatrix[0] * inMatrix[5]) * num2;
				outMatrix[6] = (inMatrix[3] * inMatrix[7] - inMatrix[4] * inMatrix[6]) * num2;
				outMatrix[7] = (inMatrix[1] * inMatrix[6] - inMatrix[0] * inMatrix[7]) * num2;
				outMatrix[8] = (inMatrix[0] * inMatrix[4] - inMatrix[1] * inMatrix[3]) * num2;
				break;
			}
		}
	}

	private static void vds_vectCrossProduct(float[] v1, float[] v2, float[] res)
	{
		res[0] = v1[1] * v2[2] - v1[2] * v2[1];
		res[1] = v1[2] * v2[0] - v1[0] * v2[2];
		res[2] = v1[0] * v2[1] - v1[1] * v2[0];
	}

	public static float vds_nXnDeterminant(float[][] a, int n)
	{
		float num = 0f;
		float[][] array = new float[n - 1][];
		for (int i = 0; i < n - 1; i++)
		{
			array[i] = new float[n - 1];
		}
		if (n < 1)
		{
			num = 0f;
		}
		else
		{
			switch (n)
			{
			case 1:
				num = a[0][0];
				break;
			case 2:
				num = a[0][0] * a[1][1] - a[1][0] * a[0][1];
				break;
			default:
			{
				num = 0f;
				for (int j = 0; j < n; j++)
				{
					for (int k = 1; k < n; k++)
					{
						int num2 = 0;
						for (int l = 0; l < n; l++)
						{
							if (l != j)
							{
								array[k - 1][num2] = a[k][l];
								num2++;
							}
						}
					}
					num += Mathf.Pow(-1f, 1f + (float)j + 1f) * a[0][j] * vds_nXnDeterminant(array, n - 1);
				}
				break;
			}
			}
		}
		return num;
	}

	private static void vds_vectNormalize(float[] v)
	{
		float num = vds_vectMagnitude(v);
		if (!(num <= 0f))
		{
			v[0] /= num;
			v[1] /= num;
			v[2] /= num;
		}
	}

	private static float vds_vectMagnitude(float[] v)
	{
		return Mathf.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
	}

	private static void vds_matrixMultiply(int r1, int c1, float[] inMatrix1, int r2, int c2, float[] inMatrix2, float[] outMatrix)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		float num5 = 0f;
		if (c1 != r2)
		{
			return;
		}
		num4 = 0;
		for (num = 0; num < r1; num++)
		{
			for (num2 = 0; num2 < c2; num2++)
			{
				num5 = 0f;
				for (num3 = 0; num3 < c1; num3++)
				{
					num5 += inMatrix1[num * c1 + num3] * inMatrix2[num3 * c2 + num2];
				}
				outMatrix[num4++] = num5;
			}
		}
	}

	public static float AngleBtwVectors(Vector3 a, Vector3 b, Vector3 n)
	{
		float num = Vector3.Angle(a, b);
		float num2 = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));
		float num3 = num * num2;
		return (num3 + 180f) % 360f;
	}

	public static float AngleBtwPoints(Vector3 pointA, Vector3 pointB, Vector3 RefVec)
	{
		Vector3 rhs = Vector3.Cross(Vector3.up, RefVec);
		Vector3 vector = new Vector3(pointA.x - pointB.x, pointA.y - pointB.y, pointA.z - pointB.z);
		vector.Normalize();
		float num = Vector3.Angle(vector, RefVec);
		float num2 = Mathf.Sign(Vector3.Dot(vector, rhs));
		float num3 = num2 * num;
		return num3 + 180f;
	}

	public static Vector3 MidPointforTwo3dPoints(Vector3 src, Vector3 dst)
	{
		float x = (src.x + dst.x) / 2f;
		float y = (src.y + dst.y) / 2f;
		float z = (src.z + dst.z) / 2f;
		return new Vector3(x, y, z);
	}

	public static Vector3 AddVectorLength(Vector3 vector, float size)
	{
		float num = Vector3.Magnitude(vector);
		float num2 = num + size;
		float num3 = num2 / num;
		return vector * num3;
	}

	public static Vector3 SetVectorLength(Vector3 vector, float size)
	{
		Vector3 vector2 = Vector3.Normalize(vector);
		return vector2 *= size;
	}

	public static Quaternion SubtractRotation(Quaternion B, Quaternion A)
	{
		return Quaternion.Inverse(A) * B;
	}

	public static bool PlanePlaneIntersection(out Vector3 linePoint, out Vector3 lineVec, Vector3 plane1Normal, Vector3 plane1Position, Vector3 plane2Normal, Vector3 plane2Position)
	{
		linePoint = Vector3.zero;
		lineVec = Vector3.zero;
		lineVec = Vector3.Cross(plane1Normal, plane2Normal);
		Vector3 vector = Vector3.Cross(plane2Normal, lineVec);
		float num = Vector3.Dot(plane1Normal, vector);
		if (Mathf.Abs(num) > 0.006f)
		{
			Vector3 rhs = plane1Position - plane2Position;
			float num2 = Vector3.Dot(plane1Normal, rhs) / num;
			linePoint = plane2Position + num2 * vector;
			return true;
		}
		return false;
	}

	public static bool LinePlaneIntersection(out Vector3 intersection, Vector3 linePoint, Vector3 lineVec, Vector3 planeNormal, Vector3 planePoint)
	{
		intersection = Vector3.zero;
		float num = Vector3.Dot(planePoint - linePoint, planeNormal);
		float num2 = Vector3.Dot(lineVec, planeNormal);
		if (num2 != 0f)
		{
			float size = num / num2;
			Vector3 vector = SetVectorLength(lineVec, size);
			intersection = linePoint + vector;
			return true;
		}
		return false;
	}

	public static bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		intersection = Vector3.zero;
		Vector3 lhs = linePoint2 - linePoint1;
		Vector3 rhs = Vector3.Cross(lineVec1, lineVec2);
		Vector3 lhs2 = Vector3.Cross(lhs, lineVec2);
		float num = Vector3.Dot(lhs, rhs);
		if (num >= 1E-05f || num <= -1E-05f)
		{
			return false;
		}
		float num2 = Vector3.Dot(lhs2, rhs) / rhs.sqrMagnitude;
		if (num2 >= 0f && num2 <= 1f)
		{
			intersection = linePoint1 + lineVec1 * num2;
			return true;
		}
		return false;
	}

	public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		closestPointLine1 = Vector3.zero;
		closestPointLine2 = Vector3.zero;
		float num = Vector3.Dot(lineVec1, lineVec1);
		float num2 = Vector3.Dot(lineVec1, lineVec2);
		float num3 = Vector3.Dot(lineVec2, lineVec2);
		float num4 = num * num3 - num2 * num2;
		if (num4 != 0f)
		{
			Vector3 rhs = linePoint1 - linePoint2;
			float num5 = Vector3.Dot(lineVec1, rhs);
			float num6 = Vector3.Dot(lineVec2, rhs);
			float num7 = (num2 * num6 - num5 * num3) / num4;
			float num8 = (num * num6 - num5 * num2) / num4;
			closestPointLine1 = linePoint1 + lineVec1 * num7;
			closestPointLine2 = linePoint2 + lineVec2 * num8;
			return true;
		}
		return false;
	}

	public static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 lineVec, Vector3 point)
	{
		Vector3 lhs = point - linePoint;
		float num = Vector3.Dot(lhs, lineVec);
		return linePoint + lineVec * num;
	}

	public static Vector3 ProjectPointOnLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 vector = ProjectPointOnLine(linePoint1, (linePoint2 - linePoint1).normalized, point);
		switch (PointOnWhichSideOfLineSegment(linePoint1, linePoint2, vector))
		{
		case 0:
			return vector;
		case 1:
			return linePoint1;
		case 2:
			return linePoint2;
		default:
			return Vector3.zero;
		}
	}

	public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		float num = SignedDistancePlanePoint(planeNormal, planePoint, point);
		num *= -1f;
		Vector3 vector = SetVectorLength(planeNormal, num);
		return point + vector;
	}

	public static Vector3 ProjectVectorOnPlane(Vector3 planeNormal, Vector3 vector)
	{
		return vector - Vector3.Dot(vector, planeNormal) * planeNormal;
	}

	public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		return Vector3.Dot(planeNormal, point - planePoint);
	}

	public static float SignedDotProduct(Vector3 vectorA, Vector3 vectorB, Vector3 normal)
	{
		Vector3 lhs = Vector3.Cross(normal, vectorA);
		return Vector3.Dot(lhs, vectorB);
	}

	public static float SignedVectorAngle(Vector3 referenceVector, Vector3 otherVector, Vector3 normal)
	{
		Vector3 lhs = Vector3.Cross(normal, referenceVector);
		float num = Vector3.Angle(referenceVector, otherVector);
		return num * Mathf.Sign(Vector3.Dot(lhs, otherVector));
	}

	public static float AngleVectorPlane(Vector3 vector, Vector3 normal)
	{
		float f = Vector3.Dot(vector, normal);
		float num = Mathf.Acos(f);
		return (float)Math.PI / 2f - num;
	}

	public static float DotProductAngle(Vector3 vec1, Vector3 vec2)
	{
		float num = Vector3.Dot(vec1, vec2);
		if (num < -1f)
		{
			num = -1f;
		}
		if (num > 1f)
		{
			num = 1f;
		}
		float num2 = Mathf.Acos(num);
		return num2;
	}

	public static void PlaneFrom3Points(out Vector3 planeNormal, out Vector3 planePoint, Vector3 pointA, Vector3 pointB, Vector3 pointC)
	{
		planeNormal = Vector3.zero;
		planePoint = Vector3.zero;
		Vector3 vector = pointB - pointA;
		Vector3 vector2 = pointC - pointA;
		planeNormal = Vector3.Normalize(Vector3.Cross(vector, vector2));
		Vector3 vector3 = pointA + vector / 2f;
		Vector3 vector4 = pointA + vector2 / 2f;
		Vector3 lineVec = pointC - vector3;
		Vector3 lineVec2 = pointB - vector4;
		Vector3 closestPointLine;
		ClosestPointsOnTwoLines(out planePoint, out closestPointLine, vector3, lineVec, vector4, lineVec2);
	}

	public static Vector3 GetForwardVector(Quaternion q)
	{
		return q * Vector3.forward;
	}

	public static Vector3 GetUpVector(Quaternion q)
	{
		return q * Vector3.up;
	}

	public static Vector3 GetRightVector(Quaternion q)
	{
		return q * Vector3.right;
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
	}

	public static Vector3 PositionFromMatrix(Matrix4x4 m)
	{
		Vector4 column = m.GetColumn(3);
		return new Vector3(column.x, column.y, column.z);
	}

	public static void LookRotationExtended(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 customForward, Vector3 customUp)
	{
		Quaternion quaternion = Quaternion.LookRotation(alignWithVector, alignWithNormal);
		Quaternion rotation = Quaternion.LookRotation(customForward, customUp);
		gameObjectInOut.transform.rotation = quaternion * Quaternion.Inverse(rotation);
	}

	public static void PreciseAlign(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 alignWithPosition, Vector3 triangleForward, Vector3 triangleNormal, Vector3 trianglePosition)
	{
		LookRotationExtended(ref gameObjectInOut, alignWithVector, alignWithNormal, triangleForward, triangleNormal);
		Vector3 vector = gameObjectInOut.transform.TransformPoint(trianglePosition);
		Vector3 translation = alignWithPosition - vector;
		gameObjectInOut.transform.Translate(translation, Space.World);
	}

	public static void VectorsToTransform(ref GameObject gameObjectInOut, Vector3 positionVector, Vector3 directionVector, Vector3 normalVector)
	{
		gameObjectInOut.transform.position = positionVector;
		gameObjectInOut.transform.rotation = Quaternion.LookRotation(directionVector, normalVector);
	}

	public static int PointOnWhichSideOfLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 rhs = linePoint2 - linePoint1;
		Vector3 lhs = point - linePoint1;
		float num = Vector3.Dot(lhs, rhs);
		if (num > 0f)
		{
			if (lhs.magnitude <= rhs.magnitude)
			{
				return 0;
			}
			return 2;
		}
		return 1;
	}

	public static float MouseDistanceToLine(Vector3 linePoint1, Vector3 linePoint2)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 linePoint3 = main.WorldToScreenPoint(linePoint1);
		Vector3 linePoint4 = main.WorldToScreenPoint(linePoint2);
		Vector3 vector = ProjectPointOnLineSegment(linePoint3, linePoint4, mousePosition);
		vector = new Vector3(vector.x, vector.y, 0f);
		return (vector - mousePosition).magnitude;
	}

	public static float MouseDistanceToCircle(Vector3 point, float radius)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = main.WorldToScreenPoint(point);
		vector = new Vector3(vector.x, vector.y, 0f);
		float magnitude = (vector - mousePosition).magnitude;
		return magnitude - radius;
	}

	public static bool IsLineInRectangle(Vector3 linePoint1, Vector3 linePoint2, Vector3 rectA, Vector3 rectB, Vector3 rectC, Vector3 rectD)
	{
		bool flag = false;
		bool flag2 = false;
		flag = IsPointInRectangle(linePoint1, rectA, rectC, rectB, rectD);
		if (!flag)
		{
			flag2 = IsPointInRectangle(linePoint2, rectA, rectC, rectB, rectD);
		}
		if (!flag && !flag2)
		{
			bool flag3 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectA, rectB);
			bool flag4 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectB, rectC);
			bool flag5 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectC, rectD);
			bool flag6 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectD, rectA);
			if (flag3 || flag4 || flag5 || flag6)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public static bool IsPointInRectangle(Vector3 point, Vector3 rectA, Vector3 rectC, Vector3 rectB, Vector3 rectD)
	{
		Vector3 vector = rectC - rectA;
		float size = 0f - vector.magnitude / 2f;
		vector = AddVectorLength(vector, size);
		Vector3 linePoint = rectA + vector;
		Vector3 vector2 = rectB - rectA;
		float num = vector2.magnitude / 2f;
		Vector3 vector3 = rectD - rectA;
		float num2 = vector3.magnitude / 2f;
		Vector3 vector4 = ProjectPointOnLine(linePoint, vector2.normalized, point);
		float magnitude = (vector4 - point).magnitude;
		vector4 = ProjectPointOnLine(linePoint, vector3.normalized, point);
		float magnitude2 = (vector4 - point).magnitude;
		if (magnitude2 <= num && magnitude <= num2)
		{
			return true;
		}
		return false;
	}

	public static bool AreLineSegmentsCrossing(Vector3 pointA1, Vector3 pointA2, Vector3 pointB1, Vector3 pointB2)
	{
		Vector3 vector = pointA2 - pointA1;
		Vector3 vector2 = pointB2 - pointB1;
		Vector3 closestPointLine;
		Vector3 closestPointLine2;
		if (ClosestPointsOnTwoLines(out closestPointLine, out closestPointLine2, pointA1, vector.normalized, pointB1, vector2.normalized))
		{
			int num = PointOnWhichSideOfLineSegment(pointA1, pointA2, closestPointLine);
			int num2 = PointOnWhichSideOfLineSegment(pointB1, pointB2, closestPointLine2);
			if (num == 0 && num2 == 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static Vector3 ProjectPoint_On_GivenLine(Vector3 srcPnt, Vector3 lineStrtPoint, Vector3 lineEndPoint)
	{
		Vector3 vector = lineEndPoint - lineStrtPoint;
		float magnitude = vector.magnitude;
		if (magnitude == 0f)
		{
			return lineStrtPoint;
		}
		vector.Normalize();
		Vector3 rhs = srcPnt - lineStrtPoint;
		float num = Vector3.Dot(vector, rhs) / magnitude;
		vector.Normalize();
		vector = Vector3.ClampMagnitude(vector, num * magnitude);
		return lineStrtPoint + vector;
	}
}
