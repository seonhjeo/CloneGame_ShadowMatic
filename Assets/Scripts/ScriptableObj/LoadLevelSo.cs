using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Load Data", menuName = "Scriptable Object/Level Load Data")]
public class LoadLevelSo : ScriptableObject
{
    public int levelToLoad = -1;
}
