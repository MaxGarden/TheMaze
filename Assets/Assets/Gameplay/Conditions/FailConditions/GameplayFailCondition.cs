public abstract class GameplayFailCondition : GameplayCondition
{
    public sealed override Type ConditionType => Type.Fail;
}