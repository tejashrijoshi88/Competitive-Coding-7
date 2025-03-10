// time complexity - O(nlogn) for sorting , logn for enqueue and dequeue and going over array of n
// so total nlogn
// space complexity - O(n)
// Approach - Sort the intervals array with starttime, create a min heap to store end times
// go through each element, get min end value and if it is low than start, dequeue it
// enqueue end time for all elements
// at end the heap count will give number of rooms required.
public class Solution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals == null || intervals.Length == 0)
        {
            return 0;
        }
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        for (int i = 0; i < intervals.Length; i++)
        {
            if (pq.Count > 0)
            {
                int minEndTime = pq.Peek();
                if (minEndTime <= intervals[i][0])
                {
                    pq.Dequeue();
                }
            }
            pq.Enqueue(intervals[i][1], intervals[i][1]);
        }
        return pq.Count;
    }
}