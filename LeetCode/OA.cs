using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class OA
    {

        /// <summary>
        /// A storeroom is used to organize items stored in it
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public int Stubhub(int[] A, int R)
        {
            #region | Problem | 
            /*
             A storeroom is used to organize items stored in it on N shelves. 
            Shelves are numbered from 0 to N-1.The K - th shelf is dedicated to items of only one type, denoted by a positive integer A[K]. 
            Recently it was decided that it is necessary to free R consecutive shelves. 
            Shelves cannot be reordered. What is the maximum number of types of items which still can be stored in the storeroom after freeing R consecutive shelves? 
            Write a function: 
                int solution(vector<int> &A, int R); 
            that, given an array A of N integers representing types of items stored on storeroom shelves, and an integer R representing the number of consecutive shelves to be freed, returns the maximum number of different types of items that can be stored in the storeroom after freeing R consecutive shelves.
            
            Examples: 1.Given A = [2, 1, 2, 3, 2, 2] and R = 3, 
            your function should return 2.It can be achieved, 
            for example, by freeing shelves 2, 3 and 4(shelves are numbered from 0). % 3D % 3D 
            2.Given A = [2, 3, 1, 1, 2] and R = 2, 
            your function should return 3.
            All three types can still be stored by freeing the last two shelves. % 3D 
            3.Given A = [20, 10, 10, 10, 30, 20] and R = 3, 
            your function should return % 3D 3.
            It can be achieved by freeing the first three shelves. 
            4.Given A = [1, 100000, 1] and R = 3, 
            your function should return 0.All % 3D shelves need to be freed.
            
            Write an efficient algorithm for the following assumptions: 
                N is an integer within the range[1..100, 000]; 
                Ris an integer within the range[1..N]; 
                each element of array A is an integer within the range[1..100, 000].
            */
            #endregion
            int len = A.Length;
            if (R >= len)
                return 0;
            else if (R + 1 == len)
                return 1;

            //type of item, count
            int maxDiffTypes = 1;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int left = 0, right = 0;
            int windowSize = len - R;
            while(right < len)
            {
                //Count a current item which is sitting on right index
                if (dic.ContainsKey(A[right]) == false)
                    dic.Add(A[right], 0);
                dic[A[right]]++;

                //Maximum length possible answers could be.
                if (right - left + 1 == windowSize)
                {
                    //Left side needs either zero space or euqal or more than R space
                    if (left == 0 || left >= R)
                    {
                        //Check if current # of different types of items is bigger than previous value
                        maxDiffTypes = Math.Max(maxDiffTypes, dic.Count);
                    }

                    //move left index to right
                    dic[A[left]]--;
                    if (dic[A[left]] == 0)
                        dic.Remove(A[left]);
                    left++;
                }
                right++;
            }


            return maxDiffTypes;
        }
    }
}
