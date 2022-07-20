using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject player;
    public Image dash;
    public float DashCooldown;
    public KeyCode dashKey;
    bool dashIsCooldown = false;
    public Image rapid;
    public float RapidfireCooldown;
    public KeyCode rapidKey;
    bool rapidIsCooldown = false;
    public Image immune;
    public float ImmuneCooldown;
    public KeyCode immuneKey;
    bool immuneIsCooldown = false;
    public Text hpText;
    string hp;
<<<<<<< HEAD
    
=======
    public GameObject player;
>>>>>>> 776169209d223ff2a5e53c32aeec91c847c5b830

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
<<<<<<< HEAD
        DashCooldown = player.GetComponent<Player>().dashLength + player.GetComponent<Player>().dashCooldown;
        RapidfireCooldown = player.GetComponent<Player>().rapidLength + player.GetComponent<Player>().rapidCooldown;
        ImmuneCooldown = player.GetComponent<Player>().immuneLength + player.GetComponent<Player>().immuneCooldown;
        dash.fillAmount = 0;
        rapid.fillAmount = 0;
        immune.fillAmount = 0;
=======
        hp = player.GetComponent<Player>().getPlayerHP();
        hpText.text = hp;
>>>>>>> 776169209d223ff2a5e53c32aeec91c847c5b830
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Dash();
        Rapid();
        Immune();
        hp = player.GetComponent<Player>().getPlayerHP();
=======
        hp = hp = player.GetComponent<Player>().getPlayerHP();
>>>>>>> 776169209d223ff2a5e53c32aeec91c847c5b830
        hpText.text = hp;
    }

    void Dash(){
        if(Input.GetKey(dashKey) && dashIsCooldown == false){
                dashIsCooldown = true;
                dash.fillAmount = 1;
        }
        if(dashIsCooldown){
            dash.fillAmount -= 1 / DashCooldown * Time.deltaTime;

            if(dash.fillAmount <= 0){
                dash.fillAmount = 0;
                dashIsCooldown = false;
            }
        }
    }

    void Rapid(){
        if(Input.GetKey(rapidKey) && rapidIsCooldown == false){
                rapidIsCooldown = true;
                rapid.fillAmount = 1;
        }
        if(rapidIsCooldown){
            rapid.fillAmount -= 1 / RapidfireCooldown * Time.deltaTime;

            if(rapid.fillAmount <= 0){
                rapid.fillAmount = 0;
                rapidIsCooldown = false;
            }
        }
    }

    void Immune(){
        if(Input.GetKey(immuneKey) && immuneIsCooldown == false){
                immuneIsCooldown = true;
                immune.fillAmount = 1;
        }
        if(immuneIsCooldown){
            immune.fillAmount -= 1 / ImmuneCooldown * Time.deltaTime;

            if(immune.fillAmount <= 0){
                immune.fillAmount = 0;
                immuneIsCooldown = false;
            }
        }
    }
}
