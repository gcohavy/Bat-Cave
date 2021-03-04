/// <summary>
/// This class is to be added to items that need to move, like the cave and all the spawned 
///  spikes and such.
/// </summary>

using UnityEngine;

public class Move : MonoBehaviour
{
    //Keep track of speed and boundary 
    private float speed = 10;
    private float zBound = -50;

    // Update is called once per frame
    void Update()
    {
        //Only move on GameState being RUNNING
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        
        //Deactivate objects that have left the boundary
        if(transform.position.z < zBound)
        {
            gameObject.SetActive(false);
        }
    }
}
