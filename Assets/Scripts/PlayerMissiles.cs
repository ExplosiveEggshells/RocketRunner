using UnityEngine;

public class PlayerMissiles : MonoBehaviour
{
    public Transform missileRoot;
    public GameObject missilePrefab;
    public float missileSpawnDistance = 4f;

    public float missileRootSpinSpeed = 50f;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateMissile();
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
    }

    private void Update()
    {
        missileRoot.Rotate(0f, missileRootSpinSpeed * Time.deltaTime, 0f);
    }
}
