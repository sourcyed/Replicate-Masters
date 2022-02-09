using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    CrowdManager crowd;

    private void Start()
    {
        crowd = GetComponent<CrowdManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            crowd.SpawnCrowd(other.GetComponent<Gate>().GetNewCount(crowd.GetCloneCount()) - crowd.GetCloneCount());
        }

        if (other.CompareTag("Finish"))
        {
            GameManager.instance.OnFinishLevel();
        }
    }
}

