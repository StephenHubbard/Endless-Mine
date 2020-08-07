using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pickaxe", menuName = "Pickaxe")]
public class Pickaxe : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int goldValue;
    public int miningPower;
    public float swingSpeed;
}
