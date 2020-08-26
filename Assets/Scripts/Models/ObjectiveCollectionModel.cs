using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Holds references to the level's objectives.</summary>
 */
public class ObjectiveCollectionModel : Element
{
    private List<GameObject> objectives = new List<GameObject>();
    private int totalObjectives = 0;
    private int completedObjectives = 0;

    /**
     * <summary>Adds an objective to the total amount.</summary>
     * 
     * <param name="objective">The objective object to add.</param>
     */
    public void AddObjective(GameObject objective)
    {
        objectives.Add(objective);
        totalObjectives++;
    }

    /**
     * <summary>Removes an objective once it has been completed.</summary>
     * 
     * <param name="objective">The objective object to remove.</param>
     */
    public void RemoveObjective(GameObject objective)
    {
        objectives.Remove(objective);
        completedObjectives++;
    }

    /**
     * <summary>Returns the number of completed objectives.</summary>
     * 
     * <returns>Objectives in level that have been completed as an int.</returns>
     */
    public int GetCompletedObjectives()
    {
        return completedObjectives;
    }

    /**
     * <summary>Returns the number of total objectives in level.</summary>
     * 
     * <returns>All objectives in level as an int.</returns>
     */
    public int GetTotalObjectives()
    {
        return totalObjectives;
    }
}
