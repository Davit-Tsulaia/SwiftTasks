bool sPalindrome(string text)
{
    for (int i = 0, j = text.Length; i < text.Length; i++, j--)
    {
        if (text[i] != text[j])
        {
            return false;
        } 
    }
    return true;
}

int MinSplit(int amount)
{
    int amountOfCoins = 0;
    while (amount != 0)
    {
        if (amount >= 50)
        {
            amount -= 50;
            amountOfCoins++;
        }
        if (amount >= 20)
        {
            amount -= 20;
            amountOfCoins++;
        }
        if (amount >= 10)
        {
            amount -= 10;
            amountOfCoins++;
        }
        if (amount >= 5)
        {
            amount -= 5;
            amountOfCoins++;
        }
        if (amount >= 1)
        {
            amount -= 1;
            amountOfCoins++;
        }
    }
    return amountOfCoins;
}

int NotContains(int[] array)
{
    var posNums = array.Where(x => x > 0).ToHashSet();

    int num = 1;
    if (posNums.Contains(num))
    {
        num++;
    }

    return num;
}

bool IsProperly(string sequence)
{
    int times = 0;

    for (int i = 0; i < sequence.Length; i++)
    {
        if (sequence[i] == '(')
        {
            times++;
        }
        if (sequence[i] == ')')
        {
            times++;
        }

        if (times < 0)
        {
            return false;
        }
    }

    return times == 0;
}

int CountVariants(int stairCount)
{
    return BackTrack(stairCount);
}

int BackTrack(int stairCount)
{
    if (stairCount == 0) return 1;
    if (stairCount < 0) return 0; 

    int variants = 0;
    variants += BackTrack(stairCount - 1); 
    variants += BackTrack(stairCount - 2); 

    return variants;
}



