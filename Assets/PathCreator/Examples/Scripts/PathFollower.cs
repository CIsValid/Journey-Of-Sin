using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.

    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public Camera mainCamera;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float maxSpeed = 20;
        public float minSpeed = 3;
        float distanceTravelled;

        private GameObject player;

        private bool isInRange;
        public bool isRiding;
        public bool completedRide;
        public GameObject target;
        private GamepadChecker gamepadChecker;
        public GameObject camera;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            if (!mainCamera)
            {
                mainCamera = Camera.main;
            }
        }

        void Update()
        {
            if (transform.rotation.x > 0 && isRiding && speed < maxSpeed)
            {
                speed += transform.rotation.x / 10;
                Debug.Log("Gaining Speed");
            }
            
            if(transform.rotation.x < 0 && isRiding && speed > minSpeed)
            {
                speed += transform.rotation.x / 5;
                Debug.Log("Losing Speed");
            }
            
            if (pathCreator != null)
            {
                if (isInRange)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        isRiding = true;
                    }
                }
                
                if (isRiding && !completedRide)
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation =
                        pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    PlayerManager.instance.isInMineCart = true;
                    player.transform.localPosition = target.transform.position;
                    player.transform.rotation = target.transform.rotation;
                    mainCamera.transform.localPosition = player.transform.localPosition;
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!player)
                {
                    player = other.gameObject;
                }

                if (player)
                {
                    if (!completedRide)
                    {
                        isInRange = true;
                    }

                    if (!gamepadChecker && player)
                    {
                        gamepadChecker = player.GetComponent<GamepadChecker>();
                    }

                    if (gamepadChecker && player)
                    {
                        gamepadChecker.minecartCamera = camera;
                    }
                }
                
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = false;
            }
        }
    }
}