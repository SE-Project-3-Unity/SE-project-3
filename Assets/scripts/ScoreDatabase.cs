using UnityEngine;

[CreateAssetMenu(fileName="New ScoreDB", menuName = "ScoreDatabase")]
public class ScoreDatabase : ScriptableObject
{
    public int[] scores = new int[10];
    public int cur;
    public int prev;
}