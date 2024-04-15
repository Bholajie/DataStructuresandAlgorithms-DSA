using DSA;
using System.Security.Cryptography;
using static DSA.Dsa;

//Problem 1

/*int[] array = { 3, 5, 5, -4, 8, 11, 1, -1, 6 };

int targetSum = 10;

int[] result = Dsa.FindTwoNumbersWithSum2(array, targetSum);
if (result.Length == 2)
{
    Console.WriteLine($"Two numbers found: {result[0]} and {result[1]}");
}
else
{
    Console.WriteLine("No two numbers found that sum up to the target sum.");
}

//Problem 2

List<int> array1 = [1, 2, 4, 6, 7];
List<int> array2 = [1, 6, 7];

bool result2 = Dsa.IsValidSubsequence(array1, array2);
Console.WriteLine(result2);*/

//Problem 3

/*int[] input = new int[] { -9, -7, -4, -2, 1, 2, 5, 8 };
int[] result = Dsa.SortedSquaredArray(input);

Console.WriteLine("Input: [" + string.Join(",", input) + "]");
Console.WriteLine("Output: [" + string.Join(",", result) + "]");*/

/*List<List<string>> competition = [["a", "b"], ["c", "b"], ["a", "c"]];
List<int> results = [1, 0, 1];

string totalResult = Dsa.TournamentWinner(competition, results);
Console.WriteLine(totalResult);*/

/*int[] array = [1, 1,2,3,5,22];
int result = Dsa.NonConstructibleChange(array);

Console.WriteLine(result);*/

/*int[,] matrix = { { 1,2},
                    {3,4 },
                       {5,6 } };

int[,] result = Dsa.TransposeMatrix(matrix);
//Console.WriteLine(result);
Dsa.DisplayMatrix(result);*/

// Creating a BST
/*BST tree = new BST(10);
tree.left = new BST(8);
tree.right = new BST(15);
tree.left.left = new BST(5);
tree.left.right = new BST(7);
tree.right.left = new BST(13);
//tree.right.left.left = new BST(11);
tree.right.right = new BST(22);
tree.left.left.left = new BST(1);
tree.right.left.right = new BST(14);

// Target value
int targetValue = 6;
// Calling the method to find the closest value
long closestValue = Dsa.FindClosestValueInBst(tree, targetValue);
Console.WriteLine($"Closest value to {targetValue} in the BST: {closestValue}");*/


BinaryTree root = new BinaryTree(1)
{
    left = new BinaryTree(2)
    {
        left = new BinaryTree(4),
        right = new BinaryTree(5)
    },
    right = new BinaryTree(3)
};

/*var result = Dsa.NodeDepths(root);
Console.WriteLine(result);*/

// Call the BranchSums method
List<int> branchSums = BranchSums(root);

// Print the results
Console.WriteLine("Branch Sums:");

foreach (var sum in branchSums)
{
    Console.WriteLine(sum);
}

List<int> redShirtHeight = [5, 8, 1, 3, 4];
List<int> blueShirtHeight = [6,9,2,4,5];

Console.WriteLine(ClassPhotos(redShirtHeight, blueShirtHeight));
