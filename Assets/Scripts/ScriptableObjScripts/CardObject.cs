using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewCardData", menuName = "ScriptableObjects/CardData")]
public class CardObject : ScriptableObject
{
    public int Id;
    public Sprite Icon;
}
