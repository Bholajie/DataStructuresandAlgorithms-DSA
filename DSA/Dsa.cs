using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
	internal class Dsa
	{

		public static int[] FindTwoNumbersWithSum2(int[] array, int targetSum)
		{
			Dictionary<int, int> numDict = new();

			for (int i = 0; i < array.Length; i++)
			{
				int currentNum = array[i];
				int potentialMatch = targetSum - currentNum;

				if (numDict.ContainsKey(potentialMatch) && numDict[potentialMatch] != i)
				{
					return new int[] { potentialMatch, currentNum };
				}

				if (!numDict.ContainsKey(currentNum))
				{
					numDict[currentNum] = i;
				}
			}
			return Array.Empty<int>();
		}


		public static bool IsValidSubsequence(List<int> array, List<int> sequence)
		{
			int arrayIndex = 0;
			int sequenceIndex = 0;

			while (arrayIndex < array.Count && sequenceIndex < sequence.Count)
			{
				if (array[arrayIndex] == sequence[sequenceIndex])
				{
					sequenceIndex++;
				}
				arrayIndex++;
			}
			return sequenceIndex == sequence.Count;
			//return true;
		}

		public static int[] SortedSquaredArray(int[] nums)
		{
			int[] result = new int[nums.Length];
			int left = 0;
			int right = nums.Length - 1;
			int currentIndex = nums.Length - 1;

			while (left <= right)
			{
				int leftSquare = nums[left] * nums[left];
				int rightSquare = nums[right] * nums[right];

				if (leftSquare > rightSquare)
				{
					result[currentIndex] = leftSquare;
					left++;
				}
				else
				{
					result[currentIndex] = rightSquare;
					right--;
				}
				currentIndex--;

			}

			return result;
		}


		public static string TournamentWinner(List<List<string>> competitions, List<int> results)
		{
			if (competitions.Count != results.Count || competitions.Count == 0)
			{
				return string.Empty;
			}
			var competitionWinner = competitions[0][0];
			var winnerDict = new Dictionary<string, int> { { competitionWinner, 0 } };

			for (int i = 0; i < competitions.Count; i++)
			{
				var roundWinner = competitions[i][1 - results[i]];

				if (!winnerDict.ContainsKey(roundWinner))
				{
					winnerDict[roundWinner] = 3;
				}
				else
				{
					winnerDict[roundWinner] += 3;
				}
				if (winnerDict[roundWinner] > winnerDict[competitionWinner])
				{
					competitionWinner = roundWinner;
				}
			}
			return competitionWinner;
		}

		public static int NonConstructibleChange(int[] coins)
		{
			Array.Sort(coins);
			int maxConstructible = 0;

			foreach (int num in coins)
			{
				if (num > maxConstructible + 1)
				{

					return maxConstructible + 1;
				}
				maxConstructible += num;

			}
			return maxConstructible + 1;

		}

		public static int[,] TransposeMatrix(int[,] matrix)
		{
			// Write your code here.
			int rows = matrix.GetLength(0);
			int columns = matrix.GetLength(1);

			var transposedMatrix = new int[columns, rows];

			for (int i = 0; i < rows; i++)
			{
				for (int o = 0; o < columns; o++)
				{
					transposedMatrix[o, i] = matrix[i, o];
				}
			}

			return transposedMatrix;
		}

		//method to display the matrix
		public static void DisplayMatrix(int[,] matrix)
		{
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					Console.Write(matrix[i, j] + " ");
				}
				Console.WriteLine();
			}
		}

		/* public static long FindClosestValueInBst(BST tree, int target)
         {

             if (tree == null) return int.MaxValue;

             long leftValue = FindClosestValueInBst(tree.left, target);
             long rightValue = FindClosestValueInBst(tree.right, target);

             long leftClosest = Math.Abs(leftValue - target);
             long rightClosest = Math.Abs(rightValue - target);
             long currentClosest = Math.Abs(tree.value - target);

             if (leftClosest < rightClosest)
             {
                 return currentClosest < leftClosest ? tree.value : leftValue;
             }
             else
             {
                 return currentClosest < rightClosest ? tree.value : rightValue;
             }

         }*/

		public static int FindClosestValueInBst(BST tree, int target)
		{
			// Write your code here.
			var smallestDifference = int.MaxValue;
			var closestValue = 0;
			var currentNode = tree;
			while (currentNode != null)
			{
				int currentDifference = Math.Abs(target - currentNode.value);

				if (currentDifference < smallestDifference)
				{
					smallestDifference = currentDifference;
					closestValue = currentNode.value;
				}

				if (target > currentNode.value)
				{
					currentNode = currentNode.right;
				}

				else
				{
					currentNode = currentNode.left;
				}
			}
			return closestValue;
		}

		public class BST
		{
			public int value;
			public BST left;
			public BST right;

			public BST(int value)
			{
				this.value = value;
			}
		}

		public class BinaryTree
		{
			public int value;
			public BinaryTree left;
			public BinaryTree right;

			public BinaryTree(int value)
			{
				this.value = value;
				this.left = null;
				this.right = null;
			}
		}

		/*public static List<int> BranchSums(BinaryTree root)
        {
            // Write your code here.
            var sums = new List<int>();
            CalculateBranchSums(root, 0, sums);
            return sums;
        }

        public static void CalculateBranchSums(BinaryTree node, int runningSum, List<int> sums)
        {
            if (node == null) return;

            var newRunningSum = runningSum + node.value;

            if (node.left == null && node.right == null)
            {
                sums.Add(newRunningSum);
            }

            CalculateBranchSums(node.left, newRunningSum, sums);
            CalculateBranchSums(node.right, newRunningSum, sums);

        }*/

		public static List<int> BranchSums(BinaryTree root)
		{
			var sums = new List<int>();
			CalculateBranchSums(root, 0, sums);
			return sums;
		}

		public static void CalculateBranchSums(BinaryTree node, int runningSum, List<int> sums)
		{
			if (node == null) return;

			var newRunningSum = runningSum + node.value;

			if (node.right == null && node.left == null)
			{
				sums.Add(newRunningSum);
			}

			CalculateBranchSums(node.left, newRunningSum, sums);
			CalculateBranchSums(node.right, newRunningSum, sums);
		}

		public static int NodeDepths(BinaryTree root)
		{
			var sumOfNodeDepths = 0;
			var stack = new Stack<(BinaryTree node, int nodeDepths)>();

			stack.Push((root, 0));

			while (stack.Count > 0)
			{
				var (node, nodeDepths) = stack.Pop();
				sumOfNodeDepths += nodeDepths;

				if (node.left != null) stack.Push((node.left, nodeDepths + 1));
				if (node.right != null) stack.Push((node.right, nodeDepths + 1));
			}
			return sumOfNodeDepths;

		}

		public static bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
		{
			// Write your code here.
			redShirtHeights.Sort();
			blueShirtHeights.Sort();
			var redIsBackRow = redShirtHeights[redShirtHeights.Count - 1] > blueShirtHeights[redShirtHeights.Count - 1];
			for (int i = 0; i < redShirtHeights.Count; i++)
			{
				if (redIsBackRow && redShirtHeights[i] <= blueShirtHeights[i]) return false;
				else if (!redIsBackRow && blueShirtHeights[i] <= redShirtHeights[i]) return false;
			}
			return true;
		}
	}

}
