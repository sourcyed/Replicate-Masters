using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CloneManager : MonoBehaviour
{
    public Action<GameObject> OnDestroyClone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            SelfDestroy();
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<CloneManager>().SelfDestroy();
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {
        if (OnDestroyClone != null)
        {
            OnDestroyClone(gameObject);
        }

        Destroy(gameObject);
    }
}
