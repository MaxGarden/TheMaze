public abstract class GameplayWinCondition : GameplayCondition
{
    public sealed override Type ConditionType => Type.Win;

    public abstract string Objective { get; }
}