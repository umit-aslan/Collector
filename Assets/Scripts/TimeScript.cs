using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public GameObject timeText;
    public int GeriSayim;
    public GameObject gameOverPanel;
    
    private void Start() 
    {
        StartCoroutine(TimeCount());
    }


    IEnumerator TimeCount() {
        while (true) {
            yield return new WaitForSeconds(1);
            GeriSayim--;
            timeText.GetComponent<Text>().text ="Time: "+ GeriSayim.ToString();
            if (GeriSayim == 0) {
                timeText.GetComponent<Text>().text = "Time: 0";
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
                break;
            } 
        }
    }
}
