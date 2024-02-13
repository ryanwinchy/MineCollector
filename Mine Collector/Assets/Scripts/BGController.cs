using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] GameObject[] ships;

    [SerializeField] int minTimeBetweenShips;
    [SerializeField] int maxTimeBetweenShips;

    [SerializeField] int minTimeBetweenStorms;
    [SerializeField] int maxTimeBetweenStorms;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("gophersbgextended").GetComponent<Animator>();
        StartCoroutine(CallStorms());
        StartCoroutine(SpawnShips());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnShips()
    {
        while (true)
        {
            int index = Random.Range(0, ships.Length);        //Random ship out of the two. Don't need length -1, because random.range is exclusive of max. So (0,2) is 0 or 1.
            Instantiate(ships[index], ships[index].transform.position, ships[index].transform.rotation, gameObject.transform);    //Instatiate with this game object as parent.

            int waitTime = Random.Range(minTimeBetweenShips, maxTimeBetweenShips);

            yield return new WaitForSeconds(waitTime);        //Time to spawn another.

        }
    }

    IEnumerator CallStorms()
    {
        while (true)
        {


            int waitTime = Random.Range(minTimeBetweenStorms, maxTimeBetweenStorms);

            yield return new WaitForSeconds(waitTime);        //Time to spawn another.

            animator.SetBool("CallStorm", true);

        }
    }




}
