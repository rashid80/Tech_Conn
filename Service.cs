using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;

namespace Tech_Conn
{
    static class Service
    {
        public static string getVersion()
        {
            return "Tech_Conn v.1.03 (with create PDF)";
        }

        public static string SelectFile(string fileName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = fileName;
            openFileDialog.Filter = "Excel-файлы (*.xls*)|*.xls*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            return (openFileDialog.ShowDialog() == DialogResult.OK) ? openFileDialog.FileName : fileName;
        }

        public static string SelectFolder(string folderName)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = folderName;
            folderBrowserDialog.ShowNewFolderButton = false;

            return (folderBrowserDialog.ShowDialog() == DialogResult.OK) ? folderBrowserDialog.SelectedPath : folderName;
        }

        public static void CreateFolder(string folderName)
        {
            if (Directory.Exists(folderName))
            {
                Directory.Delete(folderName, true);
                Thread.Sleep(1000);
            }
            Directory.CreateDirectory(folderName);
            Thread.Sleep(1000);
        }

        public static string GetFileName(string template_path, string template_name, bool exist_check = false)
        {

            string filename = template_path + @"\" + template_name;

            if (!exist_check)
            {
                return filename;
            }

            if (File.Exists(filename))
            {
                return filename;
            }

            string template_path_alt = @"c:\Tech_Conn";
            filename = template_path_alt + @"\" + template_name;

            if (File.Exists(filename))
            {
                return filename;
            }

            throw new Exception(@"Не найден файл " + filename + " в папках " + template_path + "   и   " + template_path_alt);

        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                System.IO.File.Delete(fileName);
            }
            catch (Exception e)
            {
                //return e.ToString();
            }
        }

        public static void RunCmd(string cmlLine, string workDir)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(cmlLine);
                startInfo.WorkingDirectory = workDir;
                Process.Start(startInfo);
            }
            catch (Exception e)
            {
                //return e.ToString();
            }
        }

        public static void MergePDF(List<string> inFiles, String outFile)
        {
            using (FileStream stream = new FileStream(outFile, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream))
            {
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                //fixed typo
                inFiles.ForEach(file =>
                {
                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }

                    pdf.FreeReader(reader);
                    reader.Close();
                    File.Delete(file);
                });
            }

        }
    }
}
