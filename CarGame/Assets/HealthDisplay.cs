using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text displayText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        displayText.text = player.getHealth().ToString();
    }
}
