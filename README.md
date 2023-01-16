# Tower-of-Hanoi-Algorithm

The iterative implementation of Tower of Hanoi. 
I choosed to implement the algorithm in a iterative way to can have a better time complexity than the recursive way.
 
Time complexity:
- Recursive: O(2^n)
- Iterative: O(n)

The puzzle has the following two rules:
- You can’t place a larger disk onto a smaller disk 
- Only one disk can be moved at a time

So I implemented a command line version in C# to exemplify the moves made to solve this puzzle.
In the line you will see the movement of each individual disk.
	
### The Algorithm Logic and implementation

The objective of this puzzle is to move all the disks from one pole (source pole) to another pole (destiantion pole) with the help of the third pole (auxiliary pole).

A few steps I took to be able to determine the motion between the poles (n = move):
1. For one disk:  
&nbsp; &nbsp; 1&nbsp; &nbsp; |&nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; => &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; 1  
&nbsp; &nbsp; n % 3 = 1 => then move from `source` to `destination` or inverse depending on emptiness and larger/smaller
2. For two disks:  
&nbsp; &nbsp; |&nbsp; &nbsp;&nbsp; |&nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; => &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; |  
&nbsp; &nbsp; 2&nbsp; &nbsp; |&nbsp; &nbsp; 1 &nbsp; &nbsp; &nbsp; => &nbsp; &nbsp; |&nbsp; &nbsp; 2&nbsp; &nbsp; 1  
&nbsp; &nbsp; n % 3 = 2 => then move from `source` to `auxiliar` or inverse depending on emptiness and larger/smaller  
&nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; => &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; 1&nbsp; &nbsp; |  
&nbsp; &nbsp; |&nbsp; &nbsp; 2&nbsp; 1 &nbsp; &nbsp; &nbsp; => &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; 2&nbsp; &nbsp; |  
&nbsp; &nbsp; n % 3 = 0 => then move from `destination` to `auxiliar` or inverse depending on emptiness and larger/smaller  
&nbsp; &nbsp; **AND** for even nums I swap the `auxiliar` with `destination`  
3. For three disk:  
&nbsp; &nbsp; And in final for 3 disks, if I repet the steps, than will result:  
&nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; 1  
&nbsp; &nbsp; |&nbsp; &nbsp; 1&nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; => &nbsp; &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; 2  
&nbsp; &nbsp; 3&nbsp; &nbsp; 2&nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |&nbsp; &nbsp; |&nbsp; &nbsp; 3  
&nbsp; &nbsp; n % 3 = 1 => then move from `source` to `destination` or inverse depending on emptiness and larger/smaller  
&nbsp; &nbsp; n % 3 = 2 => then move from `source` to `auxiliar` or inverse depending on emptiness and larger/smaller  
&nbsp; &nbsp; n % 3 = 0 => then move from `destination` to `auxiliar` or inverse depending on emptiness and larger/smaller  
<br />
To know how many moves I can use for each number of disks, I used the formula 2^N - 1, where N = number of disks.  
<br />
<br />
And the final Output for a number of four disks is:  
<br />
![Sample image]
(https://github.com/SpaceWK/Tower-of-Hanoi-Algorithm/blob/main/Sample.png)
<br />
Where:
<br />
- S = Source pole  
<br />
- D = Destination pole  
<br />
- A = Auxiliar pole  


