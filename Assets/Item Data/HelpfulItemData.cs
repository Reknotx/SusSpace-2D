using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Create Item Data", order = 51)]
public class HelpfulItemData : ScriptableObject
{
    [SerializeField]
    private int _numberOfUses;

    [SerializeField]
    private int _moveDistance;

    public int NumberOfUses { get { return _numberOfUses; } }

    public int MoveDistance { get { return _moveDistance; } }
}
