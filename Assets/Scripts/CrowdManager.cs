using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(0)]
public class CrowdManager : MonoBehaviour
{
    public int crowdStartCount = 10;
    public int cloneSpawnRange = 2;
    public List<GameObject> crowd;
    public GameObject clonePrefab;
    public TextMeshPro crowdCountText;

    public Transform target;
    public float radiusAroundTarget = 0.5f;

    public bool isPermanent;

    private void Start()
    {
        SpawnCrowd(crowdStartCount);
    }

    private void Update()
    {
        MakeAgentsCircleTarget();
    }

    public void SpawnCrowd(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnClone();
        }
    }

    private void SpawnClone()
    {
        GameObject clone = Instantiate(clonePrefab, transform.position + new Vector3(Random.Range(-cloneSpawnRange, cloneSpawnRange + 1), 0, Random.Range(-cloneSpawnRange, cloneSpawnRange + 1)), Quaternion.identity);
        clone.transform.parent = transform;
        clone.GetComponent<CloneManager>().OnDestroyClone += OnDestroyClone;
        crowd.Add(clone);
        DisplayCrowdCount();
    }

    public int GetCloneCount()
    {
        return crowd.Count;
    }

    void DisplayCrowdCount()
    {
        crowdCountText.text = GetCloneCount().ToString();
    }

    void OnDestroyClone(GameObject clone)
    {
        crowd.Remove(clone);
        DisplayCrowdCount();
        if (crowd.Count == 0)
        {
            if (isPermanent)
            {
                GameManager.instance.OnLevelFailed();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void MakeAgentsCircleTarget()
    {
        for (int i = 0; i < crowd.Count; i++)
        {
            crowd[i].GetComponent<AIUnit>().MoveTo(new Vector3(
                target.position.x + radiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / crowd.Count),
                target.position.y,
                target.position.z + radiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / crowd.Count)
                ));
        }
    }
}
