using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject Player;
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
    public Slider HPSlider;
  




    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DashCooldown = Player.GetComponent<Player>().dashLength + Player.GetComponent<Player>().dashCooldown;
        RapidfireCooldown = Player.GetComponent<Player>().rapidLength + Player.GetComponent<Player>().rapidCooldown;
        ImmuneCooldown = Player.GetComponent<Player>().immuneLength + Player.GetComponent<Player>().immuneCooldown;
        dash.fillAmount = 0;
        rapid.fillAmount = 0;
        immune.fillAmount = 0;
        hp = Player.GetComponent<Player>().getPlayerHP();
        hpText.text = hp;
        HPSlider.maxValue = Player.GetComponent<Player>().maxHealth;
        HPSlider.value = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        Rapid();
        Immune();
        hp = Player.GetComponent<Player>().getPlayerHP();
        HPSlider.value = (float)Player.GetComponent<Player>().health;
        hp = hp = Player.GetComponent<Player>().getPlayerHP();
        hp = hp = Player.GetComponent<Player>().getPlayerHP();
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
