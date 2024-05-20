using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] int numOfColumns, numOfRows = 1;

    [SerializeField] int x_space, y_space;
    [SerializeField] int columns_left, columns_right = 1;

    //[SerializeField] List<Sprite> occupied_sprites = null;

    [SerializeField] GameObject mom_seat_prefab = null;
    [SerializeField] GameObject empty_seat_prefab = null;
    [SerializeField] GameObject occupied_seat_prefab = null;
    [SerializeField] GameObject aisle_handles = null;

    [SerializeField] GameObject window_prefab = null;
    [SerializeField] GameObject seatbelt_prefab = null;


    [SerializeField] int empty_to_occupied_ratio = 2;
    [SerializeField] int babyOffset = -14;

    // Start is called before the first frame update
    void Start()
    {
        if (empty_seat_prefab != null)
        {
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {

                    // Check if the current column is a window column
                    if (j == 0 || j == numOfColumns - 1)
                    {
                        //Debug.Log("WINDOWS");
                        Instantiate(window_prefab, new Vector3((x_space * j) + babyOffset, (y_space * i)), Quaternion.identity);
                        continue;
                    }
                    // Check if the current column is part of the aisle
                    if (j == columns_left || j == numOfColumns - columns_right - 1)
                    {
                        if (i == numOfRows - 1 || i % numOfRows == 2)
                        {
                            Instantiate(seatbelt_prefab, new Vector3((x_space * j) + babyOffset, (y_space * i)), Quaternion.identity);

                            Instantiate(aisle_handles, new Vector3(((x_space * j) - 1.5f) + babyOffset, (y_space * i)), Quaternion.identity);
                            Instantiate(aisle_handles, new Vector3(((x_space * j) + 1.5f) + babyOffset, (y_space * i)), Quaternion.identity);

                        }
                        continue; // Skip this iteration, leaving the aisle empty
                    }

                    // Check if the current column is part of the left, middle or right sections
                    bool isLeft = j < columns_left;
                    bool isRight = j >= numOfColumns - columns_right;
                    bool isMiddle = !isLeft && !isRight;

                    // Only instantiate seats in the left, middle and right sections
                    if (isLeft || isMiddle || isRight)
                    {
                        if (i == 0 && j == 1)
                        {
                            Instantiate(mom_seat_prefab, new Vector3((x_space * j) + babyOffset, (y_space * i)), Quaternion.identity);
                        }
                        else if (i == numOfRows - 1)
                        {
                            continue;
                        }
                        else
                        {
                            InstantiateSeat(j, i);
                        }
                    }
                }
            }
        }
    }


    private void InstantiateSeat(int column, int row)
    {
        int rand = Random.Range(1, empty_to_occupied_ratio + 1);

        // If the random number is 1, instantiate an occupied seat, otherwise instantiate an empty seat
        GameObject seatToInstantiate = (rand == 1) ? occupied_seat_prefab : empty_seat_prefab;

        // the -14 below changes with the setup of the above variables;
        // It is defined for this combo: 8,10, Baby(Transform), 4,5,3,3, seat_empty (prefab)
        Instantiate(seatToInstantiate, new Vector3((x_space * column) + babyOffset, (y_space * row)), Quaternion.identity);
    }
}
