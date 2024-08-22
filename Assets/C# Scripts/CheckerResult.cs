using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckerResult : MonoBehaviour
{
    public static Action onWin;
    public static Action onLose;

    [Header("����������� ���������� ����������")]
    public int nesseryCount;

    [SerializeField] private int countSpawnedObj, countFinishedObj, countKilledObj;
    [HideInInspector] private int allCountKilledObj;

    private void Start() => allCountKilledObj = PlayerPrefs.GetInt("Kill");

    private void OnEnable()
    {
        // ���-�� ���������� �� ������
        Spawner.onSpawn += CheckSpawnObjects;

        // ���-�� ���������� �� ����������� �������
        FillingJar.onFinished += CheckFinishObjects;

        // ���-�� ������� ����������
        Enemy.onKilled += CheckKillObjects;
        VenusFlatrap.onDied += CheckKillObjects;
        StaminaFlyfire.onEndedLife += CheckKillObjects;
        Cordyceps.onKilled += CheckKillObjects;

        // ��������� ������
        DeadLine.onDiedPlayer += Lose;
    }

    private void OnDisable()
    {
        // ���-�� ���������� �� ������
        Spawner.onSpawn -= CheckSpawnObjects;

        // ���-�� ���������� �� ����������� �������
        FillingJar.onFinished -= CheckFinishObjects;

        // ���-�� ������� ����������
        Enemy.onKilled -= CheckKillObjects;
        VenusFlatrap.onDied -= CheckKillObjects;
        StaminaFlyfire.onEndedLife -= CheckKillObjects;
        Cordyceps.onKilled -= CheckKillObjects;

        // ��������� ������
        DeadLine.onDiedPlayer -= Lose;
    }

    private void CheckSpawnObjects(int startCountSpawnedObj) => countSpawnedObj = startCountSpawnedObj;

    private void CheckFinishObjects(int GetCountFinishedObj)
    {
        countFinishedObj = GetCountFinishedObj;
        CheckLevel();       
    }

    private void CheckKillObjects()
    {
        countKilledObj++;

        allCountKilledObj++;
        PlayerPrefs.SetInt("Kill", allCountKilledObj);

        CheckLevel();
    }

    private void CheckLevel()
    {
        if (countFinishedObj >= nesseryCount && (countFinishedObj + countKilledObj) == countSpawnedObj)
            Win();

        if (countFinishedObj < nesseryCount && (countFinishedObj + countKilledObj) == countSpawnedObj)
            Lose();
    }

    private void Lose() => onLose?.Invoke();

    private void Win() => onWin?.Invoke();
}
