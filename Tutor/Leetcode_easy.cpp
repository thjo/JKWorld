#include <iostream>     // std::cout
#include <algorithm>    // std::sort
#include <vector>       // std::vector
#include <unordered_map>

using namespace std;

void printVector(vector<int>& nums) {
    int n = nums.size();
    for (int i = 0; i < n; i++) {
        cout << nums[i] << "  ";
    }
    cout << "\n";
}



//https://leetcode.com/problems/two-sum/
//1. Two Sum
vector<int> twoSum(vector<int>& nums, int target) {
    int n = nums.size();

    ////Brute Force
    //for (int i = 0; i < n - 1; i++) {
    //    for (int j = i + 1; j < n; j++) {
    //        if (nums[i] + nums[j] == target)
    //            return vector<int> {i, j };
    //    }
    //}

    ////Optimize 1  if return value is Not pair of indexes
    //sort(nums.begin(), nums.end());
    //int l = 0, r = n - 1;
    //while (l < r) {
    //    int sum = nums[l] + nums[r];
    //    if (sum == target)
    //        return vector<int> {l, r };
    //    else if (sum > target)
    //        r--;
    //    else
    //        l++;
    //}

    //Optimize 2. 
    //value, index
    unordered_map<int, int> mapNums;
    mapNums[nums[0]] = 0;
    for (int i = 1; i < n; i++) {
        auto search = mapNums.find(target - nums[i]);
        if (search != mapNums.end())
            return vector<int> { search->second, i };
        else
            mapNums[nums[i]] = i;
    }

    return vector<int>{ };
}




// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
// 1608. Special Array With X Elements Greater Than or Equal X
// Brute Force
int specialArray1(vector<int>& nums) {
    int n = nums.size();
    int x = 0;

    //Work through all of possible Xs.
    //0 is always NOT an answer.
    for (int num = 1; num <= n; num++) {
        x = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] >= num)
                x++;
        }
        //if there exists a number x such that there are exactly x numbers in nums that are greater than or equal to x.
        if (x == num)
            return x;
    }

    return -1;
}

//Optimize
int specialArray2(vector<int>& nums) {
    int n = nums.size();

    //0, 4, 3, 0, 4
    
    //index indicates a possible X
    vector<int> freqs(n + 1, 0);    
    //assign frequency for each number
    for (int i = 0; i < n; i++) {
        if (nums[i] > n)    //nums[i]>=n
            freqs[n]++;
        else
            freqs[nums[i]]++;
    }

    //print
    printVector(freqs);
     
    //sum freqs
    for (int x = n; x > 0; x--) {
        if (freqs[x] == x)
            return x;
        else
            freqs[x - 1] += freqs[x];
    }

    return -1;
}


//int main()
//{
//    //vector<int> nums = { 0, 4, 3, 0, 4 };
//    //cout << specialArray2(nums);
//
//
//    vector<int> nums = { 3,2,4 };   // { 2, 7, 11, 15 };
//    vector<int> ans = twoSum(nums, 6);
//    for (int i = 0; i < ans.size(); i++)
//        cout << ans[i] << " ";
//    cout << "\n";
//}



// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file


//Hash Map
// The standard library includes the ordered and the unordered map (std::map and std::unordered_map) containers. 
// In an ordered map the elements are sorted by the key, insert and access is in O(log n). 
// Usually the standard library internally uses red black trees for ordered maps. But this is just an implementation detail. 
// In an unordered map insert and access is in O(1). It is just another name for a hashtable.



//About vector
//https://www.programiz.com/cpp-programming/vectors
//// Initializer list
//vector<int> vector1 = { 1, 2, 3, 4, 5 };
//// Uniform initialization
//vector<int> vector2{ 1, 2, 3, 4, 5 };
//vector<int> vector3(5, 12); //5 is the size of the vector and 12 is the value.
//==> vector<int> vector3 = {12, 12, 12, 12, 12};

// =================== ===================
//C++ Vector Functions
//Function	Description
//size()	    returns the number of elements present in the vector
//clear()	    removes all the elements of the vector
//front()	    returns the first element of the vector
//back()	    returns the last element of the vector
//empty()	    returns 1 (true) if the vector is empty
//capacity()	check the overall size of a vector
// =================== ===================


    //vector<int> num{ 1, 2, 3, 4, 5 };

    //cout << "Initial Vector: ";
    //for (const int& i : num) {
    //    cout << i << "  ";
    //}

    ////1. Add Elements to a Vector
    //num.push_back(6);
    //num.push_back(7);


    ////2. Access Elements of a Vector
    //cout << "Element at Index 0: " << num.at(0) << endl;
    //cout << "Element at Index 2: " << num.at(2) << endl;
    //cout << "Element at Index 4: " << num.at(4);

    //vector<int> num{ 1, 2, 3 };
    //// gives garbage value
    //cout << num[4];
    //// throws an exception
    //cout << num.at(4);


    ////3. Change Vector Element
    //num.at(1) = 9;
    //num.at(4) = 7;


    ////4. Delete Elements from C++ Vectors
    //// remove the last element
    //num.pop_back();


    ////5. C++ Vector Iterators
    //// declare iterator
    //vector<int>::iterator iter;

    //// initialize the iterator with the first element
    //iter = num.begin();

    //// print the vector element
    //cout << "num[0] = " << *iter << endl;

    //// iterator points to the 3rd element
    //iter = num.begin() + 2;
    //cout << "num[2] = " << *iter;

    //// iterator points to the last element
    //iter = num.end() - 1;
    //cout << "num[4] = " << *iter;

    //// use iterator with for loop
    //for (iter = num.begin(); iter != num.end(); ++iter) {
    //    cout << *iter << "  ";
    //}


    //cout << "\nUpdated Vector: ";
    //for (const int& i : num) {
    //    cout << i << "  ";
    //}


