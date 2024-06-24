using UnityEngine;

[CreateAssetMenu(fileName = "Banana", menuName = "Banana")]
public class BananaBase : ScriptableObject
{
    public Sprite icon;
    public Color colorRarity;
    new public string name;
    public int price;
}
