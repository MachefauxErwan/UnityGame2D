using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string Name;
    public string description;
    public int price;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public int speedDuration;
}
