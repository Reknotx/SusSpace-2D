using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
    repairSpot = 0,
    endSpot = 1
}

//Due to late conversion into MVC the objective class can be
//considered a pseudo-controller
public class Objective : Object
{
    public ObjectiveType objectiveType;

    public delegate void ObjectiveBehavior();

    public ObjectiveBehavior behavior;

    private void Awake()
    {
        switch (objectiveType)
        {
            case ObjectiveType.repairSpot:
                behavior = RepairNode;
                break;
            case ObjectiveType.endSpot:
                behavior = EndLevel;
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        if (objectiveType == ObjectiveType.repairSpot)
        {
            app.model.objectives.AddObjective(this.gameObject);
            app.controller.display.UpdateObjectiveCounter();
        }
    }

    public void ActivateObjectiveBehavior()
    {
        if (behavior != null) behavior();
    }

    public void RepairNode()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        gameObject.GetComponent<Collider2D>().enabled = false;

        app.model.objectives.RemoveObjective(this.gameObject);

        app.controller.display.UpdateObjectiveCounter();
    }

    public void EndLevel()
    {
        if (app.model.objectives.GetCompletedObjectives() == app.model.objectives.GetTotalObjectives())
        {
            // YOU WIN!
            app.view.display.endPanel.SetActive(true);
            StartCoroutine(GoToNextLevelDelay());
        }
    }

    IEnumerator GoToNextLevelDelay()
    {
        yield return new WaitForSeconds(3f);

        app.controller.scene.LoadNextScene();
    }
}
