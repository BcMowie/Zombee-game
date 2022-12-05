using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    List<int> scores = new() { 0,0,0 };
    Player player;

    public void Restart()
    {
        SceneManager.LoadScene(0);
        
    }

   

    private void OnLevelWasLoaded(int level)
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        GameObject.Find("Restart").GetComponent<Button>().onClick.AddListener(Restart);
    }

    public string GetScores()
    {
        
        for (int i = 0; i < 3; i++)
        {
            if(player.Percentage() * 10000 > scores[i])
            {
                scores.Insert(i,(int)(player.Percentage() * 10000));
                scores.RemoveAt(scores.Count - 1);
                break;
            }
        }

        return (string.Join('\n', scores));
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindGameObjectsWithTag("Persistent").Length > 1)
            Destroy(this.gameObject);

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    

}
