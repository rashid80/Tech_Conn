using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Tech_Conn
{
    public partial class Form1 : Form
    {
        private string fileNameMasValue;
        private string destFolderValue;
        private string FileNameMasValue
        {
            set { fileNameMas.Text = value; fileNameMasValue = value; Properties.Settings.Default.fileNameMas = value; Properties.Settings.Default.Save(); }
            get { return fileNameMasValue; }
        }
        private string DestFolderValue
        {
            set { destFolder.Text = value; destFolderValue = value; Properties.Settings.Default.destFolder = value; Properties.Settings.Default.Save(); }
            get { return destFolderValue; }
        }
        public Form1()
        {
            InitializeComponent();

            this.Text = Service.getVersion();

            FileNameMasValue = Properties.Settings.Default.fileNameMas;
            DestFolderValue = Properties.Settings.Default.destFolder;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSelectfileNameMas_Click(object sender, EventArgs e)
        {
            FileNameMasValue = Service.SelectFile(fileNameMas.Text);
        }

        private void buttonSelectdestFolder_Click(object sender, EventArgs e)
        {
            DestFolderValue = Service.SelectFolder(destFolder.Text);
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            MakeWordFiles();
        }

        private void MakeWordFiles()
        {
            tbProcess.Text = "";

            tbProcess.AppendText("НАЧАЛО:   " + DateTime.Now.ToString() + Environment.NewLine);

            if (String.IsNullOrEmpty(fileNameMasValue))
            {
                throw new Exception("Не выбран файл с данными!");
            }

            if (String.IsNullOrEmpty(destFolderValue))
            {
                throw new Exception("Не выбрана папка назначения!");
            }

            tbProcess.AppendText("Чтение Excel-файла (Массивы №1,2) ..." + Environment.NewLine);
            var tuple = ExcelReader.getMassfromFile(@fileNameMasValue);
            
            MakeReps1(tuple.Item1);
            MakeReps2(tuple.Item2);

            tbProcess.AppendText("ОКОНЧАНИЕ:   " + DateTime.Now.ToString() + Environment.NewLine);
        }

        private void MakeReps1(Mass1 mass)
        {
            string t_path = Application.StartupPath;

            List<Tuple<string, string>> file_names = new List<Tuple<string, string>>();
            var t = Tuple.Create(Service.GetFileName(t_path, @"1ф-1.doc", true), @"1 Титул.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"1ф-2.doc", true), @"2 паспорт объекта.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"1ф-3.doc", true), @"3 СОДЕРЖАНИЕ ТЕХОТЧЕТА.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"1ф-4.doc", true), @"4 протокол 1.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"1ф-5.doc", true), @"5 протокол 2.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"1ф-6.doc", true), @"6 протокол 3.doc");
            file_names.Add(t);
            //t = Tuple.Create(Service.GetFileName(t_path, @"1ф-7.doc", true), @"7 протокол 4.doc");
            //file_names.Add(t);

            foreach (var infoLine in mass.dataList)
            {
                tbProcess.AppendText(DateTime.Now.ToString() + "    Генерация пакета (1-ф) для договора " + infoLine.var2 + Environment.NewLine);

                var rep = new Report1(DestFolderValue, file_names, infoLine);
                var et = rep.Generate();
                tbProcess.AppendText(DateTime.Now.ToString() + "    " + ((String.IsNullOrEmpty(et)) ? "OK" : et));
                tbProcess.AppendText(Environment.NewLine + Environment.NewLine);
            }

        }

        private void MakeReps2(Mass2 mass)
        {
            string t_path = Application.StartupPath;

            List<Tuple<string, string>> file_names = new List<Tuple<string, string>>();
            var t = Tuple.Create(Service.GetFileName(t_path, @"3ф-1.doc", true), @"1 техотчет.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"3ф-2.doc", true), @"2 паспорт объекта.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"3ф-3.doc", true), @"3 СОДЕРЖАНИЕ ТЕХОТЧЕТА.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"3ф-4.doc", true), @"протокол1.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"3ф-5.doc", true), @"протокол2.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"3ф-6.doc", true), @"протокол3.doc");
            file_names.Add(t);
            t = Tuple.Create(Service.GetFileName(t_path, @"3ф-7.doc", true), @"протокол4.doc");
            file_names.Add(t);

            foreach (var infoLine in mass.dataList)
            {
                tbProcess.AppendText(DateTime.Now.ToString() + "    Генерация пакета (3-ф) для договора " + infoLine.var7 + Environment.NewLine);

                var rep = new Report2(DestFolderValue, file_names, infoLine);
                var et = rep.Generate();
                tbProcess.AppendText(DateTime.Now.ToString() + "    " + ((String.IsNullOrEmpty(et)) ? "OK" : et));
                tbProcess.AppendText(Environment.NewLine + Environment.NewLine);
            }

        }

    }
}
