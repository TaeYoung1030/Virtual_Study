using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI playTimeTxt;
    public TextMeshProUGUI coolTimeTxt;
    public Image hpImage;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        playTimeTxt.text = $"Time : {time.ToString("F2")}";
        coolTimeTxt.text = $"skill CoolTime : {player.GetComponent<myPlayerMove>().currentCoolTime.ToString("F2")}";
        //hpText.text = "HP : " + player.GetComponent<myPlayerMove>().HP;
        hpImage.fillAmount = player.GetComponent<myPlayerMove>().HP / player.GetComponent<myPlayerMove>().maxHP;
    }
}
