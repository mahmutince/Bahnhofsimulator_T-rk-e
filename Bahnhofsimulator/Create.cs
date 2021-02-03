﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bahnhofsimulator
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }
        public static string[] jobs = { "İşletmeci:Oyuna +500 TL ile başlar.", "Öğrenci:Oyuna -500 TL ile başlar.", "Şoför:Oyuna +5000 TL ile başlar, oyun boyunca şoför çalıştıramaz." };
        public static string[] place = { "Pendik", "Bostancı", "Söğütlüçeşme", "Üsküdar", "Yenikapı", "Kazlıçeşme", "Avcılar" };

        private void Create_Load(object sender, EventArgs e)
        {
            listBoxJobs.Items.AddRange(jobs);
            comboBoxPlace.Items.AddRange(place);
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Screen s = (Screen)Application.OpenForms["screen"];
            management m = (management)Application.OpenForms["management"];
            station st = (station)Application.OpenForms["station"];
            if (textBoxName != null && listBoxJobs.SelectedItem != null && comboBoxPlace.SelectedItem!=null &&(radioButtonMan.Checked == true || radioButtonWoman.Checked == true))
            {
                

                if (listBoxJobs.SelectedIndex==0)
                {

                    station.money += 500;
                    m.labelName.Text = textBoxName.Text; 
                    m.labelBeruf.Text = jobs[0];
                    CheckGender(m);

                }
                else if (listBoxJobs.SelectedIndex==1)
                {
                    station.money -= 500;
                    m.labelName.Text = textBoxName.Text;
                    m.labelBeruf.Text = jobs[1];
                    CheckGender(m);
                }
                else if (listBoxJobs.SelectedIndex==2)
                {
                    station.money += 5000;
                    management.isaDriver = true;
                    m.labelName.Text = textBoxName.Text;
                    m.labelBeruf.Text = jobs[2];
                    CheckGender(m);
                }
                s.labelPlace.Text = comboBoxPlace.SelectedItem.ToString();
                s.panelTop.Visible = true;
                s.tabPageCreate.Parent = null;
                s.tabPageHome.Parent = s.tabControl1;
                s.tabControl1.SelectedTab = s.tabPageHome;
                

            }
            else
            {
                MessageBox.Show("Tüm verileri giriniz.");

            }
        }

        private void CheckGender(management m)
        {
            if (radioButtonMan.Checked == true)
            {
                m.labelGeschlecht.Text = "Erkek";
            }
            else if (radioButtonWoman.Checked == true)
            {
                m.labelGeschlecht.Text = "Kadın";
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
