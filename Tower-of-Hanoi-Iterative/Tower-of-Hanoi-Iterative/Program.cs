using System;

class TowerOfHanoi {

    // I created a stack structure to can attach the disks to each pole
    public class Stack {
        public int capacity;
        public int top;
        public int[] array;
    }

    // The function to initialize the stack with a given capacity.
    Stack createStack(int capacity) {
        Stack stack = new Stack();
        stack.capacity = capacity;
        stack.top = -1;
        stack.array = new int[capacity];
        return stack;
    }

    // A boolean function to check if the stack is full when top is equal to the last index
    Boolean stackIsFull(Stack stack) {
        return (stack.top == stack.capacity - 1);
    }

    // A boolean function to check if the Stack is empty when top is equal to -1
    Boolean stackIsEmpty(Stack stack) {
        return (stack.top == -1);
    }

    // The function to add an item on the stack
    void stackPush(Stack stack, int item) {
        if (stackIsFull(stack))
            return;
        stack.array[++stack.top] = item;
    }

    // The function to remove an item on the stack
    int stackPop(Stack stack) {
        if (stackIsEmpty(stack))
            return int.MinValue;
        return stack.array[stack.top--];
    }

    // The function to show the disks movement between the poles
    void moveDisk(char fromPole, char toPole, int disk) {
        Console.WriteLine("Move the disk " + disk + " from " + fromPole + " to " + toPole);
    }

    // The function to implement the moves between two poles depending of emptiness and heigth
    void moveDisksBetweenTwoPoles(Stack source, Stack destination, char pole1, char pole2) {

        int pole1TopDisk = stackPop(source);
        int pole2TopDisk = stackPop(destination);

        // When pole 1 is empty
        if (pole1TopDisk == int.MinValue) {
            stackPush(source, pole2TopDisk);
            moveDisk(pole2, pole1, pole2TopDisk);
        }

        // When pole2 pole is empty
        else if (pole2TopDisk == int.MinValue) {
            stackPush(destination, pole1TopDisk);
            moveDisk(pole1, pole2, pole1TopDisk);
        }

        // When top disk of pole1 > top disk of pole2
        else if (pole1TopDisk > pole2TopDisk) {
            stackPush(source, pole1TopDisk);
            stackPush(source, pole2TopDisk);
            moveDisk(pole2, pole1, pole2TopDisk);
        }

        // When top disk of pole1 < top disk of pole2
        else {
            stackPush(destination, pole2TopDisk);
            stackPush(destination, pole1TopDisk);
            moveDisk(pole1, pole2, pole1TopDisk);
        }
    }

    // Function to implement TOH puzzle
    void towerAlgorithm(int numberOfDisks, Stack src, Stack aux, Stack dest) {

        int numberOfMoves;
        char s = 'S', d = 'D', a = 'A';

        // If the number of disks is even, then swap auxiliar with destination
        if (numberOfDisks % 2 == 0) {
            char temp = d;
            d = a;
            a = temp;
        }

        // Calculate the number of moves for each number of disks
        numberOfMoves = (int)(Math.Pow(2, numberOfDisks) - 1);

        // Larger disks will be pushed first
        for (int i = numberOfDisks; i >= 1; i--) {
            stackPush(src, i);
        }

        for (int i = 1; i <= numberOfMoves; i++) {
            if (i % 3 == 1) {
                moveDisksBetweenTwoPoles(src, dest, s, d);
            }
            else if (i % 3 == 2) {
                moveDisksBetweenTwoPoles(src, aux, s, a);
            }
            else if (i % 3 == 0) {
                moveDisksBetweenTwoPoles(aux, dest, a, d);
            }
        }
    }


    public static void Main(String[] args) {

        TowerOfHanoi ob = new TowerOfHanoi();
        Stack source, destination, auxiliar;

        // Input: number of disks
        int numberOfDisks = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert number of disks = " + numberOfDisks + "\n");


        // Create the poles
        source = ob.createStack(numberOfDisks);
        destination = ob.createStack(numberOfDisks);
        auxiliar = ob.createStack(numberOfDisks);


        ob.towerAlgorithm(numberOfDisks, source, auxiliar, destination);
    }
}
