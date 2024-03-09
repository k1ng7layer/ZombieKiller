namespace Game.AI.Tasks
{
	public static class TaskNames
	{
		public const string WAIT_RANDOM_TIME = "wait random time";
		public const string WAIT_RANDOM_TIME_PATH = "SelfState/wait random time";
		
		public const string WAIT_TIME = "Wait time";
		public const string WAIT_TIME_PATH = "SelfState/Wait time";

		public const string SKIP_TICKS = "skip ticks";
		public const string SKIP_TICKS_PATH = "Utils/skip ticks";

		public const string REPEATER_ALL_UNTIL_FAILURE = "repeatAllUntilFailure";
		public const string REPEATER_ALL_UNTIL_FAILURE_PATH = "Decorators/repeatAllUntilFailure";
		
		public const string HAS_ORDER = "has order";
		public const string HAS_ORDER_PATH = "Conditions/has order";
		
		public const string HAS_TARGET = "has target";
		public const string HAS_TARGET_PATH = "Conditions/has target";

		public const string IS_TARGET_IN_ATTACK_RANGE = "is target in attack range";
		public const string IS_TARGET_IN_ATTACK_RANGE_PATH = "Conditions/is target in attack range";
		
		public const string PERFORM_ATTACK = "perform attack";
		public const string PERFORM_ATTACK_PATH = "Actions/perform attack";
		
		public const string CAN_ATTACK = "can attack";
		public const string CAN_ATTACK_PATH = "Conditions/can attack";
		
		public const string MOVE_TO_TARGET = "move to target";
		public const string MOVE_TO_TARGET_PATH = "Actions/move to target";
		
		public const string STOP_MOVEMENT = "stop movement";
		public const string STOP_MOVEMENT_PATH = "Action/stop movement";
		
		public const string LOOK_AT_TARGET = "look at target";
		public const string LOOK_AT_TARGET_PATH = "Action/look at target";
		
		public const string IS_ATTACKING = "is attacking";
		public const string IS_ATTACKING_PATH = "Condition/is attacking";
		
		public const string IS_ACTIVE = "is active";
		public const string IS_ACTIVE_PATH = "Condition/is active";
		
		public const string USE_ABILITY = "use ability";
		public const string USE_ABILITY_PATH = "Action/use ability";
		
		public const string CAN_USE_ABILITY = "can use ability";
		public const string CAN_USE_ABILITY_PATH = "Condition/can use ability";
		
		public const string CHOOSE_ABILITY = "choose ability";
		public const string CHOOSE_ABILITY_PATH = "Action/choose ability";
		
		public const string HAS_WEAPON = "has weapon";
		public const string HAS_WEAPON_PATH = "Condition/has weapon";
		
		public const string HAS_ACTIVE_ABILITY = "has active ability";
		public const string HAS_ACTIVE_ABILITY_PATH = "Condition/has active ability";
		
		public const string SWITCH_TO_AA = "switch to aa";
		public const string SWITCH_TO_AA_PATH = "Action/switch to aa";
	}
}