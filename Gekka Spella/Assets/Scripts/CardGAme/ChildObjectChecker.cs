using UnityEngine;
public class ChildObjectChecker : MonoBehaviour
{
    public GameObject[] gameObjectsToCheck; // Array to hold the game objects to check
    private int childObjectCount = 0; // Counter for game objects with children

    void Start()
    {
        childObjectCount = 0; // Reset the counter

        foreach (GameObject obj in gameObjectsToCheck)
        {
            if (obj.transform.childCount > 0)
            {
                childObjectCount++;
            }
        }
    }
}