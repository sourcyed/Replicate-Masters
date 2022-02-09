using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool spawnLevel = true;
    public GameObject[] levels;
    int currentLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentLevel = PlayerPrefs.GetInt("Level", 0);
        LoadLevel();
    }

    void LoadLevel()
    {
        if (spawnLevel)
        {
            int prefabIndex = GetPrefabIndex(currentLevel, levels.Length);
            GameObject levelGO = Instantiate(levels[prefabIndex], Vector3.zero, Quaternion.identity);
        }
    }
    int GetPrefabIndex(int levelIndex, int levelCount)
    {
        int prefabIndex = levelIndex % levelCount;
        return prefabIndex;
    }

    public void OnLevelFailed()
    {
        Debug.Log("LEVEL FAILED");
        OnLevelRestart();
    }

    public void OnFinishLevel()
    {
        PlayerPrefs.SetInt("Level", currentLevel + 1);
        OnLevelRestart();
    }

    public void OnLevelStart()
    {
        Debug.Log("LEVEL STARTED");
    }

    void OnLevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

