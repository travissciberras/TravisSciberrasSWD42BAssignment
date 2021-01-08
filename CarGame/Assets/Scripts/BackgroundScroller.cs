using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //Scrolling Speed
    [SerializeField] float backgroundScrollSpeed = 2f;
    [SerializeField] Player player;
    //Material from texture
    Material myMaterial;
    //Movement
    Vector2 offSet;


    // Start is called before the first frame update
    void Start()
    {
        //get the material of the background from the Renderer component
        myMaterial = GetComponent<Renderer>().material;
        //will scroll in the x-axis at the speed
        offSet = new Vector2(0f, (player.returnCarMoveSpeed()/8));
    }

    // Update is called once per frame
    void Update()
    {
        //move the material mainTextureOffset by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
