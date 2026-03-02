public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Process:
        // 1. Create an array of size 'length'
        // 2. Loop through each index from 0 to length-1
        // 3. At each index i, store the value: number * (i + 1)
        // 4. Return the completed array

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Process:
        // 1. Calculate the effective rotation amount (handle case where amount >= list length)
        // 2. If amount is 0, no rotation is needed
        // 3. Extract the last 'amount' elements from the list
        // 4. Remove those elements from the end
        // 5. Insert them at the beginning (index 0)

        if (data.Count == 0)
            return;

        // Normalize amount to be within the range of the list length
        amount = amount % data.Count;
        
        if (amount == 0)
            return;

        // Get the items to move from the end to the beginning
        List<int> itemsToMove = data.GetRange(data.Count - amount, amount);
        
        // Remove these items from the end
        data.RemoveRange(data.Count - amount, amount);
        
        // Insert them at the beginning
        data.InsertRange(0, itemsToMove);
    }
}
