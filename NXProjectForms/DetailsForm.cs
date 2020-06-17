using NXOpen.UF;
using NXProject.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NXProjectForms
{
    public partial class DetailsForm : Form
    {
        string path = Application.LocalUserAppDataPath + "\\generated_mdls\\";

        public Bolt[] Bolts = new Bolt[]
        {
             new Bolt("M10", 1,  25, 10, 40,  10, 30, 0.6, 1.5),
             new Bolt("M12", 8,  28, 12, 50,  12, 40, 0.6, 1.5),
             new Bolt("M16", 10, 36, 16, 60,  16, 50, 1.0, 2),
             new Bolt("M20", 14, 42, 20, 80,  20, 60, 1.0, 2.5),
             new Bolt("M24", 18, 55, 24, 100, 24, 75, 1.6, 2.5),
             new Bolt("M30", 22, 65, 30, 125, 30, 90, 1.6, 2.5),
        };

        public Screw[] Screws = new Screw[]
        {
            new Screw("M8",  16, 12, 6,  30, 8,  5, 6,  6,  5,  0.5, 1),
            new Screw("M10", 18, 14, 8,  40, 10, 5, 7,  7,  6,  0.5, 1),
            new Screw("M12", 20, 16, 10, 50, 12, 5, 9,  9,  7,  1,   1.5),
            new Screw("M16", 24, 20, 13, 60, 16, 5, 12, 12, 8,  1,   1.5),
            new Screw("M20", 30, 20, 13, 70, 20, 5, 15, 15, 10, 1,   1.5),
        };

        public Nut[] Nuts = new Nut[]
        {
            new Nut("M6",  16, 6.0, 0.3, 6,  2.4, 3.4, 0.3),
            new Nut("M8",  21, 6.5, 1.0, 8,  3.2, 4.5, 0.5),
            new Nut("M10", 26, 8.0, 1.0, 10, 3.8, 5.5, 0.5),
            new Nut("M12", 30, 9.5, 1.0, 12, 4.5, 6.5, 0.5),
            new Nut("M16", 38, 12,  1.6, 16, 5.5, 7.5, 1),
            new Nut("M20", 45, 14,  1.6, 20, 6,   8.5, 1)
        };

        public DetailsForm()
        {
            InitializeComponent();
        }

        private void DetailsForm_Load(object sender, System.EventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            boltComboBox.SelectedIndex = 0;
            screwComboBox.SelectedIndex = 0;
            nutComboBox.SelectedIndex = 0;
        }

        private void buildButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                switch (detailsTabControl.SelectedIndex)
                {
                    case 0:
                        var bolt = Bolts[boltComboBox.SelectedIndex];
                        bolt.Length = double.Parse(boltLengthComboBox.SelectedItem.ToString());
                        bolt.Draw(UFSession.GetUFSession(), path + "bolt" + System.IO.Directory.EnumerateFiles(path).Where(f => f.Contains("bolt")).ToList().Count + 1);
                        break;
                    case 1:
                        var screw = Screws[screwComboBox.SelectedIndex];
                        screw.Length = double.Parse(screwLengthComboBox.SelectedItem.ToString());
                        screw.Draw(UFSession.GetUFSession(), path + "screw" + System.IO.Directory.EnumerateFiles(path).Where(f => f.Contains("screw")).ToList().Count + 1);
                        break;
                    case 2:
                        var nut = Nuts[nutComboBox.SelectedIndex];
                        nut.Draw(UFSession.GetUFSession(), path + "nut" + System.IO.Directory.EnumerateFiles(path).Where(f => f.Contains("nut")).ToList().Count + 1);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void boltComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            boltTextBox.Text = Bolts[boltComboBox.SelectedIndex].ToString();

            switch (boltComboBox.SelectedIndex)
            {
                case 0:
                    boltLengthComboBox.Items.Clear();
                    boltLengthComboBox.Items.AddRange(new object[] { 40, 50, 60, 80 });
                    boltLengthComboBox.SelectedIndex = 0;
                    break;
                case 1:
                    boltLengthComboBox.Items.Clear();
                    boltLengthComboBox.Items.AddRange(new object[] { 50, 60, 80, 100, 125, 150 });
                    boltLengthComboBox.SelectedIndex = 0;
                    break;
                case 2:
                    boltLengthComboBox.Items.Clear();
                    boltLengthComboBox.Items.AddRange(new object[] { 60, 80, 100, 125, 150, 180 });
                    boltLengthComboBox.SelectedIndex = 0;
                    break;
                case 3:
                    boltLengthComboBox.Items.Clear();
                    boltLengthComboBox.Items.AddRange(new object[] { 80, 100, 125, 150, 180, 210 });
                    boltLengthComboBox.SelectedIndex = 0;
                    break;
                case 4:
                    boltLengthComboBox.Items.Clear();
                    boltLengthComboBox.Items.AddRange(new object[] { 100, 125, 150, 180, 210, 250 });
                    boltLengthComboBox.SelectedIndex = 0;
                    break;
                case 5:
                    boltLengthComboBox.Items.Clear();
                    boltLengthComboBox.Items.AddRange(new object[] { 125, 150, 180, 210, 250, 300 });
                    boltLengthComboBox.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        private void screwComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            screwTextBox.Text = Screws[screwComboBox.SelectedIndex].ToString();

            switch (screwComboBox.SelectedIndex)
            {
                case 0:
                    screwLengthComboBox.Items.Clear();
                    screwLengthComboBox.Items.AddRange(new object[] { 30, 35, 40, 50 });
                    screwLengthComboBox.SelectedIndex = 0;
                    break;
                case 1:
                    screwLengthComboBox.Items.Clear();
                    screwLengthComboBox.Items.AddRange(new object[] { 40, 50, 60, 70, 80, 90 });
                    screwLengthComboBox.SelectedIndex = 0;
                    break;
                case 2:
                    screwLengthComboBox.Items.Clear();
                    screwLengthComboBox.Items.AddRange(new object[] { 50, 60, 70, 80, 90, 100 });
                    screwLengthComboBox.SelectedIndex = 0;
                    break;
                case 3:
                    screwLengthComboBox.Items.Clear();
                    screwLengthComboBox.Items.AddRange(new object[] { 60, 70, 90, 110, 130, 150 });
                    screwLengthComboBox.SelectedIndex = 0;
                    break;
                case 4:
                    screwLengthComboBox.Items.Clear();
                    screwLengthComboBox.Items.AddRange(new object[] { 70, 90, 110, 130, 150 });
                    screwLengthComboBox.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        private void nutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nutTextBox.Text = Nuts[nutComboBox.SelectedIndex].ToString();
        }
    }
}
