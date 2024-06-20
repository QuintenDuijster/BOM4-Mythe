using UnityEngine;

public class OtherScript : MonoBehaviour
{
    public ChildObjectChecker childObjectChecker;

    void Start()
    {
        int count = childObjectChecker.GetChildObjectCount();
        Debug.Log("Number of game objects with child objects: " + count);
    }
}
