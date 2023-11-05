using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
 private Vector2 direction ;
private List<Transform> segment;
public Transform segmentPrefab;

private void Start()
{
    segment = new List<Transform>();
    segment.Add(this.transform);
    direction =Vector2.right;
}

  private void Update()
{
    if(Input.GetKeyDown(KeyCode.UpArrow))
    {
        direction=Vector2.up;
    }
    else if(Input.GetKeyDown(KeyCode.DownArrow))
    {
        direction = Vector2.down;
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        direction = Vector2.left;
    }
    else if(Input.GetKeyDown(KeyCode.RightArrow))
    {
        direction = Vector2.right;
    }
}



private void FixedUpdate()
{
for(int i= segment.Count-1;i>0;i--)
{
    segment[i].position = segment[i-1].position;
}

this.transform.position= new Vector3(
    Mathf.Round(this.transform.position.x) + direction.x,
    Mathf.Round(this.transform.position.y) + direction.y,
    0.0f
);
}
private void Grow()
{
   Transform segments = Instantiate(this.segmentPrefab);
   segments.position = segment[segment.Count-1].position;
   segment.Add(segments);
   }

public void ResetState(){
for(int i=1;i<segment.Count;i++)
{
    Destroy(segment[i].gameObject);
}
segment.Clear();
segment.Add(this.transform);
this.transform.position=Vector3.zero;

}

private void OnTriggerEnter2D(Collider2D other)
{
    if(other.tag == "Food")
    Grow();
    else if(other.tag=="Obstacle")
    {
        FindObjectOfType<GameManager>().GameOver();
        
        ResetState();
    }
}

}

