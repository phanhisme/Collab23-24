using UnityEngine;

[CreateAssetMenu(fileName ="DungeonGenerationData.asset", menuName ="DungeonGenerationData/Dungeon Data")]
public class DungeonGenerationData : ScriptableObject
{
    //single long road
    public int numberOfCrawlers;
    //minimum number of rooms
    public int interationMin;
    //maximum number of rooms
    public int interationMax;
}
