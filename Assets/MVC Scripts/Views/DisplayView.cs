using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayView : Element
{
    public List<Image> itemHotbar;

    [SerializeField]
    private Text timeNumber, objectiveCounter;
    private float seconds, minutes;
    public GameObject menuPanel, endPanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Bring up the menu
            app.controller.display.PauseMenu();
        }

        //if (menuPanel.activeSelf) return;

        float time = Mathf.RoundToInt(Time.time - app.model.display.StartTime);

        seconds = time % 60f;
        minutes = Mathf.Floor(time / 60f);
        //timeNumber.text = Mathf.RoundToInt(time).ToString();
        timeNumber.text = minutes.ToString() + ":" + seconds.ToString();
    }

    public void UpdateHotbar(List<Sprite> sprites)
    {
        int index = 0;

        foreach (Sprite image in sprites)
        {
            itemHotbar[index].sprite = image;
            index++;

            if (index == itemHotbar.Count)
            {
                break;
            }
        }

        for (int i = index; i < itemHotbar.Count; i++)
        {
            itemHotbar[i].sprite = null;
        }
    }

    public void UpdateObjectiveCounter()
    {
        objectiveCounter.text = app.model.objectives.GetCompletedObjectives().ToString()
                                + " / " +
                                app.model.objectives.GetTotalObjectives().ToString();
    }
}
