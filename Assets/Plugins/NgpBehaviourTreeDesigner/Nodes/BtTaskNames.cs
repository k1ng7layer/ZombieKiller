namespace Plugins.NgpBehaviourTreeDesigner.Nodes
{
	public static class BtTaskNames
	{
		public const string SEQUENCE = "sequence";
		public const string PARALLEL = "parallel";
		public const string ASYNC_PARALLEL = "async parallel";
		public const string SELECTOR = "selector";
		public const string SELECTOR_RANDOM = "selector random";
		
		public const string REPEATER = "repeater";
		public const string SELECTOR_REPEATER = "selector repeater";
		
		public const string INVERTER = "inverter";
		public const string REPEAT_FOREVER = "repeat forever";
		public const string REPEAT_UNTIL_FAILURE = "repeatUntilFailure";
		public const string REPEAT_UNTIL_SUCCESS = "repeatUntilSuccess";
		public const string RETURN_FAILURE = "return failure";
		public const string RETURN_SUCCESS = "return success";
	}
}