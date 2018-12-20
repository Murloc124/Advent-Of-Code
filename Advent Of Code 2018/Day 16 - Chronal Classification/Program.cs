using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_16___Chronal_Classification
{
    class Program
    {
        private static List<string> Data = File.ReadAllLines(@"../../Day16_DataP1.txt").ToList();
        private static int[] Registers = new int[4];
        private static List<int[]> ResultingRegistersList = new List<int[]>();
        private static int ThreeOrMoreOpCodes = 0;
        private static Dictionary<int, string[]> OpCodeMapping = new Dictionary<int, string[]>();
        private static List<int[]> OriginalRegistersList = new List<int[]>();
        private static List<int[]> EndRegistersList = new List<int[]>();
        private static List<int[]> OperationList = new List<int[]>();

        static void Main(string[] args)
        {
            InitOpCodeMapping();
            Data.ForEach(x =>
            {
                if (x.Contains("Before"))
                {
                    var registers = x.Substring(x.IndexOf('[') + 1, x.IndexOf(']') - (x.IndexOf('[') + 1)).Split(',').ToList();
                    for (int i = 0; i < 4; i++)
                    {
                        Registers[i] = int.Parse(registers[i]);
                    }
                    OriginalRegistersList.Add((int[])Registers.Clone());
                }
                else if (x.Contains("After"))
                {
                    var registers = x.Substring(x.IndexOf('[') + 1, x.IndexOf(']') - (x.IndexOf('[') + 1)).Split(',').ToList();
                    for (int i = 0; i < 4; i++)
                        Registers[i] = int.Parse(registers[i]);
                    EndRegistersList.Add((int[])Registers.Clone());
                    var tempCounter = 0;
                    ResultingRegistersList.ForEach(result =>
                    {
                        if (result[0] == Registers[0] && result[1] == Registers[1] && result[2] == Registers[2] && result[3] == Registers[3])
                            tempCounter++;
                    });
                    if (tempCounter >= 3)
                        ThreeOrMoreOpCodes++;
                }
                else if (!string.IsNullOrWhiteSpace(x))
                {
                    ResultingRegistersList.Clear();
                    var opCode = x.Split(' ');
                    var intOpCode = new int[4];
                    for(int index = 0; index < opCode.Length; index++)
                        intOpCode[index] = int.Parse(opCode[index]);
                    OperationList.Add((int[])intOpCode.Clone());
                    var ogRegisters = (int[])Registers.Clone();
                    AddR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    AddI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    MulR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    MulI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    BanR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    BanI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    BorR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    BorI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    SetR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    SetI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    GtiR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    GtrI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    GtrR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    EqiR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    EqrI(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                    EqrR(int.Parse(opCode[1]), int.Parse(opCode[2]), int.Parse(opCode[3]));
                    ResultingRegistersList.Add((int[])Registers.Clone());
                    Registers = (int[])ogRegisters.Clone();
                }
            });

            Console.WriteLine("Day 16 - Part 1 : " + ThreeOrMoreOpCodes);

            Data = File.ReadAllLines(@"../../Day16_DataP2.txt").ToList();
            
            for (int i = 0; i < OriginalRegistersList.Count; i++)
            {
                var operation = OperationList[i][0];
                var possibleOperation = OpCodeMapping[operation];
                List<string> resultingOperations = new List<string>();
                foreach (var op in possibleOperation)
                {
                    switch (op)
                    {
                        case "Addr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            AddR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Addr");
                            break;
                        case "Addi":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            AddI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Addi");
                            break;
                        case "Mulr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            MulR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Mulr");
                            break;
                        case "Muli":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            MulI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Muli");
                            break;
                        case "Banr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            BanR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Banr");
                            break;
                        case "Bani":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            BanI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Bani");
                            break;
                        case "Borr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            BorR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Borr");
                            break;
                        case "Bori":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            BorI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Bori");
                            break;
                        case "Setr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            SetR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Setr");
                            break;
                        case "Seti":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            SetI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Seti");
                            break;
                        case "Gtir":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            GtiR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Gtir");
                            break;
                        case "Gtri":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            GtrI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Gtri");
                            break;
                        case "Gtrr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            GtrR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Gtrr");
                            break;
                        case "Eqir":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            EqiR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("EqiR");
                            break;
                        case "Eqri":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            EqrI(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Eqri");
                            break;
                        case "Eqrr":
                            Registers = (int[])OriginalRegistersList[i].Clone();
                            EqrR(OperationList[i][1], OperationList[i][2], OperationList[i][2]);
                            if (EndRegistersList[i][0] == Registers[0] && EndRegistersList[i][1] == Registers[1] && EndRegistersList[i][2] == Registers[2] && EndRegistersList[i][3] == Registers[3])
                                resultingOperations.Add("Eqrr");
                            break;
                    }
                }
                OpCodeMapping[operation] = resultingOperations.ToArray();
            }
            Console.ReadLine();
        }

        private static void InitOpCodeMapping()
        {
            string[] codes = { "Addr", "Addi", "Mulr", "Muli", "Banr", "Bani", "Borr", "Bori", "Setr", "Seti", "Gtir", "Gtri", "Gtrr", "Eqir", "Eqri", "Eqrr" };
            for (int i = 0; i < 16; i++)
                OpCodeMapping.Add(i, codes);
        }

        private static void AddR(int a, int b, int c)
        {
            Registers[c] = Registers[a] + Registers[b];
        }

        private static void AddI(int a, int b, int c)
        {
            Registers[c] = Registers[a] + b;
        }

        private static void MulR(int a, int b, int c)
        {
            Registers[c] = Registers[a] * Registers[b];
        }

        private static void MulI(int a, int b, int c)
        {
            Registers[c] = Registers[a] * b;
        }

        private static void BanR(int a, int b, int c)
        {
            Registers[c] = Registers[a] & Registers[b];
        }

        private static void BanI(int a, int b, int c)
        {
            Registers[c] = Registers[a] & b;
        }

        private static void BorR(int a, int b, int c)
        {
            Registers[c] = Registers[a] | Registers[b];
        }

        private static void BorI(int a, int b, int c)
        {
            Registers[c] = Registers[a] | b;
        }

        private static void SetR(int a, int b, int c)
        {
            Registers[c] = Registers[a];
        }

        private static void SetI(int a, int b, int c)
        {
            Registers[c] = a;
        }

        private static void GtiR(int a, int b, int c)
        {
            Registers[c] = a > Registers[b] ? 1 : 0;
        }

        private static void GtrI(int a, int b, int c)
        {
            Registers[c] = Registers[a] > b ? 1 : 0;
        }

        private static void GtrR(int a, int b, int c)
        {
            Registers[c] = Registers[a] > Registers[b] ? 1 : 0;
        }

        private static void EqiR(int a, int b, int c)
        {
            Registers[c] = a == Registers[b] ? 1 : 0;
        }

        private static void EqrI(int a, int b, int c)
        {
            Registers[c] = Registers[a] == b ? 1 : 0;
        }

        private static void EqrR(int a, int b, int c)
        {
            Registers[c] = Registers[a] == Registers[b] ? 1 : 0;
        }
    }
}
