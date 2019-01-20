using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using Microsoft.VisualBasic.FileIO;

namespace project_eular
{
    public partial class Form1 : Form
    {
        public const string Ans = "Answer =  ";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //10未満の自然数のうち, 3 もしくは 5 の倍数になっているものは 3, 5, 6, 9 の4つがあり, これらの合計は 23 になる.
            //同じようにして, 1000 未満の 3 か 5 の倍数になっている数字の合計を求めよ.
            var Sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) Sum += i;
            }
            label1.Text = Ans + Sum.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //フィボナッチ数列の項の値が400万以下の, 偶数値の項の総和を求めよ.
            long Sum = 2;
            int[] Fibonacci;
            Fibonacci = new int[100];
            Fibonacci[1] = 1;
            Fibonacci[2] = 2;
            for (int i = 3; i < 100; i++)
            {
                Fibonacci[i] = Fibonacci[i - 2] + Fibonacci[i - 1];
                if (Fibonacci[i] > 4000000) break;
                if (Fibonacci[i] % 2 == 0)
                {
                    Sum += Fibonacci[i];
                }
            }
            label1.Text = Ans + Sum;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //600851475143 の素因数のうち最大のものを求めよ.

            var Number = 600851475143;
            var i = 2;

            while (i * i < Number)
            {
                if (Number % i == 0)
                {
                    Number /= i;
                }
                else { i++; }
            }
            if (Number < i) { Number = i; }
            string Answer = Number.ToString();
            label1.Text = Ans + Answer;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //3桁の2数の積で，回文になる最大のものを求めよ．
            var Max = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    int Number = i * j;
                    string NumberString = Number.ToString();
                    string ReverseString = new string(NumberString.Reverse().ToArray());
                    if (ReverseString == NumberString)
                    {
                        if (Max < Number)
                        {
                            Max = Number;
                        }
                    }
                }
            }
            label1.Text = Ans + Max;
        }
        public static long Gcd(long a, long b)
        {
            if (a < b)
            {
                return Gcd(b, a);
            }
            else
            {
                while (b != 0)
                {
                    var tmp = a % b;
                    a = b;
                    b = tmp;
                }
                return a;
            }
        }
        public static long lcm(long a, long b)
        {
            return (a * b) / Gcd(a, b);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //1 から 20 までの整数全てで割り切れる数字の中で最小の正の数
            /*long Number = 2520;
            long Answer = 0;
            for(int i = 20; i > 10; i--)
            {
                if(Number % i != 0)
                {
                    Number += 1 ;
                    i = 20;
                }
                else
                {
                    if (i == 11)
                    {
                        Answer = Number;
                    }
                }
            }
            label1.Text = Ans + Answer;
            */
            long i;
            long n = 1;
            for (i = 1; i <= 20; i++)
            {
                n = lcm(n, i);
            }
            label1.Text = Ans + n;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //最初の100個の自然数について二乗の和と和の二乗の差
            int n = 100;
            int Sum = (n * (n + 1)) / 2;
            int SumSquare = Sum * Sum;
            int SquareSum = (n * (n + 1) * (2 * n + 1)) / 6;
            int Answer = SumSquare - SquareSum;
            label1.Text = Ans + Answer;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //10001番目の素数
            int Num = 1000000;//リストの最大値
            int[] IntegerList;
            IntegerList = new int[Num];
            var PrimeNumberList = new List<long>();
            var j = 0;
            for (int i = 2; i < Num; i++) { IntegerList[i] = i; }

            int head = 0;
            double EndNum = Math.Sqrt(Num);

            while (head < EndNum)
            {
                //先頭を探す
                for (int i = j; i < Num; i++)
                {
                    if (IntegerList[i] != 0)
                    {
                        head = IntegerList[i];
                        PrimeNumberList.Add(head);
                        j = i;
                        break;
                    }
                }
                //ふるい落とし。落としたものには0を入れる
                foreach (int i in IntegerList)
                {
                    if (IntegerList[i] % head == 0) { IntegerList[i] = 0; }
                }
            }
            for (int a = 2; a < IntegerList.Length; a++)
            {
                if (IntegerList[a] != 0)
                {
                    PrimeNumberList.Add(IntegerList[a]);
                }
            }
            label1.Text = Ans + PrimeNumberList[10000];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //この1000桁の数字から13個の連続する数字を取り出して, それらの総乗の最大
            string NumberString1 = "731671765313306249192251196744265747423553491949349698352031277450632623957831801698480" +
                "1869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744" +
                "3043557668966489504452445231617318564030987111217223831136222989342338030813533627661428280644448664523874" +
                "9303589072962904915604407723907138105158593079608667017242712188399879790879227492190169972088809377665727" +
                "3330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977" +
                "8461740649551492908625693219784686224828397224137565705605749026140797296865241453510047482166370484403199" +
                "8900088952434506585412275886668811642717147992444292823086346567481391912316282458617866458359124566529476" +
                "5456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230" +
                "9878799272442849091888458015616609791913387549920052406368991256071760605886116467109405077541002256983155" +
                "20005593572972571636269561882670428252483600823257530420752963450";

            long Number = 1;
            long MaxNumber = 0;
            for (int i = 0; i < NumberString1.Length - 13; i++)
            {
                Number = 1;
                for (int k = 0; k < 13; k++)
                {
                    char c = NumberString1[i + k];
                    Number *= (c - '0');
                }
                if (MaxNumber < Number)
                {
                    MaxNumber = Number;
                }
            }
            label1.Text = Ans + MaxNumber;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //a + b + c = 1000 となるピタゴラスの三つ組の積abc
            int a = 0;
            int b = 0;
            int c = 0;

            for (a = 1; a < 1000; a++)
            {
                for (b = 1; b < 1000; b++)
                {
                    for (c = 1; c < 1000; c++)
                    {
                        if (c * c == a * a + b * b)
                        {
                            if (a + b + c == 1000)
                            {
                                long Answer = a * b * c;
                                label1.Text = string.Format("a={0} b={1} c={2} Answer = {3}", a, b, c, Answer);
                                goto ExitLoop;
                            }
                        }
                    }
                }
            }
            ExitLoop:;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //200万以下の全ての素数の和
            int Num = 2000000;//リストの最大値
            int[] IntegerList;
            IntegerList = new int[Num];
            var PrimeNumberList = new List<long>();
            var j = 0;
            for (int i = 2; i < Num; i++) { IntegerList[i] = i; }

            int head = 0;
            double EndNum = Math.Sqrt(Num);

            while (head < EndNum)
            {
                //先頭を探す
                for (int i = j; i < Num; i++)
                {
                    if (IntegerList[i] != 0)
                    {
                        head = IntegerList[i];
                        PrimeNumberList.Add(head);
                        j = i;
                        break;
                    }
                }
                //ふるい落とし。落としたものには0を入れる
                foreach (int i in IntegerList)
                {
                    if (IntegerList[i] % head == 0) { IntegerList[i] = 0; }
                }
            }
            for (int a = 2; a < IntegerList.Length; a++)
            {
                if (IntegerList[a] != 0)
                {
                    PrimeNumberList.Add(IntegerList[a]);
                }
            }
            long PrimeSum = 0;
            for (int i = 0; i < PrimeNumberList.Count; i++)
            {
                PrimeSum += PrimeNumberList[i];
            }
            sw.Stop();
            label1.Text = Ans + PrimeSum+" "+sw.Elapsed;
        }
        public static int Max4(int a, int b, int c, int d)
        {
            int Max = a;
            Max = Math.Max(Max, b);
            Max = Math.Max(Max, c);
            Max = Math.Max(Max, d);
            return Max;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            //上下左右斜めのいずれかの方向で連続する4つの数字の積のうち最大のもの
            int[,] NumberString = new int[20, 20] {
                                            { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                                            { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                                            { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                                            { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                                            { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                                            { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                                            { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                                            { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                                            { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                                            { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                                            { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                                            { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                                            { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                                            { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                                            { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                                            { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                                            { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                                            { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                                            { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                                            { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };
            int Vertical = 0;
            int Horizontal = 0;
            int RightDiagonal = 0;
            int LeftDiagonal = 0;
            int MaxValue = 0;
            for (int i = 0; i <= NumberString.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= NumberString.GetUpperBound(1); j++)
                {
                    if (i + 3 <= NumberString.GetUpperBound(0)) { 
                        Vertical = NumberString[i, j] * NumberString[i + 1, j] * NumberString[i + 2, j] * NumberString[i + 3, j];
                    }
                    if (j + 3 <= NumberString.GetUpperBound(1))
                    {
                        Horizontal = NumberString[i, j] * NumberString[i, j + 1] * NumberString[i, j + 2] * NumberString[i, j + 3];
                    }
                    if (i + 3 <= NumberString.GetUpperBound(0) && j + 3 <= NumberString.GetUpperBound(1))
                    {
                        RightDiagonal = NumberString[i, j] * NumberString[i + 1, j + 1] * NumberString[i + 2, j + 2] * NumberString[i + 3, j + 3];
                    }
                    if (i < 17 && j > 2)
                    {
                        LeftDiagonal = NumberString[i, j] * NumberString[i + 1, j - 1] * NumberString[i + 2, j - 2] * NumberString[i + 3, j - 3];
                    }
                    int Max = Max4(Vertical, Horizontal, RightDiagonal, LeftDiagonal);
                    if (MaxValue < Max) MaxValue = Max;
                }
            }
            label1.Text = Ans + MaxValue;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //500個より多く約数をもつ最初の三角数
            int TriangularNumber = 0;
            int i = 1;
            while (true)
            {
                int Exp = 0;
                TriangularNumber += i;
                int Number = TriangularNumber;
                int NumberOfPrime = 1;

                for (int j = 2; Number >= j; j++)
                {
                    while (Number % j == 0)
                    {
                        Number /= j;
                        Exp++;
                    }
                    NumberOfPrime *= (1 + Exp);
                    Exp = 0;
                }
                if (NumberOfPrime + 1 >= 500) { break; }
                i++;
            }
            label1.Text = Ans + TriangularNumber;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            //50桁の数字100個の合計の上から10桁
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\a.txt";
            Encoding utf8 = Encoding.GetEncoding("utf-8");
            string[] NumberString;
            NumberString = new string[100];

            using (var reader = new StreamReader(path, utf8))
            {
                try
                {
                    for (int i = 0; i < 100; i++)
                    {
                        NumberString[i] = reader.ReadLine();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            long Number = 0;
            long digit = 0;

            for (int Div = 40; Div >= 0; Div -= 10)
            {
                Number = digit;
                for (int i = 0; i < 100; i++)
                {
                    Number += long.Parse(NumberString[i].Substring(Div, 10));
                }
                if (Div != 0)
                {
                    digit = Number / (long)Math.Pow(10, 10);
                }
                else
                {
                    string Answer = Number.ToString();
                    label1.Text = Ans + Answer.Substring(0, 10);
                }
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //1000000以下の最長のコラッツ数列
            int Count = 0;
            int MaxCount = 0;
            long CurrentValue = 0;
            int MaxCountNumber = 0;
            for (int i = 1; i < 1000001; i++)
            {
                CurrentValue = i;
                Count = 1;
                while (CurrentValue != 1)
                {
                    if (CurrentValue % 2 == 0)
                    {
                        CurrentValue /= 2;
                        Count++;
                    }
                    else
                    {
                        CurrentValue = (3 * CurrentValue) + 1;
                        Count++;
                    }
                }
                if (MaxCount < Count)
                {
                    MaxCountNumber = i;
                    MaxCount = Count;
                }
            }
            label1.Text = Ans + MaxCountNumber;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //20X20の格子経路の最短経路数。（横の長さX縦の長さ）C（縦か横の長さ）で求まる
            long Denom = 1;
            long Numer = 1;

            for (int i = 40; i > 20; i--)
            {
                Denom *= (i - 20);
                Numer *= i;
                for (int j = 2; j < 6; j++)
                {
                    if (Numer % j == 0 && Denom % j == 0)
                    {
                        Numer /= j;
                        Denom /= j;
                    }
                }
            }
            label1.Text = Ans + Numer / Denom;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //2の1000乗の各位の数字の和
            BigInteger Number = 1;
            for (int i = 1; i < 1001; i++)
            {
                Number *= 2;
            }
            string NumberString = Number.ToString();
            int SumEachNumber = 0;
            for (int i = 0; i < NumberString.Length; i++)
            {
                char EachNumber = NumberString[i];
                SumEachNumber += (EachNumber - '0');
            }
            label1.Text = Ans + SumEachNumber;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            //1から100までの英単語の文字数
            long LetterNumber1 = 3 + 3 + 5 + 4 + 4 + 3 + 5 + 5 + 4;//1~9
            long LetterNumber2 = 3 + 6 + 6 + 8 + 8 + 7 + 7 + 9 + 8 + 8;//10~19
            long LetterNumber3 = (6 * 10 + LetterNumber1) * 4;//20~29,30~39,80~89,90~99
            long LetterNumber4 = (5 * 10 + LetterNumber1) * 3;//40~49,50~59,60~69
            long LetterNumber5 = 7 * 10 + LetterNumber1;//70~79
            long HundredAnd = 7 + 3;
            long Hundred = 7 * 9 + LetterNumber1;//100,200,300,400,500,600,700,800,900
            long LetterNumber6 = 3 * (99 * (3 + HundredAnd) + LetterNumber1 + LetterNumber2 + LetterNumber3 + LetterNumber4 + LetterNumber5);//101~199,201~299,601~699
            long LetterNumber7 = 3 * (99 * (4 + HundredAnd) + LetterNumber1 + LetterNumber2 + LetterNumber3 + LetterNumber4 + LetterNumber5);//401~499,501~599,901~999
            long LetterNumber8 = 3 * (99 * (5 + HundredAnd) + LetterNumber1 + LetterNumber2 + LetterNumber3 + LetterNumber4 + LetterNumber5);//301~399,701~799,801~899
            long OneThousand = 11;
            long Answer = LetterNumber1 + LetterNumber2 + LetterNumber3 + LetterNumber4 + LetterNumber5 + LetterNumber6 + LetterNumber7 + LetterNumber8 + Hundred + OneThousand;
            label1.Text = Ans + Answer;
        }
        //problem18はまだ理解できてない
        internal struct MyStack
        {
            internal int X;
            internal int Y;
            internal int SumValue;
        };
        private void button18_Click(object sender, EventArgs e)
        {
            //三角形の和が最大になる経路
            var Delta = new int[][]{
                new int[]{ 75},
                new int[]{ 95,64},
                new int[]{ 17,47,82},
                new int[]{ 18,35,87,10},
                new int[]{ 20,04,82,47,65},
                new int[]{ 19,01,23,75,03,34},
                new int[]{ 88,02,77,73,07,63,67},
                new int[]{ 99,65,04,28,06,16,70,92},
                new int[]{ 41,41,26,56,83,40,80,70,33},
                new int[]{ 41,48,72,33,47,32,37,16,94,29},
                new int[]{ 53,71,44,65,25,43,91,52,97,51,14},
                new int[]{ 70,11,33,28,77,73,17,78,39,68,17,57},
                new int[]{ 91,71,52,38,17,14,91,43,58,50,27,29,48,},
                new int[]{ 63,66,04,68,89,53,67,30,73,16,69,87,40,31},
                new int[]{ 04,62,98,27,23,09,70,98,73,93,38,53,60,04,23}
            };

            var Stack = new Stack<MyStack>();
            MyStack StackState;
            StackState.X = StackState.Y = 0;
            StackState.SumValue = Delta[0][0];
            Stack.Push(StackState);

            int Max = 0;

            while (Stack.Count > 0)
            {
                MyStack Popped = Stack.Pop();
                if (Popped.X == Delta.GetUpperBound(0))
                {
                    if (Max < Popped.SumValue)
                    {
                        Max = Popped.SumValue;
                        label1.Text = Ans + Popped.SumValue;
                    }
                    continue;
                }

                StackState.X = Popped.X + 1;
                StackState.Y = Popped.Y;
                StackState.SumValue = Popped.SumValue + Delta[StackState.X][StackState.Y];
                Stack.Push(StackState);

                StackState.X = Popped.X + 1;
                StackState.Y = Popped.Y + 1;
                StackState.SumValue = Popped.SumValue + Delta[StackState.X][StackState.Y];
                Stack.Push(StackState);
            }
        }
            /*下の二つの項で大きいほうに進むアルゴリズム。やっぱり局所解だった。
            int Depth = 0;
            int SideIndex = 0;
            int Sum = 0;
            int Max = 0;
            Sum += Delta[Depth][SideIndex];
            while (Depth < 14)
            {
                if (Delta[Depth + 1][SideIndex] < Delta[Depth + 1][SideIndex + 1])
                {
                    Sum += Delta[Depth + 1][SideIndex + 1];
                    Max = Delta[Depth + 1][SideIndex + 1];
                    SideIndex++;
                }
                else
                {
                    Sum += Delta[Depth + 1][SideIndex];
                    Max = Delta[Depth + 1][SideIndex];
                }
                Depth++;
                textBox1.Text += Max + " ";
                Max = 0;

            }*/



        

        private void button19_Click(object sender, EventArgs e)
        {
            //月初が月曜日の回数
            //var Year = 10;
            //var Month = 12;
            //var WeekDay = 0;

            //WeekDay = (Year + (int)(Year / 4) - (int)(Year / 100) + (int)(Year / 400) + (int)((13 * Month + 8) / 5)) % 7;

            var Date1 = new DateTime(1901, 1, 1);
            int Count = 0;
            while (Date1 <= new DateTime(2000, 12, 31))
            {
                if (Date1.DayOfWeek == DayOfWeek.Sunday)
                {
                    Count++;
                }
                Date1 = Date1.AddMonths(1);
            }
            label1.Text = Ans + Count;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //100!の各位の数字の和
            BigInteger Number = 1;
            for (int i = 1; i < 100; i++)
            {
                Number *= i;
            }
            string NumberString = Number.ToString();
            int SumEachNumber = 0;
            for (int i = 0; i < NumberString.Length; i++)
            {
                char EachNumber = NumberString[i];
                SumEachNumber += (EachNumber - '0');
            }
            label1.Text = Ans + SumEachNumber;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int Number = 0;
            List<int> DivSumList = new List<int>();
            DivSumList.Add(0);
            int DivSum = 0;
            int AmicableSum = 0;


            for (Number = 1; Number < 10001; Number++)
            {
                for (int i = 2; i < Number; i++)
                {
                    if (Number % i == 0)
                    {
                        DivSum += i;
                    }
                }
                DivSumList.Add(DivSum + 1);
                DivSum = 0;
            }
            for (int i = 0; i < 10001; i++)
            {
                if (DivSumList[i] < 10001)
                {
                    if (i == DivSumList[DivSumList[i]] && i != DivSumList[i])
                    {
                        textBox1.AppendText(i + " " + DivSumList[i] + " ");
                        AmicableSum += i + DivSumList[i];
                    }
                }
            }
            label1.Text = Ans + AmicableSum / 2;//同じ組を2回数えてしまうため2で割る
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //ソートまではできた
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\names.txt";
            Encoding utf8 = Encoding.GetEncoding("utf-8");
            string Name = "";
            using (var Reader = new StreamReader(path, utf8))
            {
                try
                {
                    Name = Reader.ReadToEnd();
                }
                catch (Exception ex)
                {

                }
            }
            char[] DelimiterChars = { ',' };
            char[] DeleteChars = { '\"' };
            string[] Names = Name.Split(DelimiterChars);
            int i = 1;
            int ScoreSum = 0;
            foreach (string EachName in Names.OrderBy(n => n))
            {
                int Score = EachName.ToCharArray().Where(x => x >= 'A').Select(x => x - 'A' + 1).Sum() * i;
                ScoreSum += Score;
                i++;
            }
            label1.Text = Ans + ScoreSum;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var AbundantNumberList = new List<int>();
            for (int i = 1; i <= 28123; i++)
            {
                int DivisorSum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        DivisorSum += j;
                    }
                }
                if (DivisorSum > i)
                {
                    AbundantNumberList.Add(i);
                }
            }
            var MakedAbundantNumberList = new List<int>();
            for (int i = 0; i < AbundantNumberList.Count; i++)
            {
                for (int j = 0; j < AbundantNumberList.Count; j++)
                {
                    if (i <= j)
                    {
                        int MakedAbundantNumber = AbundantNumberList[i] + AbundantNumberList[j];
                        if (MakedAbundantNumber >= 28123)
                        {
                            break;
                        }
                        MakedAbundantNumberList.Add(MakedAbundantNumber);
                    }
                }
            }
            MakedAbundantNumberList.OrderBy(n => n);
            var NumberList = new List<int>();
            for (int i = 1; i < 28123; i++)
            {
                NumberList.Add(i);
            }
            HashSet<int> MakedAbundantNumberHash = new HashSet<int>(MakedAbundantNumberList.OrderBy(n => n));
            HashSet<int> NumberHash = new HashSet<int>(NumberList.OrderBy(n => n));

            NumberHash.SymmetricExceptWith(MakedAbundantNumberList);
            int Sum = NumberHash.Sum();

            label1.Text = Ans + Sum;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string[] NumberString = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var NumberList = new List<string>();
            var stack = new Stack<string>();

            stack.Push("2");
            while (stack.Count > 0)
            {
                string Popped = stack.Pop();
                if (Popped.Length == NumberString.Length)
                {
                    NumberList.Add(Popped);
                    continue;
                }
                for (int i = 0; i < NumberString.Length; i++)
                {
                    if (Popped.Contains(NumberString[i]) == false)
                    {
                        stack.Push(Popped + NumberString[i]);
                    }
                }
            }
            NumberList.Sort();
            label1.Text = Ans + NumberList[274240 - 1];
        }

        private void button25_Click(object sender, EventArgs e)
        {
            BigInteger Value = 0;
            var NumberList = new List<BigInteger>();
            NumberList.Add(1);
            NumberList.Add(1);
            for (int i = 1; ; i++)
            {
                Value = NumberList[i - 1] + NumberList[i];
                NumberList.Add(Value);
                string NumberString = Value.ToString();
                if (NumberString.Length == 1000)
                {
                    label1.Text = Ans + (i + 2);
                    break;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static int Cycle(BigInteger Value)
        {
            while (Value % 2 == 0)
            {
                Value = BigInteger.Divide(Value, 2);
            }
            while (Value % 5 == 0)
            {
                Value = BigInteger.Divide(Value, 5);
            }
            if (Value == 1) { return 0; }
            int Count = 1;
            while (BigInteger.Remainder((BigInteger.Pow(10, Count)), Value) != 1)
            {
                Count++;
            }
            return (int)Count;
        }
        private void button26_Click(object sender, EventArgs e)
        {
            int MaxCount = 0;
            int Count = 0;
            int MaxValue = 0;
            for (BigInteger i = 2; i < 1000; i = BigInteger.Add(i, 1))
            {
                Count = Cycle(i);
                if (MaxCount < Count)
                {
                    MaxCount = Count;
                    MaxValue = (int)i;
                }
            }
            label1.Text = Ans + MaxValue + " CycleLength = " + MaxCount;
        }
        public static int Sosuu(int n)
        {
            if (n <= 1) return 0;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return 0;
            }
            return 1;
        }
        private void button27_Click(object sender, EventArgs e)
        {
            int MaxLength = 0;
            for (int a = -999; a < 1000; a++)
            {
                for (int b = -1000; b < 1000; b++)
                {
                    for (int n = 0; n < int.MaxValue; n++)
                    {
                        int Value = (n * n) + (a * n) + b;
                        if (Sosuu(Value) == 0) { break; }
                        if (MaxLength < n)
                        {
                            MaxLength = n;
                            label1.Text = ("a=" + a + "b=" + b + "の時" + MaxLength + "個の素数生成、ab=" + a * b);
                        }

                    }
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int Value = 1;
            int plus = 1;
            for (int i = 1; i < 501; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    plus += i * 2;
                    Value += plus;
                }
            }
            label1.Text = Ans + Value;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var List = new HashSet<BigInteger>();
            for (BigInteger i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    List.Add(BigInteger.Pow(i, j));
                }
            }
            label1.Text = Ans + List.Count;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int AnswerSum = 0;
            int PowSum = 0;
            for (int i = 2; i < 1000000; i++)
            {
                char[] NumberString = i.ToString().ToCharArray();
                for (int j = 0; j < NumberString.Length; j++)
                {

                    int EachNumber = NumberString[j] - '0';
                    int PowEachNumber = 1;
                    for (int k = 0; k < 5; k++) { PowEachNumber *= EachNumber; }
                    PowSum += PowEachNumber;
                    if (PowSum > i)
                    {
                        break;
                    }
                }
                if (PowSum == i)
                {
                    AnswerSum += i;
                    textBox1.AppendText(i.ToString() + " ");
                }
                PowSum = 0;
            }
            label1.Text = Ans + AnswerSum;
        }

        //まだ理解できてない
        private void button31_Click(object sender, EventArgs e)
        {
            //1,2,5,10,20,50,100,200を使って200を作る全通り
            int[] Money = new int[200 + 1];
            Money[0] = 1;
            int UB = Money.GetUpperBound(0);

            foreach (int EachInt in new int[] { 1, 2, 5, 10, 20, 50, 100, 200 })
            {
                for (int i = 0; i < UB; i++)
                {
                    if (Money[i] == 0) continue;

                    int NewInd = i + EachInt;
                    if (UB < NewInd) break;
                    Money[NewInd] += Money[i];
                }
            }
            label1.Text = Ans + Money[UB];
        }

        private void button32_Click(object sender, EventArgs e)
        {
            var NumberSumHash = new HashSet<int>();
            for (int i = 1; i < 10000; i++)
            {
                for (int j = 1; j < 10000; j++)
                {
                    int Number = i * j;
                    if (Number > 9999) break;
                    string NumberString = Number.ToString() + i.ToString() + j.ToString();
                    var NumberList = new List<char>(NumberString);
                    if (NumberList.Count == 9 && NumberList.Contains('0') == false)
                    {
                        var Hash = new HashSet<char>(NumberList);
                        if (Hash.Count == 9)
                        {
                            NumberSumHash.Add(Number);
                            textBox1.AppendText("i=" + i + " j=" + j + "Number=" + Number + "  ");
                        }
                    }
                }
            }
            int NumberSum = NumberSumHash.Sum();
            label1.Text = Ans + NumberSum;
        }
        public static int[] Normal(int Numer, int Denom)
        {
            for (int i = 2; i < 20; i++)
            {
                while (Denom % i == 0 && Numer % i == 0)
                {
                    Numer /= i;
                    Denom /= i;
                }
            }
            int[] Number = new int[2];
            Number[0] = Numer;
            Number[1] = Denom;
            return Number;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            var FindList = new List<int>();
            var NormalList = new int[2];
            var StringNormalList = new int[2];
            for (int Denom = 20; Denom < 100; Denom++)
            {
                for (int Numer = 12; Numer < Denom; Numer++)
                {
                    if (Denom % 10 == 0) continue;
                    if (Denom % 11 == 0) continue;

                    string NumerString = Numer.ToString();
                    string DenomString = Denom.ToString();
                    if (NumerString[1] == DenomString[0])
                    {
                        int CalcNumer = Numer;
                        int CalcDenom = Denom;
                        NumerString = NumerString.Remove(1, 1);
                        DenomString = DenomString.Remove(0, 1);
                        StringNormalList = Normal(int.Parse(NumerString), int.Parse(DenomString));
                        NumerString = StringNormalList[0].ToString();
                        DenomString = StringNormalList[1].ToString();
                        //文字列の部分も約分する必要がある

                        NormalList = Normal(CalcNumer, CalcDenom);
                        if (NumerString == NormalList[0].ToString() && DenomString == NormalList[1].ToString())
                        {
                            textBox1.AppendText("That is" + Numer + "/" + Denom + "  ");
                            FindList.Add(Numer);
                            FindList.Add(Denom);
                        }
                    }
                }
            }
            int AnswerNumer = 1;
            int AnswerDenom = 1;
            for (int i = 0; i < FindList.Count; i = i + 2)
            {
                AnswerNumer *= FindList[i];
                AnswerDenom *= FindList[i + 1];
            }
            NormalList = Normal(AnswerNumer, AnswerDenom);
            label1.Text = Ans + NormalList[1];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static int fact(int Number)
        {
            int CalcNumber = 1;
            for (int i = Number; i > 1; i--)
            {
                CalcNumber *= i;
            }
            return CalcNumber;
        }
        private void button34_Click(object sender, EventArgs e)
        {
            int[] Number = new int[8];
            var AnswerList = new List<int>();
            foreach (int a in Number)
            {
                Number[a] = 0;
            }
            for (int i = 3; i < 2540161; i++)
            {
                string NumberString = i.ToString();
                int Sum = 0;
                for (int j = 0; j < NumberString.Length; j++)
                {
                    Number[j] = NumberString[j] - '0';
                    Sum += fact(Number[j]);
                }
                if (i == Sum)
                {
                    AnswerList.Add(i);
                    textBox1.AppendText(i + " ");
                }
            }
            label1.Text = AnswerList.Sum().ToString();
        }
        public static List<int> Eratosthenes(int Num)
        {
            int[] IntegerList = new int[Num];
            var PrimeNumberList = new List<int>();
            var j = 0;
            for (int i = 2; i < Num; i++) { IntegerList[i] = i; }

            int head = 0;
            double EndNum = Math.Sqrt(Num);

            while (head < EndNum)
            {
                //先頭を探す
                for (int i = j; i < Num; i++)
                {
                    if (IntegerList[i] != 0)
                    {
                        head = IntegerList[i];
                        PrimeNumberList.Add(head);
                        j = i;
                        break;
                    }
                }
                //ふるい落とし。落としたものには0を入れる
                foreach (int i in IntegerList)
                {
                    if (IntegerList[i] % head == 0) { IntegerList[i] = 0; }
                }
            }
            for (int a = 2; a < IntegerList.Length; a++)
            {
                if (IntegerList[a] != 0)
                {
                    PrimeNumberList.Add(IntegerList[a]);
                }
            }

            return PrimeNumberList;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            int CircularPrimeCount = 0;
            var PrimeNumberList = new List<int>(Eratosthenes(1000000));

            for (int i = 2; i <= 1000000; i++)
            {
                int JudgeCount = 0;
                for (int j = 0; j < i.ToString().Length; j++)
                {
                    string CircularNumberString = i.ToString().Substring(j) + i.ToString().Substring(0, j);
                    if (PrimeNumberList.Contains(int.Parse(CircularNumberString)))
                    {
                        JudgeCount++;
                    }
                }
                if (JudgeCount == i.ToString().Length)
                {
                    CircularPrimeCount++;
                    //textBox1.AppendText(CircularPrimeCount.ToString() + " ");
                }
            }
            label1.Text = "Answer" + CircularPrimeCount.ToString();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            int Sum = 0;
            for (int j = 1; j <= 1000000; j++)
            {
                if (j % 10 != 0)
                {
                    int Number = j;
                    string NumberString = Number.ToString();
                    var ReverseString = new string(NumberString.Reverse().ToArray());
                    if (ReverseString == NumberString)
                    {
                        string NumberString1 = Convert.ToString((Number), 2);
                        var ReverseString1 = new string(NumberString1.Reverse().ToArray());
                        if (ReverseString1 == NumberString1)
                        {
                            textBox1.AppendText(NumberString + " ");
                            Sum += Number;
                        }
                    }
                }
            }
            label1.Text = Ans + Sum;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var PrimeList = new List<int>(Eratosthenes(1000000));
            int Count = 0;
            int PrimeCount = 0;
            int sum = 0;
            for (int i = 10; Count < 11; i++)
            {
                if (PrimeList.Contains(i))
                {
                    for (int j = 1; j < i.ToString().Length; j++)
                    {
                        string RightSubString = i.ToString().Substring(j);
                        string LeftSubString = i.ToString().Substring(0, i.ToString().Length - j);
                        if (PrimeList.Contains(int.Parse(RightSubString)))
                        {
                            if (PrimeList.Contains(int.Parse(LeftSubString)))
                            {
                                PrimeCount++;
                            }
                        }
                    }
                    if (PrimeCount == i.ToString().Length - 1)
                    {
                        Count++;
                        sum += i;
                        textBox1.AppendText(i.ToString() + " ");
                    }
                    PrimeCount = 0;
                }
            }
            label1.Text = Ans + sum;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            int max = 0;
            for (int i = 1; i <= 9999; i++)
            {
                string CombineProductString = "";
                for (int j = 1; CombineProductString.Length < 9; j++)
                {
                    CombineProductString += (i * j).ToString();
                }
                if (CombineProductString.Length == 9)
                {
                    var IntHs = new HashSet<int>();
                    for (int a = 0; a < CombineProductString.Length; a++)
                    {
                        if (CombineProductString[a] != '0')
                        {
                            IntHs.Add(CombineProductString[a]);
                        }
                    }
                    if (IntHs.Count == 9)
                    {
                        textBox1.AppendText(i.ToString() + " ");
                        if (max < int.Parse(CombineProductString))
                        {
                            max = int.Parse(CombineProductString);
                        }
                    }
                }
            }
            label1.Text = Ans + max;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            int MaxCount = 0;
            var SumList = new List<int>();
            for (int a = 1; a < 500; a++)
            {
                for (int b = 1; b < 500; b++)
                {
                    for (int c = 1; c < 500; c++)
                    {
                        if (c * c == a * a + b * b && a + b + c < 1000)
                        {
                            SumList.Add(a + b + c);
                            textBox1.AppendText("a=" + a.ToString() + "b=" + b.ToString() + "c=" + c.ToString());
                        }
                    }
                }
            }
            SumList.Sort();
            int count = 0;
            int MaxNumber = 0;
            for (int a = 0; a < SumList.Count - 1; a++)
            {
                count++;
                if (SumList[a] == SumList[a + 1])
                {
                    count++;
                }
                else
                {
                    textBox1.AppendText("Number=" + SumList[a].ToString() + "count = " + count.ToString());
                    if (MaxCount < count)
                    {
                        MaxCount = count;
                        MaxNumber = SumList[a];
                    }
                    count = 0;
                }
            }
            label1.Text = Ans + MaxNumber.ToString();
        }

        public static uint Champernowne(uint Number)
        {
            if (Number < 10) return Number;
            else if (Number < 100)
            {
                if (Number % 2 == 0)
                {
                    return (Number - 10) / 20 + 1;
                }
                else
                {
                    return ((Number - 10) % 20) / 2;
                }
            }
            else return 0;
        }
        private void button40_Click(object sender, EventArgs e)
        {
            var NumberString = new StringBuilder();
            for (int i = 0; NumberString.Length <= 1000000; i++)
            {
                NumberString.Append(i.ToString());
            }
            int[] d = new int[6];
            int Index = 1;
            int Answer = 1;
            foreach (int a in d)
            {
                d[a] = int.Parse(NumberString[Index].ToString());
                Index *= 10;
                Answer *= d[a];
            }
            label1.Text = Ans + Answer.ToString();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            int Max = 0;
            for (int i = 100001; i < 1000000000; i = i + 2)
            {
                string NumberString = i.ToString();
                if (NumberString.Contains("0")) continue;
                var Hash = new HashSet<char>(NumberString);
                if (Hash.Count == NumberString.Length)
                {
                    int Flag = 0;
                    for (int j = 1; j <= NumberString.Length; j++)
                    {

                        if (NumberString.Contains(j.ToString()) == false)
                        {
                            Flag = 1;
                        }
                    }
                    if (Flag == 0)
                    {
                        if (Sosuu(i) == 1)
                        {
                            Max = i;
                        }
                    }
                }
            }
            label1.Text = Ans + Max;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\words.txt";
            Encoding UTF8 = Encoding.GetEncoding("utf-8");
            string Word = "";
            using (var Reader = new StreamReader(Path, UTF8))
            {
                try
                {
                    Word = Reader.ReadToEnd();
                }
                catch
                {

                }
            }
            char[] DelimiterChars = { ',' };
            char[] deleteChars = { '\"' };
            string[] Words = Word.Split(DelimiterChars);
            int Count = 0;
            foreach (string EachWord in Words)
            {
                int Score = EachWord.ToCharArray().Where(x => x >= 'A').Select(x => x - 'A' + 1).Sum();
                int Delta = 1;
                for (int i = 2; Score >= Delta; i++)
                {
                    if (Score == Delta)
                    {
                        Count++;
                        break;
                    }
                    Delta += i;
                }
            }
            label1.Text = Ans + Count.ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            var Stack = new Stack<string>();
            for (int i = 1; i <= 9; i++)
            {
                Stack.Push(i.ToString());
            }

            long sum = 0;
            while (Stack.Count > 0)
            {
                string Popped = Stack.Pop();
                if (Popped.Length == 10)
                {
                    sum += Convert.ToInt64(Popped);

                }

                for (int i = 0; i <= 9; i++)
                {
                    if (Popped.Contains(i.ToString()) == false)
                    {
                        string WillPush = Popped + i.ToString();
                        if (WillEdakiri(WillPush) == false)
                        {
                            Stack.Push(WillPush);
                        }
                    }
                }
            }
            label1.Text = Ans + sum.ToString();
        }
        static bool WillEdakiri(string Number)
        {
            var list = new List<int>(Eratosthenes(18));
            int Length = Number.Length;
            for (int i = 4; i < 11; i++)
            {
                if (Length == i) { return (int.Parse(Number.Substring(i - 3, 3)) % list[i - 4]) != 0; }
            }
            return false;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var PentaList = new List<int>();
            for (int i = 1; i < 10000; i++)
            {
                PentaList.Add(i * ((3 * i) - 1) / 2);
            }
            for (int i = 0; i < 9980; i++)
            {
                for (int j = 0; j < 9980; j++)
                {
                    if (i < j)
                    {
                        if (PentaList.Contains(PentaList[i] + PentaList[j]) && PentaList.Contains(Math.Abs(PentaList[i] - PentaList[j])))
                        {
                            textBox1.AppendText(PentaList[i] + " " + PentaList[j] + " ");
                            label1.Text = Ans + Math.Abs(PentaList[i] - PentaList[j]);
                            sw.Stop();
                            textBox1.AppendText($"{sw.ElapsedMilliseconds}");
                            goto end;
                        }
                    }
                }
            }
            end:;
        }
        public static long CalcKakusuu(long Kakusuu, long N)
        {
            if (Kakusuu == 3) return N * (N + 1) / 2;
            if (Kakusuu == 5) return N * (3 * N - 1) / 2;
            return N * (2 * N - 1);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            long TriangleIndex = 2;
            long PentagonalIndex = 2;
            long HexagonalIndex = 2;

            long Triangle = CalcKakusuu(3, TriangleIndex);
            long Pentagonal = CalcKakusuu(5, PentagonalIndex);
            long Hexagonal = CalcKakusuu(6, HexagonalIndex);

            int count = 0;
            while (true)
            {
                if (Triangle == Pentagonal && Pentagonal == Hexagonal)
                {
                    count++;
                    if (count == 2) break;
                }
                if (Math.Min(Math.Min(Triangle, Pentagonal), Hexagonal) == Triangle)
                {
                    Triangle = CalcKakusuu(3, ++TriangleIndex);
                    continue;
                }
                if (Math.Min(Math.Min(Triangle, Pentagonal), Hexagonal) == Pentagonal)
                {
                    Pentagonal = CalcKakusuu(5, ++PentagonalIndex);
                    continue;
                }
                if (Math.Min(Math.Min(Triangle, Pentagonal), Hexagonal) == Hexagonal)
                {
                    Hexagonal = CalcKakusuu(6, ++HexagonalIndex);
                    continue;
                }
            }
            label1.Text = Ans + Triangle;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            var list = new List<int>(Eratosthenes(10000));
            var IntegerList = new List<int>();
            for (int i = 9; i < 10000; i += 2)
            {
                IntegerList.Add(i);
            }
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    if (IntegerList.Contains(list[i] + 2 * j * j))
                    {
                        IntegerList.Remove(list[i] + 2 * j * j);
                    }
                }
            }
            label1.Text = Ans + IntegerList.Min();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            var PrimeList = new List<int>(Eratosthenes(1000000));
            int j = 0;
            var Hash = new HashSet<int>();
            int Count = 0;
            int i = 647;
            while (true)
            {
                int Number = i;
                while (Number > PrimeList[j])
                {
                    if (Number % PrimeList[j] == 0)
                    {
                        Number /= PrimeList[j];
                        Hash.Add(PrimeList[j]);
                    }
                    else { j++; }
                }
                Hash.Add(Number);
                if (Hash.Count == 4)
                {
                    Count++;
                }
                else
                {
                    Count = 0;
                }
                if (Count == 4)
                {
                    label1.Text = Ans + (i - 3);
                    break;
                }
                Hash.Clear();
                Hash.TrimExcess();
                i++;
                j = 0;
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            BigInteger Number = 1;
            BigInteger Sum = 0;
            for (BigInteger i = 1; i <= 1000; i++)
            {
                BigInteger j = i;
                for (int k = 0; k < j; k++)
                {
                    Number *= j;
                    Number %= 10000000000;
                }
                Sum += Number % 10000000000;
                Sum %= 10000000000;
                Number = 1;
            }
            label1.Text = Ans + Sum;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            int[] Number = new int[3];
            for (int i = 1; Number[0] < 10000; i++)
            {
                Number[0] = 1000 + i;
                for (int diff = 3330; ; diff++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        Number[j] = Number[j - 1] + diff;
                    }
                    if (Number[2] > 10000) break;
                    if (Sosuu(Number[0]) == 1 && Sosuu(Number[1]) == 1 && Sosuu(Number[2]) == 1)
                    {
                        var list1 = new List<char>(Number[0].ToString());
                        var list2 = new List<char>(Number[1].ToString());
                        var list3 = new List<char>(Number[2].ToString());
                        list1.Sort();
                        list2.Sort();
                        list3.Sort();
                        if (list1.SequenceEqual(list2) && list2.SequenceEqual(list3))
                        {
                            string Answer = Number[0].ToString() + Number[1].ToString() + Number[2].ToString();
                            label1.Text = Ans + Answer;
                        }
                    }
                }
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            var PrimeList = new List<int>(Eratosthenes(1000000));
            int MaxCount = 0;
            int Answer = 0;
            for (int i = 161; i < PrimeList.Count; i++)
            {
                NextLoop:;
                for (int Head = 3; Head <= i; Head++)
                {
                    int Number = PrimeList[i];
                    int Count = 0;
                    for (int j = Head; Number > 0; j++)
                    {
                        Number -= PrimeList[j];
                        Count++;
                        if (Number == 0)
                        {
                            if (MaxCount < Count)
                            {
                                MaxCount = Count;
                                Answer = PrimeList[i];
                                textBox1.AppendText(Answer.ToString() + " ");
                                goto NextLoop;
                            }
                        }
                    }
                }
            }
            label1.Text = Ans + Answer;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var PrimeList = new List<int>(Eratosthenes(1000000));
            PrimeList.RemoveAll(X => X % 2 == 0);
            PrimeList.RemoveAll(X => X < 100000);
            List<string> PatternList = new List<string>();
            foreach (char EachChar in "123456789*")
            {
                PatternList.Add(EachChar.ToString());
            }
            for (int i = 2; i <= 6; i++)
            {
                foreach (string EachStr in PatternList.FindAll(X => X.Length + 1 == i))
                {
                    foreach (char EachChar in "0123456789*")
                    {
                        PatternList.Add(EachStr + EachChar.ToString());
                    }
                }
            }
            PatternList = PatternList.FindAll(X => X.Contains('*'));
            PatternList.RemoveAll(X => X.EndsWith("*"));
            PatternList.RemoveAll(X => X.EndsWith("0") || X.EndsWith("2") || X.EndsWith("4") || X.EndsWith("6") || X.EndsWith("8"));
            PatternList.RemoveAll(X => X.Length < 6);

           
            foreach(string EachPattern in PatternList)
            {
                int count = 0;
                string ReplaceNumber = "9876543210";
                NextPattern:;
                for(int i = 0; i <= ReplaceNumber.Length - 1; i++){
                    if (EachPattern.StartsWith("*")&& ReplaceNumber[i] == 0) continue;
                    int JudgeNumber = int.Parse(EachPattern.Replace('*', ReplaceNumber[i]));
                    if (PrimeList.Contains(JudgeNumber))
                    {
                        count++;
                        if (i == 4 && count < 1) goto NextPattern;
                        if (count == 8)
                        {
                            label1.Text = Ans + JudgeNumber;
                            break;
                        }
                    }
                }
            }
            sw.Stop();
            textBox1.AppendText(sw.Elapsed.ToString());
            
        }

        private void button52_Click(object sender, EventArgs e)
        {
            for (int i = 10; i < int.MaxValue; i++)         
            {
                string NumberString = i.ToString();
                var List = new List<char>(NumberString);
                List.Sort();
                int EqualCount = 0;
                for (int j = 2; j <= 6; j++)
                {
                    int CharEqualCount = 0;
                    string NumberString2 = (i * j).ToString();
                    var List2 = new List<char>(NumberString2);
                    List2.Sort();
                    for (int k = 0; k < List.Count; k++) {
                        if (List[k] == List2[k])
                        {
                            CharEqualCount++;
                        }
                    }
                    if (CharEqualCount == List.Count)
                    {
                        EqualCount++;
                    }
                    else { break; }
                    if (EqualCount == List.Count-1)
                    {
                        label1.Text = Ans + NumberString;
                        goto end;
                    }
                }
                
            }
            end:;
        }
        public static BigInteger factorial(int n, int times)
        {
            BigInteger Number = n;
            for (; times > 1;times--)
            {
                Number = Number * (n - 1);
                n--;
            }
            return Number;
        }
        private void button53_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    BigInteger value = factorial(n, r) / factorial(r, r);
                    if (value > 1000000)
                    {
                        count++;
                    }
                }
            }
            label1.Text = Ans + count;
        }
        public static int ConvertValue(string Value)
        {
            if (Value == "A") return 14;
            else if (Value == "J") return 11;
            else if (Value == "K") return 13;
            else if (Value == "Q") return 12;
            else if (Value == "T") return 10;
            else return int.Parse(Value);
        }
        public static List<int> StrengthCheck(List<int> CardValue, List<string> CardMark)
        {
           
            int Pair = 0;
            int Flash = 0;
            int Straight = 0;
            int Strength = 0;
            int ValueCompare = 0;
            var StrengthList = new List<int>();
            //ペア判定
            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; i + j < 5; j++)
                {
                    if (CardValue[i] == CardValue[i + j])
                    {
                        Pair++;
                        ValueCompare = CardValue[i];
                    }
                }
            }
            //ストレート判定
            for(int i = 1; i < 5; i++)
            {
                if (CardValue[i - 1] + 1 == CardValue[i])
                {
                    Straight = 1;
                }
                else
                {
                    Straight = 0;
                    break;
                }
            }
            //フラッシュ判定
            for (int i = 1; i < 5; i++)
            {
                if (CardMark[i - 1] == CardMark[i])
                {
                    Flash = 1;
                }
                else
                {
                    Flash = 0;
                    break;
                }
            }
            if (ValueCompare == 0) { ValueCompare = CardValue[4]; }
            if (Straight == 1 && Flash == 1 && CardValue[0] == 10)
            {
                Strength = 9;//ロイヤルストレートフラッシュ
            }
            else if (Straight == 1 && Flash == 1)
            {
                Strength = 8;//ストレートフラッシュ
            }
            else if (Straight == 1)
            {
                Strength = 4;//ストレート
            }
            else if (Flash == 1)
            {
                Strength = 5;//フラッシュ
            }
            else if(Pair == 0)
            {
                Strength = 0;//役なし
                ValueCompare = CardValue[4];
            }
            else if (Pair == 1)
            {
                Strength = 1;//ワンペア
            }
            else if (Pair == 2)
            {
                Strength = 2;//ツーペア
            }
            else if (Pair == 3 )
            {
                Strength = 3;//スリーカード
            }
            else if (Pair == 4)
            {
                Strength = 6;//フルハウス
            }
            else if (Pair == 6)
            {
                Strength = 7;//フォーカード
            }
            
            StrengthList.Add(Strength);
            StrengthList.Add(ValueCompare);
            return StrengthList;
        }
        private void button54_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\poker.txt";
            Encoding utf8 = Encoding.GetEncoding("utf-8");
            string[] NumberString;
            NumberString = new string[1000];

            using (var reader = new StreamReader(path, utf8))
            {
                try
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        NumberString[i] = reader.ReadLine();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            char[] DelimiterChars = { ' ' };
            int P1WinCount = 0;
            for(int i = 0; i < 1000; i++)
            {
                var BothHand = NumberString[i].Split(DelimiterChars);
                string[] P1Hand = new string[5];
                string[] P2Hand = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    P1Hand[j] = BothHand[j];
                }
                for (int j = 5, k = 0; j < 10; j++, k++)
                {
                    P2Hand[k] = BothHand[j];
                }
                var P1CardValue = new List<int>();
                var P1CardMark = new List<string>();
                var P2CardValue = new List<int>();
                var P2CardMark = new List<string>();
                for (int j = 0; j < 5; j++)
                {
                    P1CardValue.Add(ConvertValue(P1Hand[j].Substring(0, 1)));
                    P1CardMark.Add(P1Hand[j].Substring(1, 1));
                    P2CardValue.Add(ConvertValue(P2Hand[j].Substring(0, 1)));
                    P2CardMark.Add(P2Hand[j].Substring(1, 1));
                }
                P1CardValue.Sort();
                P2CardValue.Sort();
                var P1Strength = StrengthCheck(P1CardValue, P1CardMark);
                var P2Strength = StrengthCheck(P2CardValue, P2CardMark);
                if (P1Strength[0] > P2Strength[0]) { P1WinCount++; }
                else if (P1Strength[0] == P2Strength[0])
                {
                    if (P1Strength[1] > P2Strength[1])
                    {
                        P1WinCount++;
                    }
                }
            }
            label1.Text = Ans + P1WinCount;
        }
        public static BigInteger BigIntReverse(BigInteger Value)
        {
            char[] Reverse = Value.ToString().ToCharArray();
            Array.Reverse(Reverse);
            var Reversed = new string(Reverse);
            return BigInteger.Parse(Reversed);
        }
        private void button55_Click(object sender, EventArgs e)
        {
            BigInteger Value = 0;
            int Count = 0;
            for (int i = 1; i < 10000; i++)
            {
                Value += i;
                for (int j = 0; j < 50; j++)
                {
                    Value += BigIntReverse(Value);
                    if (Value == BigIntReverse(Value))
                    {
                        break;
                    }
                    else if (j == 49)
                    {
                        Count++;
                    }
                }
                Value = 0;
            }
            label1.Text = Ans + Count;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            int MaxNumberSum = 0;
            
            for (int a = 1; a < 100; a++)
            {
                BigInteger Value = a;
                for (int b = 1; b < 100; b++)
                {
                    Value *= a;
                    var DigitNumberCharList = new List<char>(Value.ToString());
                    var DigitNumberIntList = new List<int>();
                    for(int i = 0; i < DigitNumberCharList.Count; i++)
                    {
                        DigitNumberIntList.Add(DigitNumberCharList[i] - '0');
                    }
                    int DigitNumberSum = DigitNumberIntList.Sum();
                    if (MaxNumberSum < DigitNumberSum)
                    {
                        MaxNumberSum = DigitNumberSum;
                        textBox1.AppendText(Value.ToString()+" ");
                    }

                }
            }
            label1.Text = Ans + MaxNumberSum;
            
        }

        private void button57_Click(object sender, EventArgs e)
        {
            int Count=0;
            var NumerList = new List<BigInteger>();
            var DenomList = new List<BigInteger>();
            NumerList.Add(3);
            NumerList.Add(7);
            DenomList.Add(2);
            DenomList.Add(5);
            for(int i = 2; i <= 1000; i++)
            {
                DenomList.Add(DenomList[i - 1] + NumerList[i - 1]);
                NumerList.Add(DenomList[i - 1] + DenomList[i]);
                if (NumerList[i].ToString().Length > DenomList[i].ToString().Length)
                {
                    Count++;
                    textBox1.AppendText(" " + NumerList[i] + "," + DenomList[i]);
                }
            }
            label1.Text = Ans + Count;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            int Value = 1;
            double PrimeCount = 0;
            int Answer = 0;
            int SideLength = 0;
            var List = new List<double>();
            for (int i = 1;　; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Value += i * 2;
                    if (Sosuu(Value) == 1)
                    {
                        PrimeCount++;
                    }
                    if (j == 2)
                    {
                        SideLength = Value - (Value - i * 2) + 1;
                    }
                }                
                double Percentage = PrimeCount / (1 + (i * 4));
                List.Add(Percentage);
                if (Percentage < 0.1)
                {
                    Answer = SideLength;
                    break;
                }
            }
            label1.Text = Ans +SideLength;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\cipher.txt";
            Encoding utf8 = Encoding.GetEncoding("utf-8");
            string String = "";
            var IntList = new List<int>();
            using (var reader = new StreamReader(path, utf8))
            {
                try
                {                    
                    String = reader.ReadToEnd();                    
                }
                catch (Exception ex)
                {

                }
            }
            char[] DelimiterChars = { ',' };
            string[] String2 = String.Split(DelimiterChars);
            foreach (string a in String2)
            {
                IntList.Add(int.Parse(a));
            }
            string[] KeyString = new string[26*26*26];
            int i = 0;
            for (int KeyFirst = 97; KeyFirst < 123; KeyFirst++)
            {                   
                for (int KeySecond = 97; KeySecond < 123; KeySecond++)
                {                        
                    for (int KeyThird = 97; KeyThird < 123; KeyThird++)
                    {
                        KeyString[i] = Convert.ToChar(KeyFirst).ToString() +
                                        Convert.ToChar(KeySecond).ToString() +
                                        Convert.ToChar(KeyThird).ToString();
                        i++;
                    }
                }                        
            }                              
            string TruePlainText="";
            for (int j = 0; j < KeyString.Length; j++)
            {
                string PlainText = "";
                int PlainTextIndex = 0;
                char[] Key = KeyString[j].ToCharArray();
                foreach (int a in IntList)
                {                   
                    string Plain = "";
                    if (PlainTextIndex % 3 == 0) Plain = Convert.ToChar(a ^ Key[0]).ToString();//value[0];
                    if (PlainTextIndex % 3 == 1) Plain = Convert.ToChar(a ^ Key[1]).ToString();//value[1];
                    if (PlainTextIndex % 3 == 2) Plain = Convert.ToChar(a ^ Key[2]).ToString();//value[2];
                    PlainTextIndex++;
                    PlainText += Plain;
                }
                if (PlainText.Contains(" the "))
                {
                    TruePlainText = PlainText;
                    break;
                }
            }
            int PlainSum = 0;
            for (int a = 0; a < TruePlainText.Length; a++)
            {
                int Plain=Convert.ToChar(TruePlainText[a]);
                PlainSum += Plain;
            }

            label1.Text = Ans + PlainSum;
        }

        public static bool StringCombineToInt(int string1,int string2)
        {
            string NumberString = string1.ToString() + string2.ToString();
            int Number = int.Parse(NumberString);
            if (Sosuu(Number) == 1)
            {
                NumberString = string2.ToString() + string1.ToString();
                Number = int.Parse(NumberString);
                if (Sosuu(Number) == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Judge(int[] Prime)
        {
            for(int i = 4; i >= 0 ; i--)
            {
                for (int j = 4; j >= 0 ; j--)
                {
                    if (i > j)
                    {
                        if (StringCombineToInt(Prime[i], Prime[j]) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        struct StackState
        {
            internal List<int> ValList;
            internal string Path;
        }
        public static bool Sosuu(long n)
        {
            if (n <= 1) return false;
            for (BigInteger i = 2; i * i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        private void button60_Click(object sender, EventArgs e)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            int SumLimit = 30000;
            var PrimeList = new List<int>(Eratosthenes(SumLimit));

            var Stk = new Stack<StackState>();
            StackState WillPush;
            foreach (int Each in PrimeList)
            {
                WillPush.ValList = new List<int> { Each };
                WillPush.Path = Each.ToString() + ",";
                Stk.Push(WillPush);
            }

            string AnswerPath = "";
            int AnswerSumMin = SumLimit;
            int ComboCount = 5;

            while (Stk.Count > 0)
            {
                StackState Popped = Stk.Pop();
                //textBox1.AppendText(string.Format("{0} Path={1} 候補={2}", sw.Elapsed, Popped.Path, AnswerPath));

                int wkSum = Popped.ValList.Sum();

                //if (AnswerSumMin > wkSum) { AnswerSumMin = wkSum; }
                if (Popped.ValList.Count == ComboCount && wkSum < AnswerSumMin)
                {
                    AnswerSumMin = wkSum;
                    AnswerPath = Popped.Path;
                    continue;
                }

                int ValCnt = Popped.ValList.Count;
                int RestCnt = ComboCount - ValCnt;

                int LastVal = Popped.ValList[ValCnt - 1];
                foreach (int Each in PrimeList.Where(X => X > LastVal && AnswerSumMin > wkSum + X * RestCnt))
                {
                    bool flag;
                    flag = Popped.ValList.TrueForAll(X => Sosuu(long.Parse(X.ToString() + Each.ToString())));
                    if (flag == false) continue;
                    flag = Popped.ValList.TrueForAll(X => Sosuu(long.Parse(Each.ToString() + X.ToString())));
                    if (flag == false) continue;

                    WillPush.ValList = new List<int>(Popped.ValList);
                    WillPush.ValList.Add(Each);
                    WillPush.Path = Popped.Path + Each.ToString() + ",";
                    Stk.Push(WillPush);
                }
                label1.Text = "Answer=" + AnswerSumMin.ToString();
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            var triangle = new List<int>();
            int triangleDelta = 2;
            int value = 1;
            var answer = new List<int>();
            for (int i = 0; value < 10000; i++)
            {
                value += triangleDelta;
                triangle.Add(value);
                triangleDelta++;
            }
            var quadrilateral = new List<int>(calcPolygon(triangle, 1));
            var pentagon = new List<int>(calcPolygon(triangle, 2));
            var hexagon = new List<int>(calcPolygon(triangle, 3));
            var heptagon = new List<int>(calcPolygon(triangle, 4));
            var octagon = new List<int>(calcPolygon(triangle, 5));

            triangle.RemoveAll(X => X <= 1000);
            triangle.RemoveAll(X => X >= 10000);

            for(int i = 0; i < 1000; i++)
            {
                int Upper = triangle[i] / 100;
                int Under = triangle[i] % 100;
                if (Under == pentagon[i]) / 100{ } 
            }
        }
        public static int SearchNextNumber(List<int> list, int Under)
        {
            int NextNumber = 0;

            //ここで次の数を探す。下2桁の数字が次の数字の上2桁と一致しているかを見て、その数字を返す処理を書く

            for (int i = 0; i < 1000; i++)
            {
                if (Under == list[i] / 100) { }
            }
            return NextNumber;
        }
        public static List<int> calcPolygon(List<int> list, int a)
        {
            var valueList = new List<int>();
            int value = 0;
            for (int i = 1; i < list.Count; i++)
            {
                value = list[i] + (a * list[i - 1]);
                if (999 < value && value < 10000) valueList.Add(value);
            }
            return valueList;
        }
    }
}
     
