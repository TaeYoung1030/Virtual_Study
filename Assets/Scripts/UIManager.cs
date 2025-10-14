using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI playTimeTxt;
    public TextMeshProUGUI coolTimeTxt;
    public Image hpImage;
    public Image coolTimeImage;
    public GameObject GameOver;
    public GameObject btn;

    [SerializeField] TextMeshProUGUI runningTxt;
    //[SerializeField] GameObject RunningUI;
    [SerializeField] myPlayerMove move;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        time = 0f;
        //RunningUI.GetComponet<TextMeshProGUI>().text = "hi";
        
        
    }

    // Update is called once per frame
    void Update()
    {
        coolTimeImage.color = Color.white;
        time += Time.deltaTime;
        playTimeTxt.text = $"Time : {time.ToString("F2")}";
        runningTxt.text = $"Running : {move.currentRunningGaze.ToString("F2")}";
        //coolTimeTxt.text = $"skill CoolTime : {move.currentCoolTime.ToString("F2")}";
        //hpText.text = "HP : " + player.GetComponent<myPlayerMove>().HP;
        hpImage.fillAmount = move.HP / move.maxHP;
        coolTimeImage.fillAmount = move.currentCoolTime / move.skillCoolTime;
        if(coolTimeImage.fillAmount >= 1)
        {
            coolTimeImage.color = Color.yellow;
        }
        if(move.HP <= 0 )
        {
            GameOver.SetActive(true);
            btn.SetActive(true);
        }

        
        
    }

    public void btnClicked()
    {
        SceneManager.LoadScene("Homework");
    }
}
