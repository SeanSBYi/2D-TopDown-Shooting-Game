using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ItemController : MonoBehaviour {
        // PUBLIC VALUABLE
        public int iItemType;
        public int itemScore = 50;

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
        }

        void OnTriggerEnter2D(Collider2D coll)
        {

            if (coll.gameObject.tag == "player")
            {
                if (iItemType == 0)
                {
                    coll.gameObject.GetComponent<ManagePlayerHealth>().RecoverPlayer();
                }
                else if (iItemType == 1)
                {
                    coll.gameObject.GetComponent<ManageTargetHealth>().SetManualScore(itemScore);
                }
                else
                {
                    coll.gameObject.GetComponent<MovePlayer>().SetPowerUp();
                }
                Destroy(gameObject);
            }
        }
    }
}
