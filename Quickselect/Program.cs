namespace Quickselect
{
    public class Program
    {
        private List<int> list = [];
        public static void Main()
        {
            new Program().Run();
        }

        private void Run()
        {
            const int NTH_LOWEST_VALUE = 2;
            list = [0, 50, 20, 10, 60, 29, 5, 1, 30];
            int nthLowestValue = Quickselect(NTH_LOWEST_VALUE, 0, list.Count - 1);
            Console.WriteLine($"The {NTH_LOWEST_VALUE + 1} lowest value is {nthLowestValue}");
        }

        private int Partition(int leftPointer, int rightPointer)
        {
            int pivotIndex = rightPointer;
            int pivot = list[pivotIndex];

            rightPointer--;

            while (true)
            {
                while (list[leftPointer].CompareTo(pivot) < 0)
                {
                    leftPointer++;
                }

                // Right pointer may go past the bounds of the array, so the additional check is necessary.
                // This is not possible with the left pointer, as it will get to the pivot and the condition will not be true

                while (rightPointer >= 0
                    && list[rightPointer].CompareTo(pivot) > 0)
                {
                    rightPointer--;
                }

                if (leftPointer >= rightPointer) break;

                // Swap left and right pointer
                int temp = list[leftPointer];
                list[leftPointer] = list[rightPointer];
                list[rightPointer] = temp;

                // Prevent the left pointer from comparing it to itself
                leftPointer++;
            }

            list[pivotIndex] = list[leftPointer];
            list[leftPointer] = pivot;

            return leftPointer;
        }

        private int Quickselect(int nthLowestValue, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex) return list[leftIndex];

            int pivotIndex = Partition(leftIndex, rightIndex);

            if(nthLowestValue < pivotIndex)
            {
                return Quickselect(nthLowestValue, leftIndex, pivotIndex - 1);
            }
            else if(nthLowestValue > pivotIndex)
            {
                return Quickselect(nthLowestValue, pivotIndex + 1, rightIndex);
            }
            else 
            { 
                return list[pivotIndex];
            }
        }
    }
}
