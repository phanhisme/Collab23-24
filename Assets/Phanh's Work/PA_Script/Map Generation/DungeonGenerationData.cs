using UnityEngine;

[CreateAssetMenu(fileName ="DungeonGenerationData.asset", menuName ="DungeonGenerationData/Dungeon Data")]
public class DungeonGenerationData : ScriptableObject
{
    //choose direction -> 1 = choose 1 road to follow
    public int minNumberOfCrawlers;
    public int maxNumberOfCrawlers;


    //minimum number of rooms
    public int interationMin;
    //maximum number of rooms
    public int interationMax;
}
