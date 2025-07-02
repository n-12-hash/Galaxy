using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	[Header("ˆÚ“®‘¬“x"), SerializeField]
	public float moveSpeed = 30f;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
	}
}
