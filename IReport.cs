using System;
using System.Collections.Generic;

namespace Tech_Conn
{
    abstract class IReport
    {
        protected List<Tuple<string, string>> file_names;
        protected string dest_path;
        protected string phase;

        protected string destFolderName;

        protected List<string> full_file_names_pdf;

        public IReport(string dest_path_in, List<Tuple<string, string>> file_names_in)
        {
            dest_path = dest_path_in;

            file_names = new List<Tuple<string, string>>();
            full_file_names_pdf = new List<string>();

            foreach (var file_tuple in file_names_in)
            {
                var t = Tuple.Create(file_tuple.Item1, file_tuple.Item2); 
                file_names.Add(t);
            }

        }

        protected string GetFolderNameFromContractNumber(string contrName)
        {
            return dest_path + @"\" + GetNameFromContractNumber(contrName);
        }

        protected string GetNameFromContractNumber(string contrName)
        {
            var str = contrName.Replace("/", ".");
            return str + phase;
        }


        protected void CreatePDF()
        {
            var contrName = destFolderName.Substring(destFolderName.LastIndexOf('\\')+1);
            var fileNameOut = Service.GetFileName(destFolderName, GetNameFromContractNumber(contrName) + ".pdf", false);
            Service.MergePDF(full_file_names_pdf, fileNameOut);
        }

        public void Show()
        {
            //ww.Show();
        }


        public string Generate()
        {
            try
            {
                GenerateTheReport();
                CreatePDF();
                return "";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        internal virtual void GenerateTheReport()
        {
        }

    }
}
