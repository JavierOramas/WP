// Decompiled with JetBrains decompiler
// Type: MainApp.Main
// Assembly: MainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A76AF54-C020-47AD-8D62-E1DA74B99A85
// Assembly location: \\192.168.0.101\Work\1_WamasolTours\WamaProcessor v1.5.1\MainApp.exe

using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WamaProcessor
{
    public class Main
    {
        private readonly List<Cadena> _cadenas = new List<Cadena>();
        private readonly List<string> _omitList = new List<string>();
        private readonly Dictionary<string, int> _posiciones = new Dictionary<string, int>();
        private readonly List<List<string>> _data = new List<List<string>>();
        private readonly List<List<string>> _unknownData = new List<List<string>>();
        private readonly List<bool> _isnumber = new List<bool>()
    {
      false,
      false
    };
        private readonly List<bool> _isdate = new List<bool>()
    {
      false,
      false
    };
        private readonly List<List<string>> _unknnown = new List<List<string>>();
        private readonly List<string> _heading = new List<string>()
    {
      "Cadena",
      "Hotel",
      "Hab",
      "Check in",
      "Check out",
      "PLAN",
      "Supl. MAP",
      "Supl. AP",
      "Supl. CP",
      "Noches",
      "SGL",
      "DBL",
      "TPL",
      "1er Niño",
      "2do Niño"
    };
        public bool Destination = true;
        private int _nextindex = 15;
        private readonly ExcelPackage _excel;
        public bool Cabezalbool;
        private string _type;

        public Main()
        {
            this.LoadData();
        }

        public Main(string direction)
        {
            this._excel = new ExcelPackage(new FileInfo(direction));
            this.LoadData();
        }

        private void LoadData()
        {
            this._posiciones.Add("Hab", 1);
            this._isdate.Add(false);
            this._isnumber.Add(false);
            this._posiciones.Add("Check in", 2);
            this._isdate.Add(true);
            this._isnumber.Add(false);
            this._posiciones.Add("Check out", 3);
            this._isdate.Add(true);
            this._isnumber.Add(false);
            this._posiciones.Add("PLAN", 4);
            this._isdate.Add(false);
            this._isnumber.Add(false);
            this._posiciones.Add("Supl. MAP", 5);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("Supl. AP", 6);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("Supl. CP", 7);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("Min. de noches", 8);
            this._isdate.Add(false);
            this._isnumber.Add(false);
            this._posiciones.Add("SGL", 9);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("DBL", 10);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("TPL", 11);
            this._posiciones.Add("TLP", 11);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("1er Niño", 12);
            this._posiciones.Add("1er niño", 12);
            this._isdate.Add(false);
            this._isnumber.Add(true);
            this._posiciones.Add("2do Niño", 13);
            this._posiciones.Add("2do niño", 13);
            this._isdate.Add(false);
            this._isnumber.Add(true);
        }

        public void Process(string type)
        {
            _type = type;
            foreach (ExcelWorksheet worksheet in this._excel.Workbook.Worksheets)
            {
                int row = worksheet.Dimension.End.Row;
                int column = worksheet.Dimension.End.Column;
                Cadena cadena = new Cadena(worksheet.Name, row + 1, column + 1);
                StringBuilder stringBuilder = new StringBuilder();
                for (int index1 = 1; index1 <= row; ++index1)
                {
                    for (int index2 = 1; index2 <= column; ++index2)
                        cadena.Data[index1, index2] = worksheet.Cells[index1, index2].Value == null ? string.Empty : worksheet.Cells[index1, index2].Value.ToString();
                }
                this._cadenas.Add(cadena);
            }
        }

        public void GetInfo()
        {
            this.ImportData();
            bool flag1 = true;
            foreach (Cadena cadena in this._cadenas)
            {
                cadena.Normalize();
                string[,] data = cadena.Data;
                int index1 = -1;
                string empty = string.Empty;
                for (int index2 = 0; index2 < data.GetLength(0); ++index2)
                {
                    if (data.GetLength(0) >= index2 + 1 && index2 - 1 >= 0)
                    {
                        if (index2 + 1 < data.GetLength(0) && data[index2 - 1, 1] == string.Empty && data[index2 + 1, 1] == "T. HABITACION")
                        {
                            empty = data[index2, 1];
                            flag1 = false;
                            index1 = index2 + 1;
                            this.Destination = true;
                        }
                        else
                        {
                            while (index1 != -1 && (data[index2, 2] != "DESDE" || data[index2, 2] != string.Empty))
                            {
                                if (index2 + 1 >= data.GetLength(0) && data[index2 + 1, 1] == string.Empty)
                                {
                                    empty = string.Empty;
                                }
                                else
                                {
                                    List<string> stringList1 = Main.InitializeList(new SortedSet<int>((IEnumerable<int>)this._posiciones.Values).Count + 1);
                                    stringList1[0] = empty;
                                    bool flag2 = true;
                                    for (int index3 = 1; index3 < cadena.MaxX; ++index3)
                                    {
                                        if (!this.Destination)
                                        {
                                            stringList1.Add(data[index2 + 1, index3]);
                                        }
                                        else
                                        {
                                            if (index1 == -1)
                                            {
                                                flag2 = false;
                                                break;
                                            }
                                            if (index3 == 1 && (data[index2 + 1, index3] == string.Empty || data[index2 + 1, index3] == null))
                                                stringList1[this._posiciones[data[index1, index3]]] = this._data[this._data.Count - 1][index3 + 1];
                                            if (this._posiciones.ContainsKey(data[index1, index3]))
                                            {
                                                stringList1[this._posiciones[data[index1, index3]]] = data[index2 + 1, index3];
                                            }
                                            else
                                            {
                                                this.FixMissing(data[index1, index3]);
                                                if (!this.Destination)
                                                {
                                                    stringList1.Add(data[index2 + 1, index3]);
                                                }
                                                else
                                                {
                                                    stringList1.Insert(stringList1.Count, string.Empty);
                                                    stringList1[this._posiciones[data[index1, index3]]] = data[index2 + 1, index3];
                                                }
                                            }
                                            if (data[index1, index3] == "PLAN" && data[index2 + 1, index3] == "TI")
                                            {
                                                stringList1[this._posiciones[data[index1, index3]] + 1] = "0";
                                                ++index3;
                                            }
                                        }
                                    }
                                    if (flag2)
                                    {
                                        stringList1.Insert(0, cadena.Name);
                                        //stringList1[this._posiciones["Oferta"] + 1] = this._type;
                                        if (this.Destination)
                                        {
                                            this._data.Add(stringList1);
                                        }
                                        else
                                        {
                                            List<string> stringList2 = new List<string>();
                                            for (int index3 = 0; index3 < cadena.MaxX; ++index3)
                                                stringList2.Add(data[index1, index3]);
                                            stringList2[0] = "Cadena";
                                            stringList2.Insert(1, "HOTEL");
                                            if (this.Cabezalbool)
                                            {
                                                this._unknownData.Add(stringList2);
                                                this.Cabezalbool = false;
                                            }
                                            this._unknownData.Add(stringList1);
                                        }
                                        ++index2;
                                        if (index2 + 1 < data.GetLength(0) && (data[index2 + 1, 2] == string.Empty || data[index2, 2] == string.Empty))
                                        {
                                            index1 = -1;
                                            this.Destination = true;
                                        }
                                        if (index2 + 1 < data.GetLength(0) && data[index2 + 1, 2] == "DESDE")
                                        {
                                            index1 = index2 + 1;
                                            this.Destination = true;
                                            ++index2;
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            empty = string.Empty;
                            if (index2 + 1 < data.GetLength(0) && !flag1 && (empty == string.Empty && data[index2 + 1, 1] != string.Empty))
                            {
                                List<string> stringList = new List<string>();
                                for (int index3 = 1; index3 < cadena.MaxX; ++index3)
                                    stringList.Add(data[index2 + 1, index3]);
                                this._unknnown.Add(stringList);
                            }
                        }
                    }
                }
            }
        }

        private static List<string> InitializeList(int posicionesCount)
        {
            List<string> stringList = new List<string>();
            for (int index = 0; index < posicionesCount; ++index)
                stringList.Add(string.Empty);
            return stringList;
        }

        public void PrintInfo(string address)
        {
            this.FixHabs();
            this._data.Insert(0, this._heading);
            this._data.Insert(0, new List<string> { _type });
            if (new FileInfo(address).Exists)
                new FileInfo(address).Delete();
            ExcelPackage excelPackage = new ExcelPackage(new FileInfo(address));
            excelPackage.Workbook.Worksheets.Add("Datos");
            excelPackage.Workbook.Worksheets.First<ExcelWorksheet>().InsertRow(1, this._data.Count);
            excelPackage.Workbook.Worksheets.First<ExcelWorksheet>().InsertColumn(1, this._data[0].Count);
            for (int index1 = 1; index1 <= this._data.Count; ++index1)
            {
                for (int index2 = 1; index2 <= this._data[index1 - 1].Count; ++index2)
                {
                    ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.First<ExcelWorksheet>();
                    if (index2 - 1 < this._isnumber.Count && this._isnumber[index2 - 1])
                    {
                        string s = this._data[index1 - 1][index2 - 1];
                        try
                        {
                            double num = double.Parse(s);
                            excelWorksheet.Cells[index1, index2].Value = (object)num;
                            excelWorksheet.Cells[index1, index2].Style.Numberformat.Format = "#,##0.00";
                        }
                        catch (Exception ex)
                        {
                            excelWorksheet.Cells[index1, index2].Value = (object)s;
                        }
                    }
                    else if (index2 - 1 < this._isdate.Count && this._isdate[index2 - 1])
                    {
                        try
                        {
                            excelWorksheet.Cells[index1, index2].Value = (object)this._data[index1 - 1][index2 - 1];
                            excelWorksheet.Cells[index1, index2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                        }
                        catch (Exception ex)
                        {
                            excelWorksheet.Cells[index1, index2].Value = (object)this._data[index1 - 1][index2 - 1];
                            excelWorksheet.Cells[index1, index2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                        }
                    }
                    else
                        excelWorksheet.Cells[index1, index2].Value = (object)this._data[index1 - 1][index2 - 1];
                }
            }
            excelPackage.Workbook.Worksheets.Add("Pendientes");
            excelPackage.Workbook.Worksheets.Last<ExcelWorksheet>().InsertRow(1, this._data.Count);
            excelPackage.Workbook.Worksheets.Last<ExcelWorksheet>().InsertColumn(1, this._data[0].Count);
            for (int index1 = 1; index1 <= this._unknownData.Count; ++index1)
            {
                for (int index2 = 1; index2 <= this._unknownData[index1 - 1].Count; ++index2)
                {
                    ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Last<ExcelWorksheet>();
                    this._unknownData[index1 - 1].RemoveAll((Predicate<string>)(s => s == string.Empty));
                    if (index2 - 1 < this._isnumber.Count && this._isnumber[index2 - 1])
                    {
                        string s = this._unknownData[index1 - 1][index2 - 1];
                        try
                        {
                            double num = double.Parse(s);
                            excelWorksheet.Cells[index1, index2].Value = (object)num;
                            excelWorksheet.Cells[index1, index2].Style.Numberformat.Format = "#,##0.00";
                        }
                        catch (Exception ex)
                        {
                            excelWorksheet.Cells[index1, index2].Value = (object)s;
                        }
                    }
                    else if (index2 - 1 < this._isdate.Count && this._isdate[index2 - 1])
                    {
                        try
                        {
                            excelWorksheet.Cells[index1, index2].Value = (object)this._unknownData[index1 - 1][index2 - 1];
                            excelWorksheet.Cells[index1, index2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                        }
                        catch (Exception ex)
                        {
                            excelWorksheet.Cells[index1, index2].Value = (object)this._unknownData[index1 - 1][index2 - 1];
                            excelWorksheet.Cells[index1, index2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                        }
                    }
                    else
                        excelWorksheet.Cells[index1, index2].Value = (object)this._unknownData[index1 - 1][index2 - 1];
                }
            }
            excelPackage.Workbook.Worksheets.Add("Notas_Supl_Otros");
            excelPackage.Workbook.Worksheets.Last<ExcelWorksheet>().InsertRow(1, this._unknnown.Count);
            excelPackage.Workbook.Worksheets.Last<ExcelWorksheet>().InsertColumn(1, this._unknnown[0].Count);
            for (int index1 = 1; index1 <= this._unknnown.Count; ++index1)
            {
                for (int index2 = 1; index2 <= this._unknnown[index1 - 1].Count; ++index2)
                    excelPackage.Workbook.Worksheets.Last<ExcelWorksheet>().Cells[index1, index2].Value = (object)this._unknnown[index1 - 1][index2 - 1];
            }
            excelPackage.Save();
        }

        public void FixHabs()
        {
            for (int index = 1; index < this._data.Count; ++index)
            {
                if (this._data[index][2] == string.Empty)
                    this._data[index][2] = this._data[index - 1][2];
            }
            for (int index = 1; index < this._unknownData.Count; ++index)
            {
                if (this._unknownData[index][2] == string.Empty)
                    this._unknownData[index][2] = this._unknownData[index - 1][2];
            }
        }

        private void FixMissing(string s)
        {
            if (this._omitList.Contains(s))
            {
                this.Destination = false;
                this.Cabezalbool = true;
            }
            else
            {
                int num1 = (int)new Fix(s, (IEnumerable<string>)this._heading).ShowDialog();
                StreamReader streamReader = new StreamReader("data\\pairs.txt");
                string[] strArray = streamReader.ReadLine()?.Split();
                streamReader.Close();
                if (strArray[0] == "-1")
                {
                    for (int index = 2; index < strArray.Length; ++index)
                    {
                        ref string local = ref strArray[1];
                        local = local + " " + strArray[index];
                    }
                    this.Destination = false;
                    this.Cabezalbool = true;
                    this._omitList.Add(strArray[1]);
                }
                else
                {
                    int index1;
                    for (index1 = 1; strArray[index1] != "|&|"; ++index1)
                    {
                        ref string local = ref strArray[0];
                        local = local + " " + strArray[index1];
                    }
                    int num2;
                    string key = strArray[num2 = index1 + 1];
                    for (int index2 = num2 + 1; index2 < strArray.Length; ++index2)
                        key = key + " " + strArray[index2];
                    if (this._posiciones.ContainsKey(key))
                    {
                        this._posiciones.Add(strArray[0], this._posiciones[key]);
                    }
                    else
                    {
                        if (!this._posiciones.ContainsKey(key))
                        {
                            this._posiciones.Add(key, this._nextindex);
                            this._heading.Add(key);
                        }
                        if (!this._posiciones.ContainsKey(strArray[0]))
                            this._posiciones.Add(strArray[0], this._nextindex);
                        ++this._nextindex;
                    }
                }
            }
        }

        public void ExportData()
        {
            StreamWriter streamWriter = new StreamWriter("data\\knowledge.txt");
            foreach (string key in this._posiciones.Keys)
                streamWriter.WriteLine(key + " |&| " + (object)this._posiciones[key]);
            streamWriter.Close();
        }

        public void ImportData()
        {
            StreamReader streamReader = new StreamReader("data\\knowledge.txt");
            string[] strArray;
            do
            {
                string str = streamReader.ReadLine();
                if (str != null)
                {
                    strArray = str.Split();
                    int index1;
                    for (index1 = 1; strArray[index1] != "|&|"; ++index1)
                    {
                        ref string local = ref strArray[0];
                        local = local + " " + strArray[index1];
                    }
                    int num;
                    string s = strArray[num = index1 + 1];
                    for (int index2 = num + 1; index2 < strArray.Length; ++index2)
                        s = s + " " + strArray[index2];
                    if (this._posiciones.ContainsValue(int.Parse(s)))
                    {
                        if (!this._posiciones.ContainsKey(strArray[0]))
                            this._posiciones.Add(strArray[0], int.Parse(s));
                    }
                    else if (!this._posiciones.ContainsKey(strArray[0]))
                    {
                        this._posiciones.Add(strArray[0], int.Parse(s));
                        this._heading.Add(strArray[0]);
                    }
                }
                else
                    return;
            } while (strArray != null || !streamReader.EndOfStream);

            return;
        }
    }
}
