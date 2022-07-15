using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour
{
    public Tilemap highlightMap;
    public GameObject brick;
    public bool canFly = true;
    public bool activeFire = false;
    // Start is called before the first frame update
    void Start()
    {
        highlightMap = GameObject.FindGameObjectWithTag("Ground").GetComponent<Tilemap>();
        brick = GameObject.FindGameObjectWithTag("Brick");
    }

    // Update is called once per frame
    void Update()
    {
        FireClick();
    }

    void FireClick(){
        if(Input.GetButtonDown("Fire1")){
            activeFire = true;
        }   
        if (Input.GetButtonUp("Fire1")){
            activeFire = false;
        }
    }

    void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            if(activeFire && canFly){
                StartCoroutine(ActiveAbility());
            }
        }
    }

    IEnumerator ActiveAbility()
    {
        canFly = false;
        Vector3Int currentCell = highlightMap.WorldToCell(transform.position);
        currentCell.y -= 1;
        TileBase currentTile = highlightMap.GetTile(currentCell);
        highlightMap.SetTile(currentCell, null);
        Vector3 currentBrickPosition = highlightMap.CellToLocal(currentCell);
        currentBrickPosition.x += 0.5f;
        currentBrickPosition.y += 0.5f;
        GameObject newBrick = Instantiate(brick, currentBrickPosition, Quaternion.identity);
        newBrick.AddComponent<Brick>();
        yield return new WaitForSeconds(15);
        Destroy(newBrick);
        highlightMap.SetTile(currentCell, currentTile);
        yield return new WaitForSeconds(15);
        canFly = true;
    }
}
