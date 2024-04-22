using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] int numOfColumns, numOfRows = 1;

    [SerializeField] int x_space, y_space;
    [SerializeField] int columns_left, columns_right = 1;

    [SerializeField] GameObject empty_seat_prefab = null;
    [SerializeField] GameObject occupied_seat_prefab = null;

    [SerializeField] int empty_to_occupied_ratio = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (empty_seat_prefab != null)
        {
            //int gridCells = numOfColumns * numOfRows;
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    if ((j < columns_left || j >= numOfColumns - columns_right) && i != 4)
                    {
                        int rand = Random.Range(1, empty_to_occupied_ratio + 1);

                        // If the random number is 1, instantiate an occupied seat, otherwise instantiate an empty seat
                        GameObject seatToInstantiate = (rand == 1) ? occupied_seat_prefab : empty_seat_prefab;

                        // the -14 below changes with the setup of the above variables;
                        // It is defined for this combo: 8,10, Baby(Transform), 4,5,3,3, seat_empty (prefab)
                        Instantiate(seatToInstantiate, new Vector3((x_space * j) - 14, (y_space * i)), Quaternion.identity);
                    }

                }
            }
        }
    }
}
