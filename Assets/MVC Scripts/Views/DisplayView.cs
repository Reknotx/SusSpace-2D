using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayView : Element
{
    public List<Image> itemHotbar;

    [SerializeField]
    private Text timeNumber, objectiveCounter, gameOverText;
    private float seconds, minutes;
    private float remainingTime;
    public GameObject menuPanel, endPanel;


    private void Start()
    {
        if (timeNumber == null) timeNumber = GameObject.Find("Time number").GetComponent<Text>();
        if (objectiveCounter == null) objectiveCounter = GameObject.Find("Objectives number").GetComponent<Text>();
        if (gameOverText == null) gameOverText = GameObject.Find("Game Over").GetComponent<Text>();

        minutes = Mathf.Floor(app.model.display.timeLimitInSeconds / 60f);
        seconds = app.model.display.timeLimitInSeconds % 60f;
        timeNumber.text = minutes.ToString() + ":" + seconds.ToString();
        remainingTime = app.model.display.timeLimitInSeconds;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Bring up the menu
            app.controller.display.PauseMenu();
        }

        //if (menuPanel.activeSelf) return;

        float time = Mathf.RoundToInt(Time.time - app.model.display.StartTime);

        remainingTime -= Time.deltaTime;

        seconds = remainingTime % 60f;
        minutes = Mathf.Floor(remainingTime / 60f);
        //timeNumber.text = Mathf.RoundToInt(time).ToString();
        timeNumber.text = minutes.ToString() + ":" + Mathf.Floor(seconds).ToString();

        if (remainingTime <= 0f)
        {
            //Game Over
            gameOverText.gameObject.SetActive(true);
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void UpdateHotbar(List<Sprite> sprites)
    {
        int index = 0;

        foreach (Sprite image in sprites)
        {
            itemHotbar[index].sprite = image;
            itemHotbar[index].color = new Color(255, 255, 255, 1);
            index++;


            if (index == itemHotbar.Count)
            {
                break;
            }
        }

        for (int i = index; i < itemHotbar.Count; i++)
        {
            itemHotbar[i].sprite = null;
            itemHotbar[i].color = new Color(255, 255, 255, 0);
        }
    }

    public void UpdateObjectiveCounter()
    {
        objectiveCounter.text = app.model.objectives.GetCompletedObjectives().ToString()
                                + " / " +
                                app.model.objectives.GetTotalObjectives().ToString();
    }
}
