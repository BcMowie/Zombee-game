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
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        textMeshPro.text = $"{player.Percentage().ToString("0.00")}%";

    }
}
