using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class MyString
    {
        private Char[] _myString;
        private StringBuilder _sb;
        private Int32 _length;

        public Int32 Length
        {
            get => _length;
        }

        public Int32 Capacity
        {
            get => _myString.Length;
        }

        /// <summary>
        /// Returns MyString as System.String.
        /// </summary>
        /// <returns></returns>
        public String GetAsString()
        {
            _sb.Clear();
            foreach (Char c in _myString)
            {
                _sb.Append(c);
            }
            return _sb.ToString();
        }

        /// <summary>
        /// MyString with arbitrary initial capacity.
        /// </summary>
        /// <param name="initCapacity">Initial capacity.</param>
        public MyString(Int32 initCapacity)
        {
            _myString = new Char[initCapacity];
            _sb = new StringBuilder();
        }

        /// <summary>
        /// MyString with default initial capacity.
        /// </summary>
        public MyString() : this(0)
        {
        }

        /// <summary>
        /// MyString with System.String as parameter.
        /// </summary>
        /// <param name="value">Input String.</param>
        public MyString(String value) : this(value.Length)
        {
            value.ToCharArray().CopyTo(_myString,0);
            _length = value.Length;
        }

        /// <summary>
        /// MyString with array of Char as parameter.
        /// </summary>
        /// <param name="value">Array of chars.</param>
        public MyString(Char[] value) : this(value.Length)
        {
            value.CopyTo(_myString,0);
            _length = value.Length;
        }

        /// <summary>
        /// MyString with MyString as parameter.
        /// </summary>
        /// <param name="value">MyString.</param>
        public MyString(MyString value) : this(value.ToCharArray())
        {
        }

        public override string ToString() => GetAsString();

        /// <summary>
        /// Represents MyString as an array of Char.
        /// </summary>
        /// <returns>Array of chars.</returns>
        public Char[] ToCharArray()
        {
            Char[] myStringAsCharArray = new Char[Length];
            for (int i = 0; i < Length; i++)
            {
                myStringAsCharArray[i] = _myString[i];
            }
            return myStringAsCharArray;
        }

        /// <summary>
        /// Concatenates two MyStrings.
        /// </summary>
        /// <param name="mstr1"></param>
        /// <param name="mstr2"></param>
        /// <returns>Concatenated MyString.</returns>
        public static MyString Concat(MyString mstr1, MyString mstr2)
        {
            Char[] concatMyString = new Char[mstr1.Length + mstr2.Length];
            Char[] mstr = mstr1.ToCharArray();
            for (int i = 0; i < mstr.Length; i++)
            {
                concatMyString[i] = mstr[i];
            }

            Int32 shift = mstr.Length;
            mstr = mstr2.ToCharArray();
            for (int i = 0; i < mstr2.Length; i++)
            {
                concatMyString[shift + i] = mstr[i];
            }
            return new MyString(concatMyString);
        }

        /// <summary>
        /// Concatenates several MyString.
        /// </summary>
        /// <param name="mstr">Array of MyString.</param>
        /// <returns>Concatenated MyString.</returns>
        public static MyString Concat(params MyString[] mstr)
        {
            Int32 length = 0;
            foreach (MyString myString in mstr)
            {
                length += myString.Length;
            }

            Char[] concatMyString = new Char[length];

            Int32 shift = 0;
            foreach (MyString myString in mstr)
            {
                myString.ToCharArray().CopyTo(concatMyString,shift);
                shift += myString.Length;
            }

            return new MyString(concatMyString);
        }
        
        /// <summary>
        /// Compares two MyStrings.
        /// </summary>
        /// <param name="mstr1"></param>
        /// <param name="mstr2"></param>
        /// <returns>-1, 0, 1 depending on lexicographical order.</returns>
        public static Int32 Compare(MyString mstr1, MyString mstr2)
        {
            int minLength = mstr1.Length < mstr2.Length ? mstr1.Length : mstr2.Length;

            Char[] mstrChar1 = mstr1.ToCharArray();
            Char[] mstrChar2 = mstr2.ToCharArray();

            for (int i = 0; i < minLength; i++)
            {
                if (mstrChar1[i] - mstrChar2[i] != 0)
                    return Math.Sign(mstrChar1[i] - mstrChar2[i]);
            }

            if (mstr1.Length == mstr2.Length) return 0;

            return mstr1.Length < mstr2.Length ? -1 : 1;
        }

        /// <summary>
        /// Checks if MyString contains Char.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>True if MyString contains c, else false.</returns>
        public Boolean Contains(Char c)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_myString[i] == c)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Search for a Char.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Index of the first entry of c, -1 if c is not found.</returns>
        public Int32 IndexOf(Char c)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_myString[i] == c)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Search for a Char.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Index of the last entry of c, -1 if c is not found.</returns>
        public Int32 LastIndexOf(Char c)
        {
            for (int i = Length - 1; i >= 0; i--)
            {
                if (_myString[i] == c)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Returns a substring.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="numberOfElements"></param>
        /// <returns>MyString or null if length is greater than number of available elements.</returns>
        public MyString Substring(Int32 startIndex, Int32 length)
        {
            if (startIndex > Length - 1 || startIndex + length > Length)
                return null;
            Char[] subString = new Char[length];
            for (int i = 0; i < length; i++)
            {
                subString[i] = _myString[i + startIndex];
            }
            return new MyString(subString);
        }

        /// <summary>
        /// Returns a substring from startIndex to the end.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public MyString Substring(Int32 startIndex)
        {
            return Substring(startIndex,Length - startIndex);
        }

        /// <summary>
        /// Returns Char by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Char at index or '\0' if the index is out of bounds.</returns>
        public Char CharAt(Int32 index)
        {
            return _myString[index];
        }

        /// <summary>
        /// Checks the equality of two MyStrings.
        /// </summary>
        /// <param name="mstr1"></param>
        /// <param name="mstr2"></param>
        /// <returns>True if MyStrings are equal, else false.</returns>
        public static Boolean Equals(MyString mstr1, MyString mstr2)
        {
            if (ReferenceEquals(mstr1,mstr2))
                return true;

            if (mstr1.Length != mstr2.Length)
                return false;

            for (int i = 0; i < mstr1.Length; i++)
            {
                if (mstr1[i] != mstr2[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Converts an array of Chars to MyString.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MyString FromCharArray(Char[] value)
        {
            return new MyString(value);
        }

        public static MyString FromString(String value)
        {
            return new MyString(value);
        }

        /// <summary>
        /// Checks the equality of this MyString to another MyString.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this,obj))
                return true;

            if (!(obj is MyString))
                return false;

            return Equals(this,(MyString)obj);
        }

        /// <summary>
        /// Converts to MyString with Upper Case chars.
        /// </summary>
        /// <returns></returns>
        public MyString ToUpper()
        {
            Char[] upperMyString = new Char[Length];
            for (int i = 0; i < Length; i++)
            {
                upperMyString[i] = Char.ToUpper(_myString[i]);
            }
            return new MyString(upperMyString);
        }

        /// <summary>
        /// Converts to MyString with Lower Case chars.
        /// </summary>
        /// <returns></returns>
        public MyString ToLower()
        {
            Char[] lowerMyString = new Char[Length];
            for (int i = 0; i < Length; i++)
            {
                lowerMyString[i] = Char.ToLower(_myString[i]);
            }
            return new MyString(lowerMyString);
        }

        public override int GetHashCode()
        {
            var hashCode = -5890885;
            hashCode = hashCode * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(_myString);
            hashCode = hashCode * -1521134295 + _length.GetHashCode();
            return hashCode;
        }

        public static Boolean operator==(MyString mstr1, MyString mstr2)
        {
            return Equals(mstr1,mstr2);
        }

        public static Boolean operator !=(MyString mstr1,MyString mstr2)
        {
            return !Equals(mstr1,mstr2);
        }

        public static MyString operator +(MyString mstr1, MyString mstr2)
        {
            return Concat(mstr1,mstr2);
        }

        public Char this[int index]
        {
            get { return _myString[index]; }
            set { _myString[index] = value; }
        }
    }

    class MyStringDemo
    {
        public static void Demo()
        {
            Console.WriteLine("Enter two non-empty strings for demonstration.");
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Creating MyString from System.String:");
            MyString myString1 = new MyString(string1);
            Console.WriteLine("mystring1 = " + myString1);

            Console.WriteLine("Creating MyString from Char[]:");
            MyString myString2 = new MyString(string2.ToCharArray());
            Console.WriteLine("mystring2 = " + myString2);

            Console.WriteLine("Get length of MyString:");
            Console.WriteLine("myString1.Length = " + myString1.Length);
            Console.WriteLine("myString2.Length = " + myString2.Length + Environment.NewLine);

            Console.WriteLine("Concatenate two MyString:");
            MyString myString3 = myString1 + myString2;
            Console.WriteLine("myString3 = " + myString3);
            Console.WriteLine();

            Console.WriteLine("Enter a char to search for in myString3:");
            char search;
            while (true)
            {
                try
                {
                    search = Console.ReadLine()[0];
                    break;
                } 
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Enter at least one char.");
                }
            }
            Console.WriteLine($"myString3 contains \'{search}\': {myString3.Contains(search)}");
            Console.WriteLine($"Index of \'{search}\' in myString3: {myString3.IndexOf(search)}'");
            Console.WriteLine($"Last index of \'{search}\' in myString3: {myString3.LastIndexOf(search)}'");

            Console.WriteLine("To upper case and to lower case:");
            Console.WriteLine(myString3 = myString3.ToUpper());
            Console.WriteLine(myString3 = myString3.ToLower());
            Console.ReadLine();

            Console.WriteLine("Get substring from myString, length of 5 from index 2:");
            Console.WriteLine(myString3.Substring(2,5));
            Console.WriteLine("Get substring from myString, from index 2 to the end:");
            Console.WriteLine(myString3.Substring(2));

            Console.WriteLine("Get char by index. Enter index:");
            int index;
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(),out index))
                {
                    Console.WriteLine("Wrong input. Enter number.");
                    continue;
                }
                if (index >= 0)
                {
                    try
                    {
                        Console.WriteLine(myString3[index]);
                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Wrong index.");
                    }
                }
                else
                {
                    Console.WriteLine("Index should be greater than or equal to 0.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Equality of two MyStrings:");
            Console.WriteLine("Enter the first MyString to compare:");
            myString1 = new MyString(Console.ReadLine());
            Console.WriteLine("Enter the second MyString to compare:");
            myString2 = new MyString(Console.ReadLine());

            Console.WriteLine("MyStrigs are equal: " + (myString1 == myString2));

        }
    }
}
