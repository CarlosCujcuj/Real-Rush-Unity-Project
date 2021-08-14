using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]

public class CoordinateLabeler : MonoBehaviour{

    Color defaultColor = Color.white;
    Color blockedColor = Color.gray;
    
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled  = true;

        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates(); 
    }

    // Update is called once per frame
    void Update(){

        if(!Application.isPlaying){
            DisplayCoordinates(); 
            updateObjectName();
        }

        SetLabelColor();
        ToogleLabels();
        
    }

    void ToogleLabels(){

        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor(){
        
        if(waypoint.IsPlaceable){
            label.color = defaultColor;
        }else{
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates(){

        float gridSpacingX = UnityEditor.EditorSnapSettings.move.x;
        float gridSpacingY = UnityEditor.EditorSnapSettings.move.z;

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridSpacingX);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridSpacingY);

        label.text = coordinates.x + "," + coordinates.y;

    }

    void updateObjectName(){
        transform.parent.name = coordinates.ToString();
    }
}
