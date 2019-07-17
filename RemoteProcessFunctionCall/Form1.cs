using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace RemoteProcessFunctionCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            applyPlaceholder(textProcessFilter);
            applyPlaceholder(textEAX);
            applyPlaceholder(textECX);
            applyPlaceholder(textEDX);
            applyPlaceholder(textEBX);
            applyPlaceholder(textESI);
            applyPlaceholder(textFunctionAddr);
        }
        public void applyPlaceholder(TextBox o)
        {
            o.GotFocus += new EventHandler(this.TextGotFocus);
            o.LostFocus += new EventHandler(this.TextLostFocus);
            TextLostFocus(o, null);
        }
        public void TextGotFocus(object sender, EventArgs e)
        {
            TextBox component = (TextBox)sender;
            if (component.Text == component.Tag.ToString())
            {
                component.Text = "";
                component.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox component = (TextBox)sender;
            if (component.Text == "")
            {
                component.Text = component.Tag.ToString();
                component.ForeColor = Color.FromArgb(130, 130, 130);
            }
        }
        int selectedPid = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedPid == 0)
            {
                MessageBox.Show("Select a process first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RemoteMethod x = new RemoteMethod(selectedPid);
            object[] r = x.allocateCall();
            if (!(bool)r[0])
            {
                MessageBox.Show((string)r[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                x.functionAddr = (IntPtr)int.Parse(textFunctionAddr.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse function addr!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (Control[] param in paramList)
                {
                    x.paramList.Add(Convert.ToInt32(param[0].Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse params!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (cEAX.Checked)
                {
                    x.registerEAX = int.Parse(textEAX.Text, System.Globalization.NumberStyles.HexNumber);
                    x.writeEAX = true;
                }
                if (cEBX.Checked)
                {
                    x.registerEBX = int.Parse(textEBX.Text, System.Globalization.NumberStyles.HexNumber);
                    x.writeEBX = true;
                }
                if (cECX.Checked)
                {
                    x.registerECX = int.Parse(textECX.Text, System.Globalization.NumberStyles.HexNumber);
                    x.writeECX = true;
                }
                if (cEDX.Checked)
                {
                    x.registerEDX = int.Parse(textEDX.Text, System.Globalization.NumberStyles.HexNumber);
                    x.writeEDX = true;
                }
                if (cESI.Checked)
                {
                    x.registerESI = int.Parse(textESI.Text, System.Globalization.NumberStyles.HexNumber);
                    x.writeESI = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse registers!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            r = x.Call();
            if (!(bool)r[0])
            {
                MessageBox.Show((string)r[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show((string)r[1], "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            x.clearCall();
        }

        private void loadProcessList(object sender, MouseEventArgs e)
        {
            ComboBox component = (ComboBox)sender;
            component.Items.Clear();
            List<Process> list = Process.GetProcesses().OrderBy(x => x.ProcessName).ToList();
            foreach (Process p in list)
            {
                string line = p.ProcessName + " (" + p.Id + ")";
                if (textProcessFilter.Text == textProcessFilter.Tag.ToString() || line.ToLower().Contains(textProcessFilter.Text.ToLower()))
                {
                    component.Items.Add(line);
                }
            }
        }
        List<Control[]> paramList = new List<Control[]>();
        private void bAddParam_Click(object sender, EventArgs e)
        {
            labelNone.Visible = false;

            TextBox x = new TextBox();
            x.Location = new Point(9, 24 + 25 * paramList.Count);
            x.Size = new Size(130, 20);
            x.Tag = "ex: 12345";
            applyPlaceholder(x);

            Button b = new Button();
            b.Click += new EventHandler(this.removeParam);
            b.Location = new Point(149, 24 + 25 * paramList.Count - 2);
            b.Size = new Size(24, 24);
            b.Text = "-";




            groupParams.Controls.Add(x);
            groupParams.Controls.Add(b);

            groupParams.Size = new Size(groupParams.Size.Width, groupParams.Size.Height + (paramList.Count > 0 ? 25 : 0));

            groupBox1.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y + (paramList.Count > 0 ? 25 : 0));
            bCall.Location = new Point(bCall.Location.X, bCall.Location.Y + (paramList.Count > 0 ? 25 : 0));

            this.Size = new Size(this.Size.Width, this.Size.Height + (paramList.Count > 0 ? 25 : 0));

            paramList.Add(new Control[] { x, b });
        }
        private void removeParam(object sender, EventArgs e)
        {
            Control[] w = null;
            bool found = false;
            foreach (Control[] x in paramList)
            {
                if (found)
                {
                    x[0].Location = new Point(x[0].Location.X, x[0].Location.Y - 25);
                    x[1].Location = new Point(x[1].Location.X, x[1].Location.Y - 25);
                }
                if (x[1] == sender)
                {
                    found = true;
                    w = x;
                }
            }

            if (paramList.Count > 1)
            {
                groupParams.Size = new Size(groupParams.Size.Width, groupParams.Size.Height - 25);

                groupBox1.Location = new Point(groupBox1.Location.X, groupBox1.Location.Y - 25);
                bCall.Location = new Point(bCall.Location.X, bCall.Location.Y - 25);

                this.Size = new Size(this.Size.Width, this.Size.Height - 25);
            }
            else
            {
                labelNone.Visible = true;
            }
            groupParams.Controls.Remove(w[0]);
            groupParams.Controls.Remove(w[1]);
            paramList.Remove(w);
        }

        private void listProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pid = listProcess.Items[listProcess.SelectedIndex].ToString();
            pid = pid.Substring(pid.LastIndexOf('(') + 1);
            pid = pid.Remove(pid.Length - 1);
            selectedPid = Convert.ToInt32(pid);
        }
    }
}
