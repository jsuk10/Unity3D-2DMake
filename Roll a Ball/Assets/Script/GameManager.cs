using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


enum SceneName { 
   SampleScene
}


public class GameManager : MonoBehaviour
{
    [SerializeField] private Hole[] holes;
    [SerializeField] private GameObject[] clearShowObject;
    [SerializeField] private Text nowTime;
    [SerializeField] private Text clearTime;
    [SerializeField] private SceneName resetScene;
    private bool clear = false;
    private float time = 0f;
    private int min = 0;

    private void Start()
    {
        Screen.SetResolution(1080, 1920, true);
        for (int i = 0; i < clearShowObject.Length; i++)
        {
            clearShowObject[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (!clear)
        {
            time += Time.deltaTime;
            if(time > 60f)
            {
                min++;
                time = 0f;
            }
            nowTime.text = string.Format("{0:D2} : {1:D2}", min, (int)time);
        }
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i].Ballin == false)
            {
                return;
            }
        }
        Clear();
        return;
    }

    private void Clear() {
        clear = true;
        for (int i = 0; i < clearShowObject.Length; i++) {
            clearShowObject[i].SetActive(true);
        }

        clearTime.text = "Clear!! \n Your Clear Time\n" + time.ToString("00:00");
    }

    public void GameReset() {
        SceneManager.LoadScene(resetScene.ToString());
    }
}
