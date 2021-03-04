/// <summary>
/// This class serves to make the cave appear endless by repeating at perfect intervals
/// </summary>

using UnityEngine;

public class CaveRepeat : MonoBehaviour
{
    //Keep track of starting position on the width, which could be gotten dynamically 
    // if I had wanted to do it :)
    private Vector3 startPos;
    private float repeatWidth = 30;

    // Start is called before the first frame update
    void Start()
    {
        //Set the starting position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //return to starting position once the perfect center is hit
        if(transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
