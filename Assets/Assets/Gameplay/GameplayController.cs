using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GameplayController : MonoBehaviour
{
    static public GameplayController Instance { get; private set; }

    private readonly IList<GameplayCondition> m_conditions = new List<GameplayCondition>();

    [SerializeField]
    private Canvas m_hudCanvas = null;

    [SerializeField]
    private Canvas m_victoryCanvas = null;

    [SerializeField]
    private AudioClip m_victorySound = null;

    [SerializeField]
    private Canvas m_gameOverCanvas = null;

    [SerializeField]
    private AudioClip m_gameOverSound = null;

    public GameplayCondition CurrentWinCondition => m_conditions
        .FirstOrDefault(condition => condition.ConditionType == GameplayCondition.Type.Win);

    private void Awake()
    {
        if (Instance)
            throw new InvalidOperationException("More than one gameplay controller");

        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void RegisterCondition(GameplayCondition condition)
    {
        if (m_conditions.Contains(condition))
            throw new InvalidOperationException("Tried to register the same condition more than one");

        m_conditions.Add(condition);
    }

    public void UnregisterCondition(GameplayCondition condition)
    {
        if (!m_conditions.Remove(condition))
            throw new InvalidOperationException("Tried to unregister not registered condition");
    }

    public void OnConditionChanged()
    {
        if (CheckIfFailed())
            OnFail();
        else if (CheckIfWin())
            OnWin();
    }

    private bool CheckIfFailed()
    {
        return m_conditions
            .Where(condition => condition.ConditionType == GameplayCondition.Type.Fail)
            .Any(condition => condition.DetermineIfFulfilled());
    }

    private bool CheckIfWin()
    {
        return m_conditions.
            Where(condition => condition.ConditionType == GameplayCondition.Type.Win)
            .All(condition => condition.DetermineIfFulfilled());
    }

    private void OnWin()
    {
        OnFinish();

        ShowVictory();
        PlayVictorySound();
    }

    private void OnFail()
    {
        OnFinish();

        ShowGameOver();
        PlayGameOverSound();
    }

    private void OnFinish()
    {
        HideHUD();
        DisableInput();
        DisableFirstPersonController();
        StartCoroutine(DestroyDynamicObjectsCoroutine());
    }

    private void DisableInput()
    {
        PlayerContext.MainPlayer.InputController.IsInputEnabled = false;
    }

    private IEnumerator DestroyDynamicObjectsCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        var dynamicObjects = FindObjectsOfType<DynamicObject>();

        foreach (var dynamicObject in dynamicObjects)
            Destroy(dynamicObject.gameObject);
    }

    private void DisableFirstPersonController()
    {
        PlayerContext.MainPlayer.FirstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void PlayVictorySound()
    {
        if (m_victorySound)
            AudioSource.PlayClipAtPoint(m_victorySound, Camera.main.transform.position);
    }

    private void ShowVictory()
    {
        if (m_victoryCanvas)
            m_victoryCanvas.gameObject.SetActive(true);
    }

    private void PlayGameOverSound()
    {
        if (m_gameOverSound)
            AudioSource.PlayClipAtPoint(m_gameOverSound, Camera.main.transform.position);
    }

    private void ShowGameOver()
    {
        if (m_gameOverCanvas)
            m_gameOverCanvas.gameObject.SetActive(true);
    }

    private void HideHUD()
    {
        if (m_hudCanvas)
            m_hudCanvas.gameObject.SetActive(false);
    }
}