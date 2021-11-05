using System;
using System.Collections.Generic;

namespace Tech_Conn
{
    internal class Report1 : IReport
    {
        private MassInfoLine1 infoLine;

        public Report1(string d_path, List<Tuple<string, string>> f_names, MassInfoLine1 infoLine1) : base(d_path, f_names)
        {
            infoLine = infoLine1;
            phase = @"(1ф)";
        }

        internal override void GenerateTheReport()
        {
            destFolderName = GetFolderNameFromContractNumber(infoLine.var2);
            Service.CreateFolder(destFolderName);

            Random rnd = new Random();

            int rand;

            rand = rnd.Next(7200, 8200);
            decimal rand720820num = (decimal)rand / 10;
            decimal rand720820left = Math.Round(220 / rand720820num, 2);
            decimal rand720820right = Math.Round(rand720820num / 630, 2);
            
            
            rand = rnd.Next(210, 260);
            var rand2126 = ((decimal)rand / 10).ToString();

            rand = rnd.Next(400, 500);
            var rand400500 = rand.ToString();

            foreach (var file_tuple in file_names)
            {
                var templateFileName = file_tuple.Item1;
                var destFileName = Service.GetFileName(destFolderName, file_tuple.Item2);

                var ww = new WordWriter(templateFileName);

                ww.ReplaceKeyWords("~var1~", infoLine.var1);
                ww.ReplaceKeyWords("~var2~", infoLine.var2);
                ww.ReplaceKeyWords("~var3~", infoLine.var3);
                ww.ReplaceKeyWords("~var4~", infoLine.var4);
                ww.ReplaceKeyWords("~var5~", infoLine.var5);
                ww.ReplaceKeyWords("~rand720820~", rand720820num.ToString());
                ww.ReplaceKeyWords("~rand720820left~", rand720820left.ToString());
                ww.ReplaceKeyWords("~rand720820right~", rand720820right.ToString());
                ww.ReplaceKeyWords("~rand2126~", rand2126);
                ww.ReplaceKeyWords("~rand400500~", rand400500);

                ww.Save(destFileName);

                var file_name_pdf = destFileName + @".pdf";
                ww.Save(file_name_pdf, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                full_file_names_pdf.Add(file_name_pdf);                
                
                ww.QuitApp();
            }   
        }
    }
}



