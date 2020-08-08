using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Torch", menuName = "Torch")]
public class Torch : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int goldValue;
    public float glowIntensity;
}
