﻿using System;

namespace QuickSort
{
    class Program
    {
        //array of integers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; // number of comparison
        private int mov_count = 0; // number of data movements

        // Number of elements in array
        private int n;

        void input ()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array : ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 0)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements");
            }
            Console.WriteLine("\n==================");
            Console.WriteLine("Enter array elements");
            Console.WriteLine("\n================--");

            //get array elements
            for(int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //Partition the list into two parts:
            //one containing elements less that or equal to pivot
            //Outher containing elments greater than pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i<= j)
            {
                //Search for an element greater than pivot
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j) //if the greater element is on the left the element
                {
                    //swap the element at index i with the elemen at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            //j now contains the index of the last element in the sorted list

            if (low < j)
            {
                //Move the pivot to its correct position in the lsit
                swap(j, low);
                mov_count++;
            }
            //Sort the list on the left of pivot using quick sort
            q_sort(low, j - 1);

            //Sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }


    }
}