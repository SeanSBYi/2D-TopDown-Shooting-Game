using UnityEngine;

namespace Assets.Scripts
{
    public class MovePlayer : MonoBehaviour
    {
        // PRIVATE VALUABLE
        private bool isPowerUp;
        private int powerUpCounter;
        private int powerUpTime;

        // PUBLIC VALUABLE
        public GameObject Bullet; //set the public field of Game Object in the inspector of player
        public GameObject BulletL;
        public GameObject BulletR;

        public float BulletVelocity = 1000.0f; //set the public field of initializing bullet's velocity.  

        //public AudioClip FireSound;
        void Start()
        {
            //GetComponent<Rigidbody2D>().isKinematic = true;
            isPowerUp = false;
            powerUpTime = 500;
        }

        // Update is called once per frame
        void Update()
        {
            powerUpCounter++;
            if (powerUpCounter > powerUpTime)
            {
                powerUpCounter++;
            }

            if(isPowerUp == true)
            {
                isPowerUp = false;
            }
            
            PlayerMove();
            BulletInstance();
        }

        private void BulletInstance()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //if player pushes the space bar, the bullet object is placed in the game.
                GameObject b = Instantiate(Bullet, transform.position + transform.up * 1.5f, Quaternion.identity);
                
                //you can use GetComponent<> to set properties on a specific component and give the bullet velocity after launching after instantiating or cloning.
                b.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletVelocity);
                //GetComponent<AudioSource>().clip = FireSound;
                //GetComponent<AudioSource>().Play();

                if(isPowerUp)
                {
                    GameObject bL = Instantiate(BulletL, transform.position + transform.up * 1.5f, Quaternion.identity);
                    GameObject bR = Instantiate(BulletR, transform.position + transform.up * 1.5f, Quaternion.identity);

                    Vector3 dir = Quaternion.AngleAxis(15.0f, Vector3.forward) * Vector3.left;
                    bL.GetComponent<Rigidbody2D>().AddForce(dir * BulletVelocity);

                    dir = Quaternion.AngleAxis(15.0f, Vector3.forward) * Vector3.right;
                    bR.GetComponent<Rigidbody2D>().AddForce(dir * BulletVelocity);
                }
            }
        }
        /// <summary>
        /// viewPortPosition; this vector will be used to define the position of the object in relation to the camera view.
        /// objects' position are expressed using x and y coordinates that range between 0 and 1.
        /// for the x coordinate 0 means the left side of the screen and 1 means the right side of the screen.
        /// for the y coordinate 0 means the bottom of the screen and 1 means the top of the screen.
        /// Mathf.Clamp ensures that the value of both x and y coordinates are within 0 and 1.
        /// </summary>
        private void PlayerMove()
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //if you want to check whether a key has been released, use GetKeyDown instead
            {
                gameObject.transform.Translate(Vector3.left * 0.1f); //o.1m to the left
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(Vector3.right * 0.1f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.Translate(Vector3.up * 0.1f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.Translate(Vector3.down * 0.1f);
            }

            Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);//1
            Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.left / 2);
            Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.up / 2);
            float deltaX = viewPortPosition.x - viewPortXDelta.x;
            float deltaY = -viewPortPosition.y + viewPortYDelta.y;
            viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);//2
            viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, 0 + deltaY, 1 - deltaY);//3
            transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);//4
        }

        public void SetPowerUp()
        {
            isPowerUp = true;
        }
    }
}
//CTRL+P to stop game scene
