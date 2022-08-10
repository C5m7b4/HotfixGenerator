using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentAce.Compression.ZipForge;


namespace HotfixGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Logs");
                if ( !dir.Exists)
                {
                    dir.Create();
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
        #endregion

        #region double clicks
        private void txtOutput_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if ( f.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = f.SelectedPath;
            }
        }

        private void txtFileToProcess_DoubleClick(object sender, EventArgs e)
        {
            txtFileToProcess.Text = "";
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = txtOutput.Text;
            o.Multiselect = true;
            if ( o.ShowDialog() == DialogResult.OK)
            {
                if ( o.FileNames.Length > 1)
                {
                    foreach( string name in o.FileNames)
                    {
                        txtFileToProcess.Text += name + ",";
                    }
                    txtFileToProcess.Text = txtFileToProcess.Text.Substring(0, txtFileToProcess.Text.Length - 1);
                }
                else
                {
                    txtFileToProcess.Text = o.FileName;
                }
            }
        }

        #endregion

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            try
            {
                string outputFolder = txtOutput.Text;
                //if ( !outputFolder.EndsWith("\\"))
                //{
                //    outputFolder += "\\";
                //}
                string files = txtFileToProcess.Text;
                if ( files.IndexOf(',') > 0)
                {
                    string[] names = files.Split(',');
                    foreach( string name in names)
                    {
                        string tmp = name.Substring(outputFolder.Length + 1, name.Length - (outputFolder.Length + 1));
                        int pos = tmp.IndexOf("\\");
                        string directory = tmp.Substring(0, pos);
                        string filename = tmp.Substring(pos + 1, tmp.Length - (pos + 1));

                        string[] fileArgs = new string[3];
                        fileArgs[0] = filename;
                        fileArgs[1] = directory;
                        fileArgs[2] = name;
                        ListViewItem li = new ListViewItem(fileArgs);
                        listFiles.Items.Add(li);
                    }
                }
                else
                {
                    string name = txtFileToProcess.Text;
                    string tmp = name.Substring(outputFolder.Length + 1, name.Length - (outputFolder.Length + 1));
                    int pos = tmp.IndexOf("\\");
                    string directory = tmp.Substring(0, pos);
                    string filename = tmp.Substring(pos + 1, tmp.Length - (pos + 1));


                    string[] fileArgs = new string[3];
                    fileArgs[0] = filename;
                    fileArgs[1] = directory;
                    fileArgs[2] = txtFileToProcess.Text;
                    ListViewItem li = new ListViewItem(fileArgs);
                    listFiles.Items.Add(li);
                }

                txtFileToProcess.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }


        #region Log

        private void Log(string msg)
        {
            try
            {
                StreamWriter w = new StreamWriter(Application.StartupPath + "\\debug_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Year.ToString() + ".log", true);
                w.WriteLine(msg);
                w.Flush();
                w.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Build Zip
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(txtOutput.Text + "\\Temp");
                if (!dir.Exists)
                    dir.Create();


                List<SmsFile> files = new List<SmsFile>();
                List<string> directories = new List<string>();
                foreach( ListViewItem li in listFiles.Items)
                {
                    string directory = li.SubItems[1].Text;
                    SmsFile s = new SmsFile
                    {
                        Directory = directory,
                        Filename = li.Text,
                        Fullname = li.SubItems[2].Text
                    };
                    files.Add(s);
                    if (!directories.Contains(directory))
                    {
                        directories.Add(directory);
                    }
                }

                // now we need to recurse each directory and 
                // create a mini zip, then we can create the master zipfile
                foreach( string directory in directories)
                {
                    List<SmsFile> targetFiles = filterFiles(files, directory);
                    miniZip(targetFiles, directory, dir.FullName);
                }

                MasterZip();

                System.Threading.Thread.Sleep(2000);
                if ( checkRemoveTemp.Checked)
                {
                    dir.Delete(true);
                }
                
                MessageBox.Show("Zip is Ready");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        #endregion

        #region filter list

        private List<SmsFile> filterFiles(List<SmsFile> inputs, string directory)
        {
            try
            {
                List<SmsFile> files = new List<SmsFile>();
                foreach( SmsFile file in inputs)
                {
                    if ( file.Directory == directory)
                    {
                        files.Add(file);
                    }
                }
                return files;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return null;
            }
        }

        #endregion

        #region mini zip

        private void miniZip(List<SmsFile> files, string directory, string tempDirectory)
        {
            try
            {
                ZipForge zip = new ZipForge();
                zip.FileName = tempDirectory + "\\" + directory + ".zip";
                zip.BaseDir = txtOutput.Text;           
                zip.OpenArchive(System.IO.FileMode.Create);

                switch(directory.ToLower())
                {
                    case "cgi":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "office":
                        zip.Comment = @"TAR_PATH=RUN";
                        break;
                    case "sqr":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "htm":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "lbz":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "public":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "script":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "dbs":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "dbt":
                        zip.Comment = @"TAR_PATH=RUN\OFFICE";
                        break;
                    case "storeman":
                        zip.Comment = @"TAR_PATH=RUN";
                        break;
                    default:

                        break;
                }

                foreach( SmsFile file in files)
                {
                    if ( directory.ToLower() == "storeman")
                    {
                        zip.BaseDir = txtOutput.Text + "\\Storeman";
                        zip.AddFiles(file.Filename);
                    }
                    else
                    {
                        zip.BaseDir = txtOutput.Text;
                        zip.AddFiles(file.Directory + "\\" + file.Filename);
                    }                    
                }

                zip.CloseArchive();

                // now take off the archive bit
                FileAttributes attr = FileAttributes.Archive | FileAttributes.ReadOnly;
                File.SetAttributes(zip.FileName, File.GetAttributes(zip.FileName) & (~attr));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        #endregion

        #region Master Zip

        private void MasterZip()
        {
            try
            {
                ZipForge zip = new ZipForge();
                zip.FileName = txtOutput.Text + "\\" + txtFilename.Text;
                zip.OpenArchive(System.IO.FileMode.Create);
                

                DirectoryInfo dir = new DirectoryInfo(txtOutput.Text + "\\Temp");
                zip.BaseDir = dir.FullName;
                FileInfo[] files = dir.GetFiles();

                foreach( FileInfo file in files)
                {
                    zip.AddFiles(file.Name);
                }

                // now take all of the base files
                dir = new DirectoryInfo(txtOutput.Text);
                FileInfo[] baseFiles = dir.GetFiles();
                zip.BaseDir = dir.FullName;
                foreach( FileInfo baseFile in baseFiles)
                {
                    // exclude our newly created zip file
                    if ( baseFile.Name != txtFilename.Text)
                    {
                        FileAttributes attr = FileAttributes.Archive | FileAttributes.ReadOnly;
                        File.SetAttributes(baseFile.FullName, File.GetAttributes(baseFile.FullName) & (~attr));

                        zip.AddFiles(baseFile.Name);
                    }                    
                }

                zip.CloseArchive();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
        #endregion


        #region Context Menu
        private void listFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right)
            {
                if ( listFiles.FocusedItem != null && listFiles.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ContextMenu m = new ContextMenu();
                    MenuItem delMenu = new MenuItem("Delete");
                    delMenu.Click += delegate (object sender2, EventArgs e2)
                    {
                        deleteAction(sender, e, listFiles.FocusedItem.Index);
                    };

                    m.MenuItems.Add(delMenu);
                    m.Show(listFiles, new Point(e.X, e.Y));
                }                
            }
        }

        private void deleteAction(object sender, MouseEventArgs e, int id)
        {
            try
            {
                foreach( ListViewItem item in listFiles.Items)
                {
                    if ( item.Index == id)
                    {
                        listFiles.Items.Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
        #endregion
    }
}
