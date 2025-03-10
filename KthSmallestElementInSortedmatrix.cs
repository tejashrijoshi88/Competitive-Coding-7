// time complexity - Max heap - (n^2logk) , inserting all elements in heap worst case k can br n^2, so O(n^2logn^2)
//                   min heap - nlogn + klogn, worst case k can be n^2 so, O(n^2logn)

// using max heap - insert all elements to max heap until the heap size < k, if it is greater than k, pop element fron it
// heap will always maintain k elements and in last it will give kth min element
// using min heap - insert first element of each row to min heap
// then dequeue element k times, if popped element has element in same row, add it to heap.
// in last return top of heap
public class pqNode
{
    public int val;
    public int r;
    public int c;
    public pqNode(int val, int r, int c)
    {
        this.val = val;
        this.r = r;
        this.c = c;
    }
}
public class Solution
{

    public int KthSmallest(int[][] matrix, int k)
    {

        //using min heap
        PriorityQueue<pqNode, int> pq = new PriorityQueue<pqNode, int>();
        for (int i = 0; i < matrix.Length; i++)
        {
            pq.Enqueue(new pqNode(matrix[i][0], i, 0), matrix[i][0]);
        }
        pqNode node = null;
        while (k >= 2)
        {
            //var (val,r,c) = pq.Dequeue();
            node = pq.Dequeue();
            int val = node.val;
            int r = node.r;
            int c = node.c;
            if (c + 1 < matrix.Length)
            {
                pq.Enqueue(new pqNode(matrix[r][c + 1], r, c + 1), matrix[r][c + 1]);
            }
            k--;
        }
        node = pq.Dequeue();
        return node.val;
        // using max heap - complexity O(n*n)*logk
        // PriorityQueue<int,int> pq = new PriorityQueue<int,int>();

        // for(int i=0;i<matrix.Length;i++)
        // {
        //     for(int j=0;j<matrix[0].Length;j++)
        //     {
        //         int curr = matrix[i][j];
        //         pq.Enqueue(curr,-curr);
        //         if(pq.Count>k)
        //         {
        //             pq.Dequeue();
        //         }
        //     }
        // }
        // return pq.Peek();
    }
}