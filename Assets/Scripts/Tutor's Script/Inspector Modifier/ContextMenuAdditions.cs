using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ContextMenuAdditions
{
    [MenuItem("CONTEXT/MoveHabit/Set target to Dummy")]
    static void dummyAsTarget(MenuCommand command)
    {
        MoveHabit moveHabit = (MoveHabit) command.context;
        moveHabit.SetTarget(moveHabit.dummyTarget);
    }
}
