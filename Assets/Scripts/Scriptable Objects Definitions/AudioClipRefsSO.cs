using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipRefsSO", menuName = "AudioClipRefsSO", order = 2)]
public class AudioClipRefsSO : ScriptableObject 
{
    public AudioClip[] footstepSounds;
    public AudioClip buttonClickSound;
    public AudioClip inventoryOpenSound;
    public AudioClip inventoryCloseSound;
    public AudioClip purchaseSound;
    public AudioClip sellSound;

}
