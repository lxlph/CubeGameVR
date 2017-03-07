﻿namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /**
     * 
     * Script damit, der Spieler seine Figur wechseln kann, mit den dazu passenden Eigenschaften der Figuren
     * 
     * */

    public class ChangePlayerCube : MonoBehaviour {
        public GameObject actualPlayerCube;
        public GameObject cubeInteraction;
        public GameObject meshAndRigid;

        void Start() {
            actualPlayerCube = VRTK_SDKManager.instance.actualBoundaries;
            cubeInteraction = this.transform.gameObject;
            meshAndRigid = this.gameObject.transform.FindChild("MeshAndRigid").gameObject;
            changeCube("SmallCube");
        }

        // Update is called once per frame
        void Update() {
            //this.transform.position = actualPlayerCube.transform.position;
        }

        public void changeCube(string cubeName) {
            float scaleSize = 0f;
            switch (cubeName) {
                case "SmallCube":
                    scaleSize = 0.2f;
                    break;
            }
            meshAndRigid.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize); 
            BoxCollider colliderMeshAndRigid = meshAndRigid.AddComponent<BoxCollider>();
            colliderMeshAndRigid.size = new Vector3(1, 1, 1);
            colliderMeshAndRigid.center = new Vector3(0, 0, 0);
            Collider playerCollider = actualPlayerCube.GetComponent<Collider>();
            playerCollider.enabled = false;
            Rigidbody rigidActualPlayer = actualPlayerCube.GetComponent<Rigidbody>();
            Destroy(rigidActualPlayer);
            //BoxCollider colliderPlayerCube = actualPlayerCube.AddComponent<BoxCollider>();
            //colliderPlayerCube.size = new Vector3(1, 1, 1);
            //colliderPlayerCube.center = new Vector3(0, 0, 0);
            //this.transform.SetParent(actualPlayerCube.transform);
            //squareArea.transform.localPosition = new Vector3(0, -meshCube.transform.localScale.y/2, 0);
        }

        private void LateUpdate() {
            //transform.position = actualPlayerCube.transform.position + offset;
        }
    }
}