using StructureMap;

namespace Resort.Container
{
	public static class ResortContainer
	{
		private static IContainer _container;

		/// <summary>
		/// getter/setter for local container
		/// </summary>
		public static IContainer Container
		{
			get
			{
				return _container;
			}

			set
			{
				if (_container == null)
					_container = value;
			}
		}


	}
}
