using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public GameObject timeText;
    public int GeriSayim;
    public GameObject gameOverPanel;
    Game_Manager game_ManagerScript;
    
    private void Start() 
    {
        StartCoroutine(TimeCount());
        game_ManagerScript=FindObjectOfType<Game_Manager>();//game_ManagerScript yolu belirtildi.
    }


    IEnumerator TimeCount() {//Zaman Sayacı
        while (true) {
            yield return new WaitForSeconds(1);// 1 saniye bekle
            GeriSayim--;
            timeText.GetComponent<Text>().text ="Time: "+ GeriSayim.ToString();
            if (GeriSayim == 0) {//Zaman sıfıra eşit ise
                timeText.GetComponent<Text>().text = "Time: 0";
                game_ManagerScript.GameOver();//Oyun bitti.
                break;
            } 
        }
    }
}
