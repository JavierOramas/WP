using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace WamaProcessor
{
    internal static class Advanced
    {
        private static ExcelPackage _excel;
        private static readonly List<string> Heading = new List<string>();
        private static readonly List<bool> Isnumber = new List<bool> { false, false };
        private static readonly List<bool> Isdate = new List<bool> { false, false };
        private static List<double> Dates;
        private static string[,] _data;
        private static object TimeSpan;

        private static void LoadData()
        {
            Isdate.Add(false);
            Isnumber.Add(false);
            Isdate.Add(true);
            Isnumber.Add(false);
            Isdate.Add(true);
            Isnumber.Add(false);
            Isdate.Add(false);
            Isnumber.Add(false);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
            Isdate.Add(false);
            Isnumber.Add(true);
        }
        public static void ReadData(string address)
        {
            LoadData();
            _excel = new ExcelPackage(new FileInfo(address));
            var myWorksheet = _excel.Workbook.Worksheets.First();
            var totalRows = myWorksheet.Dimension.End.Row;
            var totalColumns = myWorksheet.Dimension.End.Column;

            for (var i = 1; i <= totalColumns; i++)//recopilamos la informacion del Heading
            {
                Heading.Add(myWorksheet.Cells[1, i].Value != null
                    ? myWorksheet.Cells[1, i].Value.ToString()
                    : string.Empty);
            }

            _data = new string[totalRows, totalColumns];
            for (var i = 2; i < totalRows; i++)
            {
                for (var j = 1; j < totalColumns; j++)
                {
                    _data[i - 1, j - 1] = myWorksheet.Cells[i, j].Value.ToString();
                }
            }

            Dates = new List<double>(_data.GetLength(0));
            for (int i = 0; i < Dates.Capacity; i++)
            {
                Dates.Add(-1);
            }
        }

        public static void FixDate()
        {
            var index = Heading.FindIndex(x => x == "Check in");
            var roomidx = Heading.FindIndex(x => x == "Hab");
            var lastidx = 1;
            var idx = 2;
            while (idx < _data.GetLength(0))
            {
                if (_data[idx - 1, roomidx] != _data[idx, roomidx] || _data[idx - 1, roomidx - 1] != _data[idx, roomidx - 1])
                {
                    lastidx = idx;
                }
                if (idx + 1 < _data.GetLength(0) && (_data[idx + 1, roomidx] != _data[idx, roomidx] || _data[idx + 1, roomidx - 1] != _data[idx, roomidx - 1]))
                {
                    DateTime date1 = FixDateFormat(_data[idx, index + 1]);
                    DateTime date2 = FixDateFormat(_data[lastidx, index]);
                    Dates[idx] = (date1 - date2).TotalDays;

                    date1 = FixDateFormat(_data[idx, index]);
                    date2 = FixDateFormat(_data[idx - 1, index + 1]);
                    Dates[idx - 1] = (date1 - date2).TotalDays;
                    lastidx = idx + 1;
                    idx++;
                }
                else
                {
                    DateTime date1 = FixDateFormat(_data[idx, index]);
                    DateTime date2 = FixDateFormat(_data[idx - 1, index + 1]);
                    Dates[idx - 1] = (date1 - date2).TotalDays;
                }

                idx++;
            }
            PrintData();
            _excel.Save();
        }

        public static void PrintData()
        {
            var index = Heading.FindIndex(x => x == "Check in");
            var item = _excel.Workbook.Worksheets.First();
            item.InsertColumn(index + 3, 1);
            item.Cells[1, index + 3].Value = "Diferencia";
            for (int i = 2; i <= _data.GetLength(0); i++)
            {
                item.Cells[i, index + 3].Value = Dates[i - 1];
            }

            MessageBox.Show("Done!");
        }

        public static DateTime FixDateFormat(string date)
        {
            try
            {
                var month = int.Parse(date[0].ToString());
                var add = 0;
                if (int.TryParse(date[1].ToString(), out var value))
                {
                    month = month * 10 + value;
                    add++;
                }

                var day = int.Parse(date[2 + add].ToString());
                if (int.TryParse(date[3 + add].ToString(), out value))
                {
                    day = day * 10 + value;
                    add++;
                }

                var year = int.Parse(new string(new char[]
                    {date[4 + add], date[5 + add], date[6 + add], date[7 + add]}));

                return new DateTime(year, month, day);
            }

            catch
            {
                return new DateTime(0);
            }
        }
    }
}
