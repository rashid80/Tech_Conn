using System;
using System.Collections.Generic;

namespace Tech_Conn
{
    internal class Report2 : IReport
    {
        private MassInfoLine2 infoLine;

        public Report2(string d_path, List<Tuple<string, string>> f_names, MassInfoLine2 infoLine2) : base(d_path, f_names)
        {
            infoLine = infoLine2;
            phase = @"(3ф)";
        }

        internal override void GenerateTheReport()
        {
            destFolderName = GetFolderNameFromContractNumber(infoLine.var7);
            Service.CreateFolder(destFolderName);

            Random rnd = new Random();

            int rand;

            rand = rnd.Next(36000, 42000);
            decimal rand360420num1 = (decimal)rand / 100;

            rand = rnd.Next(-2000, 2000);
            decimal rand360420num2 = rand360420num1 + (decimal)rand / 100;

            rand = rnd.Next(-2000, 2000);
            decimal rand360420num3 = rand360420num1 + (decimal)rand / 100;

            decimal rand360420num1left = Math.Round(220 / rand360420num1, 2);
            decimal rand360420num1right = Math.Round(rand360420num1 / 320, 2);
            decimal rand360420num2left = Math.Round(220 / rand360420num2, 2);
            decimal rand360420num2right = Math.Round(rand360420num2 / 320, 2);
            decimal rand360420num3left = Math.Round(220 / rand360420num3, 2);
            decimal rand360420num3right = Math.Round(rand360420num3 / 320, 2);


            rand = rnd.Next(135, 149);
            var rand135149_1 = ((decimal)rand / 10).ToString();
            rand = rnd.Next(135, 149);
            var rand135149_2 = ((decimal)rand / 10).ToString();
            rand = rnd.Next(135, 149);
            var rand135149_3 = ((decimal)rand / 10).ToString();

            rand = rnd.Next(240, 244);
            var rand240244_1 = rand.ToString();
            rand = rnd.Next(240, 244);
            var rand240244_2 = rand.ToString();
            rand = rnd.Next(240, 244);
            var rand240244_3 = rand.ToString();

            foreach (var file_tuple in file_names)
            {
                var templateFileName = file_tuple.Item1;
                var destFileName = Service.GetFileName(destFolderName, file_tuple.Item2);

                var ww = new WordWriter(templateFileName);

                ww.ReplaceKeyWords("~var6~", infoLine.var6);
                ww.ReplaceKeyWords("~var7~", infoLine.var7);
                ww.ReplaceKeyWords("~var8~", infoLine.var8);
                ww.ReplaceKeyWords("~var9~", infoLine.var9);
                ww.ReplaceKeyWords("~var10~", infoLine.var10);
                ww.ReplaceKeyWords("~rand360420num1~", rand360420num1.ToString());
                ww.ReplaceKeyWords("~rand360420num2~", rand360420num2.ToString());
                ww.ReplaceKeyWords("~rand360420num3~", rand360420num3.ToString());
                ww.ReplaceKeyWords("~rand360420num1left~", rand360420num1left.ToString());
                ww.ReplaceKeyWords("~rand360420num2left~", rand360420num2left.ToString());
                ww.ReplaceKeyWords("~rand360420num3left~", rand360420num3left.ToString());
                ww.ReplaceKeyWords("~rand360420num1right~", rand360420num1right.ToString());
                ww.ReplaceKeyWords("~rand360420num2right~", rand360420num2right.ToString());
                ww.ReplaceKeyWords("~rand360420num3right~", rand360420num3right.ToString());

                ww.ReplaceKeyWords("~rand135149_1~", rand135149_1);
                ww.ReplaceKeyWords("~rand135149_2~", rand135149_2);
                ww.ReplaceKeyWords("~rand135149_3~", rand135149_3);
                
                ww.ReplaceKeyWords("~rand240244_1~", rand240244_1);
                ww.ReplaceKeyWords("~rand240244_2~", rand240244_2);
                ww.ReplaceKeyWords("~rand240244_3~", rand240244_3);

                ww.Save(destFileName);

                var file_name_pdf = destFileName + @".pdf";
                ww.Save(file_name_pdf, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                full_file_names_pdf.Add(file_name_pdf);
                
                ww.QuitApp();           
            }
        }
    }
}




//        ww.ReplaceKeyWords("~name~", mass.name);
//            ww.ReplaceKeyWords("~temp~", mass.temperature);
//            ww.ReplaceKeyWords("~hum~", mass.humidity);
//            ww.ReplaceKeyWords("~press~", mass.pressure);
//            ww.ReplaceKeyWords("~period~", mass.period);


//            int numTable = 3;
//        int beginDataRow = 5;

//        var data = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

//        int num = 1;

//        Random rnd = new Random();

//            foreach (var str in mass.var1)
//            {
//                data[0] = num.ToString() + ".";
//                num += 1;

//                data[1] = str;

//                int rand;

//        rand = rnd.Next(210, 280);
//                data[5] = ((decimal) rand / 10).ToString();

//        //Правка от 05.11.2020
//        //rand = rnd.Next(350, 550);
//        rand = rnd.Next(472, 550);

//                data[7] = rand.ToString();

//                ww.AddRowInTable(numTable, data);
//            }

//    ww.DeleteRowInTable(numTable, beginDataRow, beginDataRow);



//            numTable = 4;
//            beginDataRow = 2;

//            int addRow = 3;

//    List<int> colMerge = new List<int> { 1, 2, 3, 4, 7 };

//    var dataBeg = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

//            foreach (var str in mass.var2)
//            {
//                data = new List<string>(dataBeg);
//                data[0] = num.ToString() + ".";
//                num += 1;

//                for (int irow = 1; irow <= addRow; irow++)
//                {
//                    data[1] = str;

//                    int rand;

//    rand = rnd.Next(135, 149);
//                    data[5] = ((decimal) rand / 10).ToString();

//    //Правка от 05.11.2020
//    //rand = rnd.Next(170, 300);
//    rand = rnd.Next(224, 300);

//                    data[7] = rand.ToString();

//                    if (irow == 1)
//                    {
//                        ww.AddRowInTable(numTable, data);
//                        continue;
//                    }

//for (int col = 1; col <= data.Count; col++)
//{
//    if (colMerge.Contains(col))
//    {
//        data[col - 1] = "";
//    }
//}

//ww.AddRowInTable(numTable, data);

//                }
//            }

//            ww.DeleteRowInTable(numTable, beginDataRow, beginDataRow + addRow - 1);


//ww.MergeRows(numTable, beginDataRow, addRow, colMerge);

