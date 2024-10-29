using System;
using System.Collections;

class MyMatrix
{
    int[,] myMatrix;
    private Random rnd = new Random();
    int n;
    int m;

    public MyMatrix(int m, int n, int min, int max)
    {
        myMatrix = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                myMatrix[i, j] = rnd.Next(min, max);
            }
        }
        this.n = n;
        this.m = m;
    }

    public int this[int m, int n]
    {
        get { return myMatrix[m, n]; }
        set { myMatrix[m, n] = value; }

    }

    public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
    {
        if (m1.n == m2.n && m1.m == m2.m)
        {
            MyMatrix result = new MyMatrix(m1.n, m1.m, 0, 0);
            for (int i = 0; i < m1.m; i++)
            {
                for (int j = 0; j < m2.n; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }
        else
        {
            MyMatrix result = new MyMatrix(0, 0, 0, 0);
            return result;
        }
    }

    public void Fill(int min, int max)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                myMatrix[i, j] = rnd.Next(min, max);
            }
        }
    }

    public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
    {
        if (m1.n == m2.n && m1.m == m2.m)
        {
            MyMatrix result = new MyMatrix(m1.n, m1.m, 0, 0);
            for (int i = 0; i < m1.m; i++)
            {
                for (int j = 0; j < m2.n; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }
        else
        {
            MyMatrix result = new MyMatrix(0, 0, 0, 0);
            return result;
        }
    }

    public static MyMatrix operator *(MyMatrix m1, int m2)
    {
        MyMatrix result = new MyMatrix(m1.m, m1.n, 0, 0);
        for (int i = 0; i < m1.m; i++)
        {
            for (int j = 0; j < m1.n; j++)
            {
                result[i, j] = m1[i, j] * m2;
            }
        }
        return result;
    }

    public static MyMatrix operator /(MyMatrix m1, int m2)
    {
        MyMatrix result = new MyMatrix(m1.m, m1.n, 0, 0);
        for (int i = 0; i < m1.m; i++)
        {
            for (int j = 0; j < m1.n; j++)
            {
                result[i, j] = m1[i, j] / m2;
            }
        }
        return result;
    }

    public void ChangeSize(int n, int m)
    {
        int[,] newMatrix = new int[m, n];

        for (int i = 0; i < Math.Min(m, myMatrix.GetLength(0)); i++)
        {
            for (int j = 0; j < Math.Min(n, myMatrix.GetLength(1)); j++)
            {
                newMatrix[i, j] = myMatrix[i, j];
            }
        }


        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i >= myMatrix.GetLength(0) || j >= myMatrix.GetLength(1))
                {
                    newMatrix[i, j] = rnd.Next();
                }
            }
        }

        myMatrix = newMatrix;
    }

    public void ShowPartially(int firstElem, int secondElem)
    {
        for (int i = 0; i < this.m; i++)
        {
            for (int j = 0; j < this.n; j++)
            {
                if (myMatrix[i, j] >= firstElem && myMatrix[i, j] <= secondElem)
                {
                    Console.WriteLine(myMatrix[i, j]);
                }
            }
        }
    }

    public void Show()
    {
        for (int i = 0; i < this.m; i++)
        {
            for (int j = 0; j < this.n; j++)
            {
                Console.WriteLine(myMatrix[i, j]);
            }
        }
    }
}

class MyList<T> : IEnumerable<T>
{
    private T[] myArray;
    private int length;


    public T this[int index]
    {
        get { return myArray[index]; }
        set { myArray[index] = value; }

    }

    public MyList(int len, params T[] array)
    {
        this.myArray = array;
        this.length = len;
    }

    public void Resize()
    {
        T[] tempArray = new T[this.myArray.Length * 2];
        for (int i = 0; i < myArray.Length; i++)
        {
            tempArray[i] = this.myArray[i];
        }
        myArray = tempArray;
        length = tempArray.Length / 2;
    }

    public void add(T n)
    {
        if (myArray.Length == length)
        {
            Resize();
        }

        myArray[length] = n;
        length += 1;

    }

    public int len
    {
        get
        {
            return length;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < length; i++)
        {
            yield return myArray[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
class MyDictionary<Tkey, TValue> : IEnumerable<KeyValuePair<Tkey, TValue>>
{
    Tkey[] keys;
    TValue[] values;
    int length;

    public MyDictionary(int len, Tkey[] keys, TValue[] values)
    {
        length = len;

        this.keys = keys;
        this.values = values;
    }

    public void Resize()
    {
        Tkey[] temp = new Tkey[this.keys.Length * 2];
        TValue[] tmpValue = new TValue[this.keys.Length * 2];
        for (int i = 0; i < keys.Length; i++)
        {
            temp[i] = this.keys[i];
            tmpValue[i] = this.values[i];
        }
        keys = temp;
        values = tmpValue;
        length = temp.Length / 2;
    }

    public void add(Tkey key, TValue value)
    {
        if (this.keys.Length == length)
        {
            Resize();
        }

        this.keys[length] = key;
        values[length] = value;
        length += 1;
    }

    public int Length
    {
        get
        {
            return length;
        }
    }

    public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < length; i++)
        {
            yield return new KeyValuePair<Tkey, TValue>(keys[i], values[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public TValue this[Tkey keyArray]
    {
        get
        {
            int index = 0;
            for (int i = 0; i < length; i++)
            {
                if (keyArray.Equals(keys[i]))
                {
                    index = i;
                    break;
                }
            }
            return values[index];
        }

        set
        {
            int index = 0;
            for (int i = 0; i < length; i++)
            {
                if (keyArray.Equals(keys[i]))
                {
                    index = i;
                    break;
                }
            }
            values[index] = value;
        }
    }


}

class Programm
{
    public static void Main()
    {
        MyList<int> List = new MyList<int>(4, 1, 2, 3, 8);
        List.add(1);

        Console.WriteLine(List.len);

        for (int i = 0; i < List.len; i++)
        {
            Console.WriteLine(List[i]);
        }

        int[] keys = new int[4] { 1, 1, 2, 3 };

        int[] values = new int[4] { 3, 4, 5, 6 };

        MyDictionary<int, int> dict = new MyDictionary<int, int>(4, keys, values);

        Console.WriteLine(dict[3]);
    }
}