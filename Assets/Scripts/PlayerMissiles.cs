using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class PlayerMissiles : MonoBehaviour
{
    public Action<int> MissileCountChanged;

    public Transform missileRoot;
    public GameObject missilePrefab;

    public float missileSpawnDistance = 4f;
    public float missileRootSpinSpeed = 50f;

    private List<Missile> missileList;
    private int missilePoints;

    public void AddMissilePoints(int points)
    {
        missilePoints += points;
        SyncMissilesToPoints();

        MissileCountChanged?.Invoke(missilePoints);
    }

    public void RemoveMissilePoints(int points)
    {
        missilePoints -= points;
        missilePoints = Mathf.Max(0, missilePoints);
        SyncMissilesToPoints();


        MissileCountChanged?.Invoke(missilePoints);
    }

    public void FireMissilesAtKillable(Killable killable)
    {
        int cumulativeDamage = 0;

        for (int i = missileList.Count - 1; i >= 0 && cumulativeDamage < killable.hitPoints; i--)
        {
            Missile nextMissile = missileList[i];

            nextMissile.FireAtTarget(killable);
            cumulativeDamage += nextMissile.attackStrength;

            missileList.RemoveAt(i);
            missilePoints -= nextMissile.attackStrength;
            MissileCountChanged?.Invoke(missilePoints);
        }
    }

    private void Awake()
    {
        missileList = new List<Missile>();
        missilePoints = 0;
    }

    private void Update()
    {
        missileRoot.Rotate(0f, missileRootSpinSpeed * Time.deltaTime, 0f);
    }

    private void SyncMissilesToPoints()
    {
        int missilePointsToCreate = missilePoints - missileList.Count;

        if (missilePointsToCreate > 0)
        {
            for (int i = 0; i < missilePointsToCreate; i++)
            {
                CreateMissile();
            }
        }
        else if (missilePointsToCreate < 0)
        {
            int missilePointsToDestroy = Mathf.Abs(missilePointsToCreate);

            for (int i = missileList.Count - 1; i >= 0 && missilePointsToDestroy > 0; i--)
            {
                Missile nextMissile = missileList[i];
                missilePointsToDestroy -= nextMissile.attackStrength;

                missileList.RemoveAt(i);
                nextMissile.DestroyMissile();
            }
        }
    }

    private void CreateMissile()
    {
        if (missilePrefab == null)
        {
            Debug.LogErrorFormat("{0} has no missile prefab set!", gameObject.name);
        }

        Missile newMissile = Instantiate(missilePrefab, missileRoot).GetComponent<Missile>();

        float offsetX = Random.Range(-missileSpawnDistance, missileSpawnDistance);
        float offsetZ = Random.Range(-missileSpawnDistance, missileSpawnDistance);

        newMissile.transform.localPosition = new Vector3(offsetX, 0.0f, offsetZ);

        missileList.Add(newMissile);
    }

}
