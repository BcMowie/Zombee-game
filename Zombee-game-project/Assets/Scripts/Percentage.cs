using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Percentage : MonoBehaviour
{
    [SerializeField]
    Player player;

    TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        textMeshPro.text = $"{player.Percentage():0.00} %";

    }
}
