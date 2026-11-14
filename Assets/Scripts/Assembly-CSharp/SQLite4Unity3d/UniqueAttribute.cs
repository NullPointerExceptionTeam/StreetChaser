using System;

namespace SQLite4Unity3d
{
	[AttributeUsage(AttributeTargets.Property)]
	public class UniqueAttribute : IndexedAttribute
	{
		public override bool Unique
		{
			get
			{
				return true;
			}
			set
			{
			}
		}
	}
}
