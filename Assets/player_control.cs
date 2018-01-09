using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {
    float x, y;

    public int speed = 100;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        x = 0f;
        y = 0f;
        if (Input.GetKey(KeyCode.W)) { y += 1f; }
        if (Input.GetKey(KeyCode.S)) { y -= 1f; }
        if (Input.GetKey(KeyCode.A)) { x -= 1f; }
        if (Input.GetKey(KeyCode.D)) { x += 1f; }
        Debug.Log(x+" "+y);
        rb.AddForce((new Vector2(x, y))*speed);

        var mouse_pos = Input.mousePosition;
        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        mouse_pos.z = 0f;
        mouse_pos = mouse_pos - gameObject.transform.position;
        float rot;
        if (mouse_pos.x > 0f) { rot = Mathf.Atan(mouse_pos.y / mouse_pos.x) * 180 / Mathf.PI -90; } else
        { rot = Mathf.Atan(mouse_pos.y / mouse_pos.x) * 180 / Mathf.PI +90 ; }
       
        gameObject.transform.rotation = Quaternion.Euler(0,0,rot);
    }
}
