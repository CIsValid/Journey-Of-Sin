using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHover : MonoBehaviour {
        public float magnitude;
        public float speed;
        private float offset;
        
        private Transform thisT;
        private float anchor;

        public bool randomFloatSpeed;

        void Start () 
        {
            thisT=transform;
            anchor=thisT.localPosition.y;
            offset=Random.Range(0, Mathf.PI);
            
            if (randomFloatSpeed)
            {
                speed +=Random.Range(0.1f, 0.6f);
            }
;
        }
        

        void Update () 
        {
            float hover=magnitude*(1+Mathf.Sin(Time.time*speed+offset));
            thisT.localPosition=new Vector3(thisT.localPosition.x, anchor+hover, thisT.localPosition.z);
        }
}
