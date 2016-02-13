﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.IO;

namespace hashvalidator
{
    public partial class frmHmac : Form
    {
        //Global Residents :)
        string FILE_TO_HMAC;
        string RANDOM_KEY;

        public frmHmac()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveHmacToFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseFileToHmac_Click(object sender, EventArgs e)
        {
            string selectedFile;
            OpenFileDialog objOpenFileToHmac = new OpenFileDialog();
            objOpenFileToHmac.Title = "Select a file to calculate HMAC";
            if(objOpenFileToHmac.ShowDialog()== DialogResult.OK)
            {
                selectedFile = objOpenFileToHmac.FileName.ToString();
                lblSelectedFileValue.Text = selectedFile;
                txtFileToHmac.Text = selectedFile;
                FILE_TO_HMAC = selectedFile;
            }
            else
            {
                //do nothing for now
            }
        }

        private void txtFileToHmac_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFileToHmac.Text))
            {
                lblSelectedFileValue.Text = txtFileToHmac.Text;
            }
            else
            {
                lblSelectedFileValue.Text = "No file selected!";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbGenerateKey_CheckedChanged(object sender, EventArgs e)
        {
            if (txtHmacKey.Text != String.Empty && cbGenerateKey.Checked != true)
            {
                MessageBoxButtons choices = MessageBoxButtons.YesNo;
                DialogResult userChoice = MessageBox.Show("Do you want to save the key?", "Please confirm?",choices);                
                if(userChoice == DialogResult.Yes)
                {
                    try
                    {
                        string fileName;
                        SaveFileDialog objSaveFile = new SaveFileDialog();
                        objSaveFile.Title = "Select a location to save the key";
                        objSaveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        objSaveFile.FileName = "KEY";
                        objSaveFile.InitialDirectory = @"C:\";
                        if (objSaveFile.ShowDialog() == DialogResult.OK)
                        {
                            fileName = objSaveFile.FileName;
                            File.WriteAllText(fileName, txtHmacKey.Text);
                            txtHmacKey.Text = "";
                        }
                        else
                        {
                            txtHmacKey.Text = "";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error: Please try again!");
                        return;
                    }
                }
                else
                {
                    txtHmacKey.Text = "";
                }
            }

            if (cbGenerateKey.Checked == true && txtHmacKey.Text == String.Empty)
            {
                ClassLibraries.calculator objGenKey = new ClassLibraries.calculator();
                RANDOM_KEY = objGenKey.GenerateRandomKey();
                txtHmacKey.Text = RANDOM_KEY;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcHmac_Click(object sender, EventArgs e)
        {

        }

    }
}
