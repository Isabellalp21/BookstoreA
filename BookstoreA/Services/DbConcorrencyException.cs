using System.Runtime.Serialization;

namespace BookstoreA.Services
{
	[Serializable]
	internal class DbConcorrencyException : Exception
	{
		public DbConcorrencyException()
		{
		}

		public DbConcorrencyException(string? message) : base(message)
		{
		}

		public DbConcorrencyException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected DbConcorrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}