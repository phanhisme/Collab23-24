using UnityEngine;

[CreateAssetMenu(fileName = "activations.asset", menuName = "Spawners/Activation")]
public class ActivationSO : ScriptableObject
{
    public int activationID;

    public string activationName;
    public string activationDescription;

    public Sprite activationIcon;
}
