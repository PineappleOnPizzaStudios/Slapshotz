using UnityEngine;

[CreateAssetMenu]
public class SkinDatabase : ScriptableObject
{
    public SkinInformation[] SI;

    public int SkinCount
    {
        get
        {
            return SI.Length;
        }
    }

    public SkinInformation GetSkin (int index)
    {
        return SI[index];
    }
    
}
