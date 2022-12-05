using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class ShowScores : MonoBehaviour
{
    GameOver scores;
    TextMeshProUGUI text;
    Player player;
    void Start()
    {
        scores = GameObject.Find("Scores").GetComponent<GameOver>();
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Player>();
        player.OnDeath += DisplayScore;
    }

    void DisplayScore()
    {
        transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
        transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        text.text += scores.GetScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
