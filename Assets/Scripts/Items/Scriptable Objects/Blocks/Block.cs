using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Block", menuName = "Block")]
public class Block : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int goldValue;
}
