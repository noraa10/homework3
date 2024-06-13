/*
 
 Big (o) Notation
1
This code computes the product of two variables, what is the runtime of this code?


int product(int a, int b) {
    int sum = 0;
    for (int I = 0; I < b; I++) {
        sum += a;
    }
    return sum; 
}


*- The product function takes two parameters, a and b. These values don't matter for Big O analysis. 

- It initializes a variable sum to 0. Assigning a value always takes the same amount of time no matter what, so this is O(1).

- Now we have the for loop. It will run from 0 to b-1. 

- b is the second parameter passed into the function. So the number of times the loop runs depends on this value.

- If b is 10, the loop runs 10 times. If b is 1000, 1000 times. So the work the loop does is directly proportional to b. 

- Inside the loop, it just adds a to sum. Adding two numbers is always O(1) time no matter what numbers they are. 

- So the work done inside the loop doesn't depend on inputs and is constant. 

- Therefore, the runtime is directly proportional to how many times the loop runs, which is b. So the overall runtime is O(b).

- And we can write it as O(n) since big O ignores constants and n represents the parameter b.


2
This code computes A ^ B, what would be the runtime?


static int power(int a, int b) {
    if (b < 0) return a;
    if (b == 0) return 1;
    int sum = a;
    for (int I = 0; I < b - 1; I++) {
        sum *= a;
    }
    return sum;
}


*- First, the parameters a and b are integers passed into the function 

- They don't affect Big O notation because inputs are ignored, only how runtime grows matters

- We check if b is less than 0. Comparing two integers is O(1) operation, it doesn't matter what the actual values are.

- Same with checking if b equals 0, still O(1) time.

-Initializing sum variable to a is also O(1), so constant time regardless of inputs.

- Now the important part, the for loop! 

- It iterates from 0 to b-1. So b-1 is the number of times the loop body will execute. 

- As b gets larger, b-1 gets larger which means the loop runs more times.

- Inside the loop, it multiplies sum by a. Multiplication is a single operation, so O(1) time.

- After the loop completes, returning sum is yet another O(1) operation.

- Therefore, the part that scales based on b is the for loop iterations, which is directly proportional to b.

- So even though small inputs like a=2, b=3 may be fast, as b increases the runtime grows linearly with b.

- This means the overall algorithm has O(b) runtime or O(n) if we let b=n as the input size.



3
This code computes A% B, what would be the runtime?


int mod(int a, int b) {
    if (b <=a) return -1;
    int div = a / b;
    return a - div * b;
}


- Like always, we start by ignoring the input parameters a and b for Big O
- Their actual values don't matter, only how runtime changes based on input size

- The first step is comparing b <= a using the <= operator
- Comparing two integer values is a single machine operation 
- It doesn't matter how large a and b get, comparison time stays the same
- So this comparison step is O(1)

- Next is the if statement that returns -1
- Returning a constant value like -1 is also O(1) time

- Now we calculate the integer division a / b
- Dividing two numbers, no matter their size, uses a fixed divide operation
- It doesn't get slower if a and b increase in size 
- So integer division is also O(1) 

- Similarly, multiplying div and b is O(1) 

- Subtracting two numbers is also O(1)

- There are no loops or operations that scale based on input size

- Every step like comparison, division, multiplication, subtraction is O(1)

- Therefore, the overall runtime is O(1) for all inputs to this function


4
This code computes a division between whole integers (assuming both are positive), what would be the runtime?


int div(int a, int b) {
    int count = a;
    int sum = b;
    while (sum <= a) {
        sum += b;
        count++;
    }
    return count;
}

*- It takes two integer parameters, a and b
- We initialize count to a, which is O(1) 
- Initialize sum to b, also O(1)

- Now the important part, the while loop:

- The loop condition is sum <= a 
 - It will run while sum is less than or equal to a
- Inside the loop, we add b to sum 
 - Adding is O(1)
- And increment count by 1
 - Incrementing is O(1)  

- So each iteration does O(1) work
- But how many times will it iterate?

- It will run until sum exceeds a
- Since we add b to sum each time
- It will take a/b iterations 
- Because we are essentially dividing a by b

- Therefore, the runtime is proportional to a/b
- Which is O(n) where n is a, the parameter  a

- Since the work inside each iteration is constant



5
The following code calculates the square root of an integer. If the number is not a perfect square (there is no whole square root), then return -1. If N is 100, first guess if N is 50. Too high? Try something lower, halfway between 1 and 50, etc. What is the big-o?


int sqrt(int n) {
    return sqrt_helper(n, 1, n);
}
int sqrt_helper(int n, int min, int max) {
    if (max < min) return -1;
    int guess = (min + max) / 2;
    if (guess * guess == n) {
        return guess;
    } else if (guess *guess <n) {
        return sqrt_helper(n, guess + 1, max) ; 
    } else { 
        return sqrt_helper(n, min, guess - 1);
    }
}




- sqrt takes the number n as a parameter 
- It calls sqrt_helper, passing n and the min/max ranges

- sqrt_helper does a binary search:
  - It first checks if min/max have crossed, in which case it returns -1
  - It calculates the guess halfway between min and max
  - Checks if guess squared equals n
  - If not, it recursively calls itself, cutting the range in half

- Each recursive call halves the search range 
- Finding the square root requires narrowing the range down to just 1 number
- Binary search does this in O(log n) time

- No matter how big the input n is, it only needs log n steps max to find the answer
- Each step does constant work comparing/guessing 

- Therefore, the overall runtime is O(log n)



6
The following code calculates the square root of an integer. If the number is not a perfect square (there is no whole square root), then return -1. It does so by trying larger and larger numbers until it finds the correct value (or is too high). What is your runtime?


int sqrt(int n) {
    for (int guess = 1; guess * guess < n; guess++) {
        if (guess * guess == n) return guess;
    }
    return -1;
}


*- It uses a for loop to try guessing larger and larger numbers as potential square roots

- The loop condition is "guess * guess < n" 

- It will iterate from 1 up to the largest number that is less than the square root of n 

- So if n is 100, it would loop from 1 to 9 

- Each iteration, it performs a multiplication and comparison, which is constant time

- But the number of iterations depends on the size of n

- Specifically, it will loop around √n times on average 

- Since the input size is proportional to n

- And the runtime is directly proportional to √n 

- We can say the runtime is O(√n)

- Which means it grows slower than linearly as n increases, but faster than logarithmically



7
If a binary search tree (BST) is not balanced, how long could it take in the worst case to find an item?


*In a BST, each node only has at most two children - the values must be lower to the left and higher to the right. 

If the tree is unbalanced, it could become like a linked list shape where we add all values in order. 

To find a value in this worst case linked list tree, we may need to search all the way down through each node. 

Since there could be n nodes in an unbalanced tree, the worst case search time is O(n).

This is because we may have to look at each node once before finding the value or reaching the end. 

A balanced tree keeps the height close to log n so search takes O(log n) time on average. 

But an unbalanced tree like a linked list can be very slow at O(n).


8
What would be the worst case if we are looking for a value in a binary tree (Binary Tree - BT) that is not ordered?


*- Unlike a BST, there is no ordering rule for the values in the tree 

- A value could be located anywhere from the root node on down 

- In the worst case, we may have to search all the way down every single branch/path in the tree

- If the tree has height h (longest path from root to leaf), we could potentially need to search most or all of the h nodes

- For a full binary tree of n nodes, the max height h is around log(n) 

- Therefore, in the worst case where we have to search all paths, the runtime is O(n)

- Because we may end up visiting each of the n nodes once before finding the value


9
The appendToNew method adds a value to an array by creating a new, longer array and returning this longer array. How long does it take to copy the array?


int[] copyArray(int[] array) {
    int[] copy = new int[0];
    for (int value : array) {
        copy = appendToNew(copy, value);
    }
    return copy;
}
int[] appendToNew(int[] array, int value) {
    int[] bigger = new int[array.length + 1];
    for (int I = 0; I < array. length; I++) {
        bigger[I] = array[I];
    }
    bigger[bigger.length - 1] = value; 
    return bigger;
}


*- The copyArray method iterates through each item in the input array 
- For each item, it calls appendToNew to add it to the copy

- appendToNew creates a new array that is 1 item longer
- It uses a for loop to copy over each item from the original array 

- How long does it take to copy each item? O(1) constant time
- How many items are copied? The length of the input array 
- If the array has n items, it will copy n items

- Therefore, the for loop that does the copying is O(n)

- copyArray calls this O(n) operation once per item in the input array  
- With n items, it does n * O(n) = O(n^2) operations overall

In summary, because it copies the array inside a loop, the overall runtime is O(n^2).

10
The following code adds the digits of a number. What is your runtime?


int sumDigits(int n) { 
    int sum = 0; 
    while (n > e) { 
        sum += n % 10; 
        n /= 10; 
    } 
    return sum; 
}


*- It uses a while loop to repeatedly take the last digit of n and add it to the sum

- Each time through the loop, it divides n by 10 to remove the last digit 

- This process will repeat until n is 0 

- How many times will the loop run? At most the number of digits in n

- If n has d digits, the loop will run d times

- Each iteration just does some math (modulo, divide), so is constant time O(1)  

- Since the number of loop iterations depends on d, and d is proportional to log(n)...

- This means the overall runtime is O(log(n))









 
 */