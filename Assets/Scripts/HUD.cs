using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text hpText;
    string hp;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hp = player.GetComponent<Player>().getPlayerHP();
        hpText.text = hp;
    }

    // Update is called once per frame
    void Update()
    {
        hp = hp = player.GetComponent<Player>().getPlayerHP();
        hpText.text = hp;
    }
}
