using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public float xSmooth = 8f;      // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	private Transform _player;       // Reference to the player's transform.

    // Use this for initialization
    void Start ()
    {
        this._player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update ()
    {
        
	}

    void FixedUpdate()
    {
        TrackPlayer();
    }

	void OnPostRender() 
	{
		
	}


    void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
        //targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        targetX = _player.position.x;

        // If the player has moved beyond the y margin...
        // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
        targetY = Mathf.Lerp(transform.position.y, _player.position.y, ySmooth * Time.deltaTime);

        // Set the camera's position to the target position with the same z component.
        //transform.position = new Vector3(targetX, targetY, transform.position.z);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
