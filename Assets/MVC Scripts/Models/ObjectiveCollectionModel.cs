using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollectionModel : Element
{
    private List<GameObject> objectives = new List<GameObject>();
    private int totalObjectives = 0;
    private int completedObjectives = 0;

    public void AddObjective(GameObject objective)
    {
        objectives.Add(objective);
        totalObjectives++;
    }

    public void RemoveObjective(GameObject objective)
    {
        objectives.Remove(objective);
        completedObjectives++;
    }

    public int GetCompletedObjectives()
    {
        return completedObjectives;
    }

    public int GetTotalObjectives()
    {
        return totalObjectives;
    }
}
