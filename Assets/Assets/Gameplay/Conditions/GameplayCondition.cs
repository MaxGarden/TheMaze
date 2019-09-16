using UnityEngine;

public abstract class GameplayCondition : MonoBehaviour
{
    public enum Type
    {
        Win,
        Fail
    }

    public virtual int Priority => 0;

    public abstract Type ConditionType { get; }
    public abstract bool DetermineIfFulfilled();

    protected virtual void RegisterEvents()
    {
        //to override
    }

    protected virtual void UnregisterEvents()
    {
        //to override
    }

    protected void RecalculateFulfillment()
    {
        GameplayController.Instance.OnConditionChanged();
    }

    private void Start()
    {
        GameplayController.Instance.RegisterCondition(this);

        RegisterEvents();
    }

    private void OnDestroy()
    {
        UnregisterEvents();

        if(GameplayController.Instance)
            GameplayController.Instance.UnregisterCondition(this);
    }
}