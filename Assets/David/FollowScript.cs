using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Player.transform.position;
        transform.position = new Vector3(playerPos.x + 6, transform.position.y, -10);
    }
}
