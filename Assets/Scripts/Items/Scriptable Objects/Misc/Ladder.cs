using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ladder", menuName = "Ladder")]
public class Ladder : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int goldValue;
}
