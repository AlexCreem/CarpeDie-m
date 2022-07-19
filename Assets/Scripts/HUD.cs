using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text hpText;
    string hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = Player.getPlayerHP();
        hpText.text = hp;
    }

    // Update is called once per frame
    void Update()
    {
        hp = Player.getPlayerHP();
        hpText.text = hp;
    }
}
